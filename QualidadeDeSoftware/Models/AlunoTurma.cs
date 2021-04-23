using System;
using System.Collections.Generic;
using System.Text;

namespace QualidadeDeSoftware.Models
{
    public class AlunoTurma : Model
    {
        public AlunoTurma() { }
        public string Id { get;  set; }
        public string AlunoId { get;  set; }
        public string TurmaId { get;  set; }
        public float?[] Notas { get;  set; }

        public string getId() => this.Id;

        public void setId(string Id) => this.Id = Id;
    }
}
