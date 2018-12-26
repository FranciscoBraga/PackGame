using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PackGameWeb.Areas.Usuario.Models
{
    public class Upload
    {
       public HttpPostedFileBase Arquivo { get; set; }
    }
}