using QualidadeDeSoftware.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QualidadeDeSoftware.Mock
{
    public class TurmasMock
    {
        public static List<Turma> GetTurmas()
        {
            Random random = new Random();

            var disciplinas = new string[]
            {   
                "Qualidade de Software",
            };
  
            var alunos = new List<Turma>();

            for (int i = 0; i < disciplinas.Length; i++)
            {
                var disciplina = disciplinas[random.Next(disciplinas.Length)];
                
                alunos.Add(new Turma() { Disciplina = disciplina, Vagas = 10, NumeroDeAlunos = 0});
            }
            return alunos;
        }
        
    }
}
