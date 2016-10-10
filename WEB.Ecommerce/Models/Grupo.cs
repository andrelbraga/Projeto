using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WEB.Ecommerce.Models
{
    public class Grupo
    {
    //Modelagem de grupos de usuarios para acesso
        public int GrupoId { get; set; }
        public string Tipo { get; set; }
        public string Descricao { get; set; }

    }
}