using Microsoft.EntityFrameworkCore;
using RegistroTecnicos.DAL;
using RegistroTecnicos.Models;
using System.Linq.Expressions;

namespace RegistroTecnicos.Services
{
    public class ArticuloService(Contexto _contexto)
    {
        public async Task<bool> Guardar(Articulos articulo)
        {
            if (!await Existe(articulo.ArticuloId))
                return await Insertar(articulo);
            else
                return await Modificar(articulo);
        }

        private async Task<bool> Modificar(Articulos articulo)
        {
            _contexto.Update(articulo);
            var modificado = await _contexto.SaveChangesAsync() > 0;
            _contexto.Entry(articulo).State = EntityState.Modified;
            return modificado;
        }

        private async Task<bool> Insertar(Articulos articulo)
        {
            _contexto.Articulos.Add(articulo);
            return await _contexto.SaveChangesAsync() > 0;
        }

        private async Task<bool> Existe(int articuloId)
        {
            return await _contexto.Articulos
                .AnyAsync(c => c.ArticuloId == articuloId);
        }

        public async Task<bool> ExisteArticulo(string descripcion, int id, string numero)
        {
            return await _contexto.Articulos
                .AnyAsync(c => c.Descripcion.ToLower().Equals(descripcion.ToLower()) && c.ArticuloId != id);
        }

        public async Task<bool> Eliminar(int articuloId)
        {
            var articulo = await _contexto.Articulos.
                Where(c => c.ArticuloId == articuloId).ExecuteDeleteAsync();
            return articulo > 0;
        }

        public async Task<Articulos?> Buscar(int articuloId)
        {
            return await _contexto.Articulos
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.ArticuloId == articuloId);
        }

        public async Task<List<Articulos>> Listar(Expression<Func<Articulos, bool>> criterio)
        {
            return await _contexto.Articulos
                .AsNoTracking()
                .Where(criterio)
                .ToListAsync();
        }
    }
}
