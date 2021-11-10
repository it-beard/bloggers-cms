using System.ComponentModel.DataAnnotations;
using Pds.Core.Enums;

namespace Pds.Api.Contracts.Bill;

public class EditBillRequest
{
    [Required]
    public Guid Id { get; set; }

    [Required]
    [Range(10.00, Double.MaxValue, ErrorMessage = "Значение поля {0} должно быть больше чем {1}.")]
    public decimal Value { get; set; }

    public string Comment { get; set; }

    public string ContractNumber { get; set; }

    public DateTime? ContractDate { get; set; }

    public bool IsNeedPayNds { get; set; }

    [Required]
    public DateTime PaidAt { get; set; }

    [Required, EnumDataType(typeof(BillType))]
    public BillType Type { get; set; }

    [Required, EnumDataType(typeof(PaymentType))]
    public PaymentType PaymentType { get; set; }

    [Required]
    public Guid BrandId { get; set; }

    public BillContentDto Content { get; set; }
}