﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace CursoMVC.Models
{
    public class Contexto : DbContext

    {
        public DbSet<Categoria> Categorias { get; set; } //Informa Entity sobre a existência de tabela da categoria


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=Cursomvc;Integrated Security=True"); //Aponta qual banco de dados iremos utilizar
        }
    }
}