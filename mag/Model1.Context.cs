﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace mag
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class magazinEntities : DbContext
    {
        public magazinEntities()
            : base("name=magazinEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<tag> tag { get; set; }
        public virtual DbSet<TagClient> TagClient { get; set; }
        public virtual DbSet<Бренд> Бренд { get; set; }
        public virtual DbSet<Заказ> Заказ { get; set; }
        public virtual DbSet<Клиенты> Клиенты { get; set; }
        public virtual DbSet<Пол> Пол { get; set; }
        public virtual DbSet<страна> страна { get; set; }
        public virtual DbSet<ТипТовара> ТипТовара { get; set; }
        public virtual DbSet<Товар> Товар { get; set; }
    }
}