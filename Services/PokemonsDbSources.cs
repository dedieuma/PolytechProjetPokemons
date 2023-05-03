using Microsoft.EntityFrameworkCore;
using PokeAPIPolytech.Dtos;
using PokeAPIPolytech.Exceptions;
using PokeAPIPolytech.Models;
using PokeAPIPolytech.Repositories;

namespace PokeAPIPolytech.Services;

public class PokemonsDbSources : IPokemonsDbSources
{
    private readonly PokemonContext dbContext;

    public PokemonsDbSources(
        PokemonContext context
    )
    {
        this.dbContext = context;
    }

    public IEnumerable<PokemonDto> GetAll()
    {
        return this.dbContext.Pokemons
            .Include(pokemon => pokemon.Abilities)
            .ToList()
            .Select(pok => new PokemonDto
            {
                Id = pok.Id,
                Description = pok.Description,
                Name = pok.Name,
                Type = pok.Type,
                PictureUrl = pok.PictureUrl,
                Abilities = pok.Abilities.Select(ab => new AbilityDto
                {
                    Id = ab.Id,
                    Name = ab.Name
                }).ToList()
            });
    }

    public PokemonDto? GetByName(string name)
    {
        var pok = this.dbContext.Pokemons
            .Include(pokemon => pokemon.Abilities)
            .FirstOrDefault(pokemon => pokemon.Name.Equals(name));

        if (pok == null)
        {
            return null;
        }

        return new PokemonDto
        {
            Id = pok.Id,
            Description = pok.Description,
            Name = pok.Name,
            Type = pok.Type,
            PictureUrl = pok.PictureUrl,
            Abilities = pok.Abilities.Select(ab => new AbilityDto
            {
                Id = ab.Id,
                Name = ab.Name
            }).ToList()
        };
    }

    public PokemonDto Insert(CreatePokemonDto dto)
    {
        var existing = dbContext.Pokemons
            .Include(pok => pok.Abilities)
            .FirstOrDefault(pok => pok.Id == dto.Id);

        if (existing != null)
        {
            throw new BadRequestException($"Pokemon with id {dto.Id} already exists");
        }

        var pok = new Pokemon
        {
            Id = dto.Id,
            Name = dto.Name,
            Description = dto.Description,
            PictureUrl = dto.PictureUrl,
            Type = dto.Type
        };

        this.dbContext.Pokemons
            .Add(pok);

        this.dbContext.SaveChanges();

        return new PokemonDto
        {
            Id = pok.Id,
            Description = pok.Description,
            Name = pok.Name,
            Type = pok.Type,
            PictureUrl = pok.PictureUrl,
            Abilities = pok.Abilities.Select(ab => new AbilityDto
            {
                Id = ab.Id,
                Name = ab.Name
            }).ToList()
        };
    }

    public void DeleteById(int id)
    {
        var existing = dbContext.Pokemons
            .Find(id);

        if (existing == null)
        {
            return;
        }

        dbContext.Pokemons.Remove(existing);
        dbContext.SaveChanges();
    }

    public PokemonDto Update(int id, UpdatePokemonDto dto)
    {
        var existing = dbContext.Pokemons
            .Include(pok => pok.Abilities)
            .FirstOrDefault(pok => pok.Id == id);

        if (existing == null)
        {
            throw new NotFoundException($"Pokemon with id {id} was not found");
        }

        existing.Name = dto.Name;
        existing.Description = dto.Description;
        existing.PictureUrl = dto.PictureUrl;
        existing.Type = dto.Type;

        dbContext.Pokemons.Update(existing);
        dbContext.SaveChanges();

        return new PokemonDto
        {
            Id = existing.Id,
            Description = existing.Description,
            Name = existing.Name,
            Type = existing.Type,
            PictureUrl = existing.PictureUrl,
            Abilities = existing.Abilities.Select(ab => new AbilityDto
            {
                Id = ab.Id,
                Name = ab.Name
            }).ToList()
        };
    }
}