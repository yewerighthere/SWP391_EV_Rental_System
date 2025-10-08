using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EVRentalSystem.Models;

[Table("Renter")]
[Index("UserId", Name = "IDX_Renter_User")]
[Index("DriverLicenseNumber", Name = "UQ__Renter__4A36048FF3BF5C8A", IsUnique = true)]
[Index("IdCardNumber", Name = "UQ__Renter__7B15C048BE79D9A0", IsUnique = true)]
public partial class Renter
{
    [Key]
    [Column("renter_id")]
    public int RenterId { get; set; }

    [Column("user_id")]
    public int UserId { get; set; }

    [Column("url_cccd_cmnd")]
    [StringLength(255)]
    public string? UrlCccdCmnd { get; set; }

    [Column("id_card_number")]
    [StringLength(50)]
    public string IdCardNumber { get; set; } = null!;

    [Column("url_driver_license")]
    [StringLength(255)]
    public string? UrlDriverLicense { get; set; }

    [Column("driver_license_number")]
    [StringLength(50)]
    public string DriverLicenseNumber { get; set; } = null!;

    [Column("date_of_birth")]
    public DateOnly? DateOfBirth { get; set; }

    [Column("address")]
    [StringLength(255)]
    public string? Address { get; set; }

    [Column("registration_date")]
    public DateTime? RegistrationDate { get; set; }

    [Column("is_verified")]
    public bool? IsVerified { get; set; }

    [InverseProperty("Renter")]
    public virtual ICollection<Complaint> Complaints { get; set; } = new List<Complaint>();

    [InverseProperty("Renter")]
    public virtual ICollection<RentalOrder> RentalOrders { get; set; } = new List<RentalOrder>();

    [ForeignKey("UserId")]
    [InverseProperty("Renters")]
    public virtual User User { get; set; } = null!;
}
