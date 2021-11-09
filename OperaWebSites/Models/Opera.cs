using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations; //agregar
using System.ComponentModel.DataAnnotations.Schema; //agreagr -- DB
using OperaWebSites.Validatios;//agregar

namespace OperaWebSites.Models
{
    [Table("Opera")]//EF -->DB
    public class Opera
    {
        public int OperaID { get; set; }
        [Required(ErrorMessage ="Is Required")]
        [StringLength(150)]
        public string Title { get; set; }
        [Required(ErrorMessage = "Is required")]
        public string Composer { get; set; }
        [CheckValueYear]
        public int Year { get; set; }
    }
}