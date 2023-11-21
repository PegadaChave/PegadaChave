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
            string query = "SELECT id_usuario FROM Usuario WHERE email_usuario = @email AND senha_usuario = @senha";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@email", email);
            cmd.Parameters.AddWithValue("@senha", senha);
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                reader.Read();
                return reader.GetInt32(0);
            }
            else
            {
                return 0;
            }
        }
    }
    public void LogarUsuario(string email, string senha)
    {
        int idUsuario = ValidarLogin(email, senha);
        if (idUsuario != 0)
        {
            Globals.IdUsuarioLogado = idUsuario;
        }
    }

    public bool UsuarioEstaLogado()
    {
        return Globals.IdUsuarioLogado != 0;
    }
}
