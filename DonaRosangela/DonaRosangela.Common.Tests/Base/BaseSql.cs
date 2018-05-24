using DonaRosangela.Infra.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonaRosangela.Common.Tests.Base
{
    public static class BaseSql
    {
        private const string _truncateTBBook = "TRUNCATE TABLE TBBook";
        private const string _addTBBook = "INSERT INTO TBBook (Title, Theme, Author, Volume, Publication, Availability)" +
            "VALUES ('Senhor dos Aneis', 'Fantasia', 'J R R Tolkien',1, 1997-03-10, 1 )";

        public static void SeedDb()
        {
            Db.Delete(_truncateTBBook);
            Db.Delete(_addTBBook);
        }
    }
}
