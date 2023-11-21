using MySql.Data.MySqlClient;
using PegadaChave.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace PegadaChave.Data
{
    public class CarrinhoCRUD
    {
        string connectionString = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;

        public void AdicionarProduto(int idCliente, int idProduto, int quantidade)
        {
            float precoUnidade = 0;

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();

                // Pega o preço unitário a partir da tabela produto
                string queryProduto = "SELECT preco_produto FROM Produto WHERE id_produto = @idproduto";
                MySqlCommand cmdProduto = new MySqlCommand(queryProduto, conn);
                cmdProduto.Parameters.AddWithValue("@idproduto", idProduto);
                precoUnidade = Convert.ToSingle(cmdProduto.ExecuteScalar());

                // Obtenha o id_carrinho a partir do id_cliente
                string queryCarrinho = "SELECT id_carrinho FROM Carrinho WHERE id_cliente = @idcliente";
                MySqlCommand cmdCarrinho = new MySqlCommand(queryCarrinho, conn);
                cmdCarrinho.Parameters.AddWithValue("@idcliente", idCliente);
                int idCarrinho = Convert.ToInt32(cmdCarrinho.ExecuteScalar());

                // Inserir na tabela CarrinhoProduto
                string queryCarrinhoProduto = "INSERT INTO CarrinhoProduto (id_carrinho, id_produto, quantidade_carrinho_produto, preco_unidade_carrinho_produto) VALUES (@idcarrinho, @idproduto, @quantidadecarrinhoproduto, @precoUnidadeCarrinhoProduto)";
                MySqlCommand cmdCarrinhoProduto = new MySqlCommand(queryCarrinhoProduto, conn);
                cmdCarrinhoProduto.Parameters.AddWithValue("@idcarrinho", idCarrinho);
                cmdCarrinhoProduto.Parameters.AddWithValue("@idproduto", idProduto);
                cmdCarrinhoProduto.Parameters.AddWithValue("@quantidadecarrinhoproduto", quantidade);
                cmdCarrinhoProduto.Parameters.AddWithValue("@precoUnidadeCarrinhoProduto", precoUnidade);
                cmdCarrinhoProduto.ExecuteNonQuery();

                AtualizarTotalCarrinho(idCarrinho);
            }
        }

        public void RemoverProduto(int idCarrinho, int idProduto)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();

                // Remover do CarrinhoProduto
                string queryCarrinhoProduto = "DELETE FROM CarrinhoProduto WHERE id_carrinho = @idcarrinho AND id_produto = @idproduto";
                MySqlCommand cmdCarrinhoProduto = new MySqlCommand(queryCarrinhoProduto, conn);
                cmdCarrinhoProduto.Parameters.AddWithValue("@idcarrinho", idCarrinho);
                cmdCarrinhoProduto.Parameters.AddWithValue("@idproduto", idProduto);
                cmdCarrinhoProduto.ExecuteNonQuery();

                AtualizarTotalCarrinho(idCarrinho);
            }
        }

        public void AtualizarTotalCarrinho(int idCarrinho)
        {
            float totalCarrinho = 0;

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();

                // Pega o preço total dos produtos 
                string queryCarrinhoProduto = "SELECT SUM(preco_unidade_carrinho_produto * quantidade_carrinho_produto) AS total FROM CarrinhoProduto WHERE id_carrinho = @idcarrinho";
                MySqlCommand cmdCarrinhoProduto = new MySqlCommand(queryCarrinhoProduto, conn);
                cmdCarrinhoProduto.Parameters.AddWithValue("@idcarrinho", idCarrinho);
                totalCarrinho = Convert.ToSingle(cmdCarrinhoProduto.ExecuteScalar());

                // Atualiza o total_carrinho
                string queryCarrinho = "UPDATE Carrinho SET total_carrinho = @totalcarrinho WHERE id_carrinho = @idcarrinho";
                MySqlCommand cmdCarrinho = new MySqlCommand(queryCarrinho, conn);
                cmdCarrinho.Parameters.AddWithValue("@totalcarrinho", totalCarrinho);
                cmdCarrinho.Parameters.AddWithValue("@idcarrinho", idCarrinho);
                cmdCarrinho.ExecuteNonQuery();
            }
        }

        public CarrinhoDTO ObterCarrinho(int idCliente)
        {
            CarrinhoDTO carrinhoDTO = null;

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();

                // Pega o carrinho
                string queryCarrinho = "SELECT * FROM Carrinho WHERE id_cliente = @idcliente";
                MySqlCommand cmdCarrinho = new MySqlCommand(queryCarrinho, conn);
                cmdCarrinho.Parameters.AddWithValue("@idcliente", idCliente);

                using (MySqlDataReader reader = cmdCarrinho.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        carrinhoDTO = new CarrinhoDTO();
                        carrinhoDTO.IdCarrinho = reader.GetInt32("id_carrinho");
                        carrinhoDTO.IdCliente = reader.GetInt32("id_cliente");
                        carrinhoDTO.TotalCarrinho = reader.GetFloat("total_carrinho");
                    }
                }

                // Gera uma lista de itens
                string queryCarrinhoProduto = "SELECT * FROM CarrinhoProduto WHERE id_carrinho = @idcarrinho";
                MySqlCommand cmdCarrinhoProduto = new MySqlCommand(queryCarrinhoProduto, conn);
                cmdCarrinhoProduto.Parameters.AddWithValue("@idcarrinho", carrinhoDTO.IdCarrinho);

                carrinhoDTO.Produtos = new List<CarrinhoProdutoDTO>();

                using (MySqlDataReader reader = cmdCarrinhoProduto.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        CarrinhoProdutoDTO carrinhoProdutoDTO = new CarrinhoProdutoDTO();
                        carrinhoProdutoDTO.IdProduto = reader.GetInt32("id_produto");
                        carrinhoProdutoDTO.QuantidadeCarrinhoProduto = reader.GetInt32("quantidade_carrinho_produto");
                        carrinhoProdutoDTO.PrecoUnidadeCarrinhoProduto = reader.GetFloat("preco_unidade_carrinho_produto");

                        carrinhoDTO.Produtos.Add(carrinhoProdutoDTO);
                    }
                }
            }

            return carrinhoDTO;
        }

    }
}