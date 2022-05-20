using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notes.Application.Validator
{
    public abstract class IValidating<T>
    {
        protected Builder<T> builder = new Builder<T>();
        public abstract void Valid(T obj);
    }
}
