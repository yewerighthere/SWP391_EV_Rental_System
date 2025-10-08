using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EVRentalSystem.Models;

[Table("Handover")]
public partial class Handover
{
    [Key]
    [Column("handover_id")]
    public int HandoverId { get; set; }

    [Column("order_id")]
    public int OrderId { get; set; }

    [Column("staff_id")]
    public int? StaffId { get; set; }

    [Column("handover_type")]
    [StringLength(10)]
    public string HandoverType { get; set; } = null!;

    [Column("condition_notes")]
    public string? ConditionNotes { get; set; }

    [Column("photo_url")]
    [StringLength(255)]
    public string? PhotoUrl { get; set; }

    [Column("handover_timestamp")]
    public DateTime? HandoverTimestamp { get; set; }

    [ForeignKey("OrderId")]
    [InverseProperty("Handovers")]
    public virtual RentalOrder Order { get; set; } = null!;

    [ForeignKey("StaffId")]
    [InverseProperty("Handovers")]
    public virtual Staff? Staff { get; set; }
}
