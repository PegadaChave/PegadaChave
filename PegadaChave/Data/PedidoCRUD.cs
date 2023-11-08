using MySql.Data.MySqlClient;
using PegadaChave.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Configuration;

namespace PegadaChave.Data
{
    public class PedidoCRUD
    {
        string connectionString = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;

        public void CreatePedido(PedidoDTO pedidoDTO)
        {

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();

                // Inserir novo pedido
                string query = "INSERT INTO Pedido (IdCarrinho, IdCliente, DataHoraPedido, IdEndereco, StatusPedido) VALUES (@idcarrinho, @idcliente, @datahorapedido, @idendereco, @statuspedido)";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@idcarrinho", pedidoDTO.IdCarrinho);
                cmd.Parameters.AddWithValue("@idcliente", pedidoDTO.IdCliente);
                cmd.Parameters.AddWithValue("@datahorapedido", pedidoDTO.DataHoraPedido);
                cmd.Parameters.AddWithValue("@idendereco", pedidoDTO.IdEndereco);
                cmd.Parameters.AddWithValue("@statuspedido", pedidoDTO.StatusPedido.ToString());

                cmd.ExecuteNonQuery();

                // Buscar todos os produtos do carrinho do cliente
                query = "SELECT * FROM CarrinhoProduto WHERE IdCarrinho = @idcarrinho";
                cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@idcarrinho", pedidoDTO.IdCarrinho);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        // Inserir novo item de pedido
                        query = "INSERT INTO ItemPedido (IdPedido, IdProduto, Quantidade, PrecoUnitario) VALUES (@idpedido, @idproduto, @quantidade, @precounitario)";
                        cmd = new MySqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@idpedido", pedidoDTO.IdPedido);
                        cmd.Parameters.AddWithValue("@idproduto", reader.GetInt32("id_produto"));
                        cmd.Parameters.AddWithValue("@quantidade", reader.GetInt32("quantidade_carrinho_produto"));
                        cmd.Parameters.AddWithValue("@precounitario", reader.GetFloat("preco_unidade_carrinho_produto"));

                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }

        public List<PedidoDTO> GetPedidosCliente(int idCliente)
        {
            List<PedidoDTO> pedidos = new List<PedidoDTO>();

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();

                // Buscar todos os pedidos do cliente
                string query = "SELECT * FROM Pedido WHERE IdCliente = @idcliente";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@idcliente", idCliente);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        PedidoDTO pedido = new PedidoDTO();
                        pedido.IdPedido = reader.GetInt32("id_pedido");
                        pedido.IdCarrinho = reader.GetInt32("id_carrinho");
                        pedido.IdCliente = reader.GetInt32("id_cliente");
                        pedido.DataHoraPedido = reader.GetDateTime("data_hora_pedido");
                        pedido.IdEndereco = reader.GetInt32("id_endereco");
                        pedido.StatusPedido = (StatusPedido)Enum.Parse(typeof(StatusPedido), reader.GetString("status_pedido"));

                        // Buscar todos os itens de pedido associados ao pedido
                        query = "SELECT * FROM ItemPedido WHERE IdPedido = @idpedido";
                        cmd = new MySqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@idpedido", pedido.IdPedido);

                        decimal totalPedido = 0;

                        using (MySqlDataReader readerItem = cmd.ExecuteReader())
                        {
                            while (readerItem.Read())
                            {
                                ItemPedidoDTO itemPedido = new ItemPedidoDTO();
                                itemPedido.IdItemPedido = readerItem.GetInt32("id_item_pedido");
                                itemPedido.IdPedido = readerItem.GetInt32("id_pedido");
                                itemPedido.IdProduto = readerItem.GetInt32("id_produto");
                                itemPedido.Quantidade = readerItem.GetInt32("quantidade");
                                itemPedido.PrecoUnitario = readerItem.GetFloat("preco_unitario");

                                // Calcular o total do pedido
                                totalPedido += itemPedido.Quantidade * (decimal)itemPedido.PrecoUnitario;

                                pedido.ItensPedido.Add(itemPedido);
                            }
                        }

                        pedido.TotalPedido = totalPedido;

                        pedidos.Add(pedido);
                    }
                }
            }
            return pedidos;
        }

        public void AlterarStatusPedido(int idPedido, StatusPedido novoStatus)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();

                // Atualizar o status do pedido
                string query = "UPDATE Pedido SET StatusPedido = @statuspedido WHERE IdPedido = @idpedido";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@statuspedido", novoStatus.ToString());
                cmd.Parameters.AddWithValue("@idpedido", idPedido);

                cmd.ExecuteNonQuery();
            }
        }
    }
}