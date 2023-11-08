using MySql.Data.MySqlClient;
using PegadaChave.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Configuration;

namespace PegadaChave.Data
{
    public class FuncionarioCRUD
    {
        string connectionString = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;

        public void Create(FuncionarioDTO funcionarioDTO)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();

                // Inserir na tabela Usuario
                string queryUsuario = "INSERT INTO Usuario (nome_usuario, email_usuario, senha_usuario, data_cadastro, tipo_usuario) VALUES (@nomeusuario, @emailusuario, @senhausuario, @datacadastro, 'Funcionario')";
                MySqlCommand cmdUsuario = new MySqlCommand(queryUsuario, conn);
                cmdUsuario.Parameters.AddWithValue("@nomeusuario", funcionarioDTO.NomeUsuario);
                cmdUsuario.Parameters.AddWithValue("@emailusuario", funcionarioDTO.EmailUsuario);
                cmdUsuario.Parameters.AddWithValue("@senhausuario", funcionarioDTO.SenhaUsuario);
                cmdUsuario.Parameters.AddWithValue("@datacadastro", DateTime.Now);
                cmdUsuario.ExecuteNonQuery();

                // Lembra o id_usuario gerado
                string queryGetIdUsuario = "SELECT LAST_INSERT_ID()";
                MySqlCommand cmdGetIdUsuario = new MySqlCommand(queryGetIdUsuario, conn);
                int idUsuario = Convert.ToInt32(cmdGetIdUsuario.ExecuteScalar());

                // Inserir na tabela Funcionario
                string queryFuncionario = "INSERT INTO Funcionario (id_usuario) VALUES (@idusuario)";
                MySqlCommand cmdFuncionario = new MySqlCommand(queryFuncionario, conn);
                cmdFuncionario.Parameters.AddWithValue("@idusuario", idUsuario);
                cmdFuncionario.ExecuteNonQuery();
            }
        }

        public List<FuncionarioDTO> Read()
        {
            List<FuncionarioDTO> funcionarios = new List<FuncionarioDTO>();

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();

                string query = "SELECT * FROM Funcionario";
                MySqlCommand cmd = new MySqlCommand(query, conn);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        FuncionarioDTO funcionario = new FuncionarioDTO();
                        funcionario.IdFuncionario = reader.GetInt32("id_funcionario");
                        funcionario.IdUsuario = reader.GetInt32("id_usuario");
                        funcionario.NomeUsuario = reader.GetString("nome_usuario");
                        funcionario.EmailUsuario = reader.GetString("email_usuario");
                        funcionario.DataCadastro = reader.GetDateTime("data_cadastro");
                        funcionarios.Add(funcionario);
                    }
                }
            }

            return funcionarios;
        }

        public void Update(FuncionarioDTO funcionarioDTO)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();

                string query = "UPDATE Funcionario SET nome_usuario = @nomeusuario, email_usuario = @emailusuario, senha_usuario = @senhausuario WHERE id_funcionario = @idfuncionario";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@nomeusuario", funcionarioDTO.NomeUsuario);
                cmd.Parameters.AddWithValue("@emailusuario", funcionarioDTO.EmailUsuario);
                cmd.Parameters.AddWithValue("@senhausuario", funcionarioDTO.SenhaUsuario);
                cmd.Parameters.AddWithValue("@idfuncionario", funcionarioDTO.IdFuncionario);

                cmd.ExecuteNonQuery();
            }
        }

        public void Delete(int idFuncionario)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();

                string query = "DELETE FROM Funcionario WHERE id_funcionario = @idfuncionario";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@idfuncionario", idFuncionario);

                cmd.ExecuteNonQuery();
            }
        }

        public FuncionarioDTO FuncionarioPorId(int idFuncionario)
        {
            FuncionarioDTO funcionario = null;

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();

                string query = @"SELECT Funcionario.*, Usuario.* 
                         FROM Funcionario 
                         INNER JOIN Usuario ON Funcionario.id_usuario = Usuario.id_usuario 
                         WHERE Funcionario.id_funcionario = @idfuncionario";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@idfuncionario", idFuncionario);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        funcionario = new FuncionarioDTO();
                        funcionario.IdFuncionario = reader.GetInt32("id_funcionario");
                        funcionario.IdUsuario = reader.GetInt32("id_usuario");
                        funcionario.NomeUsuario = reader.GetString("nome_usuario");
                        funcionario.EmailUsuario = reader.GetString("email_usuario");
                        funcionario.SenhaUsuario = reader.GetString("senha_usuario");
                        funcionario.DataCadastro = reader.GetDateTime("data_cadastro");
                    }
                }
            }

            return funcionario;
        }   
    }
}