using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonaRosangela.Domain.Features.Books
{
    public class Book
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Theme { get; set; }
        public string Author { get; set; }
        public int Volume { get; set; }
        public DateTime Publication { get; set; }
        public bool Availability { get; set; }

        public void Validade()
        {
            if (Title.Length < 4) throw new BookTitleMinCaractersException();
            if (Theme.Length < 4) throw new BookThemeMinCaractersException();
            if (Author.Length < 4) throw new BookAuthorMinCaractersException();
            if (Volume <= 0) throw new BookInvalidVolumeException();
        }
    }
}
