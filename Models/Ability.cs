namespace PokeAPIPolytech.Models;

public class Ability
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;

    public virtual ICollection<Pokemon> Pokemons { get; set; } = new List<Pokemon>();
}