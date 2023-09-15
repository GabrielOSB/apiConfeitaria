using apiConfeitaria.Models.Produtos;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Data;

namespace apiConfeitaria
{
    public class SqlHelper
    {
        private const string connectionString = "server=localhost;uid=root;pwd=@Shalom5883;database=dbapiestacao;";
        public static List<ProdutosAll> GetProductAll()

        {
            var model = new List<ProdutosAll>();  

            using (var sqlCnn = new MySqlConnection(connectionString))
            {
                sqlCnn.Open();

                using (var sqlCmd = new MySqlCommand("select * from produto ORDER BY id DESC", sqlCnn))
                {
                    using (var sqlReader = sqlCmd.ExecuteReader())
                        while (sqlReader.Read())
                        {
                            model.Add(new ProdutosAll()
                            {
                                Descricao = sqlReader["descricao"].ToString(),
                                Id = (int)sqlReader["id"],
                                Preco = (decimal)sqlReader["preco"],
                                Nome = sqlReader["nome"].ToString()
                            });
                        }
                }
            }

            return model;
        }

        public static void InsertProduto(ProdutosAll Model)

        {
            using (var sqlCnn = new MySqlConnection(connectionString))
            {
                sqlCnn.Open();

                using (var sqlCmd = new MySqlCommand("insert into produto (nome, descricao, preco) values(@nome, @descricao, @preco)", sqlCnn))
                {
                    sqlCmd.Parameters.AddWithValue("@nome", Model.Nome);
                    sqlCmd.Parameters.AddWithValue("@descricao", Model.Descricao);
                    sqlCmd.Parameters.AddWithValue("@preco", Model.Preco);

                    sqlCmd.ExecuteNonQuery();
                }
            }
        }
    }
}
