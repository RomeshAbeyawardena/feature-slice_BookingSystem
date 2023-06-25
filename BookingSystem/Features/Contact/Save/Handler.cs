using AutoMapper;
using MediatR;
using ContactTypeFeature = BookingSystem.Features.ContactType;
using RST.Contracts;
using Microsoft.EntityFrameworkCore;
using RST.DependencyInjection.Extensions.Attributes;

namespace BookingSystem.Features.Contact.Save;

public class Handler : RST.Mediatr.Extensions.RepositoryHandlerBase<Command, Models.Contact, Models.Contact>
{
    [Inject]
    protected IMediator? Mediator { get; set; }

    [Inject]
    protected IMapper? Mapper { get; set; }

    public Handler(IServiceProvider serviceProvider)
        : base(serviceProvider)
    {
        this.ConfigureInjection();
    }

    public override async Task<Models.Contact> Handle(Command request, CancellationToken cancellationToken)
    {
        var contactTypes = await Mediator!.Send(new ContactTypeFeature.Get.Query
        {
            ContactTypeId = request.ContactTypeId
        }, cancellationToken);

        if (!await contactTypes.AnyAsync(cancellationToken))
        {
            throw new NullReferenceException("Contact type not found");
        }

        return await base.ProcessSave(request, Mapper!.Map<Models.Contact>, cancellationToken);
    }
}
