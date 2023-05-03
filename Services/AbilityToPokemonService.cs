using Microsoft.EntityFrameworkCore;
using PokeAPIPolytech.Dtos;
using PokeAPIPolytech.Exceptions;
using PokeAPIPolytech.Repositories;

namespace PokeAPIPolytech.Services;

public class AbilityToPokemonService: IAbilityToPokemonService
{
    private readonly PokemonContext dbContext;

    public AbilityToPokemonService(PokemonContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public PokemonDto Link(PokemonToAbilityDto dto)
    {
        var pokemon = dbContext.Pokemons
            .Include(pok => pok.Abilities)
            .FirstOrDefault(pok => pok.Id == dto.PokemonId);

        if (pokemon == null)
        {
            throw new NotFoundException($"Pokemon with id {dto.PokemonId} was not found");
        }

        var ability = dbContext.Abilities
            .Find(dto.AbilityId);

        if (ability == null)
        {
            throw new NotFoundException($"Ability with id {dto.AbilityId} was not found");
        }

        if (pokemon.Abilities.Any(a => a.Id == dto.AbilityId))
        {
            throw new BadRequestException(
                $"Pokemon with id {pokemon.Id} is already linked with ability with id {ability.Id}");
        }
        
        pokemon.Abilities.Add(ability);
        dbContext.Pokemons.Update(pokemon);
        dbContext.SaveChanges();

        return new PokemonDto
        {
            Id = pokemon.Id,
            Description = pokemon.Description,
            Name = pokemon.Name,
            Type = pokemon.Type,
            PictureUrl = pokemon.PictureUrl,
            Abilities = pokemon.Abilities.Select(ab => new AbilityDto
            {
                Id = ab.Id,
                Name = ab.Name
            }).ToList()
        };
    }

    public PokemonDto RemoveLink(PokemonToAbilityDto dto)
    {
        var pokemon = dbContext.Pokemons
            .Include(pok => pok.Abilities)
            .FirstOrDefault(pok => pok.Id == dto.PokemonId);

        if (pokemon == null)
        {
            throw new NotFoundException($"Pokemon with id {dto.PokemonId} was not found");
        }

        var ability = dbContext.Abilities
            .Find(dto.AbilityId);

        if (ability == null)
        {
            throw new NotFoundException($"Ability with id {dto.AbilityId} was not found");
        }

        if (pokemon.Abilities.All(a => a.Id != dto.AbilityId))
        {
            throw new BadRequestException(
                $"Pokemon with id {pokemon.Id} is not linked with ability with id {ability.Id}");
        }

        pokemon.Abilities.Remove(ability);
        dbContext.Pokemons.Update(pokemon);
        dbContext.SaveChanges();
        return new PokemonDto
        {
            Id = pokemon.Id,
            Description = pokemon.Description,
            Name = pokemon.Name,
            Type = pokemon.Type,
            PictureUrl = pokemon.PictureUrl,
            Abilities = pokemon.Abilities.Select(ab => new AbilityDto
            {
                Id = ab.Id,
                Name = ab.Name
            }).ToList()
        };
    }
}