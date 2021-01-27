using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace FHT_Bank.Domain.Models
{
    [Table("Account")]
    public class Account
    {
        public Guid Id { get; set; }
        public int AccountNumber { get; set; }
        public decimal Balance { get; set; }
    }
}