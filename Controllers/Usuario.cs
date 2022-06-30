using Models;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Controllers
{
    public class UsuarioController
    {

        private static void ValidateFields(string Nome, string Email, string Senha, int Id = 0)
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

            IEnumerable<Usuario> usuariosWithEmail = Usuario.GetUsuarios(Email, Id);
            if (usuariosWithEmail.Count() > 0)
            {
                throw new Exception("Email já está em uso por outro usuário");
            }
            // buscar uma forma de validar que um email já cadastrado não poderá existir em outro cadastro
            if (Senha.Length < 8)
            {
                throw new Exception("A senha deve ter no mínimo 8 caracteres.");
            }

            if (Id > 0)
            {
                try
                {
                    Usuario.GetUsuario(Id);
                }
                catch
                {
                    throw new Exception("Usuário não encontrado.");
                }
            }
        }

        public static Usuario IncluirUsuario(
            string Nome,
            string Email,
            string Senha
        )
        {
            ValidateFields(Nome, Email, Senha);
            Senha = BCrypt.Net.BCrypt.HashPassword(Senha);
            return new Usuario(Nome, Email, Senha);
        }

        public static Usuario AlterarUsuario(
            int Id,
            string Nome,
            string Email,
            string Senha
        )
        {
            ValidateFields(Nome, Email, Senha, Id);
            Usuario usuario = Usuario.GetUsuario(Id);
            if (Senha != usuario.Senha)
            {
                Senha = BCrypt.Net.BCrypt.HashPassword(Senha);
            }
            return Models.Usuario.AlterarUsuario(Id, Nome, Email, Senha);
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

        public static Usuario GetUsuario(
             int Id
         )
        {
            Usuario usuario = (
                from Usuario in Usuario.GetUsuarios()
                where Usuario.Id == Id
                select Usuario
            ).First();

            if (usuario == null)
            {
                throw new Exception("Usuario não encontrado.");
            }

            return usuario;
        }

        public static void Auth(string Email, string Senha)
        {
            try
            {
                Usuario.Auth(Email, Senha);
            }
            catch
            {
                throw new Exception("Email ou senha inválido");
            }
        }

    }
}