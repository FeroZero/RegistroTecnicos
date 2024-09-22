﻿using Microsoft.EntityFrameworkCore;
using RegistroTecnicos.DAL;
using RegistroTecnicos.Models;
using RestSharp;
using System.Linq.Expressions;

namespace RegistroTecnicos.Services;

public class TrabajoService(Contexto _contexto)
{
	public async Task<bool> Guardar(Trabajos trabajo)
	{
		if (!await Existe(trabajo.TrabajoId))
			return await Insertar(trabajo);
		else
			return await Modificar(trabajo);
	}

	private async Task<bool> Modificar(Trabajos trabajo)
	{
		_contexto.Update(trabajo);
		var modificado = await _contexto.SaveChangesAsync() > 0;
		_contexto.Entry(trabajo).State = EntityState.Modified;
		return modificado;
	}

	private async Task<bool> Insertar(Trabajos trabajo)
	{
		_contexto.Trabajos.Add(trabajo);
		return await _contexto.SaveChangesAsync() > 0;
	}

	public async Task<bool> Existe(int trabajoId)
	{
		return await _contexto.Trabajos
			.AnyAsync(t => t.TrabajoId == trabajoId);
	}

	public async Task<bool> ExisteTrabajo(string Descripcion, int id)
	{
		return await _contexto.Trabajos
			.AnyAsync(t => t.Descripcion.ToLower().Equals(Descripcion.ToLower()) && t.TrabajoId != id);

	}

	public async Task<bool> Eliminar(int trabajoId)
	{
		var tecnicos = await _contexto.Trabajos.
			Where(t => t.TrabajoId == trabajoId).ExecuteDeleteAsync();
		return tecnicos > 0;
	}

	public async Task<Trabajos?> Buscar(int trabajoId)
	{
		return await _contexto.Trabajos.
			AsNoTracking()
			.FirstOrDefaultAsync(t => t.TrabajoId == trabajoId);
	}

	public async Task<List<Trabajos>> Listar(Expression<Func<Trabajos, bool>> criterio)
	{
		return await _contexto.Trabajos.
			Include(l => l.Tecnicos).
			Include(l => l.Clientes).
			AsNoTracking().
			Where(criterio).
			ToListAsync();
	}
}