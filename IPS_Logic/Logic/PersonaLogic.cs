using IPS_Entity.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using IPS_Logic.DatabaseIPS;

namespace IPS_Logic.Logic
{
    public class PersonaLogic
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
                persona.Message = "Ya existe un usuario con esa cédula";
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

        // filtrando por cédula
        public PersonaEntity GetPersonForCedula(string cedula)
        {
            var personEntity = GetAllPeople().Where(x => x.Cedula == cedula).FirstOrDefault();

            if (personEntity == null)
            {
                PersonaEntity persona = new PersonaEntity();
                persona.Message = "No existe una persona con esa cédula";
                persona.Type = "danger";
                return persona;
            }

            return personEntity;
        }
        // ------------- filtro

        // Actualizando desde el campo cédula
        public PersonaEntity UpdatePerson(PersonaEntity personaEntity)
        {
            try
            {
                var personDataBase = _IPSContext.Personas.Where(x => x.Cedula == personaEntity.Cedula).FirstOrDefault();

                if (personDataBase == null)
                {

                    PersonaEntity persona = new PersonaEntity();
                    persona.Message = "Ya existe un usuario con esa cédula";
                    persona.Type = "danger";
                    return persona;
                }

                personDataBase.Id = personaEntity.Id;
                personDataBase.Nombre = personaEntity.Nombre;
                personDataBase.Apellidos = personaEntity.Apellidos;
                personDataBase.Cedula = personaEntity.Cedula;
                personDataBase.Contraseña = personaEntity.Contraseña;

                _IPSContext.Personas.Update(personDataBase);
                _IPSContext.SaveChanges();
                personaEntity.Message = "Persona actualizada con exito";
                personaEntity.Type = "success";

                return personaEntity; 
            }
            catch (Exception ex)
            {
                PersonaEntity persona = new PersonaEntity();
                persona.Message = ex.Message;
                return persona;
            }
        }
        //------------ Actualización

        //------------ los conversores
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
        //------------
    }

}
