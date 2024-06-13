using System;
using System.Collections.Generic;

namespace LlamitraApi.Models;

public partial class Video
{
    public int IdVideo { get; set; }

    public string Professor { get; set; }

    public decimal Price { get; set; }

    public string Title { get; set; }

    public string Description { get; set; }

    public string Url { get; set; }
}
