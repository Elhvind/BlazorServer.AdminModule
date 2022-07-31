using ApplicationCore.Common.Mappings;
using ApplicationCore.Common.Models;
using AutoMapper.QueryableExtensions;
using Domain.Entities;
using static ApplicationCore.Vouchers.GetVouchersWithPaginationQueryResponse;

namespace ApplicationCore.Vouchers;

public class GetVouchersWithPaginationQueryResponse
{
    public PaginatedList<VoucherDTO> Vouchers { get; set; } = null!;

    public class VoucherDTO : IMapFrom<Voucher>
    {
        public int Id { get; set; }
        public string Code { get; set; } = null!;
    }
}

public record GetVouchersWithPaginationQuery : IRequest<GetVouchersWithPaginationQueryResponse>
{
    public int PageNumber { get; init; } = 1;
    public int PageSize { get; init; } = 10;
}

public class GetTodoItemsWithPaginationQueryValidator : AbstractValidator<GetVouchersWithPaginationQuery>
{
    public GetTodoItemsWithPaginationQueryValidator()
    {
        RuleFor(x => x.PageNumber)
            .GreaterThanOrEqualTo(1);

        RuleFor(x => x.PageSize)
            .GreaterThanOrEqualTo(1);
    }
}

public class GetVouchersWithPaginationQueryHandler : IRequestHandler<GetVouchersWithPaginationQuery, GetVouchersWithPaginationQueryResponse>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetVouchersWithPaginationQueryHandler(
        IApplicationDbContext context,
        IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<GetVouchersWithPaginationQueryResponse> Handle(GetVouchersWithPaginationQuery request, CancellationToken cancellationToken)
    {
        var vouchers = await _context.Vouchers
            .OrderByDescending(x => x.Created)
            .ProjectTo<VoucherDTO>(_mapper.ConfigurationProvider)
            .PaginatedListAsync(request.PageNumber, request.PageSize);

        return new()
        {
            Vouchers = vouchers
        };
    }
}
