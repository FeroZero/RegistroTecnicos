using Microsoft.EntityFrameworkCore;
using RegistroTecnicos.DAL;
using RegistroTecnicos.Models;
using System.Linq.Expressions;

namespace RegistroTecnicos.Services;

public class ClienteService(Contexto _contexto)
{
	public async Task<bool> Guardar(Clientes cliente)
	{
		if (!await Existe(cliente.ClienteId))
			return await Insertar(cliente);
		else
			return await Modificar(cliente);
	}

	private async Task<bool> Modificar(Clientes cliente)
	{
		_contexto.Update(cliente);
		var modificado = await _contexto.SaveChangesAsync() > 0;
		_contexto.Entry(cliente).State = EntityState.Modified;
		return modificado;
	}

	private async Task<bool> Insertar(Clientes cliente)
	{
		_contexto.Clientes.Add(cliente);
		return await _contexto.SaveChangesAsync() > 0;
	}

	private async Task<bool> Existe(int clienteId)
	{
		return await _contexto.Clientes
			.AnyAsync(c => c.ClienteId == clienteId);
	}

	public async Task<bool> ExisteCliente(string nombre,int id, string numero)
	{
		return await _contexto.Clientes
			.AnyAsync(c => c.Nombres.ToLower().Equals(nombre.ToLower()) && c.ClienteId != id && c.WhatsApp.ToLower().Equals(numero.ToLower()));
	}

	public async Task<bool> Eliminar(int clienteId)
	{
		var cliente = await _contexto.Clientes.
			Where(c => c.ClienteId == clienteId).ExecuteDeleteAsync();
		return cliente > 0;
	}

	public async Task<Clientes?> Buscar(int clienteId)
	{
		return await _contexto.Clientes
			.AsNoTracking()
			.FirstOrDefaultAsync(c => c.ClienteId == clienteId);
	}

	public async Task<List<Clientes>> Listar(Expression<Func<Clientes, bool>> criterio)
	{
		return await _contexto.Clientes
			.AsNoTracking()
			.Where(criterio)
			.ToListAsync();
	}
}
