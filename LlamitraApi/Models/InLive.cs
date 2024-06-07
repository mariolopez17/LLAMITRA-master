using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LlamitraApi.Models;

public partial class InLive
{
    public int IdLive { get; set; }
    
    //public int? IdCategory { get; set; }

    public string? Professor { get; set; }

    public decimal? Price { get; set; }

    public string? Title { get; set; }

    public string? Description { get; set; }

    public string? Url { get; set; }

    //public virtual Category? IdCategoryNavigation { get; set; }
}


