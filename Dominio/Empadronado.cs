using System;
using System.Collections.Generic;

namespace Dominio
{
    public partial class Empadronado
    {
        public int EmpadronadoId { get; set; }
        public string Dni { get; set; } = null!;
        public string ApePaterno { get; set; } = null!;
        public string ApeMaterno { get; set; } = null!;
        public string Nombres { get; set; } = null!;
        public string NombreCompleto { get; set; } = null!;
        public string Manzana { get; set; } = null!;
        public string Lote { get; set; } = null!;
        public string? Celular { get; set; }
        public string? Direccion { get; set; }
        public string? DireccionReferencia { get; set; }
        public string Sexo { get; set; } = null!;
        public DateTime? FechaNacimiento { get; set; }
        public bool IndAgua { get; set; }
        public bool IndHabita { get; set; }
        public string? Conyugue { get; set; }
        public string? ConyugueDni { get; set; }
        public string? ConyugueCelular { get; set; }
        public int? NroHijos { get; set; }
        public bool Activo { get; set; }
    }
}
