using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSAula10_exercicioEstacionamento
{
    internal class Utilidades
    {
        public bool txt_em_branco(TextBox txt)
        {
            if (txt.Text.Trim() == "")
            {

                return true;

            }
            else
            {
                return false;
            }
        
        }
    }
}
