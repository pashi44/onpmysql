using Microsoft.AspNetCore.Identity;
namespace Models.Identity;
public class AppUser : IdentityUser
{

    //IdentityUser extends from  the  IdentityUser<String>


    public string? Tagname = String.Empty;
    public String? ProfielPicture = String.Empty;

    public bool Gender { get; set; }
    // public override string? UserName {
    //      get => base.UserName; set => base.UserName = value; }

}