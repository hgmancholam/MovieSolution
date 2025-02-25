using Application.Common.Dto;
using Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Movies.Query
{
    public record GetMovieByIdQuery : IRequest<MovieDto>
    {
        public int Id { get; set; }
    }

    public class GetMovieByIdQueryHandler : IRequestHandler<GetMovieByIdQuery, MovieDto>
    {
        private readonly IMovieDbContext _dbContext;

        public GetMovieByIdQueryHandler(IMovieDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<MovieDto> Handle(GetMovieByIdQuery request, CancellationToken cancellationToken)
        {
            if (request.Id <= 0)
            {
                throw new Exception("Invalid Id");
            }

            var movie = await _dbContext.Movies.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            if (movie == null)
            {
                throw new Exception("Movie not found");
            }

            return new MovieDto(movie);
        }
    }
}