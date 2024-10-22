﻿using System;
using System.Collections.Generic;

namespace PruebaApiNet.SakilaDatabase;

public partial class FilmList
{
    public int? Fid { get; set; }

    public string Title { get; set; }

    public string Description { get; set; }

    public string Category { get; set; }

    public decimal? Price { get; set; }

    public short? Length { get; set; }

    public string Rating { get; set; }

    public string Actors { get; set; }
}
