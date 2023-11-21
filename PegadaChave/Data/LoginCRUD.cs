using System;
using System.Data;
using System.Data.SqlClient;
using PegadaChave.Models;

public class LoginCRUD
{
    private string connectionString = "sua string de conexão";

    public int ValidarLogin(string email, string senha)
    {
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            string query = "SELECT id_usuario, tipo_usuario FROM Usuario WHERE email_usuario = @email AND senha_usuario = @senha";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@email", email);
            cmd.Parameters.AddWithValue("@senha", senha);
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                reader.Read();
                string tipoUsuario = reader.GetString(1);
                int idUsuario = reader.GetInt32(0);

                if (tipoUsuario == "Cliente")
                {
                    string queryCliente = "SELECT id_cliente FROM Cliente WHERE id_usuario = @idusuario";
                    SqlCommand cmdCliente = new SqlCommand(queryCliente, conn);
                    cmdCliente.Parameters.AddWithValue("@idusuario", idUsuario);
                    int idCliente = Convert.ToInt32(cmdCliente.ExecuteScalar());

                    Globals.IdClienteLogado = idCliente;
                    return idCliente;
                }
                else if (tipoUsuario == "Funcionario")
                {
                    string queryFuncionario = "SELECT id_funcionario FROM Funcionario WHERE id_usuario = @idusuario";
                    SqlCommand cmdFuncionario = new SqlCommand(queryFuncionario, conn);
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
