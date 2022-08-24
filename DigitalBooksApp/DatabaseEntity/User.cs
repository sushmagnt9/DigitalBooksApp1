using System;
using System.Collections.Generic;

namespace DigitalBooksApp.DatabaseEntity
{
    public partial class User
    {
        public int UserId { get; set; }
        public string UserName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string UserRole { get; set; } = null!;
    }
}
