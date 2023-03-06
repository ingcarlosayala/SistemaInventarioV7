using SistemaInventario.AccesoDatos.Data;
using SistemaInventario.AccesoDatos.Repositorio.IRepositorio;
using SistemaInventario.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaInventario.AccesoDatos.Repositorio
{
    public class AlmacenRepositorio : Repositorio<Almacen>, IAlmacenRepositorio
    {
        private readonly ApplicationDbContext db;

        public AlmacenRepositorio(ApplicationDbContext db) : base(db)
        {
            this.db = db;
        }

        public void Actualizar(Almacen almacen)
        {
            var obj = db.Almacen.FirstOrDefault(a => a.Id.Equals(almacen.Id));
            if (obj != null)
            {
                obj.Nombre = almacen.Nombre;
                obj.Descripcion = almacen.Descripcion;
                obj.Estado = almacen.Estado;
                db.SaveChanges();
            }
        }
    }
}
