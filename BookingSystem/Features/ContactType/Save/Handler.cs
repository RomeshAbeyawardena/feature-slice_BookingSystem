using AutoMapper;
using RST.DependencyInjection.Extensions.Attributes;

namespace BookingSystem.Features.ContactType.Save;

public class Handler : RST.Mediatr.Extensions.RepositoryHandlerBase<Command, Models.ContactType, Models.ContactType>
{
    [Inject]
    protected IMapper? Mapper { get; set; }

    public Handler(IServiceProvider serviceProvider) : base(serviceProvider)
    {
    }

    public override Task<Models.ContactType> Handle(Command request, CancellationToken cancellationToken)
    {
        return base.ProcessSave(request, Mapper!.Map<Models.ContactType>, cancellationToken);
    }
}
