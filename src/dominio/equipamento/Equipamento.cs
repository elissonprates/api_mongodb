using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class Equipamento: Entidade
    {
        public int? codigo { get; set; }
        public string nome { get; set; }
    }
}
