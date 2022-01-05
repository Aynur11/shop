using CSharpFunctionalExtensions;
using System.Collections.Generic;

namespace Domain
{
    public class ProductQuantity : ValueObject
    {
        private readonly int _value;
        private ProductQuantity(int value)
        {
            _value = value;
        }

        public int Value => _value;

        public static Result<ProductQuantity> Create(int value)
        {
            if (value < 0)
            {
                return Result.Failure<ProductQuantity>("Количество должно быть больше или равно нулю");
            }
            return Result.Success(new ProductQuantity(value));
        }
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return _value;
        }
    }
}
