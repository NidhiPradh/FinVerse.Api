using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinVerse.Infrastructure.models
{
    public class LoginRequestEntity
    {
        public string? Email { get; set; }
        public string? Password { get; set; }
    }
}
