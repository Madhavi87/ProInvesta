﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ProInvesta.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class DB_A34082_proinvestaEntities : DbContext
    {
        public DB_A34082_proinvestaEntities()
            : base("name=DB_A34082_proinvestaEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<ContactU> ContactUs { get; set; }
        public DbSet<Enquiry> Enquiries { get; set; }
        public DbSet<Loan> Loans { get; set; }
        public DbSet<LoanData> LoanDatas { get; set; }
        public DbSet<MutualFundEnquiry> MutualFundEnquiries { get; set; }
        public DbSet<User> Users { get; set; }
    }
}