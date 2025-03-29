using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using     Microsoft.AspNetCore;
namespace  onpmysql.Models;

public class  Corona{

[Key]

public int Id{get; set;}
    [StringLength(100, MinimumLength = 3,
     ErrorMessage = "Name must be between 3-100 characters")]
    public  string?  Geo {get;set;}
    [StringLength(100, MinimumLength = 3,
     ErrorMessage = "Name must be between 3-100 characters")]
    public string? Text{get;  set;}
    [StringLength(100, MinimumLength = 3,

     ErrorMessage = "Name must be between 3-100 characters")]
public string?  Location{get;set;}
    [StringLength(100, MinimumLength = 3,

     ErrorMessage = "Name must be between 3-100 characters")]

    public string? Entites{get;set;}
    [StringLength(100, MinimumLength = 3,

     ErrorMessage = "Name must be between 3-100 characters")]

    public string? Sentiment{get;set;}

    [StringLength(100, MinimumLength = 3,

     ErrorMessage = "Name must be between 3-100 characters")]

    public string Country{get;set;}  =  null!;
}
