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

        // Conversión tipo Db a Entity
        public List<PersonaEntity> GetAllPeople()
        {
            List<PersonaEntity> listPersonEntities = new List<PersonaEntity>();

           var listPersonDataBase = _IPSContext.Personas.ToList(); // Trae una lista desde la BD

            foreach (var PersonDataBase in listPersonDataBase)
            {
                PersonaEntity personaEntity = new PersonaEntity();

                listPersonEntities.Add(ConvertPersonDatabaseToPersonEntity(PersonDataBase));
            }

            return listPersonEntities;
        }

        public PersonaEntity AddPerson(PersonaEntity personaEntity)
        {
            try
            {

            
            if (GetAllPeople().Where(x => x.Cedula == personaEntity.Cedula).Any()) {

                PersonaEntity persona = new PersonaEntity();
                persona.Message = "Ya extiste un usuario con esa cédula";
                persona.Type = "danger";
                return persona;
            }

                _IPSContext.Personas.Add(ConvertPersonEntityToPersonDatabase(personaEntity)); // conversión Ent to Db
                _IPSContext.SaveChanges();
                personaEntity.Message = "Persona guardada con exito";
                personaEntity.Type = "success";

                return personaEntity; // temporal
            }
            catch (Exception ex)
            {
                PersonaEntity persona = new PersonaEntity();
                persona.Message = ex.Message;
                return persona;
            }
            
        }

        //----------------------------
        private Persona ConvertPersonEntityToPersonDatabase(PersonaEntity personaEntity) // Ent to Db
        {
            Persona persona = new Persona();

            persona.Id = personaEntity.Id;
            persona.Nombre = personaEntity.Nombre;
            persona.Apellidos = personaEntity.Apellidos;
            persona.Cedula = personaEntity.Cedula;
            persona.Contraseña = personaEntity.Contraseña;

            return persona;
        }

        private PersonaEntity ConvertPersonDatabaseToPersonEntity(Persona persona) // Db to Ent
        {
            PersonaEntity personaEntity = new PersonaEntity();

            personaEntity.Id = persona.Id;
            personaEntity.Nombre = persona.Nombre;
            personaEntity.Apellidos = persona.Apellidos;
            personaEntity.Cedula = persona.Cedula;
            personaEntity.Contraseña = persona.Contraseña;

            return personaEntity;
        }


    }

}
