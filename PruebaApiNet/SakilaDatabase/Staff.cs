using System;
using System.Collections.Generic;

namespace PruebaApiNet.SakilaDatabase;

public partial class Staff
{
    public short StaffId { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public int AddressId { get; set; }

    public byte[] Picture { get; set; }

    public string Email { get; set; }

    public int StoreId { get; set; }

    public short Active { get; set; }

    public string Username { get; set; }

    public string Password { get; set; }

    public DateTime LastUpdate { get; set; }

    public virtual Address Address { get; set; }

    public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();

    public virtual ICollection<Rental> Rentals { get; set; } = new List<Rental>();

    public virtual Store Store { get; set; }

    public virtual ICollection<Store> Stores { get; set; } = new List<Store>();
}
