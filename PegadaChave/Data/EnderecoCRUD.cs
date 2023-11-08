using MySql.Data.MySqlClient;
using PegadaChave.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace PegadaChave.Data
{
    public class EnderecoCRUD
    {
        string connectionString = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;

        public void Create(EnderecoDTO enderecoDTO)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();

                string query = "INSERT INTO Endereco (IdCliente, CepEndereco, LogradouroEndereco, NumeroEndereco, BairroEndereco, CidadeEndereco, UfEndereco) VALUES (@idcliente, @cependereco, @logradouroendereco, @numeroendereco, @bairoendereco, @cidadeendereco, @ufendereco)";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@idcliente", enderecoDTO.IdCliente);
                cmd.Parameters.AddWithValue("@cependereco", enderecoDTO.CepEndereco);
                cmd.Parameters.AddWithValue("@logradouroendereco", enderecoDTO.LogradouroEndereco);
                cmd.Parameters.AddWithValue("@numeroendereco", enderecoDTO.NumeroEndereco);
                cmd.Parameters.AddWithValue("@bairoendereco", enderecoDTO.BairroEndereco);
                cmd.Parameters.AddWithValue("@cidadeendereco", enderecoDTO.CidadeEndereco);
                cmd.Parameters.AddWithValue("@ufendereco", enderecoDTO.UfEndereco.ToString());

                cmd.ExecuteNonQuery();
            }
        }

        public List<EnderecoDTO> Read()
        {
            List<EnderecoDTO> enderecos = new List<EnderecoDTO>();

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();

                string query = "SELECT * FROM Endereco";
                MySqlCommand cmd = new MySqlCommand(query, conn);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        EnderecoDTO endereco = new EnderecoDTO();
                        endereco.IdEndereco = reader.GetInt32("id_endereco");
                        endereco.IdCliente = reader.GetInt32("id_cliente");
                        endereco.CepEndereco = reader.GetString("cep_endereco");
                        endereco.LogradouroEndereco = reader.GetString("logradouro_endereco");
                        endereco.NumeroEndereco = reader.GetInt32("numero_endereco");
                        endereco.BairroEndereco = reader.GetString("bairro_endereco");
                        endereco.CidadeEndereco = reader.GetString("cidade_endereco");
                        endereco.UfEndereco = (UfEndereco)Enum.Parse(typeof(UfEndereco), reader.GetString("uf_endereco"));
                        enderecos.Add(endereco);
                    }
                }
            }

            return enderecos;
        }

        public void Update(EnderecoDTO enderecoDTO)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();

                string query = "UPDATE Endereco SET IdCliente = @idcliente, CepEndereco = @cependereco, LogradouroEndereco = @logradouroendereco, NumeroEndereco = @numeroendereco, BairroEndereco = @bairoendereco, CidadeEndereco = @cidadeendereco, UfEndereco = @ufendereco WHERE IdEndereco = @idendereco";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@idcliente", enderecoDTO.IdCliente);
                cmd.Parameters.AddWithValue("@cependereco", enderecoDTO.CepEndereco);
                cmd.Parameters.AddWithValue("@logradouroendereco", enderecoDTO.LogradouroEndereco);
                cmd.Parameters.AddWithValue("@numeroendereco", enderecoDTO.NumeroEndereco);
                cmd.Parameters.AddWithValue("@bairoendereco", enderecoDTO.BairroEndereco);
                cmd.Parameters.AddWithValue("@cidadeendereco", enderecoDTO.CidadeEndereco);
                cmd.Parameters.AddWithValue("@ufendereco", enderecoDTO.UfEndereco.ToString());
                cmd.Parameters.AddWithValue("@idendereco", enderecoDTO.IdEndereco);

                cmd.ExecuteNonQuery();
            }
        }

        public void Delete(int idEndereco)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();

                string query = "DELETE FROM Endereco WHERE IdEndereco = @idendereco";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@idendereco", idEndereco);

                cmd.ExecuteNonQuery();
            }
        }

        public List<EnderecoDTO> EnderecosPorCliente(int idCliente)
        {
            List<EnderecoDTO> enderecos = new List<EnderecoDTO>();

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();

                string query = "SELECT * FROM Endereco WHERE IdCliente = @idcliente";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@idcliente", idCliente);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        EnderecoDTO endereco = new EnderecoDTO();
                        endereco.IdEndereco = reader.GetInt32("id_endereco");
                        endereco.IdCliente = reader.GetInt32("id_cliente");
                        endereco.CepEndereco = reader.GetString("cep_endereco");
                        endereco.LogradouroEndereco = reader.GetString("logradouro_endereco");
                        endereco.NumeroEndereco = reader.GetInt32("numero_endereco");
                        endereco.BairroEndereco = reader.GetString("bairro_endereco");
                        endereco.CidadeEndereco = reader.GetString("cidade_endereco");
                        endereco.UfEndereco = (UfEndereco)Enum.Parse(typeof(UfEndereco), reader.GetString("uf_endereco"));
                        enderecos.Add(endereco);
                    }
                }
            }

            return enderecos;
        }
    }
}