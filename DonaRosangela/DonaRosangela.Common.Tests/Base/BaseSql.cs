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
        private const string _truncateTBLoan = "TRUNCATE TABLE TBLoan";
        private static string _deleteBooks = "DELETE FROM TBBook";
        private static string _resetAutoIdentity = "DBCC CHECKIDENT('TBBook', RESEED, 0)";
        private const string _addTBBook = "INSERT INTO TBBook (Title, Theme, Author, Volume, Publication, Availability)" +
            "VALUES ('Senhor dos Aneis', 'Fantasia', 'J R R Tolkien',1, 1997-03-10, 1 )";
        private const string _addTBLoan = "INSERT INTO TBLoan (CLient, Book_Id, Devolution) VALUES ('Bruno Wagner', 1, 28-05-2018)";

        public static void SeedDbTBBook()
        {
            Db.Delete(_truncateTBLoan);
            Db.Delete(_deleteBooks);
            Db.Delete(_resetAutoIdentity);
            Db.Delete(_addTBBook);
        }

        public static void SeedDbTBLoan()
        {
            Db.Delete(_truncateTBLoan);
            Db.Delete(_deleteBooks);
            Db.Delete(_resetAutoIdentity);
            Db.Delete(_addTBBook);
            Db.Delete(_addTBLoan);
        }
    }
}
