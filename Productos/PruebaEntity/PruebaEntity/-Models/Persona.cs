﻿using System;
using System.Collections.Generic;

namespace PruebaEntity.-Models;

public partial class Persona
{
    public int Id { get; set; }

    public string? Nombre { get; set; }

    public DateTime? Fecha { get; set; }

    public bool? Status { get; set; }
}
