using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.interfaces.usecases
{
    public interface IDepartamentoRepositoryUsecase
    {
        public List<Departamento> getAllDepartamentos();
        public int createDepartamento(Departamento departamento);
        public int updateDepartamento(int id, Departamento departamento);
        public int deleteDepartamento(int id);
        public Departamento getDepartamentoByID(int id);


    }
}
