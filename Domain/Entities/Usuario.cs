﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Usuario
    {
        [Key]
        public int pkUsuario { get; set; }
        public string Nombre { get; set;}

        public string User { get; set; }
        public string Password { get; set; }

        [ForeignKey("Roles")]
        public int FkRol { get; set; }

        public Rol Roles { get; set; }
    }
}
