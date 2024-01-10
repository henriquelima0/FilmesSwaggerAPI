using FilmesSwaggerAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace FilmesSwaggerAPI.Data;

public class FilmeContext : DbContext
{
    public FilmeContext(DbContextOptions<FilmeContext> opts)
        : base(opts)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        // Configuração da chave primária composta da entidade Sessao usando FilmeId e CinemaId.
        builder.Entity<Sessao>()
            .HasKey(sessao => new {sessao.FilmeId, sessao.CinemaId});

        // Configuração da relação entre Sessao e Cinema usando CinemaId como chave estrangeira.
        builder.Entity<Sessao>()
            .HasOne(sessao => sessao.Cinema)
            .WithMany(cinema => cinema.Sessoes)
            .HasForeignKey(sessao => sessao.CinemaId);

        // Configuração da relação entre Sessao e Filme usando FilmeId como chave estrangeira.
        builder.Entity<Sessao>()
           .HasOne(sessao => sessao.Filme) 
           .WithMany(filme => filme.Sessoes)
           .HasForeignKey(sessao => sessao.FilmeId);

        builder.Entity<Endereco>()
            .HasOne(endereco => endereco.Cinema)
            .WithOne(cinema => cinema.Endereco)
            .OnDelete(DeleteBehavior.Restrict); // não é em cascata !
    }

    public DbSet<Filme> Filmes { get; set; }
    public DbSet<Cinema> Cinemas { get; set; }
    public DbSet<Endereco> Enderecos { get; set; }
    public DbSet<Sessao> Sessoes { get; set; }
}