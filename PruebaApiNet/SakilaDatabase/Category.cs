using System;
using System.Collections.Generic;

namespace PruebaApiNet.SakilaDatabase;

public partial class Category
{
    public short CategoryId { get; set; }

    public string Name { get; set; }

    public DateTime LastUpdate { get; set; }

    public virtual ICollection<FilmCategory> FilmCategories { get; set; } = new List<FilmCategory>();
}
