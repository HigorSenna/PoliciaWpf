using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Policia.Model.Model
{
    public class Desaparecido
    {
        public Desaparecido()
        {
            this.Caracteristica = new Caracteristica();
        }

        public int Id { get; set; }
        public string Nome{get;set;}
        public string UltimoLugarVisto { get; set; }
        public string Contato { get; set; }
        public byte[] Imagem { get; set; }
        public DateTime DataDesaparecimento { get; set; }
        public Caracteristica Caracteristica { get; set; }
    }

    public class DesaparecidoDao
    {
        private MySqlConnection conexao;

        public DesaparecidoDao(MySqlConnection conexao)
        {
            this.conexao = conexao;
        }

        public List<Desaparecido> GetAll()
        {
            var eventos = new List<Desaparecido>();
            var sql = "SELECT * FROM desaparecido";
            var dataSet = new DataSet();
            var query = new MySqlDataAdapter(sql, this.conexao);

            query.Fill(dataSet); // pega tudo que trouxer na query e joga apra o data set;

            foreach (var linhaDesaparecido in dataSet.Tables[0].AsEnumerable().ToList())
            {
                var desaparecido = new Desaparecido()
                {
                    Id = Convert.ToInt32(linhaDesaparecido["id"]),
                    Nome = linhaDesaparecido["nome"].ToString(),
                    Contato = linhaDesaparecido["contato"].ToString(),
                    UltimoLugarVisto = linhaDesaparecido["ultimoLugarVisto"].ToString(),
#warning Faltou acrescentar a caracteristica
                };

                eventos.Add(desaparecido);
            }

            return eventos;
        }
    }
}
