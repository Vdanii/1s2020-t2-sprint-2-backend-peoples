using Senai.Peoples.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Peoples.WebApi.Interfaces
{
	interface IFuncionariosRepository
	{
			List<FuncionariosDomains> Listar();

        void Apagar(int id);

        void AtualizarIdUrl(int id, FuncionariosDomains funcionarios);

        void Cadastrar(FuncionariosDomains funcionarios);

        FuncionariosDomains PegarPorId(int id);
    }
}
