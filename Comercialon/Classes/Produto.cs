using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comercialon.Classes
{
   public class Produto
    { 
       public string Id { get; set; }
       public string Descrição { get; set; }
       public double ValorUnitario { get; set; }
       public string UnidadeVenda { get; set; }
       public string CodBar { get; set; }
       public double Desconto { get; set; }
       public bool Descontinuando { get; set; }
       public Marca Marca { get; set; }
       public Categoria Categoria { get; set; }

        public Produto()
        {
        }

        public Produto(string descrição, double valorUnitario, string unidadeVenda, string codBar, double desconto, bool descontinuando, Marca marca, Categoria categoria)
        {
            Descrição = descrição;
            ValorUnitario = valorUnitario;
            UnidadeVenda = unidadeVenda;
            CodBar = codBar;
            Desconto = desconto;
            Descontinuando = descontinuando;
            Marca = marca;
            Categoria = categoria;
        }

        public Produto(string id, string descrição, double valorUnitario, string unidadeVenda, string codBar, double desconto, bool descontinuando, Marca marca, Categoria categoria)
        {
            Id = id;
            Descrição = descrição;
            ValorUnitario = valorUnitario;
            UnidadeVenda = unidadeVenda;
            CodBar = codBar;
            Desconto = desconto;
            Descontinuando = descontinuando;
            Marca = marca;
            Categoria = categoria;
        }

        public void inserir()
        {

        }
        public static List<Produto> ObterLista()
        {
            List<Produto> lista = new List<Produto>();

            return lista;
        }
        public void BuscarPorId(int id)
        {

        }
        public void BuscarPorCodbar(string codbar)
        {

        }
        public bool Alterar()
        {
            return true;
        }
    }
}
