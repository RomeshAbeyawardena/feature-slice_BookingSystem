using AutoMapper;
using MediatR;
using ContactTypeFeature = BookingSystem.Features.ContactType;
using RST.Contracts;
using Microsoft.EntityFrameworkCore;

namespace BookingSystem.Features.Contact.Save;

public class Handler : RST.Mediatr.Extensions.RepositoryHandlerBase<Command, Models.Contact, Models.Contact>
{
    private readonly IMediator mediator;
    private readonly IMapper mapper;
    
    public Handler(IMediator mediator, IMapper mapper, IServiceProvider serviceProvider)
        : base(serviceProvider)
    {
        this.mediator = mediator;
        this.mapper = mapper;
    }

    public override async Task<Models.Contact> Handle(Command request, CancellationToken cancellationToken)
    {
        var contactTypes = await mediator.Send(new ContactTypeFeature.Get.Query
        {
            ContactTypeId = request.ContactTypeId
        }, cancellationToken);

        if (!await contactTypes.AnyAsync(cancellationToken))
        {
            throw new NullReferenceException("Contact type not found");
        }

        return await base.ProcessSave(request, mapper.Map<Models.Contact>, cancellationToken);
    }
}
