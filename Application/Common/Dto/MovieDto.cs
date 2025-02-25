
using Domain.Entities;

namespace Application.Common.Dto
{
    public class MovieDto
    {
        public int? Id { get; set; }
        public string? Title { get; set; }
        public string? Director { get; set; }
        public int? Year { get; set; }

        public MovieDto() { }
        public MovieDto(int id = 0, string title = "", string director = "", int year = 0)
        {
            Id = id;
            Title = title;
            Director = director;
            Year = year;
        }

        public MovieDto(Movie m)
        {
            Id = m.Id;
            Title = m.Title;
            Director = m.Director;
            Year = m.Year;
        }

        public Movie ToMovie()
        {
            return new Movie
            {
                Id = Id,
                Title = Title,
                Director = Director,
                Year = Year
            };
        }

    }
}
