using PruebaApiNet.SakilaDatabase;

namespace PruebaApiNet.Repositories;

public class LenguajeRepository : Repository<Language, short>
{
    public LenguajeRepository(SakilaMasterContext context) : base(context)
    {
    }
}
