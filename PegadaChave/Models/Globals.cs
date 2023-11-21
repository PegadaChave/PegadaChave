using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PegadaChave.Models
{
    public static class Globals
    {
        static Globals()
        {
            IdUsuarioLogado = 0;
        }
        public static int IdUsuarioLogado { get; set; }
    }

}