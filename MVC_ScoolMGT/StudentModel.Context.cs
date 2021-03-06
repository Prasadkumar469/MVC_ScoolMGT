﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MVC_ScoolMGT
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class StudentEntities : DbContext
    {
        public StudentEntities()
            : base("name=StudentEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<ClassName> ClassNames { get; set; }
        public virtual DbSet<FeesType> FeesTypes { get; set; }
        public virtual DbSet<mstrole> mstroles { get; set; }
        public virtual DbSet<mstsiteaction> mstsiteactions { get; set; }
        public virtual DbSet<mstroleaccess> mstroleaccesses { get; set; }
        public virtual DbSet<Fee> Fees { get; set; }
        public virtual DbSet<SchoolUser> SchoolUsers { get; set; }
    
        public virtual ObjectResult<GetSiteActions_Result> GetSiteActions(Nullable<int> roleId)
        {
            var roleIdParameter = roleId.HasValue ?
                new ObjectParameter("RoleId", roleId) :
                new ObjectParameter("RoleId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetSiteActions_Result>("GetSiteActions", roleIdParameter);
        }
    }
}
