using System;
using System.Collections.Generic;

namespace Doctor.Service.Models.EntityModel;

public partial class DoctorInformation
{
    public int Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string? LastName { get; set; }

    public int Age { get; set; }

    public string Gander { get; set; } = null!;

    public byte[]? Image { get; set; }

    public decimal Phone { get; set; }

    public int EducationId { get; set; }

    public int CountryId { get; set; }

    public int? DivisionId { get; set; }

    public int? DistrictId { get; set; }

    public DateTime CreateDate { get; set; }

    public DateTime UpdateDate { get; set; }

    public int UpdateBy { get; set; }

    public string LastAction { get; set; } = null!;

    public string Status { get; set; } = null!;
}
