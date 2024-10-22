
using PruebaApiNet.Repositories;
using PruebaApiNet.SakilaDatabase;

namespace PruebaApi.Repositories;

public class UnitOfWork
{
    private readonly SakilaMasterContext _context;

    private AddressRepository _addressRepository;
    private FilmRepository _filmRepository;
    private LenguajeRepository _lenguajeRepository;

    public AddressRepository AddressRepository => _addressRepository ??= new AddressRepository(_context);
    public FilmRepository FilmRepository => _filmRepository ??= new FilmRepository(_context);
    public LenguajeRepository LenguajeRepository => _lenguajeRepository ??= new LenguajeRepository(_context);   

    // Constructor
    public UnitOfWork(SakilaMasterContext context)
    {
        _context = context;
    }

    public async Task<bool> SaveAsync()
    {
        return await _context.SaveChangesAsync() > 0;
    }


}