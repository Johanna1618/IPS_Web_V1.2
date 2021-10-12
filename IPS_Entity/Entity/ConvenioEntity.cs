using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPS_Entity.Entity
{
    class ConvenioEntity
    {
        public int Id { get; set; }
        public bool TipoConvenio { get; set; }
        public DateTime HorarioA { get; set; } // revisar
        public DateTime HorarioB { get; set; } // revisar
        public int Mensualidad { get; set; }
        public int Descuento { get; set; }
    }
}
