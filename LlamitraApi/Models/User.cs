using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace LlamitraApi.Models;

public partial class User
{
    public int IdUser { get; set; }
    public string Name { get; set; }
    public string Lastname { get; set; }
    public string Mail { get; set; }
    public int IdRol { get; set; }
    public string Password { get; set; }
    public bool IsActive { get; set; }
    public virtual Role IdRolNavigation { get; set; }
    public virtual ICollection<Publication> Publications { get; set; } = [];
    
}
