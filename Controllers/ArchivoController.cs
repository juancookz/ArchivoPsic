using Microsoft.AspNetCore.Mvc;
using ArchivoPsic.Models;

public class ArchivoController : Controller
{
    private readonly ArchivoRepository ArchivoRepository;

    public ArchivoController()
    {
        ArchivoRepository = new ArchivoRepository(@"Data Source=db/Archivo.db;Cache=Shared");
    }

    // Example: List all archivos (not by seccion)
    public IActionResult Index()
    {
        // Implement if needed
        return View();
    }
}