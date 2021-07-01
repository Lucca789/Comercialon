using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comercialon.Classes
{
    public class Usuario
    {
        public string Id { get; set; }
        public string Nome { get; set; }
        public string Senha { get; set; }
        public string Nivel { get; set; }
        public string Situacao { get; set; }

        public Usuario()
        {
            
        }

        public Usuario(string id, string nome, string senha, string nivel, string situacao)
        {
            Id = id;
            Nome = nome;
            Senha = senha;
            Nivel = nivel;
            Situacao = situacao;
        }

        public Usuario(string nome, string senha, string nivel, string situacao)
        {
            Nome = nome;
            Senha = senha;
            Nivel = nivel;
            Situacao = situacao;
        }

        public void Inserir()
        {
            var cmd = Banco.Abrir();
            if (cmd.Connection.State == System.Data.ConnectionState.Open)
            {
                //inserir usando concatenações
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = "insert clientes " +
                    "(nome, Senha, nivel, situação) " +
                    "values('" + Nome + "', '" + Senha + "', '" + Nivel + "', '" + Situacao + "',)";
                cmd.ExecuteNonQuery();//
                cmd.CommandText = "select @@identity";
                
            }
        }












        //propriedades
        /*
         Id, Nome, Email, Senha, Nivel, Situacao(classe usuario)
         Id, Descricao, Preco, Desconto, Descontinuando
         */ //          double double bool







        //  Metodos construtores 
        /*
         Vazio , com todos as propriedades, e sem id 
         */


        // Metodos da classe 
        /*
         Inserir que retorne valor do  id do usuario inserido 
         ListarTodos que retorne uma lista de Usuários 
         Alterar passando o id que retorne verdadeiro ou falso 
         BuscaPorId que nãio retorne valor
         */
    }
}
