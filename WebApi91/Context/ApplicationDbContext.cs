﻿using Domain.Entities;
using Microsoft.EntityFrameworkCore;


namespace WebApi91.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Rol> Roles { get; set; }

        public DbSet<Libro> Libros { get; set; }
        public DbSet<Autor> Autores { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // INsertar en la tabla usuario
            modelBuilder.Entity<Usuario>().HasData(
                new Usuario
                {
                    pkUsuario= 1,
                    Nombre= "Jaime",
                    User="Usuario1",
                    Password="123",
                    FkRol= 1
                }

            );

            //Insertar en la tabla rol
            modelBuilder.Entity<Rol>().HasData(
                new Rol
                {
                    PkRol = 1,
                    Nombre = "sa"
                });
        }

    }
}
