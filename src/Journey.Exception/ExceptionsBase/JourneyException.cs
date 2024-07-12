using System.Net;

namespace Journey.Exception.ExceptionsBase
{
    // nao da pra fazer new com abstract
    public abstract class JourneyException : SystemException
    {
        public JourneyException(string message) : base(message) // repassa a mensage para o construtor do SystemException
        {

        }

        // toda classe que herda o JouneyException vai precisar ter uma função GetStatusCOde que vai devolver o status code
        public abstract HttpStatusCode GetStatusCode();
        public abstract IList<string> GetErrorMessages();
    }
}
