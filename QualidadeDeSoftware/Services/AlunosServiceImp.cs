using QualidadeDeSoftware.Models;
using QualidadeDeSoftware.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QualidadeDeSoftware.Services
{
    public class AlunosServiceImp : AlunosService
    {
        private Repository<Aluno> repository;
        public AlunosServiceImp(Repository<Aluno> repository)
        {
            this.repository = repository;
        }

        public async Task<Aluno> CadastrarAluno(string primeiroNome, string ultimoNome)
        {
            string id = Guid.NewGuid().ToString();
            return await repository.AddItemAsync(new Aluno() { Id = id,  PrimeiroNome = primeiroNome, UltimoNome = ultimoNome});
        }

        public async Task<Aluno> GetAlunoById(string id)
        {
            return await repository.GetItemAsync(id);
        }

        public async Task<IEnumerable<Aluno>> getAlunos()
        {
            return await repository.GetItemsAsync();
        }
    }
}
