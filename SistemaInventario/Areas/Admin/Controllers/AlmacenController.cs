using Microsoft.AspNetCore.Mvc;
using SistemaInventario.AccesoDatos.Repositorio.IRepositorio;
using SistemaInventario.Models;

namespace SistemaInventario.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AlmacenController : Controller
    {
        private readonly IUnidadTrabajo unidadTrabajo;

        public AlmacenController(IUnidadTrabajo unidadTrabajo)
        {
            this.unidadTrabajo = unidadTrabajo;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> upSert(int? id)
        {
            Almacen almacen = new Almacen();

            if (id is null)
            {
                //Crear
                return View(almacen);
            }

            almacen = await unidadTrabajo.Almacen.Obtener(id.GetValueOrDefault());

            if (almacen == null)
            {
                return NotFound();
            }

            return View(almacen);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> upSert(Almacen almacen)
        {
            if(ModelState.IsValid)
            {
                if (almacen.Id == 0)
                {
                    await unidadTrabajo.Almacen.Agregar(almacen);
                    await unidadTrabajo.Guardar();
                }
                else
                {
                    unidadTrabajo.Almacen.Actualizar(almacen);
                    await unidadTrabajo.Guardar();
                }
                return RedirectToAction(nameof(Index));
            }
            return View(almacen);
        }

        #region API
        [HttpGet]
        public async Task<IActionResult> ObtenerTodos()
        {
            var todos = await unidadTrabajo.Almacen.ObtenerTodos();
            return Json(new { data = todos });
        }

        [HttpDelete]
        public async Task<IActionResult> delete(int? id)
        {
            if (id == null)
            {
                return Json(new {success = false, message = "Error al eliminar"});
            }

            var obj = await unidadTrabajo.Almacen.Obtener(id.GetValueOrDefault());
            unidadTrabajo.Almacen.Remover(obj);
            await unidadTrabajo.Guardar();
            return Json(new {success = true, message = "Almacen eliminado correctamente"});
        }
        #endregion
    }
}
