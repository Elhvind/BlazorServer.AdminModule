using Domain.Entities;

namespace ApplicationCore.Vouchers;

public record CreateVoucherCommand : IRequest<int>
{
}

public class CreateVoucherCommandHandler : IRequestHandler<CreateVoucherCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreateVoucherCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateVoucherCommand request, CancellationToken cancellationToken)
    {
        var voucher = Voucher.NewVoucher();

        await _context.Vouchers.AddAsync(voucher, cancellationToken);

        await _context.SaveChangesAsync(cancellationToken);

        return voucher.Id;
    }
}
