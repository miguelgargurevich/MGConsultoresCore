using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MGConsultores.Models;

using Microsoft.AspNetCore.Identity;
using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Hosting.Server;

using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Net.Mail;
using System.Net.Mime;
using System.Net;
using MGConsultores.Interfaces;

namespace MGConsultores.Controllers;




//[Authorize]
public class HomeController : Controller
{
    private readonly IConfiguration _config;
    private readonly ILogger _logger;
    private readonly IEmailSender _emailSender;

    public HomeController(
        IConfiguration config,
        ILogger<HomeController> logger,
        IEmailSender emailSender
)
    {
        _config = config;
        _logger = logger;
        _emailSender = emailSender;
    }

    public ActionResult Index()
    {
        return View();
    }


    public ActionResult Consultoria()
    {
        return View();
    }

    public ActionResult DesarrolloSoftware()
    {
        return View();
    }

    public ActionResult WebDesign()
    {
        return View();
    }

    public ActionResult AplicacionesMoviles()
    {
        return View();
    }

    public ActionResult TiendasVirtuales()
    {
        return View();
    }

    public ActionResult IntranetExtranet()
    {
        return View();
    }

    public ActionResult HostingDominio()
    {
        return View();
    }

    public ActionResult SoporteMantenimiento()
    {
        return View();
    }

    public ActionResult Nosotros()
    {
        return View();
    }

    public ActionResult ComoTrabajamos()
    {
        return View();
    }

    public ActionResult CalidadGarantia()
    {
        return View();
    }

    public ActionResult Cultura()
    {
        return View();
    }

    public ActionResult PaginaWebCorporativa()
    {
        return View();
    }

    public ActionResult PaginaWebCatalogo()
    {
        return View();
    }

    public ActionResult AplicacionesWeb()
    {
        return View();
    }

    public ActionResult Contacto()
    {
        return View();
    }

    public ActionResult About()
    {
        ViewBag.Message = "Your application description page.";

        return View();
    }

    public ActionResult Contact()
    {
        ViewBag.Message = "Your contact page.";

        return View();
    }

    [HttpPost]
    public string EnviarComentario(ComentarioModel model)
    {
        var rpta = "true";
        try
        {
            _ = EnviarCorreoAsync(model);
            //Comentarios entidad = new Comentarios();
            //entidad.DesComentario = model.Mensaje;
            //entidad.FechaCreacion = DateTime.Now;
            //entidad.Puntaje = model.Puntaje;
            //entidad.CodUsuario = string.Empty;

            //bool isAuth = User.Identity.IsAuthenticated;
            //if (isAuth)
            //{
            //    _db = new dbTuCalcuEntities();
            //    AspNetUsers user = _db.AspNetUsers.Where(m => m.Email == User.Identity.Name).ToList().FirstOrDefault();
            //    entidad.CodUsuario = user.Id;
            //}

            //ComentarioDA _da = new ComentarioDA();
            //_da.GrabarComentario(entidad);

            return rpta;

        }
        catch (Exception e)
        {
            rpta = CapturarError(e, "HomeController", "EnviarComentario");
            return "false";

        }

    }

    private async Task EnviarCorreoAsync(ComentarioModel model)
    {

       

        try
        {
            await _emailSender
        .SendEmailAsync("miguel.gargurevich@gmail.com", "Asunto", "Mensaje")
        .ConfigureAwait(false);
        }
        catch (SmtpException exm)
        {
            CapturarError(exm, "Home", "EnviarComentario");
        }
        catch (Exception ex)
        {
            CapturarError(ex, "Home", "EnviarComentario");
        }

    }

    public string CapturarError(Exception error, string controlador = "", string accion = "")
    {
        var msg = error.Message;
        if (error.InnerException != null)
        {
            msg = msg + "/;/" + error.InnerException.Message;
            if (error.InnerException.InnerException != null)
            {
                msg = msg + "/;/" + error.InnerException.InnerException.Message;
                if (error.InnerException.InnerException.InnerException != null)
                    msg = msg + "/;/" + error.InnerException.InnerException.InnerException.Message;
            }
        }


        var comentario = $@"Se ejecutó la accion: [{controlador}/{accion}] - MensajeError: {msg}";
        var logErrorFinal = string.Format("{0} | {1}", comentario, error.StackTrace);
        //log.ErrorFormat("{0} | {1}", comentario, error.StackTrace);

        //PARA LOG ERROR
        var fileUnicoName = String.Concat("ERROR", ".txt");
        var fileUnicoPath = System.IO.Path.Combine("~/", fileUnicoName);

        using (FileStream fs = new FileStream(fileUnicoPath, FileMode.Create))
        {
            byte[] bytes = Encoding.UTF8.GetBytes(logErrorFinal);
            fs.Write(bytes, 0, bytes.Length);
            fs.Close();
        }

        ViewBag.ErrorMessage = logErrorFinal;

        return string.Format(logErrorFinal);
    }

    public string CapturarError(SmtpException error, string controlador = "", string accion = "")
    {
        var msg = error.Message;
        if (error.InnerException != null)
        {
            msg = msg + "/;/" + error.InnerException.Message;
            if (error.InnerException.InnerException != null)
            {
                msg = msg + "/;/" + error.InnerException.InnerException.Message;
                if (error.InnerException.InnerException.InnerException != null)
                    msg = msg + "/;/" + error.InnerException.InnerException.InnerException.Message;
            }
        }


        var comentario = $@"Se ejecutó la accion: [{controlador}/{accion}] - MensajeError: {msg}";
        var logErrorFinal = string.Format("{0} | {1}", comentario, error.StackTrace);
        //log.ErrorFormat("{0} | {1}", comentario, error.StackTrace);

        //PARA LOG ERROR
        var fileUnicoName = String.Concat("ERROR", ".txt");
        var fileUnicoPath = System.IO.Path.Combine("~/", fileUnicoName);

        using (FileStream fs = new FileStream(fileUnicoPath, FileMode.Create))
        {
            byte[] bytes = Encoding.UTF8.GetBytes(logErrorFinal);
            fs.Write(bytes, 0, bytes.Length);
            fs.Close();
        }

        ViewBag.ErrorMessage = logErrorFinal;

        return string.Format(logErrorFinal);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

