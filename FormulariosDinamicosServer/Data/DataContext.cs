using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FormulariosDinamicosServer.Models;
using Microsoft.EntityFrameworkCore;

namespace FormulariosDinamicosServer.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Form> Forms => Set<Form>();    
        public DbSet<FormField> Fields => Set<FormField>();
        public DbSet<FieldType> FieldTypes => Set<FieldType>();
        public DbSet<FormValue> FormValues => Set<FormValue>();
        
    }
}