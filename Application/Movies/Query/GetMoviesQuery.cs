using Application.Common.Dto;
using Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Movies.Query
{
    public record GetMoviesQuery : IRequest<List<MovieDto>>
    {
    }

    public class GetMoviesQueryHandler : IRequestHandler<GetMoviesQuery, List<MovieDto>>
    {
        private readonly IMovieDbContext _dbContext;
        public GetMoviesQueryHandler(IMovieDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<MovieDto>> Handle(GetMoviesQuery request, CancellationToken cancellationToken)
        {
            var movies = await _dbContext.Movies.ToListAsync(cancellationToken);
            return movies.Select(movie => new MovieDto(movie)).ToList();
        }
    }
}
