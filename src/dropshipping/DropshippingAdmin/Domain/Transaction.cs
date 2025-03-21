﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace InfrastructureService.Domain;

public partial class Transaction
{
    public Guid Id { get; set; }

    public string TransactionId { get; set; }

    public Guid PaymentId { get; set; }

    public string Gateway { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual Payment Payment { get; set; }
}