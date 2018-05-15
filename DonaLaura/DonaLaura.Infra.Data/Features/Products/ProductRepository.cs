using DonaLaura.Domain.Features.Products;
using DonaLaura.Infra.Base;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonaLaura.Infra.Data.Features.Products
{
    public class ProductRepository : IProductRepository
    {
        private string _sqlAdd = @"INSERT INTO TBProduct (NOME, 
                                                PRECO_VENDA, 
                                                PRECO_CUSTO, 
                                                DISPONIBILIDADE, 
                                                DATA_FAB, 
                                                DATA_VAL)
                                       VALUES
                                                ({0}NOME,
                                                {0}PRECO_VENDA,
                                                {0}PRECO_CUSTO, 
                                                {0}DISPONIBILIDADE, 
                                                {0}DATA_FAB, 
                                                {0}DATA_VAL)";

        private string _sqlUpdate = @"UPDATE TBProduct SET NOME = {0}NOME,
                                                         PRECO_VENDA = {0}PRECO_VENDA,
                                                         PRECO_CUSTO = {0}PRECO_CUSTO,
                                                         DISPONIBILIDADE = {0}DISPONIBILIDADE,
                                                         DATA_FAB = {0}DATA_FAB,
                                                         DATA_VAL = {0}DATA_VAL
                                                       WHERE ID = {0}ID";

        private string _sqlGet = @"SELECT * FROM TBProduct WHERE ID = {0}ID";
        private string _sqlGetAll = @"SELECT * FROM TBProduct";
        private string _sqlDelete = @"DELETE FROM TBProduct WHERE ID = {0}ID";

        public Product Add(Product product)
        {
            product.Id = Db.Add(_sqlAdd, Take(product));
            return product;
        }


        public void Delete(long id)
        {
            var parms = new Dictionary<string, object> { { "ID", id } };

            Db.Delete(_sqlDelete, parms);
        }

        public Product Get(long id)
        {
            var parms = new Dictionary<string, object> { { "ID", id } };

            return Db.Get(_sqlGet, Make, parms);
        }

        public IList<Product> GetAll()
        {
            return Db.GetAll(_sqlGetAll, Make);
        }

        public Product Update(Product product)
        {
            Db.Update(_sqlUpdate, Take(product));

            return product;
        }

        private static Func<IDataReader, Product> Make = reader =>
            new Product
            {
                Id = Convert.ToInt32(reader["ID"]),
                Name = Convert.ToString(reader["NOME"]),
                SalePrice = Convert.ToDouble(reader["PRECO_VENDA"]),
                CostPrice = Convert.ToDouble(reader["PRECO_CUSTO"]),
                Availability = Convert.ToInt32(reader["DISPONIBILIDADE"]),
                Manufacture = Convert.ToDateTime(reader["DATA_FAB"]),
                Expiration = Convert.ToDateTime(reader["DATA_VAL"])
            };

        private Dictionary<string, object> Take(Product product)
        {
            return new Dictionary<string, object>
            {
                { "ID", product.Id },
                { "NOME", product.Name },
                { "PRECO_VENDA", product.SalePrice },
                { "PRECO_CUSTO", product.CostPrice },
                { "DISPONIBILIDADE", product.Availability },
                { "DATA_FAB", product.Manufacture },
                { "DATA_VAL", product.Expiration }
            };
        }
    }
}
