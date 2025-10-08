using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EVRentalSystem.Models;

[Table("Image")]
public partial class Image
{
    [Key]
    [Column("image_id")]
    public int ImageId { get; set; }

    [Column("related_type")]
    [StringLength(50)]
    public string RelatedType { get; set; } = null!;

    [Column("related_id")]
    public int RelatedId { get; set; }

    [Column("url")]
    [StringLength(255)]
    public string Url { get; set; } = null!;

    [Column("uploaded_at")]
    public DateTime? UploadedAt { get; set; }
}
