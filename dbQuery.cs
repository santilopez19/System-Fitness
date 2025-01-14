﻿using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace System_Fitness
{
    internal class dbQuery
    {
        private static readonly string connectionString = "server=localhost; database=dbSystemFitness; integrated security=true; Encrypt=False;";

        public SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }

        // Método genérico para ejecutar consultas de tipo INSERT, UPDATE o DELETE
        public int ExecuteNonQuery(string query, SqlParameter[] parameters = null, SqlTransaction transaction = null)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection, transaction))
                    {
                        if (parameters != null)
                            command.Parameters.AddRange(parameters);

                        return command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al ejecutar consulta: {ex.Message}");
                return -1;
            }
        }

        public int InsertarCliente(string nombre, string apellido, string dni, DateTime fechaNacimiento, char sexo, string email, string usuarioWeb, string contraseñaWeb)
        {
            string query = "INSERT INTO Clientes (Nombre, Apellido, DNI, FechaNacimiento, Sexo, Email, UsuarioWeb, ContraseñaWeb) " +
                           "VALUES (@Nombre, @Apellido, @DNI, @FechaNacimiento, @Sexo, @Email, @UsuarioWeb, @ContraseñaWeb);" +
                           "SELECT SCOPE_IDENTITY();"; // Obtener el ID del nuevo cliente

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@Nombre", nombre),
                new SqlParameter("@Apellido", apellido),
                new SqlParameter("@DNI", dni),
                new SqlParameter("@FechaNacimiento", fechaNacimiento),
                new SqlParameter("@Sexo", sexo),
                new SqlParameter("@Email", email),
                new SqlParameter("@UsuarioWeb", usuarioWeb),
                new SqlParameter("@ContraseñaWeb", HashPassword(contraseñaWeb))
            };

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddRange(parameters);
                        var result = command.ExecuteScalar(); // Devuelve el ID insertado
                        return result != null ? Convert.ToInt32(result) : -1; // Devuelve el ID o -1 en caso de error
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al insertar cliente: {ex.Message}");
                return -1; // Devuelve -1 si hay un error
            }
        }

        public DataTable GetClases()
        {
            string query = "SELECT ClaseID, NombreClase, Dia, HoraInicio, HoraFin, CupoMaximo, FechaClase FROM Clases";
            return GetDataTable(query); // Ahora utiliza correctamente GetDataTable con un solo argumento
        }

        public int InsertarPago(int clienteId, DateTime fechaPago, decimal monto, string metodoPago, string dni)
        {
            string query = "INSERT INTO Pagos (ClienteID, FechaPago, Monto, MetodoPago, DNI) " +
                           "VALUES (@ClienteID, @FechaPago, @Monto, @MetodoPago, @DNI);";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@ClienteID", clienteId),
                new SqlParameter("@FechaPago", fechaPago),
                new SqlParameter("@Monto", monto),
                new SqlParameter("@MetodoPago", metodoPago),
                new SqlParameter("@DNI", dni)
            };

            return ExecuteNonQuery(query, parameters);
        }

        // Método para encriptar contraseñas
        private string HashPassword(string password)
        {
            using (var sha256 = System.Security.Cryptography.SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return BitConverter.ToString(bytes).Replace("-", "").ToLower();
            }
        }

        public object ExecuteScalar(string query, SqlParameter[] parameters = null)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        if (parameters != null)
                        {
                            command.Parameters.AddRange(parameters);
                        }

                        return command.ExecuteScalar();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error en ExecuteScalar: {ex.Message}");
                    return null;
                }
            }
        }
        public DataTable ExecuteQuery(string query, SqlParameter[] parameters = null)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                if (parameters != null)
                    command.Parameters.AddRange(parameters);

                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    return dt;
                }
            }
        }

        public DataTable GetDataTable(string query, SqlParameter[] parameters = null)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        if (parameters != null)
                            command.Parameters.AddRange(parameters);

                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            DataTable table = new DataTable();
                            adapter.Fill(table);
                            return table;
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error al obtener datos: {ex.Message}");
                    return null;
                }
            }
        }
    }
}
