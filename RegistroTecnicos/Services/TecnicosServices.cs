using Microsoft.EntityFrameworkCore;
using RegistroTecnicos.DAL;
using RegistroTecnicos.Models;
using System.Linq.Expressions;

namespace RegistroTecnicos.Services
{
	public class TecnicosServices
	{
		private readonly Contexto _contexto;

		public TecnicosServices(Contexto contexto)
		{
			_contexto = contexto;
		}

		private async Task<bool> Existe(int TecnicoId)
		{
			return await _contexto.Tecnicos
				.AnyAsync(t => t.TecnicoId == TecnicoId);
		}

		private async Task<bool> Insertar(Tecnicos tecnico)
		{
			_contexto.Tecnicos.Add(tecnico);
			return await _contexto.SaveChangesAsync() > 0;
		}

		public async Task<bool> Modificar(Tecnicos tecnico)
		{
			_contexto.Update(tecnico);
			return await _contexto.SaveChangesAsync() > 0;
		}

		public async Task<bool> Guardar(Tecnicos tecnico)
		{
			if (!await Existe(tecnico.TecnicoId))
				return await Insertar(tecnico);
			else
				return await Modificar(tecnico);
		}

		public async Task<bool> Eliminar(int id)
		{
			var tecnicos = await _contexto.Tecnicos.
				Where(T => T.TecnicoId == id).ExecuteDeleteAsync();
			return tecnicos > 0;
		}

		public async Task<Tecnicos?> Buscar(int id)
		{
			return await _contexto.Tecnicos.
				AsNoTracking()
				.FirstOrDefaultAsync(T => T.TecnicoId == id);
		}

		public List<Tecnicos> Listar(Expression<Func<Tecnicos, bool>> criterio)
		{
			return _contexto.Tecnicos.
				AsNoTracking()
				.Where(criterio)
				.ToList();
		}
	}
}