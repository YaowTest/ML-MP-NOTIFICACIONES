using Microsoft.Ajax.Utilities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Utilidades;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private Herramientas _herramientas = new Herramientas();
        public ActionResult Index()
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
        public ActionResult RecibirNotificacion()
        {
            try
            {
                // Leer el cuerpo de la solicitud directamente
                using (var reader = new System.IO.StreamReader(Request.InputStream))
                {
                    string requestBody = reader.ReadToEnd();

                    // Validar si el cuerpo está vacío
                    if (string.IsNullOrWhiteSpace(requestBody))
                    {
                        return new HttpStatusCodeResult(400, "Cuerpo de la solicitud vacío");
                    }

                    // Convertir el JSON a un JObject para procesarlo dinámicamente
                    var jsonObject = Newtonsoft.Json.JsonConvert.DeserializeObject<Newtonsoft.Json.Linq.JObject>(requestBody);

                    // Loguear datos recibidos
                    _herramientas.LogMPERP($"Notificación recibida: {jsonObject}");

                    // Validar campos importantes si es necesario
                    string resource = jsonObject["resource"]?.ToString();
                    string topic = jsonObject["topic"]?.ToString();

                    if (string.IsNullOrEmpty(resource) || string.IsNullOrEmpty(topic))
                    {
                        return new HttpStatusCodeResult(400, "Campos requeridos faltantes");
                    }

                    // Procesar la notificación
                    //_herramientas.LogMPERP($"Procesando notificación: resource={resource}, topic={topic}");

                    // Responder con éxito
                    return new HttpStatusCodeResult(200, "Ok");
                }
            }
            catch (Exception ex)
            {
                // Manejo de otros errores
                return new HttpStatusCodeResult(500, $"Error inesperado: {ex.Message}");
            }
        }


    }
}