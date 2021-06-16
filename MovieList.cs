using System.Collections.Generic;
using apiWeb.Models;
using webapiejemplo.Models;

namespace apiWeb
{
    public class MovieList
    {
        public List<MovieDto> Movies {set; get;}
        public static MovieList Current {get;} = new MovieList();
        public MovieList(){
            Movies = new List<MovieDto>(){
                new MovieDto(){
                    Id = 1,
                    Name = "AAAA",
                    Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book",
                    Casts = new List<CastDto>(){
                        new CastDto {Id=1, Name="aaaaa", CharName="bbbbb"},
                        new CastDto {Id=2, Name="bbbbb", CharName="ccccc"},
                        new CastDto {Id=3, Name="ddddd", CharName="eeeee"}
                    }
                },
                new MovieDto(){
                    Id = 2,
                    Name = "BBBB",
                    Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book",
                    Casts = new List<CastDto>(){
                        new CastDto {Id=1, Name="aaaaa", CharName="bbbbb"},
                        new CastDto {Id=2, Name="bbbbb", CharName="ccccc"},
                        new CastDto {Id=3, Name="ddddd", CharName="eeeee"}
                    }
                },
                new MovieDto(){
                    Id = 3,
                    Name = "CCCC",
                    Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book",
                    Casts = new List<CastDto>(){
                        new CastDto {Id=1, Name="aaaaa", CharName="bbbbb"},
                        new CastDto {Id=2, Name="bbbbb", CharName="ccccc"},
                        new CastDto {Id=3, Name="ddddd", CharName="eeeee"}
                    }
                }
            };
        }
    }
}