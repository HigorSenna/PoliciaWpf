using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Policia.Model.Model
{
    public class Caracteristica
    {
        public int Id { get; set; }
        public string CorDoCabelo { get; set; }
        public string CorDosOlhos { get; set; }
        public string CorDaPele { get; set; }
        public double AlturaAproximada { get; set; }
        public double Peso { get; set; }
        public int Idade { get; set; }
        public Desaparecido Desaparecido { get; set; }
    }

    public class CaracteristicaDao
    {
        private MySqlConnection conexao;

        public CaracteristicaDao(MySqlConnection conexao)
        {
            this.conexao = conexao;
        }

        public void InsertCaracteristica(Caracteristica caracteristica)
        {
            var sql = "INSERT INTO caracteristica(corDoCabelo, corDosOlhos, corDaPele, alturaAproximada, peso, idade) " +
                "VALUES(_corDoCabelo, _corDosOlhos, _corDaPele, _alturaAproximada, _peso, _idade)";

            var dataSet = new DataSet();

            var command = new MySqlCommand(sql, this.conexao);
            command.Parameters.AddWithValue("_corDoCabelo", caracteristica.CorDoCabelo);
            command.Parameters.AddWithValue("_corDosOlhos", caracteristica.CorDosOlhos);
            command.Parameters.AddWithValue("_corDaPele", caracteristica.CorDaPele);
            command.Parameters.AddWithValue("_alturaAproximada", caracteristica.AlturaAproximada);
            command.Parameters.AddWithValue("_peso", caracteristica.Peso);
            command.Parameters.AddWithValue("_idade", caracteristica.Idade);

#warning Verificar como será feito a captura do id.
        }

        public Caracteristica GetByDesaparecido(Desaparecido desaparecido)
        {
            var sql = "SELECT * FROM caracteristica where idDesaparecido = idDesaparecido";
            var dataSet = new DataSet();

            var command = new MySqlCommand(sql, this.conexao);
            command.Parameters.AddWithValue("idDesaparecido", desaparecido.Id);

            var query = new MySqlDataAdapter(command);
            query.Fill(dataSet); // pega tudo que trouxer na query e joga apra o data set;
            
            var dadosBuscados = dataSet.Tables[0].AsEnumerable().ToList().FirstOrDefault();

            if (dadosBuscados == null)
                return null;

            var caracteristica = new Caracteristica()
            {
                Id = Convert.ToInt32(dadosBuscados["id"]),
                AlturaAproximada = Convert.ToDouble(dadosBuscados["alturaAproximada"]),
                CorDaPele = dadosBuscados["corDaPele"].ToString(),
                CorDoCabelo = dadosBuscados["corDoCabelo"].ToString(),
                CorDosOlhos = dadosBuscados["corDosOlhos"].ToString(),
                Idade = Convert.ToInt32(dadosBuscados["idade"].ToString()),
                Peso = Convert.ToDouble(dadosBuscados["peso"].ToString()),
                Desaparecido = desaparecido
            };
            
            return caracteristica;
        }
    }
}
