using SistemaInventario.AccesoDatos.Data;
using SistemaInventario.AccesoDatos.Repositorio.IRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaInventario.AccesoDatos.Repositorio
{
    public class UnidadTrabajo : IUnidadTrabajo
    {
        private readonly ApplicationDbContext db;

        public IAlmacenRepositorio Almacen { get; private set; }

        public UnidadTrabajo(ApplicationDbContext db)
        {
            this.db = db;
            Almacen = new AlmacenRepositorio(db);
        }

        public void Dispose()
        {
            db.Dispose();
        }

        public async Task Guardar()
        {
            await db.SaveChangesAsync();
        }
    }
}
