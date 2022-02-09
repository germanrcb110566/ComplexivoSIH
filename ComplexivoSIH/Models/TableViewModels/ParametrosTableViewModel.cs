using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ComplexivoSIH.Models.TableViewModels
{
    public class ParametrosTableViewModel
    {
        public int Parametro_id { get; set; }
        public string Smtpserver { get; set; }
        public int Smtppuerto { get; set; }
        public string Correo_sistema { get; set; }
        
    }
}