using Dominio;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Quicapata.Controllers
{
    public class EmpadronadoController : Controller
    {
        private readonly QUICAPATAContext context;

        public EmpadronadoController(QUICAPATAContext context)
        {
            this.context = context;
        }
        public async Task< IActionResult> Index(string pBuscar="")
        {
            ViewBag.NroEmpadronados = await context.Empadronado.CountAsync(x => x.Activo);
            if (string.IsNullOrEmpty(pBuscar.Trim()))
                return View(await context.Empadronado.ToListAsync());
            else
                return View(await context.Empadronado.Where(x=>x.NombreCompleto.Contains(pBuscar)).ToListAsync());
        }
        public async Task<IActionResult> Editar(int id=0)
        {
            if (id > 0)
                return View(await context.Empadronado.FindAsync(id));
            else
                return View(new Empadronado { Sexo = "M", IndAgua = true, IndHabita = true, Activo = true });
        }
        [HttpPost]
        public async Task<IActionResult> Guardar(Empadronado emp)
        {
            emp.ApePaterno=emp.ApePaterno.ToUpper();
            emp.ApeMaterno = emp.ApeMaterno.ToUpper();
            emp.Nombres = emp.Nombres.ToUpper();
            emp.NombreCompleto = emp.ApePaterno + " " + emp.ApeMaterno + " " + emp.Nombres;
            if (!string.IsNullOrEmpty(emp.Conyugue))
                emp.Conyugue = emp.Conyugue.ToUpper();
            if (!string.IsNullOrEmpty(emp.Direccion))
                emp.Direccion = emp.Direccion.ToUpper();


            if (emp.EmpadronadoId > 0)
                context.Empadronado.Update(emp);
            else
                context.Empadronado.Add(emp);

            await context.SaveChangesAsync();

            return RedirectToAction("Index");
        }
    }
}
