using Domain.DTOs;
using Domain.Entities;
using Domain.interfaces.repos;
using Domain.interfaces.usecases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.usecases
{
    public class DepartamentoRepositoryUsecase : IDepartamentoRepositoryUsecase
    {
        public IDepartamentoRepository _departamentoRepository { get; }
        public IPersonaRepository _personaRepository { get;}

        public DepartamentoRepositoryUsecase(IDepartamentoRepository departamentoRepository, IPersonaRepository personaRepository)
        {
            _personaRepository = personaRepository;
            _departamentoRepository = departamentoRepository;
        }

        public List<Departamento> getAllDepartamentos()
        {
            return _departamentoRepository.getAllDepartamentos();
        }

        public int createDepartamento(Departamento departamento)
        {
            return _departamentoRepository.createDepartamento(departamento);
        }
        public int updateDepartamento(int id, Departamento departamento)
        {
            return _departamentoRepository.updateDepartamento(id, departamento);
        }

        public int deleteDepartamento(int id)
        {
            int result = 0;
            var personasInDepartamento = _departamentoRepository.countPersonasInDepartamento(id);
            if (personasInDepartamento > 0)
            {
               result = -1;
            }
            else
            {
                result= _departamentoRepository.deleteDepartamento(id);
            }

            return result;

        }

        public Departamento getDepartamentoByID(int id)
        {
            return _departamentoRepository.getDepartamentoByID(id);
        }
    }
}
