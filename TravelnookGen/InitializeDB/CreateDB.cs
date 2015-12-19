
/*PROTECTED REGION ID(CreateDB_imports) ENABLED START*/
using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using TravelnookGenNHibernate.EN.Travelnook;
using TravelnookGenNHibernate.CEN.Travelnook;
using TravelnookGenNHibernate.CAD.Travelnook;
using TravelnookCP.CPs;


/*PROTECTED REGION END*/
namespace InitializeDB
{
    public class CreateDB
    {
        public static void Create(string databaseArg, string userArg, string passArg)
        {
            String database = databaseArg;
            String user = userArg;
            String pass = passArg;

            // Conex DB
            SqlConnection cnn = new SqlConnection(@"Server=(local)\sqlexpress; database=master; integrated security=yes");

            // Order T-SQL create user
            String createUser = @"IF NOT EXISTS(SELECT name FROM master.dbo.syslogins WHERE name = '" + user + @"')
            BEGIN
                CREATE LOGIN [" + user + @"] WITH PASSWORD=N'" + pass + @"', DEFAULT_DATABASE=[master], CHECK_EXPIRATION=OFF, CHECK_POLICY=OFF
            END";

            //Order delete user if exist
            String deleteDataBase = @"if exists(select * from sys.databases where name = '" + database + "') DROP DATABASE [" + database + "]";
            //Order create databas
            string createBD = "CREATE DATABASE " + database;
            //Order associate user with database
            String associatedUser = @"USE [" + database + "];CREATE USER [" + user + "] FOR LOGIN [" + user + "];USE [" + database + "];EXEC sp_addrolemember N'db_owner', N'" + user + "'";
            SqlCommand cmd = null;

            try
            {
                // Open conex
                cnn.Open();

                //Create user in SQLSERVER
                cmd = new SqlCommand(createUser, cnn);
                cmd.ExecuteNonQuery();

                //DELETE database if exist
                cmd = new SqlCommand(deleteDataBase, cnn);
                cmd.ExecuteNonQuery();

                //CREATE DB
                cmd = new SqlCommand(createBD, cnn);
                cmd.ExecuteNonQuery();

                //Associate user with db
                cmd = new SqlCommand(associatedUser, cnn);
                cmd.ExecuteNonQuery();

                System.Console.WriteLine("DataBase create sucessfully..");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (cnn.State == ConnectionState.Open)
                {
                    cnn.Close();
                }
            }
        }

        public static void InitializeData()
        {
            /*PROTECTED REGION ID(initializeDataMethod) ENABLED START*/
            try
            {
                /*******************ADMIN************************/
                AdministradorEN adminEN = new AdministradorEN();
                AdministradorCEN adminCEN = new AdministradorCEN();
                adminEN.NomUsu = "aaaaaaaaaa";
                adminEN.Email = "administrador@boss.es";
                adminEN.Contrasenya = "qwerty";

                adminCEN.New_(adminEN.NomUsu,adminEN.Contrasenya, adminEN.Email);

                /*************************USUARIOS**********************************/
                UsuarioEN usu1EN = new UsuarioEN();
                UsuarioEN usu2EN = new UsuarioEN();
                UsuarioEN usu3EN = new UsuarioEN();
                UsuarioCEN usu1CEN = new UsuarioCEN();
                UsuarioCEN usu2CEN = new UsuarioCEN();
                UsuarioCEN usu3CEN = new UsuarioCEN();

                usu1EN.Email = "usu1@hotmail.com";
                usu1EN.Nombre = "usu1";
                usu1EN.Apellidos = "ario1";
                usu1EN.NomUsu = "u1";
                usu1EN.Localidad = "Orihuela";
                usu1EN.Provincia = "Alicante";
                usu1EN.Contrasenya = "111111";
                usu1EN.FechaNacimiento = new DateTime(2000, 03, 12);
                usu1EN.Foto_perfil = "/Images/profilepictures/default.jpg";
                usu1CEN.CrearUsuario(usu1EN.Email, usu1EN.Nombre, usu1EN.Apellidos, usu1EN.NomUsu, usu1EN.Localidad, usu1EN.Provincia, usu1EN.Contrasenya, usu1EN.FechaNacimiento, usu1EN.Foto_perfil);


                usu2EN.Email = "usu2@hotmail.com";
                usu2EN.Nombre = "usu2";
                usu2EN.Apellidos = "ario2";
                usu2EN.NomUsu = "u2";
                usu2EN.Localidad = "Sanvi";
                usu2EN.Provincia = "Alicante";
                usu2EN.Contrasenya = "222222";
                usu2EN.FechaNacimiento = new DateTime(1994, 03, 12);
                usu2EN.Foto_perfil = "/Images/profilepictures/default.jpg";
                usu2CEN.CrearUsuario(usu2EN.Email, usu2EN.Nombre, usu2EN.Apellidos, usu2EN.NomUsu, usu2EN.Localidad, usu2EN.Provincia, usu2EN.Contrasenya, usu2EN.FechaNacimiento, usu2EN.Foto_perfil);


                usu3EN.Email = "usu3@hotmail.com";
                usu3EN.Nombre = "usu3";
                usu3EN.Apellidos = "ario3";
                usu3EN.NomUsu = "u3";
                usu3EN.Localidad = "San Juan";
                usu3EN.Provincia = "Alicante";
                usu3EN.Contrasenya = "333";
                usu3EN.FechaNacimiento = new DateTime(1994, 02, 01);
                usu3EN.Foto_perfil = "";
                usu3CEN.CrearUsuario(usu3EN.Email, usu3EN.Nombre, usu3EN.Apellidos, usu3EN.NomUsu, usu3EN.Localidad, usu3EN.Provincia, usu3EN.Contrasenya, usu3EN.FechaNacimiento, usu3EN.Foto_perfil);



                /****************************Actividades************************/
                ActividadEN acti1EN = new ActividadEN();
                ActividadCEN acti1CEN = new ActividadCEN();
                acti1EN.Tipo = TravelnookGenNHibernate.Enumerated.Travelnook.TipoActividadesEnum.camping;
                acti1CEN.New_(acti1EN.Tipo);

                ActividadEN acti2EN = new ActividadEN();
                ActividadCEN acti2CEN = new ActividadCEN();
                acti2EN.Tipo = TravelnookGenNHibernate.Enumerated.Travelnook.TipoActividadesEnum.culturales;
                acti2CEN.New_(acti2EN.Tipo);

                ActividadEN acti3EN = new ActividadEN();
                ActividadCEN acti3CEN = new ActividadCEN();
                acti3EN.Tipo = TravelnookGenNHibernate.Enumerated.Travelnook.TipoActividadesEnum.gastronomia;
                acti3CEN.New_(acti3EN.Tipo);

                ActividadEN acti4EN = new ActividadEN();
                ActividadCEN acti4CEN = new ActividadCEN();
                acti4EN.Tipo = TravelnookGenNHibernate.Enumerated.Travelnook.TipoActividadesEnum.deportes;
                acti4CEN.New_(acti4EN.Tipo);

                ActividadEN acti5EN = new ActividadEN();
                ActividadCEN acti5CEN = new ActividadCEN();
                acti5EN.Tipo = TravelnookGenNHibernate.Enumerated.Travelnook.TipoActividadesEnum.deportes_acuaticos;
                acti5CEN.New_(acti5EN.Tipo);

                ActividadEN acti6EN = new ActividadEN();
                ActividadCEN acti6CEN = new ActividadCEN();
                acti6EN.Tipo = TravelnookGenNHibernate.Enumerated.Travelnook.TipoActividadesEnum.ludicas;
                acti6CEN.New_(acti6EN.Tipo);

                ActividadEN acti7EN = new ActividadEN();
                ActividadCEN acti7CEN = new ActividadCEN();
                acti7EN.Tipo = TravelnookGenNHibernate.Enumerated.Travelnook.TipoActividadesEnum.ocio_nocturno;
                acti7CEN.New_(acti7EN.Tipo);

                ActividadEN acti8EN = new ActividadEN();
                ActividadCEN acti8CEN = new ActividadCEN();
                acti8EN.Tipo = TravelnookGenNHibernate.Enumerated.Travelnook.TipoActividadesEnum.senderismo;
                acti8CEN.New_(acti8EN.Tipo);



                /*****************************SITIOS***********************************/
                SitioEN sitio1EN = new SitioEN();
                SitioEN sitio2EN = new SitioEN();
                SitioCEN sitio1CEN = new SitioCEN();
                SitioCEN sitio2CEN = new SitioCEN();


                sitio1EN.Nombre = "Guadalest";
                sitio1EN.Provincia = "Alicante";
                sitio1EN.Descripcion = "Precioso lugar";
                sitio1EN.Puntuacion = 5;
                sitio1EN.Usuario = usu1EN;
                sitio1EN.Localizacion = "";
                sitio1EN.FechaCreacion = new DateTime(2015, 11, 11);
                sitio1EN.NumPuntuados = 1;
                sitio1EN.PuntuacionMedia = 5;
                sitio1EN.Fotos = new List<string>();
                sitio1EN.Videos = new List<string>();
                sitio1EN.TipoSitio = TravelnookGenNHibernate.Enumerated.Travelnook.TipoSitioEnum.montanya;
                IList<TravelnookGenNHibernate.Enumerated.Travelnook.TipoActividadesEnum> acti = new List<TravelnookGenNHibernate.Enumerated.Travelnook.TipoActividadesEnum>();
                acti.Add(acti3EN.Tipo);
                //acti.Add (acti2EN.Tipo);
                sitio1CEN.CrearSitio(sitio1EN.Nombre, sitio1EN.Provincia, sitio1EN.Descripcion, sitio1EN.Puntuacion, sitio1EN.Fotos, sitio1EN.Usuario.NomUsu, sitio1EN.Videos, sitio1EN.Localizacion, sitio1EN.FechaCreacion, sitio1EN.NumPuntuados, sitio1EN.PuntuacionMedia, sitio1EN.TipoSitio, acti);
                System.Console.Write("Crea sitio 1");
                SitioEN prueba = new SitioEN();
                /*Si hago esto de golpe va mal, si lo hago paso a paso va bien
                prueba = sitio1CEN.DevuelveSitioPorNombre("Guadalest");
                System.Console.Write(prueba.Descripcion+"\n");
                foreach (ActividadEN actividaddad in prueba.Actividades)
                {
                    System.Console.Write(actividaddad.Tipo + "\n");
                }*/
                sitio2EN.Nombre = "Xixona";
                sitio2EN.Provincia = "Alicante";
                sitio2EN.Descripcion = "Ricos turrones";
                sitio2EN.Puntuacion = 3;
                sitio2EN.Usuario = usu1EN;
                sitio2EN.Localizacion = "";
                sitio2EN.FechaCreacion = new DateTime(2015, 07, 11);
                sitio2EN.NumPuntuados = 1;
                sitio2EN.PuntuacionMedia = 3;
                sitio2EN.Fotos = new List<string>();
                sitio2EN.Videos = new List<string>();
                sitio2EN.TipoSitio = TravelnookGenNHibernate.Enumerated.Travelnook.TipoSitioEnum.espacio_natural;
                IList<TravelnookGenNHibernate.Enumerated.Travelnook.TipoActividadesEnum> acti2 = new List<TravelnookGenNHibernate.Enumerated.Travelnook.TipoActividadesEnum>();
                acti2.Add(acti1EN.Tipo);
                acti2.Add(acti2EN.Tipo);
                System.Console.WriteLine("Creo sitio2");
                sitio2CEN.CrearSitio(sitio2EN.Nombre, sitio2EN.Provincia, sitio2EN.Descripcion, sitio2EN.Puntuacion, sitio2EN.Fotos, sitio2EN.Usuario.NomUsu, sitio2EN.Videos, sitio2EN.Localizacion, sitio2EN.FechaCreacion, sitio2EN.NumPuntuados, sitio2EN.PuntuacionMedia, sitio2EN.TipoSitio, acti2);
                System.Console.Write("Crea sitio 2");


                //Devuelve sitio por actividad
                //actividades para buscar
                IList<ActividadEN> actividades = new List<ActividadEN>();
                actividades.Add(acti1EN);
                actividades.Add(acti2EN);
                //IList<SitioCEN> sitiosPorActividad = sitio1CEN.DevuelveSitiosPorActividad(actividades);


                /*********************************RUTAS************************************/
                RutaCEN ruta1CEN = new RutaCEN();
                RutaEN ruta1EN = new RutaEN();

                ruta1EN.Nombre = "la ruta del bacalao";
                ruta1EN.Descripcion = "to guapa";
                ruta1EN.Provincia = "Orihuelica";
                IList<string> sitios = new List<string>();
                sitios.Add(sitio1EN.Nombre);
                sitios.Add(sitio2EN.Nombre);
                ruta1EN.Puntuacion = 4;
                ruta1EN.NumPuntuados = 34;
                ruta1EN.FechaCreacion = new DateTime(2015, 05, 05);

                System.Console.WriteLine("Creo ruta 1");
                ruta1CEN.CrearRuta(ruta1EN.Nombre, ruta1EN.Descripcion, ruta1EN.Provincia, sitios, ruta1EN.Puntuacion, ruta1EN.NumPuntuados, ruta1EN.FechaCreacion, ruta1EN.PuntuacionMedia);


                /*******************************COMENTARIOS**************************/
                ComentarioCEN comen1CEN = new ComentarioCEN();
                ComentarioEN com1EN = new ComentarioEN();
                int a = comen1CEN.CrearComentario(usu1EN.NomUsu, "Precioso sitio, estuve allí hace unos meses", 0, 0, DateTime.Today);
                comen1CEN.AsignarSitio(a, "Guadalest");
                a = comen1CEN.CrearComentario(usu2EN.NomUsu, "Pues a mi no me gustó", 3, 0, DateTime.Today);
                comen1CEN.AsignarSitio(a, "Guadalest");

                a = comen1CEN.CrearComentario(usu2EN.NomUsu, "Este sitio si que me gustó, no como Guadalest", 0, 0, DateTime.Today);
                comen1CEN.AsignarSitio(a, "Xixona");

                /**********************SOLICITUD*******************************/
                SolicitudEN solicitud1EN = new SolicitudEN();
                SolicitudCEN solicitud1CEN = new SolicitudCEN();


                solicitud1EN.Estado = TravelnookGenNHibernate.Enumerated.Travelnook.EstadoSolicitudEnum.pendiente;
                solicitud1EN.Fecha = DateTime.Today;
                System.Console.Write("**********************************************usuarios");
                System.Console.Write(usu2EN.NomUsu);
                System.Console.Write(usu1EN.NomUsu);

                int Id = solicitud1CEN.EnviarSolicitud(usu2EN.NomUsu, solicitud1EN.Estado, solicitud1EN.Fecha, usu1EN.NomUsu);
                System.Console.Write("************Enviada\n\n");
                SolicitudEN solicitud2EN = new SolicitudEN();
                IList<SolicitudEN> listapet = new List<SolicitudEN>();
                listapet = solicitud1CEN.DevuelveSolicitudes("u1");
                /***********************USUARIOCP**********************************/
                foreach (SolicitudEN solaux in listapet)
                {
                    System.Console.Write(solaux.Solicitante.NomUsu + "\n");
                }
                UsuarioCP usuCP = new UsuarioCP();
                usuCP.AceptarSolicitud(usu1EN.NomUsu, usu2EN.NomUsu, Id); //usu1 introduce en su lista a usu2

                /*PRUEBA*/
                IList<string> agregar1 = new List<string>();
                agregar1.Add(usu3EN.NomUsu);
                usu1CEN.AnyadirAmigo(usu2EN.NomUsu, agregar1);


                IList<UsuarioEN> misAmigos1 = new List<UsuarioEN>();
                misAmigos1 = usu1CEN.ConsultarAmigos(usu1EN.NomUsu);
                System.Console.Write("FUNCIONO\n");
                System.Console.Write("Amigos usu1" + usu1EN.NomUsu + "\n");
                foreach (UsuarioEN aux1 in misAmigos1)
                {
                    System.Console.Write(aux1.NomUsu + "\n");
                }

                System.Console.Write("Fin Amigos usu1------ABAJO AMIGOS DE USU2\n");
                IList<UsuarioEN> misAmigos2 = new List<UsuarioEN>();
                misAmigos2 = usu2CEN.MisAmigosPorEmail(usu2EN.NomUsu, "@hotmail.com");
                System.Console.Write("FUNCIONO2\n");
                System.Console.Write("Amigos usu2" + usu2EN.NomUsu + "\n");
                foreach (UsuarioEN aux2 in misAmigos2)
                {
                    System.Console.Write(aux2.NomUsu + "\n");
                }
                System.Console.WriteLine("**************Usuario por email*******************\n");

                UsuarioEN usu1 = new UsuarioEN();
                usu1 = usu1CEN.DevuelveUsuarioPorEmail(usu2EN.Email);
                System.Console.Write(usu1.NomUsu + "\n");
                IList<UsuarioEN> aux = new List<UsuarioEN>();

                aux = usu1CEN.MisAmigosPorNomUsu(usu2EN.NomUsu, "u");
                System.Console.Write("******************MI AMIGO por nomUsu*****\n");
                foreach (UsuarioEN aux2 in aux)
                {
                    System.Console.Write(aux2.NomUsu + "\n");
                }
                IList<string> borrar1 = new List<string>();
                borrar1.Add(usu3EN.NomUsu);

                usu1CEN.BorrarAmigo(usu2EN.NomUsu, usu1EN.NomUsu);
                IList<UsuarioEN> misAmigos9 = new List<UsuarioEN>();
                misAmigos9 = usu1CEN.MisAmigos(usu2EN.NomUsu);
                System.Console.Write("Amigos de: " + usu2EN.NomUsu + " despues del borrado\n");
                foreach (UsuarioEN aux1 in misAmigos9)
                {
                    System.Console.Write(aux1.NomUsu + "\n");
                }

                System.Console.Write("***************SITIOS*****************\n");
                IList<SitioEN> aux5 = new List<SitioEN>();
                SitioEN sit = new SitioEN();
                aux5 = sitio1CEN.DevuelveSitiosOrdenadosPorFecha();
                foreach (SitioEN sitio in aux5)
                {
                    System.Console.Write(sitio.Nombre + "\n");
                }
                System.Console.Write(ruta1EN.PuntuacionMedia + "TYTY\n");
                System.Console.Write(ruta1EN.Puntuacion + "TYTY\n");
                ruta1CEN.PuntuarRuta(ruta1EN.Nombre, 2);
                ruta1EN = ruta1CEN.DevuelveRutaPorNombre(ruta1EN.Nombre);
                System.Console.Write(ruta1EN.Nombre + "\n");
                System.Console.Write(ruta1EN.PuntuacionMedia + "\n");

                ReporteCP reporCP = new ReporteCP();
                ReporteCEN repCEN = new ReporteCEN();
                reporCP.ReporteUsuario("mal reporte", usu1EN.NomUsu);
                ReporteEN reporteEN = new ReporteEN();
                reporteEN = repCEN.DevuelveReportePorId(1);
                System.Console.Write(reporteEN.Usuario.NomUsu + " ********************************\n");

                IList<ReporteEN> reportes = repCEN.MostrarReportes(0, -1);
                System.Console.Write(reportes.Count + "\n");
                if (reportes != null)
                {
                    foreach (ReporteEN r in reportes)
                    {
                        System.Console.Write(r.Motivo);
                    }
                }
                IList<UsuarioEN> reportesUsuario = repCEN.MostrarReportesUsuario();
                System.Console.Write(reportesUsuario.Count + "\n");
                if (reportesUsuario != null)
                {
                    foreach (UsuarioEN r in reportesUsuario)
                    {
                        System.Console.Write(r.Nombre);
                    }
                }


                ////////////////////////////////FAVORITOS////////////////////////////////////////

                FavoritoCEN favCEN = new FavoritoCEN();
                FavoritoEN favENSitio = new FavoritoEN();
                FavoritoEN favENRuta = new FavoritoEN();

                favENSitio.Id = favCEN.CrearFavorito(usu1.NomUsu);
                favENRuta.Id = favCEN.CrearFavorito(usu1.NomUsu);
                favCEN.AnyadirSitioFavoritos(favENSitio.Id, sitio2EN.Nombre);
                favCEN.AnyadirRutaFavoritos(favENRuta.Id, ruta1EN.Nombre);
                System.Console.Write("***************FAVORITO CREADO********************************\n");
                System.Console.Write("***********ID DEL FAVORITO SITIO********************************\n" + favENSitio.Id + "\n");
                System.Console.Write("***********ID DEL FAVORITO RUTA********************************\n" + favENRuta.Id + "\n");
                IList<FavoritoEN> favs = favCEN.DevuelveFavoritos(0, -1);
                usu1.Favorito = favs;
                System.Console.Write("Favoritos en total:" + usu1.Favorito.Count + "\n\n");

                IList<SitioEN> sitiosfavs1 = new List<SitioEN>();
                sitiosfavs1 = favCEN.DevuelveSitiosFavoritos();
                System.Console.Write("Sitios favoritos en total:" + sitiosfavs1.Count + "\n\n");

                IList<RutaEN> rutasfavs1 = new List<RutaEN>();
                rutasfavs1 = favCEN.DevuelveRutasFavoritas();
                System.Console.Write("Rutas favoritas en total:" + rutasfavs1.Count + "\n\n");

                foreach (FavoritoEN s in favs)
                {
                    System.Console.Write(s + "\n");
                }
                System.Console.Write("fin lista1\n");

                favCEN.EliminarFavorito(favENSitio.Id);

                IList<FavoritoEN> favs2 = favCEN.DevuelveFavoritos(0, -1);
                usu1.Favorito = favs2;
                System.Console.Write("Favoritos en total:" + usu1.Favorito.Count + "\n\n");

                IList<SitioEN> sitiosfavs2 = new List<SitioEN>();
                sitiosfavs2 = favCEN.DevuelveSitiosFavoritos();
                System.Console.Write("Sitios favoritos en total:" + sitiosfavs2.Count + "\n\n");

                IList<RutaEN> rutasfavs2 = new List<RutaEN>();
                rutasfavs2 = favCEN.DevuelveRutasFavoritas();
                System.Console.Write("Rutas favoritas en total:" + rutasfavs2.Count + "\n\n");

                foreach (FavoritoEN s in favs2)
                {
                    System.Console.Write(s + "\n");
                }
                //Peta en favENSitio y cualquier cosa
                /* favENSitio = favCEN.DevuelveFavoritoPorId(1);
                 * System.Console.Write("Favorito por id"+favENSitio.Sitio);*/

                /*********************************EVENTO********************************/

                EventoCEN evento1CEN = new EventoCEN();
                EventoEN evento1EN = new EventoEN();
                EventoCEN evento2CEN = new EventoCEN();
                EventoEN evento2EN = new EventoEN();
                evento1CEN.CrearEvento("evento1", "dasldskvjdfv", usu2EN.NomUsu, 34, 23, 12);
                evento1CEN.CrearEvento("evento2", "dasldskvjSDFSDFGSDFG", usu2EN.NomUsu, 38, 23, 12);
                evento1EN = evento1CEN.DevueleEventoPorId(1);
                evento2EN = evento1CEN.DevueleEventoPorId(2);
                System.Console.Write(evento1EN.Id + " EVENTO MOSTRADO ********************************\n");

                IList<EventoEN> eventos = new List<EventoEN>();
                eventos = evento2CEN.EventosPorMayorNumAsistentes(0, -1);
                foreach (EventoEN evento in eventos)
                {
                    System.Console.Write(evento.Id + "\n");
                }



                /*List<TravelnookGenNHibernate.EN.Mediaplayer.MusicTrackEN> musicTracks = new List<TravelnookGenNHibernate.EN.Mediaplayer.MusicTrackEN>();
                 * TravelnookGenNHibernate.EN.Mediaplayer.UserEN userEN = new TravelnookGenNHibernate.EN.Mediaplayer.UserEN();
                 * TravelnookGenNHibernate.EN.Mediaplayer.ArtistEN artistEN = new TravelnookGenNHibernate.EN.Mediaplayer.ArtistEN();
                 * TravelnookGenNHibernate.EN.Mediaplayer.MusicTrackEN musicTrackEN = new TravelnookGenNHibernate.EN.Mediaplayer.MusicTrackEN();
                 * TravelnookGenNHibernate.CEN.Mediaplayer.ArtistCEN artistCEN = new TravelnookGenNHibernate.CEN.Mediaplayer.ArtistCEN();
                 * TravelnookGenNHibernate.CEN.Mediaplayer.UserCEN userCEN = new TravelnookGenNHibernate.CEN.Mediaplayer.UserCEN();
                 * TravelnookGenNHibernate.CEN.Mediaplayer.MusicTrackCEN musicTrackCEN = new TravelnookGenNHibernate.CEN.Mediaplayer.MusicTrackCEN();
                 * TravelnookGenNHibernate.CEN.Mediaplayer.PlayListCEN playListCEN = new TravelnookGenNHibernate.CEN.Mediaplayer.PlayListCEN();
                 *
                 *              //Add Users
                 * userEN.Email = "user@user.com";
                 * userEN.Name = "user";
                 * userEN.Surname = "userSurname";
                 * userEN.Password = "user";
                 * userCEN.New_(userEN.Name, userEN.Surname, userEN.Email, userEN.Password);
                 *
                 * //Add Music Track1
                 * musicTrackEN.Id = "http://www2.b3ta.com/mp3/Beer Beer Beer (YOB mix).mp3";
                 * musicTrackEN.Format = "mp3";
                 * musicTrackEN.Lyrics = "Beer Beer Beer Beer Beer Beer ..";
                 * musicTrackEN.Name = "Beer Beer Beer";
                 * musicTrackEN.Company = "Company";
                 * musicTrackEN.Cover = "http://www.tomasabraham.com.ar/cajadig/2007/images/nro18-2/beer1.jpg";
                 * musicTrackEN.Price = 20;
                 * musicTrackEN.Rating = 5;
                 * musicTrackEN.CommunityRating = 5;
                 * musicTrackEN.Duration = 200;
                 * musicTrackCEN.New_(musicTrackEN.Id, musicTrackEN.Format, musicTrackEN.Lyrics, musicTrackEN.Name,
                 *  musicTrackEN.Company, musicTrackEN.Cover, musicTrackEN.CommunityRating, musicTrackEN.Rating,
                 *  musicTrackEN.Price, musicTrackEN.Duration);
                 * musicTracks.Add(musicTrackEN);
                 * musicTrackCEN.AsignUser(musicTrackEN.Id,userEN.Email);
                 *
                 * //Define Album
                 * //TravelnookGenNHibernate.CEN.Mediaplayer.AlbumCEN albumCEN = new TravelnookGenNHibernate.CEN.Mediaplayer.AlbumCEN();
                 * //albumCEN.New_("Album 1", "This is a Album 1", artists, musicTracks);*/


                /*PROTECTED REGION END*/
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.InnerException);
                throw ex;
            }
        }
    }
}
