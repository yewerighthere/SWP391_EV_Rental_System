using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EVRentalSystem.Models;

[Table("Vehicle")]
[Index("StationId", Name = "IDX_Vehicle_Station")]
[Index("LicensePlate", Name = "UQ__Vehicle__F72CD56E4B9670C7", IsUnique = true)]
public partial class Vehicle
{
    [Key]
    [Column("vehicle_id")]
    public int VehicleId { get; set; }

    [Column("license_plate")]
    [StringLength(50)]
    public string LicensePlate { get; set; } = null!;

    [Column("vehicle_model_id")]
    public int VehicleModelId { get; set; }

    [Column("model")]
    [StringLength(100)]
    public string Model { get; set; } = null!;

    [Column("release_year")]
    public int? ReleaseYear { get; set; }

    [Column("battery_capacity")]
    public int? BatteryCapacity { get; set; }

    [Column("current_mileage")]
    public int? CurrentMileage { get; set; }

    [Column("img_car_url")]
    [StringLength(255)]
    public string? ImgCarUrl { get; set; }

    [Column("condition")]
    [StringLength(20)]
    public string? Condition { get; set; }

    [Column("is_available")]
    public bool? IsAvailable { get; set; }

    [Column("station_id")]
    public int? StationId { get; set; }

    [Column("created_at")]
    public DateTime CreatedAt { get; set; }

    [InverseProperty("Vehicle")]
    public virtual ICollection<RentalOrder> RentalOrders { get; set; } = new List<RentalOrder>();

    [ForeignKey("StationId")]
    [InverseProperty("Vehicles")]
    public virtual Station? Station { get; set; }

    [ForeignKey("VehicleModelId")]
    [InverseProperty("Vehicles")]
    public virtual VehicleModel VehicleModel { get; set; } = null!;
}
