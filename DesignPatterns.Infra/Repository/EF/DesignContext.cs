using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using DesignPatterns.Domain;

namespace DesignPatterns.Infra.Repository.EF
{
    public class DesignContext : DbContext
    {
        public DesignContext(DbContextOptions<DesignContext> options) : base(options)
        {}


        public DbSet<Veiculo> Veiculos {get;set;}

    }
}