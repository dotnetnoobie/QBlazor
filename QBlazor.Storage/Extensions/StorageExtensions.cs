using System;
using System.Linq.Expressions;

namespace QBlazor
{
    public static class StorageExtensions
    {
        public static string GetKey<T>(this Expression<Func<T>> expression)
        {
            var member = ((MemberExpression)expression.Body).Member;
            var name = member.Name;
            var key = member.DeclaringType.FullName + "." + name;

            return key;
        }

        public static T GetValue<T>(this Expression<Func<T>> expression)
        {
            var value = expression.Compile()();

            return value;
        }
    }
}