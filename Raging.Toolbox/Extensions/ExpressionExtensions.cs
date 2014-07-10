using System;
using System.Linq.Expressions;

namespace Raging.Toolbox.Extensions
{
    public static class ExpressionExtensions
    {
        public static string GetVariableName<T>(this Expression<Func<T>> source)
        {
            return ((MemberExpression)source.Body).Member.Name;
        }
    }
}