using System;
using System.Collections.Generic;
using System.Text;

namespace Sadad.Core.Entities.Exceptions
{
    public class AppExecption : ApplicationException
    {
        public AppExecption(string massage) : base(massage)
        {

        }
    }
}
