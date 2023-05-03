using PokeAPIPolytech.Models;

namespace PokeAPIPolytech.Dtos;

public record PokemonDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public PokemonType Type { get; set; } 
    public string Description { get; set; } = string.Empty;
    public string PictureUrl { get; set; } = string.Empty;

    public ICollection<AbilityDto> Abilities { get; set; } = new List<AbilityDto>();
}