using Microsoft.EntityFrameworkCore;

namespace PruebaApiNet.Database;

public class MyDbContext : DbContext //Hereda de DbContext que provee de varios metodos para la configuracion
{
    private const string DATABASE_PATH = "books.db"; //Fichero de nuestra base de datos
    //Con esto le decimos cuales son las tablas del proyecto
    public DbSet<Author> Authors { get; set; } 
    public DbSet<Book> Books { get; set; }

    //Donde esta la base de datos y que tipo
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        string baseDir = AppDomain.CurrentDomain.BaseDirectory; //Devuelve la ruta del ejecutable donde se crea la base de datos
        optionsBuilder.UseSqlite($"DataSource={baseDir}{DATABASE_PATH}");
    }
}
