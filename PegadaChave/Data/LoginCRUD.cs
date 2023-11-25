using System;
using System.Configuration;
using System.Data;
using MySql.Data.MySqlClient;
using PegadaChave.Models;

public class LoginCRUD
{
    private string connectionString = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;

    public int ValidarLogin(string email, string senha)
    {
        using (MySqlConnection conn = new MySqlConnection(connectionString))
        {
            string query = "SELECT id_usuario, tipo_usuario FROM Usuario WHERE email_usuario = @email AND senha_usuario = @senha";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@email", email);
            cmd.Parameters.AddWithValue("@senha", senha);
            conn.Open();
            MySqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                reader.Read();
                string tipoUsuario = reader.GetString(1);
                int idUsuario = reader.GetInt32(0);
                reader.Close();

                if (tipoUsuario == "Cliente")
                {
                    string queryCliente = "SELECT id_cliente FROM Cliente WHERE id_usuario = @idusuario";
                    MySqlCommand cmdCliente = new MySqlCommand(queryCliente, conn);
                    cmdCliente.Parameters.AddWithValue("@idusuario", idUsuario);
                    int idCliente = Convert.ToInt32(cmdCliente.ExecuteScalar());

                    Globals.IdClienteLogado = idCliente;
                    return idCliente;
                }
                else if (tipoUsuario == "Funcionario")
                {
                    string queryFuncionario = "SELECT id_funcionario FROM Funcionario WHERE id_usuario = @idusuario";
                    MySqlCommand cmdFuncionario = new MySqlCommand(queryFuncionario, conn);
                    cmdFuncionario.Parameters.AddWithValue("@idusuario", idUsuario);
                    int idFuncionario = Convert.ToInt32(cmdFuncionario.ExecuteScalar());

                    Globals.IdFuncionarioLogado = idFuncionario;
                    return idFuncionario;
                }
                else
                {
                    return 0;
                }
            }
            else
            {
                return 0;
            }
        }
    }

    public void DeslogarUsuario()
    {
        Globals.IdClienteLogado = 0;
        Globals.IdFuncionarioLogado = 0;
    }
}

