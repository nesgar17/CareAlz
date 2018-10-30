
namespace CareAlz.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Web;

    public class RequestInstitute
    {

        [Key]
        public int RequestId { get; set; }

        public DateTime SendDate { get; set; }

        [Required(ErrorMessage = "EL campo {0} es obligatorio")]
        [StringLength(60, ErrorMessage = "El campo {0} debe tener minimo {1} y maximo {2} caracteres", MinimumLength = 3)]
        [Display(Name = "Nombre de la Institución")]
        public string Name { get; set; }

        public int CategoryId { get; set; }

        public int StateId { get; set; }

        public int MunicipalityId { get; set; }

        public int ColonyId { get; set; }


        [Required(ErrorMessage = "EL campo {0} es obligatorio")]
        [StringLength(210, ErrorMessage = "El campo {0} debe tener minimo {1} y maximo {2} caracteres", MinimumLength = 3)]
        [Display(Name = "Dirección")]
        public string Address { get; set; }

        [Required(ErrorMessage = "EL campo {0} es obligatorio")]
        [Display(Name = "Telefono")]
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }

        [Required(ErrorMessage = "EL campo {0} es obligatorio")]
        [StringLength(60, ErrorMessage = "El campo {0} debe tener minimo {1} y maximo {2} caracteres", MinimumLength = 3)]
        [Display(Name = "Dueño o Responsable del Instituto")]
        public string Responsable { get; set; }

        [Required(ErrorMessage = "EL campo {0} es obligatorio")]
        [Display(Name = "Correo Electronico")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        public string Status { get; set; }


        public string FullAddress { get { return string.Format("{0},{1},{2},{3}"
            , State.Description
            , Municipality.Description
            , Colony.Description
            , Address); } }

        public virtual State State { get; set; }

        public virtual Municipality Municipality { get; set; }

        public virtual Colony Colony { get; set; }

        public virtual Category Category { get; set; }
    }
}