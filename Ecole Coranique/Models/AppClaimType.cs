using Microsoft.AspNetCore.Authorization;

namespace Ecole_Coranique.Models;

public class AppClaimType
{
    public const string Concern = "Concern";
}
public class AppClaimValue
{
    public const string Admin = "Admin";
    public const string Teacher = "Teacher";
    public const string Student = "Student";
}
public class AppPolicyName
{
    public const string Administration = "Administration";
    public const string TeacherTrack = "Teachning activities";
    public const string StudentTrack = "Student activities";
}
