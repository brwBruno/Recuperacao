using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonaLaura.Infra.Base
{
    public static class ExtensionSql
    {
        private static string truncate = "TRUNCATE TABLE TBProduct";
        private static string add = "INSERT INTO TBProduct (NOME, PRECO_VENDA, PRECO_CUSTO, DISPONIBILIDADE,DATA_FAB, DATA_VAL) VALUES ('Creme Facial',  10.50, 8.50, 1, 2018-11-05,2018-13-05)";

        public static void SeedDb()
        {
            Db.Delete(truncate);
            Db.Delete(add);
        }
    }
}
