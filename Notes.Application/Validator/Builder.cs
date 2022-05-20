using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notes.Application.Validator
{
    public class Builder<T> : IBuilder<T>
    {
        private int maxLength;
        private int minLength;
        private bool isNull;
        private string name;
        private Func<T, object> func;
        public IBuilder<T> RuleFor(Func<T, object> func)
        {
            this.func = func;
            return this;
        }
        public IBuilder<T> SetMaxLength(int len)
        {
            this.maxLength = len;
            return this;
        }
        public IBuilder<T> SetMinLength(int len)
        {
            this.minLength = len;
            return this;
        }
        public IBuilder<T> SetIsNull(bool isNull)
        {
            this.isNull = isNull;
            return this;
        }
        public IBuilder<T> SetName(string name)
        {
            this.name = name;
            return this;
        }
        public Validator<T> Build()
        {
            return new Validator<T>(func, maxLength, minLength, isNull, name);
        }
    }
}
