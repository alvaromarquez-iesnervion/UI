using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.interfaces.repos
{
    public interface IDepartamentoRepository
    {
        public List<Entities.Departamento> getAllDepartamentos();
        public Entities.Departamento getDepartamentoByID(int id);
        public int createDepartamento(Entities.Departamento departamento);
        public int updateDepartamento(int id, Entities.Departamento departamento);
        public int deleteDepartamento(int id);
        public int countPersonasInDepartamento(int idDepartamento);
    }
}
