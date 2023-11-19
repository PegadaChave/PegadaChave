using MySql.Data.MySqlClient;
using PegadaChave.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;

namespace PegadaChave.Data
{
    public class ProdutoCRUD
    {
        string connectionString = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;

        public void Create(ProdutoDTO produtoDTO)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();

                // Inserir na tabela Produto
                string queryProduto = "INSERT INTO Produto (nome_produto, descricao_produto, categoria_produto, tamanho_produto, condicao_produto, preco_produto, imagem_produto, estoque_produto, genero_produto) VALUES (@nomeproduto, @descricaoproduto, @categoriaproduto, @tamanhoproduto, @condicaoproduto, @precoproduto, @imagemproduto, @estoqueproduto, @generoproduto)";
                MySqlCommand cmdProduto = new MySqlCommand(queryProduto, conn);
                cmdProduto.Parameters.AddWithValue("@nomeproduto", produtoDTO.NomeProduto);
                cmdProduto.Parameters.AddWithValue("@descricaoproduto", produtoDTO.DescricaoProduto);
                cmdProduto.Parameters.AddWithValue("@categoriaproduto", produtoDTO.CategoriaProduto.ToString());
                cmdProduto.Parameters.AddWithValue("@tamanhoproduto", produtoDTO.TamanhoProduto.ToString());
                cmdProduto.Parameters.AddWithValue("@condicaoproduto", produtoDTO.CondicaoProduto.ToString());
                cmdProduto.Parameters.AddWithValue("@precoproduto", produtoDTO.PrecoProduto);
                cmdProduto.Parameters.AddWithValue("@imagemproduto", produtoDTO.ImagemProduto);
                cmdProduto.Parameters.AddWithValue("@estoqueproduto", produtoDTO.EstoqueProduto);
                cmdProduto.Parameters.AddWithValue("@generoproduto", produtoDTO.GeneroProduto.ToString());
                cmdProduto.ExecuteNonQuery();
            }
        }

        public List<ProdutoDTO> Read()
        {
            List<ProdutoDTO> produtos = new List<ProdutoDTO>();

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();

                string query = "SELECT * FROM Produto";
                MySqlCommand cmd = new MySqlCommand(query, conn);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        ProdutoDTO produto = new ProdutoDTO();
                        produto.IdProduto = reader.GetInt32("id_produto");
                        produto.NomeProduto = reader.GetString("nome_produto");
                        produto.DescricaoProduto = reader.GetString("descricao_produto");
                        produto.CategoriaProduto = (PegadaChave.Models.DTOs.CategoriaProduto)Enum.Parse(typeof(PegadaChave.Models.DTOs.CategoriaProduto), reader.GetString("categoria_produto"));
                        produto.TamanhoProduto = (PegadaChave.Models.DTOs.TamanhoProduto)Enum.Parse(typeof(PegadaChave.Models.DTOs.TamanhoProduto), reader.GetString("tamanho_produto"));
                        produto.CondicaoProduto = (PegadaChave.Models.DTOs.CondicaoProduto)Enum.Parse(typeof(PegadaChave.Models.DTOs.CondicaoProduto), reader.GetString("condicao_produto"));
                        produto.PrecoProduto = reader.GetFloat("preco_produto");
                        produto.ImagemProduto = reader.GetString("imagem_produto");
                        produto.EstoqueProduto = reader.GetInt32("estoque_produto");
                        produto.GeneroProduto = (PegadaChave.Models.DTOs.GeneroProduto)Enum.Parse(typeof(PegadaChave.Models.DTOs.GeneroProduto), reader.GetString("genero_produto"));
                        produtos.Add(produto);
                    }
                }
            }

            return produtos;
        }

        public void Update(ProdutoDTO produtoDTO)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();

                string query = "UPDATE Produto SET nome_produto = @nomeproduto, descricao_produto = @descricaoproduto, categoria_produto = @categoriaproduto, tamanho_produto = @tamanhoproduto, condicao_produto = @condicaoproduto, preco_produto = @precoproduto, imagem_produto = @imagemproduto, estoque_produto = @estoqueproduto, genero_produto = @generoproduto WHERE id_produto = @idproduto";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@nomeproduto", produtoDTO.NomeProduto);
                cmd.Parameters.AddWithValue("@descricaoproduto", produtoDTO.DescricaoProduto);
                cmd.Parameters.AddWithValue("@categoriaproduto", produtoDTO.CategoriaProduto.ToString());
                cmd.Parameters.AddWithValue("@tamanhoproduto", produtoDTO.TamanhoProduto.ToString());
                cmd.Parameters.AddWithValue("@condicaoproduto", produtoDTO.CondicaoProduto.ToString());
                cmd.Parameters.AddWithValue("@precoproduto", produtoDTO.PrecoProduto);
                cmd.Parameters.AddWithValue("@imagemproduto", produtoDTO.ImagemProduto);
                cmd.Parameters.AddWithValue("@estoqueproduto", produtoDTO.EstoqueProduto);
                cmd.Parameters.AddWithValue("@idproduto", produtoDTO.IdProduto);
                cmd.Parameters.AddWithValue("@generoproduto", produtoDTO.GeneroProduto.ToString());

                cmd.ExecuteNonQuery();
            }
        }

        public void Delete(int idProduto)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();

                string query = "DELETE FROM Produto WHERE id_produto = @idproduto";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@idproduto", idProduto);

                cmd.ExecuteNonQuery();
            }
        }

        public ProdutoDTO ProdutoPorId(int idProduto)
        {
            ProdutoDTO produto = null;

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();

                string query = "SELECT * FROM Produto WHERE id_produto = @idproduto";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@idproduto", idProduto);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        produto = new ProdutoDTO();
                        produto.IdProduto = reader.GetInt32("id_produto");
                        produto.NomeProduto = reader.GetString("nome_produto");
                        produto.DescricaoProduto = reader.GetString("descricao_produto");
                        produto.CategoriaProduto = (PegadaChave.Models.DTOs.CategoriaProduto)Enum.Parse(typeof(PegadaChave.Models.DTOs.CategoriaProduto), reader.GetString("categoria_produto"));
                        produto.TamanhoProduto = (PegadaChave.Models.DTOs.TamanhoProduto)Enum.Parse(typeof(PegadaChave.Models.DTOs.TamanhoProduto), reader.GetString("tamanho_produto"));
                        produto.CondicaoProduto = (PegadaChave.Models.DTOs.CondicaoProduto)Enum.Parse(typeof(PegadaChave.Models.DTOs.CondicaoProduto), reader.GetString("condicao_produto"));
                        produto.PrecoProduto = reader.GetFloat("preco_produto");
                        produto.ImagemProduto = reader.GetString("imagem_produto");
                        produto.EstoqueProduto = reader.GetInt32("estoque_produto");
                        produto.GeneroProduto = (PegadaChave.Models.DTOs.GeneroProduto)Enum.Parse(typeof(PegadaChave.Models.DTOs.GeneroProduto), reader.GetString("genero_produto"));
                    }
                }
            }
            return produto;
        }
    }
}