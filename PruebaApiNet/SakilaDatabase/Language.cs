using System;
using System.Collections.Generic;

namespace PruebaApiNet.SakilaDatabase;

public partial class Language
{
    public short LanguageId { get; set; }

    public string Name { get; set; }

    public DateTime LastUpdate { get; set; }

    public virtual ICollection<Film> FilmLanguages { get; set; } = new List<Film>();

    public virtual ICollection<Film> FilmOriginalLanguages { get; set; } = new List<Film>();
}
