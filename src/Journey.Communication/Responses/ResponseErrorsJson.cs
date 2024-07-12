using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Journey.Communication.Responses
{
    public class ResponseErrorsJson
    {
        // cria lista de erros iniciando vazia
        public IList<string> Errors { get; set; } = [];
        
        public ResponseErrorsJson(IList<string> errors)
        {
            Errors = errors;
        }
    }
}
