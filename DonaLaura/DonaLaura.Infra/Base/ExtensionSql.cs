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
        private static string add = @"INSERT INTO TBProduct (NOME, 
                                                     PRECO_VENDA, 
                                                     PRECO_CUSTO,
                                                     DISPONIBILIDADE,
                                                     DATA_FAB,
                                                     DATA_VAL)
                                     VALUES ('Bruno', 
                                                     10.50, 
                                                     8,50,
                                                     1,
                                                     '11-05-2018',
                                                     '13-05-2018')";

        public static void SeedDb()
        {
            //Db.Deletar(truncate);
            //Db.Adicionar(add, null);
        }
    }
}
