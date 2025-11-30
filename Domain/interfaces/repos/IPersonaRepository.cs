using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.interfaces.repos
{
    public interface IPersonaRepository
    {
        public List<Persona> getAllPersonas();
        public Persona getPersonaByID(int id);
        public int createPersona(Persona persona);
        public int updatePersona(int id, Persona persona);
        public int deletePersona(int id);
    }
}
