namespace Domain.Entities;

public class Voucher : BaseAuditableEntity
{
    public string Code { get; set; } = null!;
}
