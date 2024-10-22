using System;
using System.Collections.Generic;

namespace PruebaApiNet.SakilaDatabase;

public partial class Store
{
    public int StoreId { get; set; }

    public short ManagerStaffId { get; set; }

    public int AddressId { get; set; }

    public DateTime LastUpdate { get; set; }

    public virtual Address Address { get; set; }

    public virtual ICollection<Customer> Customers { get; set; } = new List<Customer>();

    public virtual ICollection<Inventory> Inventories { get; set; } = new List<Inventory>();

    public virtual Staff ManagerStaff { get; set; }

    public virtual ICollection<Staff> Staff { get; set; } = new List<Staff>();
}
