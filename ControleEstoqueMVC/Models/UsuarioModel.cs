﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ControleEstoqueMVC.Models
{
    public class UsuarioModel
    {
        public static bool ValidarUsuario(string login, string senha)
        {
            var ret = false;
            using(var conexao = new SqlConnection())
            {
                conexao.ConnectionString = "Data Source=DESKTOP-LSD8KOT\\SQLEXPRESS;Initial Catalog=controle-estoque;User Id=sa;Password=hiro";
                conexao.Open();
                using (var comando = new SqlCommand())
                {
                    comando.Connection = conexao;
                    comando.CommandText = string.Format("select count(*) from usuario where login='{0}' and senha='{1}'", login, senha);
                    ret=((int)comando.ExecuteScalar() > 0);
                }
            }
            return ret;
        }
    }
}