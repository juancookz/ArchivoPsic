using Microsoft.Data.Sqlite;
using ArchivoPsic.Models;

public class ArchivoRepository
{
    private string _stringConnection;
    public ArchivoRepository(string stringConnection)
    {
        _stringConnection = stringConnection;
    }

    public List<Archivo> GetBySeccionId(int seccionId)
    {
        List<Archivo> archivos = new List<Archivo>();
        string query = @"SELECT id, seccion_id, titulo, ruta_archivo FROM archivos WHERE seccion_id = @seccionId;";
        using (var connection = new SqliteConnection(_stringConnection))
        {
            connection.Open();
            SqliteCommand command = new SqliteCommand(query, connection);
            command.Parameters.AddWithValue("@seccionId", seccionId);
            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    archivos.Add(new Archivo
                    {
                        Id = reader.GetInt32(0),
                        SeccionId = reader.GetInt32(1),
                        Titulo = reader.GetString(2),
                        RutaArchivo = reader.GetString(3)
                    });
                }
            }
            connection.Close();
        }
        return archivos;
    }
}