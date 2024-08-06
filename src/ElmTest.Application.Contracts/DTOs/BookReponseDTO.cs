using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElmTest.Application.Contracts.DTOs
{
    public class BookReponseDTO
    {
        public long BookId { get; set; }
        public string BookTitle { get; set; }
        public string BookDescription { get; set; }
        public string Author { get; set; }
        public DateTime PublishDate { get; set; }
        public string CoverBase64 { get; set; }
        public DateTime? LastModifiedDate { get; set; }
    }
}
