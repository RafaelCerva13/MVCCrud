using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCCrud.Models.ViewModels
{
    public class TablaViewModel
    {

        public int ID { get; set; }
        [Required]
        [StringLength(50)]
        
        public string NOMBRE { get; set; }
        [Required]
        [StringLength(15)]
        public string APELLIDO_P { get; set; }
        [Required]
        [StringLength(15)]
        public string APELLIDO_M { get; set; }
        [Required]
        [StringLength(15)]

        public int EDAD { get; set; }
        [Required]
        public bool IsActive { get; set; }
     

    }
}