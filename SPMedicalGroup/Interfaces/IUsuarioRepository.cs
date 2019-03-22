using SPMedicalGroup.DomainsContextDir;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SPMedicalGroup.Interface
{
    public interface IUsuarioRepository
    {
        void Cadastrar(Usuarios usuario);

        List<Usuarios> Listar();

        Usuarios BuscarPorEmailESenha(string email, string senha);

        void Login(Usuarios usuario);

        void Deletar(Usuarios usuario);
    }
}
