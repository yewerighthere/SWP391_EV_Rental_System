using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EVRentalSystem.Models;

public partial class Staff
{
    [Key]
    [Column("staff_id")]
    public int StaffId { get; set; }

    [Column("user_id")]
    public int UserId { get; set; }

    [Column("position")]
    [StringLength(50)]
    public string Position { get; set; } = null!;

    [Column("station_id")]
    public int? StationId { get; set; }

    [Column("hire_date")]
    public DateTime HireDate { get; set; }

    [InverseProperty("ResolveByStaff")]
    public virtual ICollection<Complaint> Complaints { get; set; } = new List<Complaint>();

    [InverseProperty("Staff")]
    public virtual ICollection<Handover> Handovers { get; set; } = new List<Handover>();

    [ForeignKey("StationId")]
    [InverseProperty("Staff")]
    public virtual Station? Station { get; set; }

    [ForeignKey("UserId")]
    [InverseProperty("Staff")]
    public virtual User User { get; set; } = null!;
}
