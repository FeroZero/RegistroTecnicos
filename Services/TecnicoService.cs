using Microsoft.EntityFrameworkCore;
using RegistroTecnicos.DAL;
using RegistroTecnicos.Models;
using System.Linq.Expressions;

namespace RegistroTecnicos.Services
{
    public class TecnicoService(Contexto _contexto)
    {
        public async Task<bool> Guardar(Tecnicos tecnico)
        {
            if (!await Existe(tecnico.TecnicoId))
                return await Insertar(tecnico);
            else
                return await Modificar(tecnico);
        }

        private async Task<bool> Modificar(Tecnicos tecnico)
        {
            _contexto.Update(tecnico);
            var modificado = await _contexto.SaveChangesAsync() > 0;
            _contexto.Entry(tecnico).State = EntityState.Modified;
            return modificado;
        }

        private async Task<bool> Insertar(Tecnicos tecnico)
        {
            _contexto.Tecnicos.Add(tecnico);
            return await _contexto.SaveChangesAsync() > 0;
        }

        public async Task<bool> Existe(int tecnicoId)
        {
            return await _contexto.Tecnicos
                .AnyAsync(t => t.TecnicoId == tecnicoId);
        }

        public async Task<bool> ExisteTecnico(string nombre, int id)
        {
            return await _contexto.Tecnicos
                .AnyAsync(t => t.Nombre.ToLower().Equals(nombre.ToLower()) && t.TecnicoId != id);
        }

        public async Task<bool> Eliminar(int tecnicoId)
        {
            var tecnicos = await _contexto.Tecnicos.
                Where(t => t.TecnicoId == tecnicoId).ExecuteDeleteAsync();
            return tecnicos > 0;
        }

        public async Task<Tecnicos?> Buscar(int tecnicoId)
        {
            return await _contexto.Tecnicos.
                AsNoTracking()
                .FirstOrDefaultAsync(t => t.TecnicoId == tecnicoId);
        }

        public async Task<List<Tecnicos>> Listar(Expression<Func<Tecnicos, bool>> criterio)
        {
            return _contexto.Tecnicos.
                AsNoTracking().
                Where(criterio).
                ToList();
        }
    }
}
