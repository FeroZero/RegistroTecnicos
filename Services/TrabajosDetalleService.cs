using Microsoft.EntityFrameworkCore;
using RegistroTecnicos.DAL;
using RegistroTecnicos.Models;
using System.Linq.Expressions;

namespace RegistroTecnicos.Services
{
    public class TrabajosDetalleService(Contexto contexto)
    {
        public async Task<List<Trabajos>> Listar(Expression<Func<Trabajos, bool>> criterio)
        {
            return await contexto.Trabajos
                .AsNoTracking()
                .Where(criterio)
                .ToListAsync();
        }
    }
}
