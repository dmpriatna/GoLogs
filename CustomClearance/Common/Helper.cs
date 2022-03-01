using System;
using System.Collections.Generic;
using System.Linq;

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
  }
}