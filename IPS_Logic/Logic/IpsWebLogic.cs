using IPS_Entity.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using IPS_Logic.DatabaseIPS;

namespace IPS_Logic.Logic
{
    public class IpsWebLogic
    {
        DB_IPSContext _IPSContext = new DB_IPSContext();

        // Personas convertidas del tipo Db a Entity
        public List<PersonaEntity> GetAllPeople()
        {
            List<PersonaEntity> listPersonEntities = new List<PersonaEntity>();

           var listPersonDataBase = _IPSContext.Personas.ToList(); // Trae una lista desde la BD

            foreach (var PersonDataBase in listPersonDataBase)
            {
                PersonaEntity personaEntity = new PersonaEntity();

                personaEntity.Id = PersonDataBase.Id;
                personaEntity.Nombre = PersonDataBase.Nombre;
                personaEntity.Apellidos = PersonDataBase.Apellidos;
                personaEntity.Cedula = PersonDataBase.Cedula;
                personaEntity.Contraseña = PersonDataBase.Contraseña;

                listPersonEntities.Add(personaEntity);
            }

            return listPersonEntities;
        }
        /* Paciente nuevo...
         trae herencia de PersonaEntity
         tiene IdPersona y IdConvenio
         el convenio tiene: TipoConvenio 1 y 2, valor bit 1 y 0
        */


    }
}
