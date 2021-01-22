using Microsoft.EntityFrameworkCore;
using MySql.Data.EntityFrameworkCore.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace WappExcelNobleza.Data
{
    public static partial class ExpressionUtils
    {
        public sealed class ComparisonTypes
        {
            private readonly string value;

            public static readonly ComparisonTypes Equal = new ComparisonTypes("==");
            public static readonly ComparisonTypes NotEqual = new ComparisonTypes("!=");
            public static readonly ComparisonTypes GreaterThan = new ComparisonTypes(">");
            public static readonly ComparisonTypes GreaterThanOrEqual = new ComparisonTypes(">=");
            public static readonly ComparisonTypes LessThan = new ComparisonTypes("<");
            public static readonly ComparisonTypes LessThanOrEqual = new ComparisonTypes("<=");
            public static readonly ComparisonTypes Contains = new ComparisonTypes("Contains");
            public static readonly ComparisonTypes StartsWith = new ComparisonTypes("StartsWith");
            public static readonly ComparisonTypes EndsWith = new ComparisonTypes("EndsWith");

            private ComparisonTypes(string value)
            {
                this.value = value;
            }

            public override String ToString()
            {
                return value;
            }
        }

        
        public static Expression<Func<T, bool>> BuildPredicate<T>(IEnumerable<string> propertyNames, ComparisonTypes comparison, string value)
        {
            if (!propertyNames.Any())
            {
                throw new Exception("No hay elementos en la coleccion de nombre de propiedades");
            }

            var itemParameter = Expression.Parameter(typeof(T), "item");
            Expression selectorExpression = null;
            foreach (var property in propertyNames)
            {
                var previousSelectorExpression = selectorExpression;

                var left = property.Split('.').Aggregate((Expression)itemParameter, Expression.Property);

                selectorExpression = MakeComparison(left, comparison, value);

                if (previousSelectorExpression != null)
                {
                    selectorExpression = Expression.Or(previousSelectorExpression, selectorExpression);
                }
            }

            return Expression.Lambda<Func<T, bool>>(selectorExpression, itemParameter);
        }
        private static Expression MakeComparison(Expression left, ComparisonTypes comparison, string value)
        {
            switch (comparison.ToString())
            {
                case "==":
                    return MakeBinary(ExpressionType.Equal, left, value);
                case "!=":
                    return MakeBinary(ExpressionType.NotEqual, left, value);
                case ">":
                    return MakeBinary(ExpressionType.GreaterThan, left, value);
                case ">=":
                    return MakeBinary(ExpressionType.GreaterThanOrEqual, left, value);
                case "<":
                    return MakeBinary(ExpressionType.LessThan, left, value);
                case "<=":
                    return MakeBinary(ExpressionType.LessThanOrEqual, left, value);
                case "Contains":
                case "StartsWith":
                case "EndsWith":
                    return Expression.Call(MakeString(left), comparison.ToString(), Type.EmptyTypes, Expression.Constant(value, typeof(string)));
                default:
                    throw new NotSupportedException($"Invalid comparison operator '{comparison}'.");
            }
        }
        private static Expression MakeString(Expression source)
        {
            return source.Type == typeof(string) ? source : Expression.Call(source, "ToString", Type.EmptyTypes);
        }
        private static Expression MakeBinary(ExpressionType type, Expression left, string value)
        {
            object typedValue = value;
            if (left.Type != typeof(string))
            {
                if (string.IsNullOrEmpty(value))
                {
                    typedValue = null;
                    if (Nullable.GetUnderlyingType(left.Type) == null)
                        left = Expression.Convert(left, typeof(Nullable<>).MakeGenericType(left.Type));
                }
                else
                {
                    var valueType = Nullable.GetUnderlyingType(left.Type) ?? left.Type;
                    typedValue = valueType.IsEnum ? Enum.Parse(valueType, value) :
                        valueType == typeof(Guid) ? Guid.Parse(value) :
                        Convert.ChangeType(value, valueType);
                }
            }
            var right = Expression.Constant(typedValue, left.Type);
            return Expression.MakeBinary(type, left, right);
        }
    }
}
