using Microsoft.EntityFrameworkCore;
using RegistroTecnicos.DAL;
using RegistroTecnicos.Models;
using System.Linq.Expressions;

namespace RegistroTecnicos.Services
{
	public class TipoTecnicoService(Contexto _contexto)
	{
		public async Task<bool> Guardar(TiposTecnicos tipoTecnico)
		{
			if (!await Existe(tipoTecnico.TiposTecnicosId))
				return await Insertar(tipoTecnico);
			else
				return await Modificar(tipoTecnico);
		}

		private async Task<bool> Modificar(TiposTecnicos tipoTecnico)
		{
			_contexto.Update(tipoTecnico);
			var modificado = await _contexto.SaveChangesAsync() > 0;
			_contexto.Entry(tipoTecnico).State = EntityState.Modified;
			return modificado;
		}

		private async Task<bool> Insertar(TiposTecnicos tipoTecnico)
		{
			_contexto.TiposTecnicos.Add(tipoTecnico);
			return await _contexto.SaveChangesAsync() > 0;
		}

		public async Task<bool> Existe(int tipoId)
		{
			return await _contexto.TiposTecnicos
				.AnyAsync(t => t.TiposTecnicosId == tipoId);
		}

		public async Task<bool> ExisteTipo(string descripcion, int id)
		{
			return await _contexto.TiposTecnicos
				.AnyAsync(t => t.Descripcion.ToLower().Equals(descripcion.ToLower()) && t.TiposTecnicosId != id);

		}

		public async Task<bool> Eliminar(int tipoId)
		{
			var tecnicos = await _contexto.TiposTecnicos.
				Where(t => t.TiposTecnicosId == tipoId).ExecuteDeleteAsync();
			return tecnicos > 0;
		}

		public async Task<TiposTecnicos?> Buscar(int tipoId)
		{
			return await _contexto.TiposTecnicos.
				AsNoTracking()
				.FirstOrDefaultAsync(t => t.TiposTecnicosId == tipoId);
		}

		public async Task<List<TiposTecnicos>> Listar(Expression<Func<TiposTecnicos, bool>> criterio)
		{
			return await _contexto.TiposTecnicos.
				AsNoTracking().
				Where(criterio).
				ToListAsync();
		}
	}
}
