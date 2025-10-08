using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EVRentalSystem.Models;

[Table("ExtraFee")]
public partial class ExtraFee
{
    [Key]
    [Column("fee_id")]
    public int FeeId { get; set; }

    [Column("order_id")]
    public int OrderId { get; set; }

    [Column("fee_type")]
    [StringLength(100)]
    public string? FeeType { get; set; }

    [Column("amount", TypeName = "decimal(12, 2)")]
    public decimal? Amount { get; set; }

    [Column("description")]
    public string? Description { get; set; }

    [Column("created_at")]
    public DateTime? CreatedAt { get; set; }

    [ForeignKey("OrderId")]
    [InverseProperty("ExtraFees")]
    public virtual RentalOrder Order { get; set; } = null!;
}
