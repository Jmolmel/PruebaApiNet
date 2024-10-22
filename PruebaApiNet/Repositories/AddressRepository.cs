using Microsoft.EntityFrameworkCore;
using PruebaApiNet.SakilaDatabase;

namespace PruebaApiNet.Repositories;

public class AddressRepository : Repository<Address , int>
{
    public AddressRepository(SakilaMasterContext context) : base(context)
    {
    }

    public async Task<ICollection<Address>> GetByPostalCode(string postalCode)
    {
        return await GetQueryable()
            .Where(address => address.PostalCode == postalCode)
            .ToListAsync();
    }


    public async Task<ICollection<Address>> GetAddressesWithCity()
    {
        return await GetQueryable()
            .Include(address => address.City)
            .ToArrayAsync();
    }
}


