using Application.Common.Dto;
using Domain.Entities;
using Infrastructure.Persistence;
using MediatR;


namespace Application.Movies.Command
{
    public record DeleteMovieCommand : IRequest<Unit>
    {
        public int Id { get; set; }
    }

    public class DeleteMovieCommandHandler : IRequestHandler<DeleteMovieCommand, Unit>
    {
        private readonly IMovieDbContext _dbContext;

        public DeleteMovieCommandHandler(IMovieDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Unit> Handle(DeleteMovieCommand request, CancellationToken cancellationToken)
        {
            if (request.Id == null)
            {
                throw new Exception("No Id to delete ");
            }
            var actualMovie = _dbContext.Movies.FirstOrDefault(x => x.Id == request.Id);
            if (actualMovie == null)
            {
                throw new Exception("Movie not found");
            }

            _dbContext.Movies.Remove(actualMovie);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
