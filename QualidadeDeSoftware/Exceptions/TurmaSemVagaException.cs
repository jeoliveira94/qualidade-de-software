using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QualidadeDeSoftware.Exceptions
{
    public class TurmaSemVagaException : Exception
    {
        public TurmaSemVagaException() : base() { }
        public TurmaSemVagaException(string message) : base(message) { }
    }
}
