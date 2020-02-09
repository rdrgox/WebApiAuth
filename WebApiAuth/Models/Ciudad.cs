using System;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace WebApiAuth.Models
{
    public class Ciudad
    {
        public int Id { get; set; }

        public string Nombre { get; set; }

        [ForeignKey("Pais")]
        public int PaisId { get; set; }

        [JsonIgnore]
        public Pais Pais { get; set; }
    }
}
