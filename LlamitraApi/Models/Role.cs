﻿using System;
using System.Collections.Generic;

namespace LlamitraApi.Models;

public partial class Role
{
    public int IdRol { get; set; }

    public string Name { get; set; }

    public virtual ICollection<User> Users { get; set; } = [];
}
