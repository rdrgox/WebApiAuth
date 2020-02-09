using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApiAuth.Models
{
    public class Pais
    {
        public Pais()
        {
            Ciudads = new List<Ciudad>();
        }

        public int Id { get; set; }

        [StringLength(30, ErrorMessage = "El campo {0} debe ser de máximo de 30 caracteres")]
        public string Nombre { get; set; }

        public List<Ciudad> Ciudads { get; set; }
    }
}
