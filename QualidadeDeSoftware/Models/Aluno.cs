using System;
using System.Collections.Generic;

namespace QualidadeDeSoftware.Models
{
    public class Aluno : Model
    {
        public Aluno() { }
        public string Id { get;  set; }
        public string PrimeiroNome { get;  set; }
        public string UltimoNome { get;  set; }

        public string getId() => this.Id;

        public void setId(string Id) => this.Id = Id;
    }
}
