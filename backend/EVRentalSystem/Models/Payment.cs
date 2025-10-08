using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EVRentalSystem.Models;

[Table("Payment")]
public partial class Payment
{
    [Key]
    [Column("payment_id")]
    public int PaymentId { get; set; }

    [Column("order_id")]
    public int OrderId { get; set; }

    [Column("amount", TypeName = "decimal(12, 2)")]
    public decimal Amount { get; set; }

    [Column("payment_method")]
    [StringLength(50)]
    public string? PaymentMethod { get; set; }

    [Column("payment_date")]
    public DateTime? PaymentDate { get; set; }

    [Column("external_ref")]
    [StringLength(255)]
    public string? ExternalRef { get; set; }

    [ForeignKey("OrderId")]
    [InverseProperty("Payments")]
    public virtual RentalOrder Order { get; set; } = null!;
}
