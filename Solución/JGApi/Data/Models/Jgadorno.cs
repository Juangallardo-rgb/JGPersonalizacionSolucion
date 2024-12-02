using System;
using System.Collections.Generic;

namespace JGApi.Data.Models;

public partial class Jgadorno
{
    public int JgadornosId { get; set; }

    public string Jgname { get; set; } = null!;

    public bool Jgnavideno { get; set; }

    public decimal Jgprice { get; set; }
}
