using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EVRentalSystem.Models;

[Table("Log_History")]
public partial class LogHistory
{
    [Key]
    [Column("log_id")]
    public int LogId { get; set; }

    [Column("user_id")]
    public int? UserId { get; set; }

    [Column("log_type")]
    [StringLength(50)]
    public string? LogType { get; set; }

    [Column("action")]
    public string? Action { get; set; }

    [Column("log_date")]
    public DateTime? LogDate { get; set; }

    [ForeignKey("UserId")]
    [InverseProperty("LogHistories")]
    public virtual User? User { get; set; }
}
