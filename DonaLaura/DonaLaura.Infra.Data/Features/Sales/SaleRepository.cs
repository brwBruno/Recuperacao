using DonaLaura.Domain.Features.Products;
using DonaLaura.Domain.Features.Sales;
using DonaLaura.Infra.Base;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonaLaura.Infra.Data.Features.Sales
{
    public class SaleRepository : ISaleRepository
    {
        private string _sqlAdd = @"INSERT INTO TBSale (PRODUTO_ID, 
                                                CLIENTE, 
                                                QUANTIDADE, 
                                                LUCRO)
                                       VALUES
                                                ({0}PRODUTO_ID,
                                                {0}CLIENTE,
                                                {0}QUANTIDADE, 
                                                {0}LUCRO)";
        private string _sqlUpdate = @"UPDATE TBSale SET PRODUTO_ID = {0}PRODUTO_ID,
                                                         CLIENTE = {0}CLIENTE,
                                                         QUANTIDADE = {0}QUANTIDADE,
                                                         LUCRO = {0}LUCRO
                                                       WHERE ID = {0}ID";
        private string _sqlGet = @"SELECT * FROM TBSale WHERE ID = {0}ID";
        private string _sqlGetAll = @"SELECT * FROM TBSale";
        private string _sqlDelte = @"DELETE FROM TBSale WHERE ID = {0}ID";

        public Sale Add(Sale sale)
        {
            sale.Id = Db.Add(_sqlAdd, Take(sale));
            return sale;
        }

        public void Delete(long id)
        {
            var parms = new Dictionary<string, object> { { "ID", id } };
            Db.Delete(_sqlDelte, parms);
        }

        public Sale Get(long id)
        {
            var parms = new Dictionary<string, object> { { "ID", id } };
            return Db.Get(_sqlGet, Make, parms);
        }

        public IList<Sale> GetAll()
        {
            return Db.GetAll(_sqlGetAll, Make);
        }

        public Sale Update(Sale sale)
        {
            Db.Update(_sqlUpdate, Take(sale));
            return sale;
        }

        private static Func<IDataReader, Sale> Make = reader =>
            new Sale
            {
                Id = Convert.ToInt32(reader["ID"]),
                ProductSale = new Product
                {
                    Id = Convert.ToInt32(reader["PRODUTO_ID"])
                },
                Client = Convert.ToString(reader["CLIENTE"]),
                Amount = Convert.ToInt32(reader["QUANTIDADE"]),
                Profit = Convert.ToDouble(reader["LUCRO"])
            };

        private Dictionary<string, object> Take(Sale sale)
        {
            return new Dictionary<string, object>
            {
                { "ID", sale.Id },
                { "PRODUTO_ID", sale.ProductSale.Id },
                { "CLIENTE", sale.Client },
                { "QUANTIDADE", sale.Amount },
                { "LUCRO", sale.Profit }
            };
        }
    }
}
