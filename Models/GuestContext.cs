using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Kutse_TSYBIREV.Models;

namespace Kutse_TSYBIREV
{
    public class GuestContext: DbContext
    {
        public DbSet<Guest> Guests { get; set; }
    }
}