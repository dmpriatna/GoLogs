using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Logging;
using Microsoft.IdentityModel.Tokens;

namespace GoLogs.CustomClearance.Common
{
  public static class Helper
  {
    public static void Changes<TSource, TResult>(this TResult self, TSource source)
    where TResult : class, new()
    {
      if (self == null)
      self = new TResult();

      var properties = source.GetType().GetProperties();
      foreach (var each in properties)
      {
        var en = each.Name;
        var ev = each.GetValue(source);
        if (each.PropertyType.Name != "IEnumerable`1" &&
          each.PropertyType.BaseType.Name != "Array")
        self.GetType().GetProperty(en)?.SetValue(self, ev);
      }
    }
  
    public static IEnumerable<R> SelectSafe<S,R>(this ICollection<S> source, Func<S,R> selector)
    {
      if (source == null) return new List<R>();
      return source.Select(selector);
    }

    private static string Key = "GoLogsAuthKey@678";

    public static JwtDecodedClaims DecodeJwtToken(string accessToken)
    {
      IdentityModelEventSource.ShowPII = true;
      var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Key));
      var handler = new JwtSecurityTokenHandler();
      var validations = new TokenValidationParameters
      {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = secretKey,
        ValidateIssuer = false,
        ValidateAudience = false
      };
      var claims = handler.ValidateToken(accessToken, validations, out var tokenSecure);
      
      return new JwtDecodedClaims()
      {
        Email = claims.FindFirst(ClaimTypes.Email)?.Value,
        Name = claims.FindFirst(ClaimTypes.Name)?.Value,
        PersonId = claims.FindFirst(ClaimTypes.NameIdentifier)?.Value,
        CompanyType = claims.FindFirst(ClaimsIdentity.DefaultRoleClaimType)?.Value,
      }; 
    }
  }

  public class JwtDecodedClaims
  {
    public string Email { get; set; }
    public string Name { get; set; }
    public string PersonId { get; set; }
    public string CompanyType { get; set; }
  }
}