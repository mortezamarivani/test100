using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Gx.DataLayer.Entities.Common;

namespace Gx.DataLayer.Entities.Crud
{
    public class Crud : BaseEntity
    {
        #region properties

        [Display(Name = "Firstname ")]
        [Required(ErrorMessage = "Please  enter the {0}")]
        [MaxLength(100, ErrorMessage = "The number of {0} characters cannot be more than {1}")]
        public string Firstname { get; set; }

        [Display(Name = "Lastname")]
        [Required(ErrorMessage = "Please  enter the {0}")]
        [MaxLength(100, ErrorMessage = "The number of {0} characters cannot be more than {1}")]
        public string Lastname { get; set; }

        [Display(Name = "DateOfBirth")]
        [Required(ErrorMessage = "Please  enter the {0}")]
        public int DateOfBirth { get; set; }

        [Display(Name = "PhoneNumber")]
        [Required(ErrorMessage = "Please  enter the {0}")]
        [MaxLength(13, ErrorMessage = "The number of {0} characters cannot be more than {1}")]
        public string PhoneNumber { get; set; }


        [Display(Name = "Email")]
        [Required(ErrorMessage = "Please  enter the {0}")]
        [MaxLength(50, ErrorMessage = "The number of {0} characters cannot be more than {1}")]
        public string Email { get; set; }

        [Display(Name = "BankAccountNumber")]
        [Required(ErrorMessage = "Please  enter the {0}")]
        public int BankAccountNumber { get; set; }

        #endregion

        #region Relations


        #endregion
    }
}
