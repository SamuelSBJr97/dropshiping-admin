﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace InfrastructureService.Domain;

public partial class WhatsAppMessagesStatus
{
    public Guid Id { get; set; }

    public string Status { get; set; }

    public DateTime? SentAt { get; set; }

    public virtual ICollection<WhatsAppMessage> WhatsAppMessages { get; set; } = new List<WhatsAppMessage>();
}