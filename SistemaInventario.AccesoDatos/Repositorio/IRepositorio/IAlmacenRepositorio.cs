using SistemaInventario.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaInventario.AccesoDatos.Repositorio.IRepositorio
{
    public interface IAlmacenRepositorio:IRepositorio<Almacen>
    {
        void Actualizar(Almacen almacen);
    }
}
