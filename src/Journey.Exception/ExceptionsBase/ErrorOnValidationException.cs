using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;

namespace Journey.Exception.ExceptionsBase
{
    public class ErrorOnValidationException : JourneyException
    {
        private readonly IList<string> _errors; // so o construtor vai preencher o valor dessa propriedade
        // private entao _ antes

        public ErrorOnValidationException(IList<string> messages) : base(string.Empty)
        {
            // caso especifico que recebe lista e nao pode alterar classe pai
            _errors = messages;
        }

        
        public override HttpStatusCode GetStatusCode()
        {
            return HttpStatusCode.BadRequest;
        }

        public override IList<string> GetErrorMessages()
        {
            return _errors;
        }
    }
}
