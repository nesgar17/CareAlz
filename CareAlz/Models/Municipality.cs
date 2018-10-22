﻿namespace CareAlz.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Web;

    public class Municipality
    {


        [Key]
        public int MunicipalityId { get; set; }

        [Required(ErrorMessage = "EL campo {0} es obligatorio")]
        [StringLength(60, ErrorMessage = "El campo {0} debe tener minimo {1} y maximo {2} caracteres", MinimumLength = 3)]
        [Display(Name = "Nombre")]
        public string Description { get; set; }

        public int StateId { get; set; }

        public virtual State State { get; set; }

        public virtual ICollection<Colony> Colonies { get; set; }

        public virtual ICollection<Administrator> Administrators { get; set; }

        public virtual ICollection<RequestInstitute> RequestInstitutes { get; set; }

    }
}