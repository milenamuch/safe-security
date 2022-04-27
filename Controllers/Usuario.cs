using Models;
using System;
using System.Linq;
using System.Collections.Generic;
using Repository;

namespace Controllers
{
    public class UsuarioController
    {
        public static Usuario IncluirUsuario(
            string Nome,
            string Email,
            string Senha
        )
        {
            if (String.IsNullOrEmpty(Nome))
            {
                throw new Exception("O nome é obrigatório.");
            }

            if (String.IsNullOrEmpty(Senha))
            {
                throw new Exception("A senha é obrigatória.");
            }

            if (Senha.Length < 8) {
                throw new Exception("A senha deve ter no mínimo 8 caracteres.");
            }

            return new Usuario(Nome, Email, Senha);
        }

        public static Usuario AlterarUsuario(
            int Id,
            string Nome,
            string Email,
            string Senha
        )
        {
            Usuario usuario = Usuario.GetUsuario(Id);

            if (!String.IsNullOrEmpty(Nome))
            {
                usuario.Nome = Nome;
            }
            usuario.Nome = Nome;

            if (!String.IsNullOrEmpty(Email))
            {
                usuario.Email = Email;
            }
            usuario.Email = Email;

            if (!String.IsNullOrEmpty(Senha))
            {
                usuario.Senha = Senha;
            }
            usuario.Senha = Senha;

            Models.Usuario.AlterarUsuario(Id, Nome, Email, Senha);

            return usuario;
        }

        public static Usuario RemoverUsuario(
            int Id
        )
        {
            Usuario usuario = Usuario.GetUsuario(Id);
            Models.Usuario.RemoverUsuario(usuario);

            if (usuario == null)
            {
                throw new Exception("Usuário não encontrado.");
            }

            return usuario;
        }

    }
}