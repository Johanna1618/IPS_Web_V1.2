using System;
using System.Collections.Generic;

#nullable disable

namespace IPS_Entity.Entity
{
    public partial class PacienteEntity : PersonaEntity
    {

        public int IdPaciente { get; set; }
        public int IdConvenio { get; set; }
        //public int IdPersona { get; set; } se agregó por herencia

    }
}