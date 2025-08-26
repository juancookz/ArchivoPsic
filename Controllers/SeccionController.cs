using Microsoft.AspNetCore.Mvc;
using ArchivoPsic.Models;

public class SeccionController : Controller
{
    private readonly SeccionRepository SeccionRepository;
    private readonly ArchivoRepository ArchivoRepository;

    public SeccionController()
    {
        SeccionRepository = new SeccionRepository(@"Data Source=db/Archivo.db;Cache=Shared");
        ArchivoRepository = new ArchivoRepository(@"Data Source=db/Archivo.db;Cache=Shared");
    }

    public IActionResult Index()
    {
        List<Seccion> Secciones = SeccionRepository.GetAll();
        return View(Secciones);
    }

    public IActionResult ListArchivos(int id)
    {
        var archivos = ArchivoRepository.GetBySeccionId(id);
        ViewBag.SeccionId = id;
        return View(archivos);
    }
}