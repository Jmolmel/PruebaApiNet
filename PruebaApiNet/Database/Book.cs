using Microsoft.EntityFrameworkCore;

namespace PruebaApiNet.Database;

[PrimaryKey(nameof(ISB))] //Selecciona clave primaria concreta
[Index(nameof(Name), IsUnique = true)] //No puede haber dos libros con el mismo nombre
public class Book
{
    public int ISB { get; set; }

    public string Name { get; set; }
    public double Price { get; set; }

    public Author Author { get; set; } 
}
