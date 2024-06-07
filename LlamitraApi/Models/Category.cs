using System;
using System.Collections.Generic;

namespace LlamitraApi.Models;

public partial class Category
{
    public int IdCategory { get; set; }

    public string? Name { get; set; }

    public bool? IsActive { get; set; }

    public virtual ICollection<InLive> InLives { get; set; } = [];

    public virtual ICollection<Presential> Presentials { get; set; } = [];

    public virtual ICollection<Video> Videos { get; set; } = [];
}
