using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EVRentalSystem.Models;

[Table("RentalOrder")]
[Index("RenterId", Name = "IDX_RentalOrder_Renter")]
public partial class RentalOrder
{
    [Key]
    [Column("order_id")]
    public int OrderId { get; set; }

    [Column("renter_id")]
    public int RenterId { get; set; }

    [Column("vehicle_id")]
    public int VehicleId { get; set; }

    [Column("pickup_station_id")]
    public int? PickupStationId { get; set; }

    [Column("return_station_id")]
    public int? ReturnStationId { get; set; }

    [Column("start_time")]
    public DateTime StartTime { get; set; }

    [Column("end_time")]
    public DateTime? EndTime { get; set; }

    [Column("total_amount", TypeName = "decimal(12, 2)")]
    public decimal? TotalAmount { get; set; }

    [Column("deposit_amount", TypeName = "decimal(12, 2)")]
    public decimal? DepositAmount { get; set; }

    [Column("payment_status")]
    [StringLength(20)]
    public string? PaymentStatus { get; set; }

    [Column("status")]
    [StringLength(50)]
    public string? Status { get; set; }

    [Column("created_at")]
    public DateTime? CreatedAt { get; set; }

    [InverseProperty("Order")]
    public virtual ICollection<Complaint> Complaints { get; set; } = new List<Complaint>();

    [InverseProperty("Order")]
    public virtual ICollection<Contract> Contracts { get; set; } = new List<Contract>();

    [InverseProperty("Order")]
    public virtual ICollection<ExtraFee> ExtraFees { get; set; } = new List<ExtraFee>();

    [InverseProperty("Order")]
    public virtual ICollection<Handover> Handovers { get; set; } = new List<Handover>();

    [InverseProperty("Order")]
    public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();

    [ForeignKey("PickupStationId")]
    [InverseProperty("RentalOrderPickupStations")]
    public virtual Station? PickupStation { get; set; }

    [ForeignKey("RenterId")]
    [InverseProperty("RentalOrders")]
    public virtual Renter Renter { get; set; } = null!;

    [ForeignKey("ReturnStationId")]
    [InverseProperty("RentalOrderReturnStations")]
    public virtual Station? ReturnStation { get; set; }

    [ForeignKey("VehicleId")]
    [InverseProperty("RentalOrders")]
    public virtual Vehicle Vehicle { get; set; } = null!;
}
