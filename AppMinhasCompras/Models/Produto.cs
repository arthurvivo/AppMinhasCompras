using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace AppMinhasCompras.Models
{

    public class Produto
    {
        string descricao;


        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Descricao { 
            get => descricao;
            set 
            { 
                if(value == null)
                {
                    throw new Exception("Descrição não pode ser vazia");
                }
                
                descricao = value;
            } }
        public double Preco { get; set; }
        public double Quantidade { get; set; }
        public DateTime DataCadastro { get; set; } = DateTime.Now;


        public double Total { get => Quantidade * Preco; }
    }
}
