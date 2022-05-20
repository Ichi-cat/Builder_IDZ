using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Notes.Application.Common.Exceptions;

namespace Notes.Application.Validator
{
    public class Validator<T>
    {
        private readonly Func<T, object> func;
        private T value;

        private string name;
        private int maxLength;
        private int minLength;
        private bool isNull;

        private List<string> errors = new List<string>();
        public Validator(Func<T, object> func, int maxLength, int minLength, bool isNull, string name)
        {
            this.func = func;
            this.maxLength = maxLength;
            this.minLength = minLength;
            this.isNull = isNull;
            this.name = name;
        }
        private void ValidateLength()
        {
            var len = 0;
            try
            {
                len = this.func.Invoke(value).ToString().Length;
                
            }
            catch (NullReferenceException)
            {
                throw new BadRequestException(this.name, "Null object may not has length");
            }
            if (len < minLength) throw new BadRequestException(this.name, "Min length is " + minLength);
            if (len > maxLength && maxLength != 0) throw new BadRequestException(this.name, "Max length is " + maxLength);
        }
        private void ValidateIsNullOrEmpty()
        {
            bool nulling = false;
            try
            {
                nulling = string.IsNullOrEmpty(this.func.Invoke(value).ToString());
            }
            catch (NullReferenceException)
            {
                if (!isNull) throw new BadRequestException(this.name, "Object may not be null");
            }
            if (nulling && !isNull) throw new BadRequestException(this.name, "Field may not be empty");
        }
        public List<string> Validate(T obj)
        {
            this.value = obj;
            ValidateLength();
            ValidateIsNullOrEmpty();
            return errors;
        }
    }
}
