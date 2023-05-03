using PokeAPIPolytech.Dtos;

namespace PokeAPIPolytech.Services;

public interface IPokemonsDbSources
{
    IEnumerable<PokemonDto> GetAll();
    PokemonDto? GetByName(string name);
    PokemonDto Insert(CreatePokemonDto dto);
    void DeleteById(int id);
    PokemonDto Update(int id, UpdatePokemonDto dto);
}