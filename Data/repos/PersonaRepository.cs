using _07_CRUD_Personas_DAL.Conexion;
using Domain.Entities;
using Domain.interfaces.repos;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.repos
{
    public class PersonaRepository : IPersonaRepository
    {
        private readonly clsMyConnection _connectionManager;

        // Constructor con inyección de dependencias
        public PersonaRepository(clsMyConnection connectionManager)
        {
            _connectionManager = connectionManager;
        }

        // Constructor sin parámetros (por compatibilidad)
        public PersonaRepository()
        {
            _connectionManager = new clsMyConnection();
        }
        
        public List<Persona> getAllPersonas()
        {
            List<Persona> personas = new List<Persona>();
            SqlConnection connection = null;
            SqlCommand command = null;
            SqlDataReader reader = null;

            try
            {
                connection = _connectionManager.getConnection();
                command = new SqlCommand("Select * From Personas", connection);
                reader = command.ExecuteReader();

                while (reader.Read())
                {
                    int id = reader.GetInt32(0);
                    string nombre = reader.GetString(1);
                    string apellidos = reader.GetString(2);
                    string telefono = reader.GetString(3);
                    string direccion = reader.GetString(4);
                    string foto = reader.IsDBNull(5) ? null : reader.GetString(5);
                    DateTime fechaNacimiento = reader.GetDateTime(6);
                    int idDepartamento = reader.GetInt32(7);
                    personas.Add(new Persona(id, nombre, apellidos, fechaNacimiento, direccion, telefono, idDepartamento, foto));
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
            return personas;
        }

        /// <summary>
        /// Obtiene una Persona por su ID
        /// </summary>
        /// <param name="id">ID de la Persona</param>
        /// <returns>Persona encontrada o null si no existe</returns>

        public Persona getPersonaByID(int id)
        {
            Persona persona = null;
            SqlConnection connection = null;
            SqlCommand command = null;
            SqlDataReader reader = null;

            try
            {
                connection = _connectionManager.getConnection();
                command = new SqlCommand("Select * From Personas Where ID = @id", connection);
                command.Parameters.AddWithValue("@id", id);
                reader = command.ExecuteReader();
                if (reader.Read())
                {
                    
                    string nombre = reader.GetString(1);
                    string apellidos = reader.GetString(2);
                    string telefono = reader.GetString(3);
                    string direccion = reader.GetString(4);
                    string foto = reader.IsDBNull(5) ? null : reader.GetString(5);
                    DateTime fechaNacimiento = reader.GetDateTime(6);
                    int idDepartamento = reader.GetInt32(7);
                    persona = new Persona(id, nombre, apellidos, fechaNacimiento, direccion, telefono, idDepartamento, foto);
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
            return persona;
        }


        /// <summary>
        ///  Crea una nueva persona en la base de datos
        ///  </summary>
        ///  <param name="persona">Objeto Persona a crear</param>
        ///  <returns>Número de filas afectadas</returns>
        public int createPersona(Persona persona)
        {
            SqlCommand command = null;
            SqlConnection connection = null;
            int filasAfectadas = 0;

            try
            {
                connection = _connectionManager.getConnection();
                command = new SqlCommand(
                    "INSERT INTO Personas (Nombre, Apellidos, Telefono, Direccion, Foto, FechaNacimiento, IDDepartamento) " +
                    "VALUES (@Nombre, @Apellidos, @Telefono, @Direccion, @Foto, @FechaNacimiento, @IDDepartamento)", connection);
                command.Parameters.AddWithValue("@Nombre", persona.Nombre);
                command.Parameters.AddWithValue("@Apellidos", persona.Apellidos);
                command.Parameters.AddWithValue("@FechaNacimiento", persona.FechaNacimiento);
                command.Parameters.AddWithValue("@Direccion", persona.Direccion);
                command.Parameters.AddWithValue("@Telefono", persona.Telefono);
                command.Parameters.AddWithValue("@IDDepartamento", persona.IdDepartamento);
                command.Parameters.AddWithValue("@Foto", (object)persona.foto ?? DBNull.Value);
                filasAfectadas = command.ExecuteNonQuery();

            }
            catch(SqlException)
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
        /// Este metodo actualiza una persona en la base de datos
        /// </summary>
        /// <param name="id"> Id de la persona que se quiere actualizar</param>
        /// <param name="persona"> La persona nueva</param>
        /// <returns></returns>
        public int updatePersona(int id, Persona persona)
        {
            int filasAfectadas = 0;
            SqlConnection connection = null;
            SqlCommand command = null;

            try
            {
                connection = _connectionManager.getConnection();
                command = new SqlCommand("Update Personas Set Nombre = @Nombre, Apellidos = @Apellidos, Telefono = @Telefono, Direccion = @Direccion, Foto= @Foto, FechaNacimiento = @FechaNacimiento, IDDepartamento = @IDDepartamento " +
                    "Where ID = @id", connection);
                command.Parameters.AddWithValue("@Nombre", persona.Nombre);
                command.Parameters.AddWithValue("@Apellidos", persona.Apellidos);
                command.Parameters.AddWithValue("@FechaNacimiento", persona.FechaNacimiento);
                command.Parameters.AddWithValue("@Direccion", persona.Direccion);
                command.Parameters.AddWithValue("@Telefono", persona.Telefono);
                command.Parameters.AddWithValue("@IDDepartamento", persona.IdDepartamento);
                command.Parameters.AddWithValue("@id", id);
                command.Parameters.AddWithValue("@Foto", (object)persona.foto ?? DBNull.Value);
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
        /// Borra una persona por su ID
        /// </summary>
        /// <param name="id"> Id de la persona</param>
        /// <returns>0 numero de filas afectadas </returns>

        public int deletePersona(int id)
        {
            int filasAfectadas = 0;
            SqlConnection connection = null;
            SqlCommand command = null;

            try
            {
                connection = _connectionManager.getConnection();
                command = new SqlCommand("DELETE FROM Personas WHERE ID = @id", connection);
                command.Parameters.AddWithValue("@id", id);

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

    }
}
