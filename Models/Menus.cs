﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace Jamiat_web.Models
{
    public partial class Menus
    {
        public Menus()
        {
            MenuMappings = new HashSet<MenuMappings>();
        }

        public int Id { get; set; }
        public string Menu { get; set; }
        public string Url { get; set; }
        public bool? IsParent { get; set; }

        public virtual ICollection<MenuMappings> MenuMappings { get; set; }
    }
}