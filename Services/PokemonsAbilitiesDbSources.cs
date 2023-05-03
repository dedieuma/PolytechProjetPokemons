using PokeAPIPolytech.Dtos;
using PokeAPIPolytech.Exceptions;
using PokeAPIPolytech.Models;
using PokeAPIPolytech.Repositories;

namespace PokeAPIPolytech.Services;

public class PokemonsAbilitiesDbSources: IPokemonsAbilitiesDbSources
{
    private readonly PokemonContext dbContext;

    public PokemonsAbilitiesDbSources(PokemonContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public IEnumerable<AbilityDto> GetAllAbilities()
    {
        return dbContext.Abilities.ToList()
            .Select(ab => new AbilityDto
            {
                Id = ab.Id,
                Name = ab.Name
            });
    }

    public AbilityDto CreateAbility(CreateAbilityDto dto)
    {
        var existing = dbContext.Abilities
            .Find(dto.Id);

        if (existing != null)
        {
            throw new BadRequestException($"Ability with id {dto.Id} already exists");
        }

        var ability = new Ability
        {
            Id = dto.Id,
            Name = dto.Name
        };

        dbContext.Abilities.Add(ability);
        dbContext.SaveChanges();
        return new AbilityDto
        {
            Id = ability.Id,
            Name = ability.Name
        };
    }

    public AbilityDto UpdateAbility(int id, UpdateAbilityDto dto)
    {
        var existing = dbContext.Abilities
            .Find(id);

        if (existing == null)
        {
            throw new NotFoundException($"Ability with id {id} not found");
        }

        existing.Name = dto.Name;
        dbContext.Abilities.Update(existing);
        dbContext.SaveChanges();
        return new AbilityDto
        {
            Id = existing.Id,
            Name = existing.Name
        };
    }

    public void DeleteAbility(int id)
    {
        var ability = dbContext.Abilities
            .Find(id);

        if (ability == null)
        {
            return;
        }

        dbContext.Abilities.Remove(ability);
        dbContext.SaveChanges();
    }
}