using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace AspNetWebApi.Models
{
    public class SelecaoDal : ISelecaoDal
    {
        /// <summary>
        /// 0. Injeção de dependencia - Variavel local com a conexao direta ao banco por meio de IConfiguration, onde esta nossa string de conexão 
        /// </summary>
        readonly string _connectionString;
        public SelecaoDal(IConfiguration config)
        {
            _connectionString = config.GetConnectionString("DefaultConnection");
        }

        /// <summary>
        /// 1. O primeiro método é o IncluirSelecao que recebe como argumento um objeto Selecao, em seguida informamos a conexão informamos qual procedure vamos utilizar e informa os parâmetros da procedure IncluirSelecao.
        /// </summary>
        /// <param name="selecao"></param>
        /// <returns></returns>
        public int IncluirSelecao(Selecao selecao)
        {
            //Inclusao de uma nova selecao
            try
            {
                using (var con = new SqlConnection(_connectionString))
                {
                    var cmd = new SqlCommand("IncluirSelecao", con)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.AddWithValue("@Selecao", selecao.NomeSelecao);
                    cmd.Parameters.AddWithValue("@Continente", selecao.Continente);
                    cmd.Parameters.AddWithValue("@NumeroParticipacoes", selecao.NumeroParticipacoes);
                    cmd.Parameters.AddWithValue("@MelhorResultado", selecao.MelhorResultado);

                    con.Open();
                    return cmd.ExecuteNonQuery();
                    //con.Close();//não precisa, pois o mesmo sera fechadoao sair do bloco using
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// 2. O segundo método é o AtualizarSelecao, ele é bem parecido com o Incluir.
        /// </summary>
        /// <param name="selecao"></param>
        /// <returns></returns>
        public int AtualizarSelecao(Selecao selecao)
        {
            //Atualizar uma selecao
            try
            {
                using (var con = new SqlConnection(_connectionString))
                {
                    var cmd = new SqlCommand("AtualizarSelecao", con)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.AddWithValue("@Id", selecao.Id);
                    cmd.Parameters.AddWithValue("@Selecao", selecao.NomeSelecao);
                    cmd.Parameters.AddWithValue("@Continente", selecao.Continente);
                    cmd.Parameters.AddWithValue("@NumeroParticipacoes", selecao.NumeroParticipacoes);
                    cmd.Parameters.AddWithValue("@MelhorResultado", selecao.MelhorResultado);

                    con.Open();
                    return cmd.ExecuteNonQuery();
                    //con.Close();//não precisa, pois o mesmo sera fechadoao sair do bloco using
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// 3. Abaixo temos a exclusão das seleções.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int ExcluirSelecao(int id)
        {
            //Excluir selecao por id
            try
            {
                using (var con = new SqlConnection(_connectionString))
                {
                    var cmd = new SqlCommand("ExcluirSelecao", con)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.AddWithValue("@Id", id);

                    con.Open();
                    return cmd.ExecuteNonQuery();
                    //con.Close();//não precisa, pois o mesmo sera fechadoao sair do bloco using
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// 4. O método ObterSelecaoPorId recebe como parâmetro o id da seleção e é o único método que não utilizamos procedure, e para isso realizamos a query diretamente no método, em seguida verificamos se a consulta tem resultados (HasRows), caso positivo preenchemos um objeto Selecao e retornamos.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Selecao ObeterSelecaoPorId(int id)
        {
            //Obter selecao por id
            var selecao = new Selecao();
            try
            {
                using (var con = new SqlConnection(_connectionString))
                {
                    var query = $"SELECT Id, Selecao, Continente, NumeroParticipacoes, MelhorResultado FROM Selecao2018 WHERE Id = {id}";
                    var cmd = new SqlCommand(query, con);

                    con.Open();
                    var reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            selecao.Id = Convert.ToInt32(reader["Id"]);
                            selecao.NomeSelecao = Convert.ToString(reader["Selecao"]);
                            selecao.Continente = Convert.ToString(reader["Continente"]);
                            selecao.NumeroParticipacoes = Convert.ToInt32(reader["NumeroParticipacoes"]);
                            selecao.MelhorResultado = Convert.ToString(reader["MelhorResultado"]);
                        }
                    }
                    else
                    {
                        return null;
                    }
                    return selecao;
                }
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// 5. Por fim o método que retorna todas as seleções.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Selecao> ObterSelecoes()
        {
            //Método que obtem todos as selecoes
            try
            {
                var selecaoList = new List<Selecao>();
                using (var con = new SqlConnection(_connectionString))
                {
                    var cmd = new SqlCommand("ObterTodasAsSelecoes", con)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    con.Open();
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        var aux = new Selecao()
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            NomeSelecao = Convert.ToString(reader["Selecao"]),
                            Continente = Convert.ToString(reader["Continente"]),
                            MelhorResultado = Convert.ToString(reader["MelhorResultado"]),
                            NumeroParticipacoes = Convert.ToInt32(reader["NumeroParticipacoes"])

                        };
                        selecaoList.Add(aux);
                    }
                    con.Close();
                    return selecaoList;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
