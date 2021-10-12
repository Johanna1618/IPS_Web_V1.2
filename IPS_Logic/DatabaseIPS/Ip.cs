using System;
using System.Collections.Generic;

#nullable disable

namespace IPS_Logic.DatabaseIPS
{
    public partial class Ip
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int IdSede { get; set; }

        public virtual Sede IdSedeNavigation { get; set; }
    }
}
