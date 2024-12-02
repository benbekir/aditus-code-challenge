using System.ComponentModel.DataAnnotations;

namespace ADITUS.CodeChallenge.API.Domain.Events;

[Flags]
public enum EventType
{
  [Display(Name = "OnSite")]
  OnSite = 1,

  [Display(Name = "Online")]
  Online = 2,

  [Display(Name = "Hybrid")]
  Hybrid = OnSite | Online
}