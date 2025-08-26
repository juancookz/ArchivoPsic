using Microsoft.Data.Sqlite;
public class SeccionRepository
{
    private string _stringConnection;
    public SeccionRepository(string stringConnection)
    {
        _stringConnection = stringConnection;
    }
    public List<Seccion> GetAll()
    {
        List<Seccion> Secciones = new List<Seccion>();
        string query = @"SELECT * FROM secciones;";
        using (var connection = new SqliteConnection(_stringConnection))
        {
            connection.Open();
            SqliteCommand command = new SqliteCommand(query, connection);
            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    Secciones.Add(new Seccion
                    {
                        Id = reader.GetInt32(0),
                        Nombre = reader.GetString(1),
                        Descripcion = reader.GetString(2)
                    });
                }
            }
            connection.Close();
        }
        return Secciones;
    }
}