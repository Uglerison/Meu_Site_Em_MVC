﻿using Meu_Site_Em_MVC.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Meu_Site_Em_MVC.Data
{
    public class BancoContext : DbContext
    {
        public BancoContext(DbContextOptions<BancoContext> options) : base(options) { 

        }

        public DbSet<ContactModel> Contatos { get; set; }
        public DbSet<UserModel> Usuarios { get; set; }
    }
}
