namespace Domain.Entities;

public class Voucher : BaseAuditableEntity
{
    private const int LengthOfVoucher = 20;

    private Voucher()
    {
        // required by EF
    }

    public static Voucher NewVoucher()
    {
        var random = new Random();
        var keys = "ABCDEFGHIJKLMNOPQRSTUVWXYZ01234567890".ToCharArray();

        return new Voucher()
        {
            Code = Enumerable
                .Range(1, LengthOfVoucher)
                .Select(k => keys[random.Next(0, keys.Length - 1)])
                .Aggregate("", (e, c) => e + c)
        };
    }

    public string Code { get; private set; } = null!;

    public string UserGuid { get; private set; } = null!;

    public void AssignToUser(string userGuid)
    {
        UserGuid = userGuid;
    }
}
