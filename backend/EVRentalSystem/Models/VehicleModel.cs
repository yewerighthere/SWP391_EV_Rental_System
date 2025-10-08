using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EVRentalSystem.Models;

[Table("Vehicle_Model")]
public partial class VehicleModel
{
    [Key]
    [Column("vehicle_model_id")]
    public int VehicleModelId { get; set; }

    [Column("brand_name")]
    [StringLength(100)]
    public string BrandName { get; set; } = null!;

    [Column("vehicle_color")]
    [StringLength(50)]
    public string? VehicleColor { get; set; }

    [Column("number_of_seats")]
    public int NumberOfSeats { get; set; }

    [Column("mileage")]
    public int? Mileage { get; set; }

    [InverseProperty("VehicleModel")]
    public virtual ICollection<Vehicle> Vehicles { get; set; } = new List<Vehicle>();
}
