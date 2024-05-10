using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Food_Delivery_API.Authority;

public class Application
{
    public int ApplicationId {get; set;}
    public string? ApplicationName {get; set;} 
    public string? ClientId {get; set;}
    public string? Secret {get; set;}
}