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
       public double Preço { get; set; }
       public double Desconto { get; set; }
       public bool Descontinuando { get; set; }

        public Produto()
        {
        }

        public Produto(string id, string descrição, double preço, double desconto, bool descontinuando)
        {
            Id = id;
            Descrição = descrição;
            Preço = preço;
            Desconto = desconto;
            Descontinuando = descontinuando;
        }

        public Produto(string descrição, double preço, double desconto, bool descontinuando)
        {
            Descrição = descrição;
            Preço = preço;
            Desconto = desconto;
            Descontinuando = descontinuando;
        }
    }
}
