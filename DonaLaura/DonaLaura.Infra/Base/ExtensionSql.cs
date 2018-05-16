using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonaLaura.Infra.Base
{
    public static class ExtensionSql
    {
        private static string truncateSale = "TRUNCATE TABLE TBSale";
        private static string deleteProduct = "DELETE FROM TBProduct";
        private static string resetAutoIdentity = "DBCC CHECKIDENT('TBProduct', RESEED, 0)";
        private static string addProduct = "INSERT INTO TBProduct (NOME, PRECO_VENDA, PRECO_CUSTO, DISPONIBILIDADE,DATA_FAB, DATA_VAL) VALUES ('Creme Facial',  10.50, 8.50, 1, 2018-11-05,2018-13-05)";
        private static string addSale = "INSERT INTO TBSale (PRODUTO_ID, CLIENTE, QUANTIDADE, LUCRO) VALUES (1, 'Bruno Ribeiro', 3, 10)";


        public static void SeedDb()
        {
            Db.Delete(truncateSale);
            Db.Delete(deleteProduct);
            Db.Delete(resetAutoIdentity);
            Db.Delete(addProduct);
            Db.Delete(addSale);
        }

        public static void SeedDbWithoutDependence()
        {
            Db.Delete(truncateSale);
            Db.Delete(deleteProduct);
            Db.Delete(resetAutoIdentity);
            Db.Delete(addProduct);
        }
    }
}
