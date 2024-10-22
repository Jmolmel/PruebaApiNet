using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PruebaApi.Repositories;
using PruebaApiNet.Repositories;
using PruebaApiNet.SakilaDatabase;

namespace PruebaApiNet.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SakilaController : ControllerBase
{

    private readonly UnitOfWork _unitOfWork;

    public SakilaController(UnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }


    [HttpGet("addresses")] //EndPoint lo llamamos films para buscarlo directamente
    public async Task<IEnumerable<Address>> GetAddresses()
    {
        return await _unitOfWork.AddressRepository.GetAllAsync();

    }

    [HttpGet("films")] //EndPoint lo llamamos films para buscarlo directamente
    public async Task<IEnumerable<Film>> GetFilms()
    {
        return await _unitOfWork.FilmRepository.GetAllAsync();
    }


    [HttpGet("addresessByPostalCode")] 
    public async Task<IEnumerable<Address>> GetAddressByPostalCode(string postalCode)
    {
        return await _unitOfWork.AddressRepository.GetByPostalCode(postalCode);
    }


    [HttpGet("addressesWithCity")]
    public async Task<IEnumerable<Address>> GetAddressesWithCity()
    {
        return await _unitOfWork.AddressRepository.GetAddressesWithCity();
    }
}
