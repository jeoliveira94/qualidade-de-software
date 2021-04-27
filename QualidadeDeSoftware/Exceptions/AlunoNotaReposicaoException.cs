using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QualidadeDeSoftware.Exceptions
{
    public class AlunoNotaReposicaoException : Exception
    {
        public AlunoNotaReposicaoException() : base() { }
        public AlunoNotaReposicaoException(string message) : base(message) { }
    }
}
