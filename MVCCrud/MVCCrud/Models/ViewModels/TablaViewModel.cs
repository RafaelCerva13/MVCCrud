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

       
        public string NOMBRE { get; set; }
       
        public string APELLIDO_P { get; set; }

        public string APELLIDO_M { get; set; }
        

        public int EDAD { get; set; }
        
        
        public bool IsActive { get; set; }
     

    }
}