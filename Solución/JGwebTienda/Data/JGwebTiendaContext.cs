using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using JGwebTienda.Models;

    public class JGwebTiendaContext : DbContext
    {
        public JGwebTiendaContext (DbContextOptions<JGwebTiendaContext> options)
            : base(options)
        {
        }

        public DbSet<JGwebTienda.Models.JGadornos> JGadornos { get; set; } = default!;
    }
