using Microsoft.EntityFrameworkCore;
using RegistroTecnicos.DAL;
using RegistroTecnicos.Models;
using System.Linq.Expressions;

namespace RegistroTecnicos.Services;

public class PrioridadService(Contexto _contexto)
{
	public async Task<bool> Guardar(Prioridades prioridad)
	{
		if (!await Existe(prioridad.PrioridadId))
			return await Insertar(prioridad);
		else
			return await Modificar(prioridad);
	}

	private async Task<bool> Modificar(Prioridades prioridad)
	{
		_contexto.Update(prioridad);
		var modificado = await _contexto.SaveChangesAsync() > 0;
		_contexto.Entry(prioridad).State = EntityState.Modified;
		return modificado;
	}

	private async Task<bool> Insertar(Prioridades prioridad)
	{
		_contexto.Prioridades.Add(prioridad);
		return await _contexto.SaveChangesAsync() > 0;
	}

	public async Task<bool> Existe(int prioridadId)
	{
		return await _contexto.Prioridades
			.AnyAsync(t => t.PrioridadId == prioridadId);
	}

	public async Task<bool> ExistePrioridad(string descripcion, int id)
	{
		return await _contexto.Prioridades
			.AnyAsync(t => t.Descripcion.ToLower().Equals(descripcion.ToLower()) && t.PrioridadId != id);

	}

	public async Task<bool> Eliminar(int prioridadId)
	{
		var tecnicos = await _contexto.Prioridades.
			Where(t => t.PrioridadId == prioridadId).ExecuteDeleteAsync();
		return tecnicos > 0;
	}

	public async Task<Prioridades?> Buscar(int prioridadId)
	{
		return await _contexto.Prioridades.
			AsNoTracking()
			.FirstOrDefaultAsync(t => t.PrioridadId == prioridadId);
	}

	public async Task<List<Prioridades>> Listar(Expression<Func<Prioridades, bool>> criterio)
	{
		return await _contexto.Prioridades.
			AsNoTracking().
			Where(criterio).
			ToListAsync();
	}
}
