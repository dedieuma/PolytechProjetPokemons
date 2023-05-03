﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PokeAPIPolytech.Repositories;

#nullable disable

namespace PokeAPIPolytech.Migrations
{
    [DbContext(typeof(PokemonContext))]
    [Migration("20221222095938_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.1");

            modelBuilder.Entity("Pokemon", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("PictureUrl")
                        .HasColumnType("TEXT");

                    b.Property<int>("Type")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Pokemons");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "A strange seed was planted on its back at birth. The plant sprouts and grows with this POKéMON.",
                            Name = "Bulbasaur",
                            PictureUrl = "https://img.pokemondb.net/artwork/large/bulbasaur.jpg",
                            Type = 11
                        },
                        new
                        {
                            Id = 4,
                            Description = "Obviously prefers hot places. When it rains, steam is said to spout from the tip of its tail.",
                            Name = "Charmander",
                            PictureUrl = "https://img.pokemondb.net/artwork/large/charmander.jpg",
                            Type = 9
                        },
                        new
                        {
                            Id = 7,
                            Description = "After birth, its back swells and hardens into a shell. Powerfully sprays foam from its mouth.",
                            Name = "Squirtle",
                            PictureUrl = "https://img.pokemondb.net/artwork/large/squirtle.jpg",
                            Type = 10
                        },
                        new
                        {
                            Id = 10,
                            Description = "Its short feet are tipped with suction pads that enable it to tirelessly climb slopes and walls.",
                            Name = "Caterpie",
                            PictureUrl = "https://img.pokemondb.net/artwork/large/caterpie.jpg",
                            Type = 6
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
