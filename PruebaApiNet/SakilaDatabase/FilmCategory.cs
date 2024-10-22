using System;
using System.Collections.Generic;

namespace PruebaApiNet.SakilaDatabase;

public partial class FilmCategory
{
    public int FilmId { get; set; }

    public short CategoryId { get; set; }

    public DateTime LastUpdate { get; set; }

    public virtual Category Category { get; set; }

    public virtual Film Film { get; set; }
}
