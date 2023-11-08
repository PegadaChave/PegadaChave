using MySql.Data.MySqlClient;
using PegadaChave.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Configuration;

namespace PegadaChave.Data
{
    public class ClienteCRUD
    {
        string connectionString = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;

        public void Create(ClienteDTO clienteDTO)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();

                // Inserir na tabela Usuario
                string queryUsuario = "INSERT INTO Usuario (nome_usuario, email_usuario, senha_usuario, data_cadastro, tipo_usuario) VALUES (@nomeusuario, @emailusuario, @senhausuario, @datacadastro, 'Cliente')";
                MySqlCommand cmdUsuario = new MySqlCommand(queryUsuario, conn);
                cmdUsuario.Parameters.AddWithValue("@nomeusuario", clienteDTO.nomeUsuario);
                cmdUsuario.Parameters.AddWithValue("@emailusuario", clienteDTO.emailUsuario);
                cmdUsuario.Parameters.AddWithValue("@senhausuario", clienteDTO.senhaUsuario);
                cmdUsuario.Parameters.AddWithValue("@datacadastro", DateTime.Now);
                cmdUsuario.ExecuteNonQuery();

                // Lembra o id_usuario gerado
                string queryGetIdUsuario = "SELECT LAST_INSERT_ID()";
                MySqlCommand cmdGetIdUsuario = new MySqlCommand(queryGetIdUsuario, conn);
                int idUsuario = Convert.ToInt32(cmdGetIdUsuario.ExecuteScalar());

                // Inserir na tabela Cliente
                string queryCliente = "INSERT INTO Cliente (id_usuario, cpf_cliente, data_nascimento_cliente, sexo_cliente, celular_cliente) VALUES (@idusuario, @cpfcliente, @datanascimentocliente, @sexocliente, @celularcliente)";
                MySqlCommand cmdCliente = new MySqlCommand(queryCliente, conn);
                cmdCliente.Parameters.AddWithValue("@idusuario", idUsuario);
                cmdCliente.Parameters.AddWithValue("@cpfcliente", clienteDTO.cpfCliente);
                cmdCliente.Parameters.AddWithValue("@datanascimentocliente", clienteDTO.dataNascimentoCliente);
                cmdCliente.Parameters.AddWithValue("@sexocliente", clienteDTO.sexoCliente.ToString());
                cmdCliente.Parameters.AddWithValue("@celularcliente", clienteDTO.celularCliente);
                cmdCliente.ExecuteNonQuery();

                // Criar o carrinho junto do cliente
                string queryCarrinho = "INSERT INTO Carrinho (id_cliente, total_carrinho) VALUES (@idcliente, 0)";
                MySqlCommand cmdCarrinho = new MySqlCommand(queryCarrinho, conn);
                cmdCarrinho.Parameters.AddWithValue("@idcliente", idUsuario);
                cmdCarrinho.ExecuteNonQuery();
            }
        }

        public List<ClienteDTO> Read()
        {
            List<ClienteDTO> clientes = new List<ClienteDTO>();

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();

                string query = "SELECT * FROM Cliente";
                MySqlCommand cmd = new MySqlCommand(query, conn);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        ClienteDTO cliente = new ClienteDTO();
                        cliente.idCliente = reader.GetInt32("id_cliente");
                        cliente.idUsuario = reader.GetInt32("id_usuario");
                        cliente.cpfCliente = reader.GetString("cpf_cliente");
                        cliente.dataNascimentoCliente = reader.GetDateTime("data_nascimento_cliente");
                        cliente.sexoCliente = (PegadaChave.Models.DTOs.Sexocliente)Enum.Parse(typeof(PegadaChave.Models.DTOs.Sexocliente), reader.GetString("sexo_cliente"));
                        cliente.celularCliente = reader.GetString("celular_cliente");
                        clientes.Add(cliente);
                    }
                }
            }

            return clientes;
        }

        public void Update(ClienteDTO clienteDTO)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();

                string query = "UPDATE Cliente SET nome_usuario = @nomeusuario, email_usuario = @emailusuario, senha_usuario = @senhausuario WHERE id_cliente = @idcliente";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@nomeusuario", clienteDTO.nomeUsuario);
                cmd.Parameters.AddWithValue("@emailusuario", clienteDTO.emailUsuario);
                cmd.Parameters.AddWithValue("@senhausuario", clienteDTO.senhaUsuario);
                cmd.Parameters.AddWithValue("@idcliente", clienteDTO.idCliente);

                cmd.ExecuteNonQuery();
            }
        }

        public void Delete(int idCliente)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();

                string query = "DELETE FROM Cliente WHERE id_cliente = @idcliente";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@idcliente", idCliente);

                cmd.ExecuteNonQuery();
            }
        }

        public ClienteDTO ClientePorId(int idCliente)
        {
            ClienteDTO cliente = null;

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();

                string query = @"SELECT Cliente.*, Usuario.* 
                         FROM Cliente 
                         INNER JOIN Usuario ON Cliente.id_usuario = Usuario.id_usuario 
                         WHERE Cliente.id_cliente = @idcliente";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@idcliente", idCliente);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        cliente = new ClienteDTO();
                        cliente.idCliente = reader.GetInt32("id_cliente");
                        cliente.idUsuario = reader.GetInt32("id_usuario");
                        cliente.cpfCliente = reader.GetString("cpf_cliente");
                        cliente.dataNascimentoCliente = reader.GetDateTime("data_nascimento_cliente");
                        cliente.sexoCliente = (PegadaChave.Models.DTOs.Sexocliente)Enum.Parse(typeof(PegadaChave.Models.DTOs.Sexocliente), reader.GetString("sexo_cliente"));
                        cliente.celularCliente = reader.GetString("celular_cliente");
                        cliente.nomeUsuario = reader.GetString("nome_usuario");
                        cliente.emailUsuario = reader.GetString("email_usuario");
                        cliente.senhaUsuario = reader.GetString("senha_usuario");
                    }
                }
            }

            return cliente;
        }
    }
}
