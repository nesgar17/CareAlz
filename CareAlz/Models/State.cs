namespace CareAlz.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class State
    {

        [Key]
        public int StateId { get; set; }

        [Required(ErrorMessage = "EL campo {0} es obligatorio")]
        [StringLength(60, ErrorMessage = "El campo {0} debe tener minimo {1} y maximo {2} caracteres", MinimumLength = 3)]
        [Display(Name = "Nombre")]
        public string Description { get; set; }

        public virtual ICollection<Municipality> Municipalities { get; set; }

        public virtual ICollection<Administrator> Administrators { get; set; }

        public virtual ICollection<RequestInstitute> RequestInstitutes { get; set; }

    }
}