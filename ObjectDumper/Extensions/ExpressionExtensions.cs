namespace System.Linq.Expressions
{
    public static class ExpressionExtensions
    {
        public static string GetPropertyName<T, TResult>(this Expression<Func<T, TResult>> expression)
        {
            MemberExpression memberExpression = (MemberExpression)expression.Body;
            return memberExpression.IsNotNull() ? memberExpression.Member.Name : null;
        }     
    }
}
