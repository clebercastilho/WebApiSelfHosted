using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExceptionContainer;
using ModelDB;

namespace BusinessAccess
{
    public class Usuarios
    {
        #region DB data simulação
        public static List<Usuario> SimulacaoDB = new List<Usuario>
        {
            new Usuario
            {
                ID = 1,
                Email = "usuario1@email.com",
                Login = "usuario1",
                NomeCompleto = "Usuario One",
                DataNascimento = new DateTime(1980,01,01,08,30,00),
                DataCadastro = new DateTime(2017,04,15,19,45,30),
                PermissaoLogin = false
            },
            new Usuario
            {
                ID = 1,
                Email = "maradona@email.com",
                Login = "dmaradona",
                NomeCompleto = "Diego Maradona",
                DataNascimento = new DateTime(1980,01,01,08,30,00),
                DataCadastro = new DateTime(2017,04,15,19,45,30),
                PermissaoLogin = true
            },
            new Usuario
            {
                ID = 1,
                Email = "darth.vader@email.com",
                Login = "darth_vader",
                NomeCompleto = "Darth Vader",
                DataNascimento = new DateTime(1980,01,01,08,30,00),
                DataCadastro = new DateTime(2017,04,15,19,45,30),
                PermissaoLogin = true
            }
        };
        #endregion

        public static Try<Notification, Usuario> GetUserByLogin(string login)
        {
            var notification = new Notification(NotificationDelimiter.WebDelimiter);

            if (string.IsNullOrEmpty(login))
                notification.AddError("O login informado é inválido!");

            var usuario = SimulacaoDB.Where(u => u.Login == login);
            if (!usuario.Any())
                notification.AddMessage(NotificationType.Warning, "Nenhum usuário encontrado com o login informado.");

            if (notification.HasAnyMessage)
                return notification;
            
            return usuario.First();
        }
    }
}
