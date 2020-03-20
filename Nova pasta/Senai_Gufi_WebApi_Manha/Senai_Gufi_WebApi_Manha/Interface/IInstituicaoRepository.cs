using Senai_Gufi_WebApi_Manha.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai_Gufi_WebApi_Manha.Interface
{
    interface IInstituicaoRepository
    {
        List<Instituicao> Listar();

        Instituicao BuscarPorId(int id);

        void Cadastrar(Instituicao novaInstituicao);

        void Atualizar(int id, Instituicao instituicaoNova);
    }
}
