using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SQLite;
using System.Windows.Forms;

namespace GeradorAreaInventario
{
    class metodos
    {
        // Método para cadastrar uma área na tabela Areas
        public static bool CadastrarArea(string codigo, string nome, string connString)
        {
            try
            {
                using (SQLiteConnection conn = new SQLiteConnection(connString))
                {
                    conn.Open();
                    string sql = "INSERT INTO area (codigo_area, desc_area) VALUES (@codigo, @nome_area);";
                    using (SQLiteCommand cmd = new SQLiteCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@nome_area", nome);
                        cmd.Parameters.AddWithValue("@codigo", codigo);
                        int rowsAffected = cmd.ExecuteNonQuery();
                        return rowsAffected > 0;
                        
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error :");
                return false;
            }
        }

        
        

    }
}
