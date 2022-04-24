using Ecole_Coranique.Data;
using Ecole_Coranique.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace Ecole_Coranique.Helpers;

public class Helpers
{
    // These methods check the tables Identification of Etudiants and Enseignants to not return the already listed entries
    public static IQueryable EtudiantsNotAlreadyListed(ApplicationDbContext context) {
        return context.Etudiants.Where(x => !context.IdentificationEtudiants.Select(x => x.EtudiantId).Contains(x.Id));
    }
    public static IQueryable EnseignantsNotAlreadyListed(ApplicationDbContext context) {
        return context.Enseignants.Where(x => !context.IdentificationEnseignants.Select(x => x.EnseignantId).Contains(x.Id));
    }
    /// <summary>
    /// The method exlude the identity users that are already associated with users, teachers, as well as excludes the administrators
    /// Administrators are know by their claims
    /// </summary>
    /// <param name="context"></param>
    /// <returns></returns>
    public static IQueryable IdentityUsersNotAlreadyListed(ApplicationDbContext context) {
        var administrators = context.UserClaims.Where(x => x.ClaimType.Equals(AppClaimType.Concern)).Where(x => x.ClaimValue.Contains(AppClaimValue.Admin));
        var identityUsersNotAlreadyTaken = context.Users.Where(x => !context.IdentificationEtudiants.Select(x => x.IdentityUserId).Contains(x.Id));
        identityUsersNotAlreadyTaken = identityUsersNotAlreadyTaken.Where(x => !context.IdentificationEnseignants.Select(x => x.IdentityUserId).Contains(x.Id));
        identityUsersNotAlreadyTaken = identityUsersNotAlreadyTaken.Where(x => !administrators.Select(x => x.UserId).Contains(x.Id));
        return identityUsersNotAlreadyTaken;
    }
    public static int CurrentTeacherId(ApplicationDbContext context, ClaimsPrincipal user) {
        var userId = user.FindFirstValue(ClaimTypes.NameIdentifier);
        var idCurrent = context.IdentificationEnseignants
                .Where(x => x.IdentityUserId.Equals(userId)).Select(x => x.EnseignantId).FirstOrDefault();
        return idCurrent;
    }
    public static int CurrentStudentId(ApplicationDbContext context, ClaimsPrincipal user) {
        var userId = user.FindFirstValue(ClaimTypes.NameIdentifier);
        var idCurrent = context.IdentificationEtudiants
                .Where(x => x.IdentityUserId.Equals(userId)).Select(x => x.EtudiantId).FirstOrDefault();
        return idCurrent;
    }
    /// <summary>
    /// Generate an Identity User from parameters
    /// </summary>
    /// <param name="userId"></param>
    /// <param name="username"></param>
    /// <param name="password"></param>
    /// <returns></returns>
    public static IdentityUser InitializeIdentityUser(string userId, string username, string password) {
        var identityUser = new IdentityUser {
            Id = userId, // Primary key
            Email = username,
            NormalizedEmail = username.ToUpper(),
            UserName = username,
            NormalizedUserName = username.ToUpper(),
            EmailConfirmed = true,
        };
        identityUser.PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(identityUser, password);
        return identityUser;
    }
}
