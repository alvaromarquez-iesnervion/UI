using Domain.Entities;
using Microsoft.Data.SqlClient;
using _07_CRUD_Personas_DAL.Conexion;
using System;
using System.Collections.Generic;
using Domain.interfaces.repos;

namespace Infrastructure.Repositories
{
    public class DepartamentoRepository : IDepartamentoRepository
    {
        private readonly clsMyConnection _connectionManager;

        // Constructor con inyección de dependencias
        public DepartamentoRepository(clsMyConnection connectionManager)
        {
            _connectionManager = connectionManager;
        }

        // Constructor sin parámetros (por compatibilidad)
        public DepartamentoRepository()
        {
            _connectionManager = new clsMyConnection();
        }

        /// <summary>
        /// Obtiene todos los departamentos de la base de datos
        /// </summary>
        /// <returns>Lista de departamentos</returns>
        public List<Departamento> getAllDepartamentos()
        {
            List<Departamento> departamentos = new List<Departamento>();
            SqlConnection connection = null;
            SqlCommand command = null;
            SqlDataReader reader = null;

            try
            {
                connection = _connectionManager.getConnection();
                command = new SqlCommand("SELECT Id, Nombre FROM Departamentos", connection);
                reader = command.ExecuteReader();

                while (reader.Read())
                {
                    int id = reader.GetInt32(0);
                    string nombre = reader.GetString(1);
                    departamentos.Add(new Departamento(id, nombre));
                }
            }
            catch (SqlException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                reader?.Close();
                if (connection != null)
                {
                    _connectionManager.closeConnection(ref connection);
                }
            }

            return departamentos;
        }

        /// <summary>
        /// Obtiene un departamento por su ID
        /// </summary>
        /// <param name="id">ID del departamento</param>
        /// <returns>Departamento encontrado o null si no existe</returns>
        public Departamento getDepartamentoByID(int id)
        {
            Departamento departamento = null;
            SqlConnection connection = null;
            SqlCommand command = null;
            SqlDataReader reader = null;

            try
            {
                connection = _connectionManager.getConnection();
                command = new SqlCommand("SELECT Id, Nombre FROM Departamentos WHERE Id = @Id", connection);
                command.Parameters.AddWithValue("@Id", id);
                reader = command.ExecuteReader();

                if (reader.Read())
                {
                    int departamentoId = reader.GetInt32(0);
                    string nombre = reader.GetString(1);
                    departamento = new Departamento(departamentoId, nombre);
                }
            }
            catch (SqlException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                reader?.Close();
                if (connection != null)
                {
                    _connectionManager.closeConnection(ref connection);
                }
            }

            return departamento;
        }

        /// <summary>
        /// Crea un nuevo departamento en la base de datos
        /// </summary>
        /// <param name="departamento">Departamento a crear</param>
        /// <returns>Número de filas afectadas</returns>
        public int createDepartamento(Departamento departamento)
        {
            int filasAfectadas = 0;
            SqlConnection connection = null;
            SqlCommand command = null;

            try
            {
                connection = _connectionManager.getConnection();
                command = new SqlCommand("INSERT INTO Departamentos (Nombre) VALUES (@Nombre)", connection);
                command.Parameters.AddWithValue("@Nombre", departamento.Nombre);

                filasAfectadas = command.ExecuteNonQuery();
            }
            catch (SqlException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (connection != null)
                {
                    _connectionManager.closeConnection(ref connection);
                }
            }

            return filasAfectadas;
        }

        /// <summary>
        /// Actualiza un departamento existente
        /// </summary>
        /// <param name="id">ID del departamento a actualizar</param>
        /// <param name="departamento">Datos actualizados del departamento</param>
        /// <returns>Número de filas afectadas</returns>
        public int updateDepartamento(int id, Departamento departamento)
        {
            int filasAfectadas = 0;
            SqlConnection connection = null;
            SqlCommand command = null;

            try
            {
                connection = _connectionManager.getConnection();
                command = new SqlCommand("UPDATE Departamentos SET Nombre = @Nombre WHERE Id = @Id", connection);
                command.Parameters.AddWithValue("@Id", id);
                command.Parameters.AddWithValue("@Nombre", departamento.Nombre);

                filasAfectadas = command.ExecuteNonQuery();
            }
            catch (SqlException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (connection != null)
                {
                    _connectionManager.closeConnection(ref connection);
                }
            }

            return filasAfectadas;
        }

        /// <summary>
        /// Elimina un departamento de la base de datos
        /// </summary>
        /// <param name="id">ID del departamento a eliminar</param>
        /// <returns>Número de filas afectadas</returns>
        public int deleteDepartamento(int id)
        {
            int filasAfectadas = 0;
            SqlConnection connection = null;
            SqlCommand command = null;

            try
            {
                connection = _connectionManager.getConnection();
                command = new SqlCommand("DELETE FROM Departamentos WHERE Id = @Id", connection);
                command.Parameters.AddWithValue("@Id", id);

                filasAfectadas = command.ExecuteNonQuery();
            }
            catch (SqlException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (connection != null)
                {
                    _connectionManager.closeConnection(ref connection);
                }
            }

            return filasAfectadas;
        }

        /// <summary>
        /// cuenta el numero de personas que hay en un departamento
        /// </summary>
        /// <param name="idDepartamento"></param>
        /// <returns></returns>
        public int countPersonasInDepartamento(int idDepartamento)
        {
            int count = 0;
            SqlConnection connection = new SqlConnection();
            SqlCommand command = new SqlCommand();
            try
            {
                connection = _connectionManager.getConnection();
                command = new SqlCommand("SELECT COUNT(*) FROM Personas WHERE IdDepartamento = @IdDepartamento", connection);
                command.Parameters.AddWithValue("@IdDepartamento", idDepartamento);
                count = (int)command.ExecuteScalar();
            }
            catch (SqlException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (connection != null)
                {
                    _connectionManager.closeConnection(ref connection);
                }
            }
            return count;
        }
    }
}