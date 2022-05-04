using Models;
using System;
using System.Linq;
using System.Collections.Generic;
using Repository;
using System.Text.RegularExpressions;

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

            if (String.IsNullOrEmpty(Email))
            {
                throw new Exception("O e-mail é obrigatório.");
            }
            Regex rx = new Regex("^[a-z0-9.]+@[a-z0-9]+\\.[a-z]+(\\.[a-z]+)?$");
            if (String.IsNullOrEmpty(Email) || !rx.IsMatch(Email))
            {
                throw new Exception("Email inválido");
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
            Usuario usuario;
            try {
                usuario = Usuario.GetUsuario(Id);
            }
            catch
            {
                throw new Exception("Usuário não encontrado.");
            }

            if (!String.IsNullOrEmpty(Nome))
            {
                usuario.Nome = Nome;
            }
            usuario.Nome = Nome;

            Regex rx = new Regex("^[a-z0-9.]+@[a-z0-9]+\\.[a-z]+(\\.[a-z]+)?$");
            if (String.IsNullOrEmpty(Email) || !rx.IsMatch(Email))
            {
                throw new Exception("Email inválido");
            }
            if (!String.IsNullOrEmpty(Email))
            {
                usuario.Email = Email;
            }
            usuario.Email = Email;

            if (Senha.Length < 8) {
                throw new Exception("A senha deve ter no mínimo 8 caracteres.");
            }
            usuario.Senha = Senha;

            Models.Usuario.AlterarUsuario(Id, Nome, Email, Senha);

            return usuario;
        }

        public static Usuario RemoverUsuario(
            int Id
        )
        {
            try
            {
                Usuario usuario = Usuario.GetUsuario(Id);
                Models.Usuario.RemoverUsuario(usuario);
                return usuario;
            }
            catch
            {
                throw new Exception("Usuário não encontrado.");
            }            
        }

        public static IEnumerable<Usuario> GetUsuarios()
        {
            return Usuario.GetUsuarios();
        }

        public static void Auth(string Email, string Senha) {
            try {
                Usuario.Auth(Email, Senha);
            }
            catch
            {
                throw new Exception("Email ou senha inválido");
            }
        }

    }
}