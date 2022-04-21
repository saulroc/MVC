using System;
using System.ComponentModel.DataAnnotations;

namespace MVC.Models
{
    public class Cliente
    {
        public int Id { get; set; }
        
        [Required]
        [StringLength(255)]
        [Display(Name = "Nombre Cliente")]
        public string Nombre { get; set; }

        public bool EstaSubscritoAlBoletinInformativo { get; set; }
        public virtual TipoMembresia TipoMembresia { get; set; }
        public byte TipoMembresiaId { get; set; }
        public DateTime? FechaDeNacimiento { get; set; }
    }
}
