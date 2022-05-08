using MVC.Models;
using System.Collections.Generic;

namespace MVC.ViewModels
{
    public class FormularioClienteViewModel
    {
        public Cliente Cliente { get; set; }
        public IEnumerable<TipoMembresia> TiposMembresia { get; set; } = new List<TipoMembresia>();

        public string Titulo => this.Cliente.Id == 0 ? "Nuevo Cliente" : "Editar Cliente";
    }
}
