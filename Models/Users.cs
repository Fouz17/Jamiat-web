﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace Jamiat_web.Models
{
    public partial class Users
    {
        public Users()
        {
            UserRespMapping = new HashSet<UserRespMapping>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public int Association { get; set; }
        public string Status { get; set; }

        public virtual Associations AssociationNavigation { get; set; }
        public virtual ICollection<UserRespMapping> UserRespMapping { get; set; }
    }
}