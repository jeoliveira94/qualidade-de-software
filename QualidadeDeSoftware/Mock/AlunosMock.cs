using QualidadeDeSoftware.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QualidadeDeSoftware.Mock
{
    public class AlunosMock
    {
        public static List<Aluno> GetAlunos()
        {
            Random random = new Random();

            var primeirosNomes = new string[]
            {   "Michael",
                "Christopher",
                "Jessica",
                "Matthew",
                "Ashley",
                "Jennifer",
                "Joshua",
                "Amanda",
                "Daniel",
                "David",
                "James",
                "Robert",
                "John",
                "Joseph",
                "Andrew",
                "Ryan",
                "Brandon",
                "Jason",
                "Justin",
            };
            var ultimosNomes = new string[] {
                "SMITH",
                "JOHNSON",
                "WILLIAMS",
                "JONES",
                "BROWN",
                "DAVIS",
                "MILLER",
                "WILSON",
                "MOORE",
                "TAYLOR",
                "ANDERSON",
                "THOMAS",
                "JACKSON",
                "WHITE",
                "HARRIS",
                "MARTIN",
                "THOMPSON",
                "GARCIA",
                "MARTINEZ",
                 };

            var alunos = new List<Aluno>();

            for (int i = 0; i < primeirosNomes.Length; i++)
            {
                var primeiroNome = primeirosNomes[random.Next(primeirosNomes.Length)];
                var ultimoNome = ultimosNomes[random.Next(ultimosNomes.Length)];
                alunos.Add(new Aluno() { PrimeiroNome = primeiroNome, UltimoNome = ultimoNome });
            }
            return alunos;
        }
        
    }
}
