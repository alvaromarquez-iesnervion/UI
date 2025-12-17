using Domain.Entities;
using Domain.interfaces.usecases;
using Microsoft.AspNetCore.Mvc;

namespace UI.Controllers
{
    public class DepartamentoController : Controller
    {
        private readonly IDepartamentoRepositoryUsecase _departamentoRepositoryUsecase;
        private readonly IPersonaRepositoryUsecase _personaRepositoryUsecase;
        public DepartamentoController(IDepartamentoRepositoryUsecase departamentoRepositoryUsecase, IPersonaRepositoryUsecase _personaRepositoryUsecase)
        {
            this._departamentoRepositoryUsecase = departamentoRepositoryUsecase;
            this._personaRepositoryUsecase = _personaRepositoryUsecase;
        }
        public IActionResult Index()
        {
            var departamentos = _departamentoRepositoryUsecase.getAllDepartamentos();
            return View(departamentos);
        }

        public IActionResult Details(int id)
        {
            var departamento = _departamentoRepositoryUsecase.getDepartamentoByID(id);
            return View(departamento);
        }

        public IActionResult Create()
        {
           
            return View();

        }
        [HttpPost]
        public IActionResult Create(Departamento departamento)
        {
            _departamentoRepositoryUsecase.createDepartamento(departamento);
            return RedirectToAction("Index");
        }
        public IActionResult Edit(int id)
        {
            var departamento = _departamentoRepositoryUsecase.getDepartamentoByID(id);
            return View(departamento);
        }
        [HttpPost]
        public IActionResult Edit(int id, Departamento departamento)
        {
            _departamentoRepositoryUsecase.updateDepartamento(id, departamento);
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            var departamento = _departamentoRepositoryUsecase.getDepartamentoByID(id);
            return View(departamento);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            int result = _departamentoRepositoryUsecase.deleteDepartamento(id);
            if (result == -1)
            {
                TempData["ErrorMessage"] = "No se puede eliminar el departamento porque tiene personas asignadas.";
                return RedirectToAction("Delete", new { id = id });
            }
            return RedirectToAction("Index");
        }
    }
}
