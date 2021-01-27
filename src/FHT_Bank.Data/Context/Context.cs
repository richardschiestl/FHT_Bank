using System;
using System.Collections.Generic;
using System.Text;
using FHT_Bank.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace FHT_Bank.Data.Context
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        { }

        public DbSet<Account> Accounts { get; set; }
    }
}
