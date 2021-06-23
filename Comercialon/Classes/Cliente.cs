using System;
using System.Collections.Generic;

namespace Comercialon.Classes
{
    public  class Cliente
    {//Declaração de atributo.
       

        public int Id { get; set; }

        public string Nome { get; set; }

        public string Cpf { get; set; }

        public string Email { get; set; }

        public string Telefone { get; set; }

        public List<Endereco> Enderecos { get; set; }
        public bool Ativo { get; set; } 


            
        // metodos construtores
        public Cliente() { Id = 0; }

        public Cliente(string nome, string cpf, string email, string telefone, bool ativo = true , List<Endereco> endereco=null)
        {
            Nome = nome;
            Cpf = cpf;
            Email = email;
            Telefone = telefone;
            Enderecos = endereco;
            Ativo = ativo;
        }

        public Cliente(int id, string nome, string cpf, string email, string telefone, bool ativo = true, List<Endereco> endereco=null)
        {
            Id = id;
            Nome = nome;
            Cpf = cpf;
            Email = email;
            Telefone = telefone;
            Enderecos = endereco;
            Ativo = ativo;
        }


        //métodos da classe
        public void Inserir()
        {
            var cmd = Banco.Abrir();
            if (cmd.Connection.State==System.Data.ConnectionState.Open)
            {

            }
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "insert clientes " +
                "(nome, cpf, email, telefone, ativo) " +
                "values('" + Nome + "', '" + Cpf + "', '" + Email + "', '" + Telefone + "', default); ";
            cmd.ExecuteNonQuery();//
            cmd.CommandText = "select @@identity";
            Id = Convert.ToInt32(cmd.ExecuteScalar());
        }

        public bool Alterar(int id) 
        {
            return true;
        }
        public static List<Cliente> ListarTodos() 
        {
            List<Cliente> lista = new List<Cliente>();
            //Code de listar
            string query = "select * from clientes";
            var cmd = Banco.Abrir();
            cmd.CommandText = query;
            var dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                lista.Add(new Cliente(
                    dr.GetInt32(0),
                    dr.GetString(1),
                    dr.GetString(2),
                    dr.GetString(3),
                    dr.GetString(4),
                    dr.GetBoolean(5),
                    Endereco.ListaEnderecos(dr.GetInt32(0))
                    ));

            }
            return lista;
        }
        public void BuscarPorId(int id) 
        { 
        
        }
    }

}
/*-- MySQL Workbench Forward Engineering

SET @OLD_UNIQUE_CHECKS =@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS =@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE =@@SQL_MODE, SQL_MODE='ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION';

-- -----------------------------------------------------
-- Schema comercialondb
-- -----------------------------------------------------

-- -----------------------------------------------------
-- Schema comercialondb
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS `comercialondb` DEFAULT CHARACTER SET utf8;
USE `comercialondb` ;

-- -----------------------------------------------------
-- Table `comercialondb`.`Clientes`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `comercialondb`.`Clientes` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `nome` VARCHAR(45) NOT NULL,
  `cpf` CHAR(11) NOT NULL,
  `email` VARCHAR(45) NOT NULL,
  `telefone` VARCHAR(14) NULL,
  `ativo` BIT NOT NULL DEFAULT 1,
  PRIMARY KEY(`id`),
  UNIQUE INDEX `cpf_UNIQUE` (`cpf` ASC) ,
  UNIQUE INDEX `email_UNIQUE` (`email` ASC) )
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `comercialondb`.`Usuarios`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `comercialondb`.`Usuarios` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `nome` VARCHAR(45) NOT NULL,
  `email` VARCHAR(45) NOT NULL,
  `senha` CHAR(32) NOT NULL,
  `nivel` VARCHAR(45) NOT NULL,
  `ativo` BIT NOT NULL DEFAULT 1,
  `cpf` CHAR(11) NOT NULL,
  PRIMARY KEY(`id`),
  UNIQUE INDEX `email_UNIQUE` (`email` ASC) ,
  UNIQUE INDEX `cpf_UNIQUE` (`cpf` ASC) )
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `comercialondb`.`Enderecos`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `comercialondb`.`Enderecos` (
  `Clientes_id` INT NOT NULL,
  `cep` CHAR(8) NOT NULL,
  `logradouro` VARCHAR(45) NOT NULL,
  `numero` VARCHAR(45) NOT NULL,
  `complemento` VARCHAR(45) NULL,
  `bairro` VARCHAR(45) NOT NULL,
  `cidade` VARCHAR(45) NOT NULL,
  `estado` VARCHAR(45) NOT NULL,
  `sigla_estado` CHAR(2) NOT NULL,
  `tipo` VARCHAR(45) NOT NULL,
  INDEX `fk_Enderecos_Clientes1_idx` (`Clientes_id` ASC) ,
  CONSTRAINT `fk_Enderecos_Clientes1`
    FOREIGN KEY (`Clientes_id`)
    REFERENCES `comercialondb`.`Clientes` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `comercialondb`.`Marcas`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `comercialondb`.`Marcas` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `nome` VARCHAR(45) NOT NULL,
  `sigla` VARCHAR(45) NULL,
  PRIMARY KEY (`id`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `comercialondb`.`Categorias`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `comercialondb`.`Categorias` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `nome` VARCHAR(45) NOT NULL,
  `sigla` VARCHAR(45) NULL,
  PRIMARY KEY (`id`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `comercialondb`.`Produtos`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `comercialondb`.`Produtos` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `descricao` VARCHAR(128) NOT NULL,
  `valor_unitario` DECIMAL(10,2) NOT NULL,
  `unidade_venda` VARCHAR(20) NOT NULL,
  `codbar` VARCHAR(32) NULL,
  `desconto` DECIMAL(10,2) NOT NULL,
  `descontinuado` BIT NOT NULL DEFAULT 0,
  `Marcas_id` INT NOT NULL,
  `Categorias_id` INT NOT NULL,
  PRIMARY KEY (`id`),
  INDEX `fk_Produtos_Marcas1_idx` (`Marcas_id` ASC) ,
  INDEX `fk_Produtos_Categorias1_idx` (`Categorias_id` ASC) ,
  CONSTRAINT `fk_Produtos_Marcas1`
    FOREIGN KEY (`Marcas_id`)
    REFERENCES `comercialondb`.`Marcas` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_Produtos_Categorias1`
    FOREIGN KEY (`Categorias_id`)
    REFERENCES `comercialondb`.`Categorias` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `comercialondb`.`Pedidos`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `comercialondb`.`Pedidos` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `data` TIMESTAMP NOT NULL DEFAULT current_timestamp,
  `situacao` VARCHAR(45) NOT NULL DEFAULT 'A',
  `desconto` DECIMAL(10,2) NOT NULL,
 `Usuarios_id` INT NOT NULL,
  `Clientes_id` INT NOT NULL,
  PRIMARY KEY (`id`),
  INDEX `fk_Pedidos_Usuarios_idx` (`Usuarios_id` ASC) ,
  INDEX `fk_Pedidos_Clientes1_idx` (`Clientes_id` ASC) ,
  CONSTRAINT `fk_Pedidos_Usuarios`
    FOREIGN KEY (`Usuarios_id`)
    REFERENCES `comercialondb`.`Usuarios` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_Pedidos_Clientes1`
    FOREIGN KEY (`Clientes_id`)
    REFERENCES `comercialondb`.`Clientes` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `comercialondb`.`ItemPedido`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `comercialondb`.`ItemPedido` (
  `Pedidos_id` INT NOT NULL,
  `Produtos_id` INT NOT NULL,
  `quantidade` DECIMAL(10,2) NOT NULL,
  `valor_produto` DECIMAL(10,2) NOT NULL,
  `desconto` DECIMAL(10,2) NOT NULL,
  INDEX `fk_ItemPedido_Pedidos1_idx` (`Pedidos_id` ASC) ,
  INDEX `fk_ItemPedido_Produtos1_idx` (`Produtos_id` ASC) ,
  CONSTRAINT `fk_ItemPedido_Pedidos1`
    FOREIGN KEY (`Pedidos_id`)
    REFERENCES `comercialondb`.`Pedidos` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_ItemPedido_Produtos1`
    FOREIGN KEY (`Produtos_id`)
    REFERENCES `comercialondb`.`Produtos` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS; */


