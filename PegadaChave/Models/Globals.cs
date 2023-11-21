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
            IdClienteLogado = 0;
            IdFuncionarioLogado = 0;    
        }
        public static int IdClienteLogado { get; set; }
        public static int IdFuncionarioLogado { get; set; }
    }

}