﻿using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HomesEngland.AHP.Data;

public class Scheme
{
	[Required, Key]
	public Guid SchemeId { get; set; }

	[Required, StringLength(200)]
	public required string SchemeName { get; set; }

	[Required]
	public Guid ProviderId { get; set; }

	public Provider? Provider { get; set; }

	[Required]
	public Guid ProgrammeId { get; set; }

	public Programme? Programme { get; set; }

	public ICollection<Property>? Properties { get; set; }

	public ICollection<GrantMilestone>? GrantMilestones { get; set; }

	public ICollection<SchemeRevenueClaim>? RevenueFundingClaims { get; set; }

	[Column(TypeName = ColumnTypes.Money)]
	public decimal? TotalGrantAmount { get; set; }

	[Column(TypeName = ColumnTypes.Money)]
	public decimal? TotalRevenueFundingAmount { get; set; }

	[Column(TypeName = ColumnTypes.Money)]
	public decimal? TotalAmount { get; set; }

	[Required]
	public bool Complete { get; set; }

	public DateTimeOffset? Completed { get; set; }

	public Guid? LocalAuthorityId { get; set; }

	public LocalAuthority? LocalAuthority { get; set; }

	[Required]
	public required string StatusName { get; set; }

	[Required]
	public int StatusCode { get; set; }
}
