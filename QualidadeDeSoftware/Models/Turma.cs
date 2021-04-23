using System;
using System.Collections.Generic;
using System.Text;

namespace QualidadeDeSoftware.Models
{
    public class Turma : Model
    {
        public Turma() { }
        public string Id { get;  set; }
        public string Disciplina { get;  set; }
        public int Vagas { get;  set; }

        public int NumeroDeAlunos { get; set; }

        public string getId() => this.Id;

        public void setId(string Id) => this.Id = Id;

    }
}
