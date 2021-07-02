using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comercialon.Classes
{
    public class Pedido
    {
        public int Id { get; set; }
        public int Data { get; set; }
        public string Situacao { get; set; }
        public double Desconto { get; set; }
        public Usuario Usuario { get; set; }
        public Cliente Cliente { get; set; }
        public List<ItemPedido> ItemsPedidos { get; set; }

        public Pedido()
        {
        }

        public Pedido(int data, string situacao, double desconto, Usuario usuario, Cliente cliente, List<ItemPedido> itemsPedidos)
        {
            Data = data;
            Situacao = situacao;
            Desconto = desconto;
            Usuario = usuario;
            Cliente = cliente;
            ItemsPedidos = itemsPedidos;
        }

        public Pedido(int id, int data, string situacao, double desconto, Usuario usuario, Cliente cliente, List<ItemPedido> itemsPedidos)
        {
            Id = id;
            Data = data;
            Situacao = situacao;
            Desconto = desconto;
            Usuario = usuario;
            Cliente = cliente;
            ItemsPedidos = itemsPedidos;
        }
    }
}
