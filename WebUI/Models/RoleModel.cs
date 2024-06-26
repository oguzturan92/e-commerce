using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using ProjeEntity.Concrete;

namespace WebUI.Models
{
    // Role/
    public class RoleModel
    {
        public string RoleId { get; set; }

        [Required(ErrorMessage = "Zorunlu alan.")]
        public string RoleName { get; set; }
        public IQueryable<ProjeRole> Roles { get; set; }
    }
}