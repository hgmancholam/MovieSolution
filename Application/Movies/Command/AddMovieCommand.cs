using Application.Common.Dto;
using Infrastructure.Persistence;
using MediatR;

namespace Application.Movies.Command
{
    public record AddMovieCommand : IRequest<Unit>
    {
        public MovieDto? MovieToAdd { get; set; }
    }

    public class AddMovieCommandHandler : IRequestHandler<AddMovieCommand, Unit>
    {
        private readonly IMovieDbContext _dbContext;

        public AddMovieCommandHandler(IMovieDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Unit> Handle(AddMovieCommand request, CancellationToken cancellationToken)
        {
            if (request.MovieToAdd == null)
            {
                throw new Exception("No Movie to add");
            }

            var movie = request.MovieToAdd.ToMovie();
            _dbContext.Movies.Add(movie);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}