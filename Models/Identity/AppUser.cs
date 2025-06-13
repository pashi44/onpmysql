using Microsoft.AspNetCore.Identity;

public class AppUser : IdentityUser
{

    //IdentityUser extends from  the  IdentityUser<String>


    public string? Tagname = String.Empty;
    public String? ProfielPicture = String.Empty;


}