using DonaRosangela.Domain.Features.Books;
using DonaRosangela.Domain.Features.Loans;
using DonaRosangela.Infra.Base;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonaRosangela.Infra.Data.Features.Loans
{
    public class LoanRepository : ILoanRepository
    {
        public Loan Add(Loan loan)
        {
            const string addSql = @"INSERT INTO TBLoan (Client, Book_Id, Devolution)
                                VALUES ({0}Client, {0}Book_Id, {0}Devolution)";
            loan.Id = Db.Add(addSql, Take(loan));
            return loan;
        }

        public void Delete(long id)
        {
            const string sqlDelete = @"DELETE FROM TBLoan WHERE Id = {0}Id";
            var parms = new Dictionary<string, object> { { "Id", id } };
            Db.Delete(sqlDelete, parms);
        }

        public Loan Get(long id)
        {
            const string getSql = @"SELECT * FROM TBLoan WHERE Id = {0}Id";
            var parms = new Dictionary<string, object> { { "Id", id } };
            return Db.Get(getSql, Make, parms);
        }

        public IList<Loan> GetAll()
        {
            const string getAllSql = @"SELECT * FROM TBLoan";
            return Db.GetAll(getAllSql, Make);
        }

        public Loan Update(Loan loan)
        {
            const string sqlUpdate = @"UPDATE TBLoan SET Client = {0}Client, Book_Id = {0}Book_Id, Devolution = {0}Devolution
                                        WHERE Id = {0}Id";
            Db.Update(sqlUpdate, Take(loan));
            return Get(loan.Id);
        }

        private Dictionary<string, object> Take(Loan loan)
        {
            return new Dictionary<string, object>
            {
                { "Id", loan.Id },
                { "Client", loan.Client },
                { "Book_Id", loan.LoanBook.Id },
                { "Devolution", loan.Devolution }
            };
        }

        private Func<IDataReader, Loan> Make => reader =>
            new Loan
            {
                Id = Convert.ToInt64(reader["Id"]),
                Client = Convert.ToString(reader["Client"]),
                LoanBook = new Book
                {
                    Id = Convert.ToInt32(reader["Book_Id"])
                },
                Devolution = Convert.ToDateTime(reader["Devolution"])
            };
    }
}
