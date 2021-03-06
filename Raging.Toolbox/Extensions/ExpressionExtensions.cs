﻿using System;
using System.Linq.Expressions;

namespace Raging.Toolbox.Extensions
{
    // ReSharper disable PossibleNullReferenceException
    public static class ExpressionExtensions
    {
        public static string GetParameterName<T>(this Expression<Func<T>> reference)
        {
            return ((MemberExpression)reference.Body).Member.Name;
        }

        public static string GetParameterName(this Expression reference)
        {
            var lambda = reference as LambdaExpression;
            var member = lambda.Body as MemberExpression;

            return member.Member.Name;
        }
    }
    // ReSharper restore PossibleNullReferenceException
}