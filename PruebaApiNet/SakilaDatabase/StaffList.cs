using System;
using System.Collections.Generic;

namespace PruebaApiNet.SakilaDatabase;

public partial class StaffList
{
    public short? Id { get; set; }

    public string Name { get; set; }

    public string Address { get; set; }

    public string ZipCode { get; set; }

    public string Phone { get; set; }

    public string City { get; set; }

    public string Country { get; set; }

    public int? Sid { get; set; }
}
