using Microsoft.EntityFrameworkCore;
using PokeAPIPolytech.Models;

namespace PokeAPIPolytech.Repositories;

public class PokemonContext : DbContext
{
    public PokemonContext(DbContextOptions<PokemonContext> dbContextOptions) : base(dbContextOptions)
    {
    }

    private static readonly List<Pokemon> PokemonList = new()
    {
        new Pokemon{
            Id = 1,
            Name = "Bulbasaur",
            Description = "A strange seed was planted on its back at birth. The plant sprouts and grows with this POKéMON.",
            Type = PokemonType.Grass,
            PictureUrl = "https://img.pokemondb.net/artwork/large/bulbasaur.jpg"
        },
        new Pokemon{
            Id = 4,
            Name = "Charmander",
            Description = "Obviously prefers hot places. When it rains, steam is said to spout from the tip of its tail.",
            Type = PokemonType.Fire,
            PictureUrl = "https://img.pokemondb.net/artwork/large/charmander.jpg"
        },
        new Pokemon{
            Id = 7,
            Name = "Squirtle",
            Description = "After birth, its back swells and hardens into a shell. Powerfully sprays foam from its mouth.",
            Type = PokemonType.Water,
            PictureUrl = "https://img.pokemondb.net/artwork/large/squirtle.jpg"
        }
    };
    

    public DbSet<Pokemon> Pokemons { get; set; } = default!;

    public DbSet<Ability> Abilities { get; set; } = default!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        var dataPokemon = PokemonList.Append(new Pokemon
        {
            Id = 10,
            Name = "Caterpie",
            Description = "Its short feet are tipped with suction pads that enable it to tirelessly climb slopes and walls.",
            Type = PokemonType.Bug,
            PictureUrl = "https://img.pokemondb.net/artwork/large/caterpie.jpg"
        });

        modelBuilder.Entity<Pokemon>()
            .HasData(dataPokemon);

        var dataAbilities = new List<Ability>{
            new Ability{
                Id = 1,
                Name = "shield-dust"
            }
        };

        modelBuilder.Entity<Ability>()
            .HasData(dataAbilities);

        modelBuilder.Entity<Pokemon>()
            .HasMany(pokemon => pokemon.Abilities)
            .WithMany(ab => ab.Pokemons)
            .UsingEntity(abPok => abPok.HasData(new { PokemonsId = 10, AbilitiesId = 1 }));
            
    }
}