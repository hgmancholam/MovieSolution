using Application.Common.Dto;
using Infrastructure.Persistence;
using MediatR;

namespace Application.Movies.Command
{
    public record UpdateMovieCommand : IRequest<Unit>
    {
        public MovieDto? MovieToAdd { get; set; }
    }

    public class UpdateMovieCommandHandler : IRequestHandler<UpdateMovieCommand, Unit>
    {
        private readonly IMovieDbContext _dbContext;

        public UpdateMovieCommandHandler(IMovieDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Unit> Handle(UpdateMovieCommand request, CancellationToken cancellationToken)
        {
            if (request.MovieToAdd == null)
            {
                throw new Exception("No Movie to Update");
            }
            var actualMovie = _dbContext.Movies.FirstOrDefault(x => x.Id == request.MovieToAdd.Id);
            if (actualMovie == null)
            {
                throw new Exception("Movie not found");
            }
            actualMovie.Title = request.MovieToAdd.Title;
            actualMovie.Director = request.MovieToAdd.Director;
            actualMovie.Year = request.MovieToAdd.Year;
            await _dbContext.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}