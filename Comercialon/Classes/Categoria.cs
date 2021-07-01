using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comercialon.Classes
{
    public class Categoria
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Sigla { get; set; }

        public Categoria()
        {
        }

        public Categoria(string nome, string sigla)
        {
            Nome = nome;
            Sigla = sigla;
        }

        public Categoria(int id, string nome, string sigla)
        {
            Id = id;
            Nome = nome;
            Sigla = sigla;
        }

        public void inserir (int id)
        {
            string query = "insert categorias values(" +
                id +", "+
                "'"+Nome+", "+
                "'"+Sigla+ "')";

            var cmd = Banco.Abrir();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = query;
            cmd.ExecuteNonQuery();
            cmd.CommandText = "select@@identity";
            Id = Convert.ToInt32 (cmd.ExecuteScalar());


        }

    }
}
