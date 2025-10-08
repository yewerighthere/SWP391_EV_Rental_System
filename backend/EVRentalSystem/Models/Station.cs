using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EVRentalSystem.Models;

[Table("Station")]
public partial class Station
{
    [Key]
    [Column("station_id")]
    public int StationId { get; set; }

    [Column("station_name")]
    [StringLength(255)]
    public string StationName { get; set; } = null!;

    [Column("address")]
    [StringLength(500)]
    public string Address { get; set; } = null!;

    [Column("latitude", TypeName = "decimal(10, 8)")]
    public decimal? Latitude { get; set; }

    [Column("longitude", TypeName = "decimal(11, 8)")]
    public decimal? Longitude { get; set; }

    [Column("status")]
    [StringLength(10)]
    public string Status { get; set; } = null!;

    [Column("created_at")]
    public DateTime CreatedAt { get; set; }

    [Column("capacity")]
    public int Capacity { get; set; }

    [InverseProperty("PickupStation")]
    public virtual ICollection<RentalOrder> RentalOrderPickupStations { get; set; } = new List<RentalOrder>();

    [InverseProperty("ReturnStation")]
    public virtual ICollection<RentalOrder> RentalOrderReturnStations { get; set; } = new List<RentalOrder>();

    [InverseProperty("Station")]
    public virtual ICollection<Staff> Staff { get; set; } = new List<Staff>();

    [InverseProperty("Station")]
    public virtual ICollection<Vehicle> Vehicles { get; set; } = new List<Vehicle>();
}
