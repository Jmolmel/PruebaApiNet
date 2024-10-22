using System;
using System.Collections.Generic;

namespace PruebaApiNet.SakilaDatabase;

public partial class Film
{
    public int FilmId { get; set; }

    public string Title { get; set; }

    public string Description { get; set; }

    public string ReleaseYear { get; set; }

    public short LanguageId { get; set; }

    public short? OriginalLanguageId { get; set; }

    public short RentalDuration { get; set; }

    public decimal RentalRate { get; set; }

    public short? Length { get; set; }

    public decimal ReplacementCost { get; set; }

    public string Rating { get; set; }

    public string SpecialFeatures { get; set; }

    public DateTime LastUpdate { get; set; }

    public virtual ICollection<FilmActor> FilmActors { get; set; } = new List<FilmActor>();

    public virtual ICollection<FilmCategory> FilmCategories { get; set; } = new List<FilmCategory>();

    public virtual ICollection<Inventory> Inventories { get; set; } = new List<Inventory>();

    public virtual Language Language { get; set; }

    public virtual Language OriginalLanguage { get; set; }
}
