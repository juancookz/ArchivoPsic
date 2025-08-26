using Microsoft.AspNetCore.Mvc;
using ArchivoPsic.Models;

public class SeccionController : Controller
{
    private readonly SeccionRepository SeccionRepository;
    public SeccionController()
    {
        SeccionRepository = new SeccionRepository(@"Data Source=db/Archivo.db;Cache=Shared");
    }
    public IActionResult ListAll()
    {
        List<Seccion> Secciones = SeccionRepository.GetAll();
        return View(Secciones);
    }
        public IActionResult Index()
    {
        return View();
    }
}