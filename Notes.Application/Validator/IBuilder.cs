using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notes.Application.Validator
{
    public interface IBuilder<T>
    {
        IBuilder<T> RuleFor(Func<T, object> func);
        public IBuilder<T> SetMaxLength(int len);
        public IBuilder<T> SetMinLength(int len);
        public IBuilder<T> SetIsNull(bool isNull);
        public IBuilder<T> SetName(string name);
        public Validator<T> Build();
    }
}
