using PruebaApiNet.SakilaDatabase;

namespace PruebaApiNet.Repositories;

public class FilmRepository : Repository<Film, int>
{
    public FilmRepository(SakilaMasterContext context) : base(context)
    {
    }
}
