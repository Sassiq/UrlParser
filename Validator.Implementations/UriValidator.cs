using System;
using System.Text.RegularExpressions;
using Validator.Contract;

namespace Validator.Implementations
{
    public class UriValidator : IValidator
    {
        public bool IsValid(object obj)
        {
            Uri uri = obj as Uri;

            if (uri is null)
            {
                throw new ArgumentNullException(nameof(obj));
            }

            Regex regex = new Regex(@"\??(?:&?[^=&]*=[^=&]*)*");
            if (uri.Query.Length > 0 && !regex.IsMatch(uri.Query))
            {
                return false;
            }

            return true;
        }
    }
}
