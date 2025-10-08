using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EVRentalSystem.Models;

[Table("Contract")]
public partial class Contract
{
    [Key]
    [Column("contract_id")]
    public int ContractId { get; set; }

    [Column("order_id")]
    public int OrderId { get; set; }

    [Column("signed_date")]
    public DateTime? SignedDate { get; set; }

    [Column("contract_content")]
    public string? ContractContent { get; set; }

    [Column("contract_pdf_url")]
    [StringLength(255)]
    public string? ContractPdfUrl { get; set; }

    [ForeignKey("OrderId")]
    [InverseProperty("Contracts")]
    public virtual RentalOrder Order { get; set; } = null!;
}
