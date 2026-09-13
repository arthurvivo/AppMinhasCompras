using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using AppMinhasCompras.Models;

namespace AppMinhasCompras.Helpers
{
    public class SqliteDatabaseHelper
    {
        readonly SQLiteAsyncConnection _con;
        public SqliteDatabaseHelper(string path)
        {
            _con = new SQLiteAsyncConnection(path);
            _con.CreateTableAsync<Produto>().Wait();
        }

        public Task<int> InsertProduto(Produto p)
        {
            return _con.InsertAsync(p);
        }

        public Task<List<Produto>> UpdateProduto(Produto p)
        {
            string sql = "UPDATE Produto SET Descricao = ?, Preco = ?, Quantidade = ? WHERE Id = ?";
            return _con.QueryAsync<Produto>(sql, p.Descricao, p.Preco, p.Quantidade, p.Id);
        }

        public Task<int> DeleteProduto(int id)
        {
            return _con.Table<Produto>().DeleteAsync(i => i.Id == id);
        }

        public Task<List<Produto>> getAllProdutos()
        {
            return _con.Table<Produto>().ToListAsync();
        }

        public Task<List<Produto>> SearchProduto(string d)
        {
            string sql = "SELECT * FROM Produto WHERE descricao LIKE '%" + d + "%'";
            return _con.QueryAsync<Produto>(sql);
        }

        public Task<List<Produto>> GetProdutosPorPeriodo(DateTime inicio, DateTime fim)
        {
            DateTime inicioAjustado = inicio.Date;
            DateTime fimAjustado = fim.Date.AddDays(1).AddTicks(-1);

            return _con.Table<Produto>()
                        .Where(p => p.DataCadastro >= inicioAjustado && p.DataCadastro <= fimAjustado)
                        .ToListAsync();
        }
    }

}
