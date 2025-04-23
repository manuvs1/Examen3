using Servicios_18_20.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Servicios_18_20.Clases
{
    public class clsLogin
    {
        public clsLogin()
        {
            loginRespuesta = new LoginRespuesta();
        }


            public EventosEntities dbeventos = new EventosEntities();
            public Login login { get; set; }
            public LoginRespuesta loginRespuesta { get; set; }

            public IQueryable<LoginRespuesta> Ingresar()
            {
                try
                {
                    var admin = dbeventos.Administradors.FirstOrDefault(a =>
                        a.Usuario == login.Usuario &&
                        a.Clave == login.Clave // Se compara en plano, sin cifrado
                    );

                    if (admin == null)
                    {
                        loginRespuesta.Autenticado = false;
                        loginRespuesta.Mensaje = "Usuario o clave incorrecta";
                        return new List<LoginRespuesta> { loginRespuesta }.AsQueryable();
                    }

                    // Genera el token JWT
                    string token = TokenGenerator.GenerateTokenJwt(login.Usuario);

                    loginRespuesta = new LoginRespuesta
                    {
                        Usuario = login.Usuario,
                        Autenticado = true,
                        Perfil = "Administrador",
                        PaginaInicio = "/eventos", 
                        Token = token,
                        Mensaje = "Autenticación exitosa"
                    };

                    return new List<LoginRespuesta> { loginRespuesta }.AsQueryable();
                }
                catch (Exception ex)
                {
                    loginRespuesta.Autenticado = false;
                    loginRespuesta.Mensaje = $"Error: {ex.Message}";
                    return new List<LoginRespuesta> { loginRespuesta }.AsQueryable();
                }
            }
        }
    }
