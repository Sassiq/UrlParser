using System;

namespace Validator.Contract
{
    public interface IValidator
    {
        bool IsValid(object obj);
    }
}
