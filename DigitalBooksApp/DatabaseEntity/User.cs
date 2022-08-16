using System;
using System.Collections.Generic;

namespace DigitalBooksApp.DatabaseEntity
{
    public partial class User
    {
        public User()
        {
            Books = new HashSet<Book>();
        }

        public int UserId { get; set; }
        public string UserName { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string UserType { get; set; } = null!;

        public virtual ICollection<Book> Books { get; set; }
    }
}
