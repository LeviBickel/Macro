using System.Security.Claims;
using System.Security.Principal;

public class ClaimsLoader
{
    public static string Role { get; set; }
    public static bool IsInGroup(ClaimsPrincipal User, string GroupName)
    {
        bool check = false;
        var user = (WindowsIdentity)User.Identity;
        if (user.Groups != null)
        {
            foreach (var group in user.Groups)
            {
                check = group.Translate(typeof(NTAccount)).ToString().Contains(GroupName);
                if (check)
                    break;
            }
        }
        return check;
    }
}