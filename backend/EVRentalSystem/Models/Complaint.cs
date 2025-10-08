using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EVRentalSystem.Models;

[Table("Complaint")]
public partial class Complaint
{
    [Key]
    [Column("complaint_id")]
    public int ComplaintId { get; set; }

    [Column("renter_id")]
    public int RenterId { get; set; }

    [Column("order_id")]
    public int? OrderId { get; set; }

    [Column("description")]
    public string? Description { get; set; }

    [Column("created_date")]
    public DateTime? CreatedDate { get; set; }

    [Column("resolve_date")]
    public DateTime? ResolveDate { get; set; }

    [Column("resolve_by_staff_id")]
    public int? ResolveByStaffId { get; set; }

    [Column("status")]
    [StringLength(50)]
    public string? Status { get; set; }

    [ForeignKey("OrderId")]
    [InverseProperty("Complaints")]
    public virtual RentalOrder? Order { get; set; }

    [ForeignKey("RenterId")]
    [InverseProperty("Complaints")]
    public virtual Renter Renter { get; set; } = null!;

    [ForeignKey("ResolveByStaffId")]
    [InverseProperty("Complaints")]
    public virtual Staff? ResolveByStaff { get; set; }
}
