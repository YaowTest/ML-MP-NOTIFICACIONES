using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace WebApplication1.Utilidades
{
    public class Herramientas
    {
        public void LogMPERP(string mensaje1)
        {
            //string logs = System.Web.HttpContext.Current.Server.MapPath("~/Recursos/Logs");
            try
            {
                string logs = System.Web.HttpContext.Current.Server.MapPath("~/Recursos/Logs");
                if (!Directory.Exists(logs))
                    Directory.CreateDirectory(logs);

                if (!File.Exists(logs + "\\logMPERP" + DateTime.Now.ToString("dd-MM-yyyy") + ".txt"))
                {
                    using (FileStream fs = File.Create(logs + "\\logMPERP" + DateTime.Now.ToString("dd-MM-yyyy") + ".txt"))
                    {
                    }
                }
                //if (!File.Exists(logs + "\\logMPERP" + DateTime.Now.ToString("dd-MM-yyyy") + ".txt"))
                //File.Create(logs + "\\logMPERP" + DateTime.Now.ToString("dd-MM-yyyy") + ".txt");
                File.AppendAllText(logs + @"\logMPERP" + DateTime.Now.ToString("dd-MM-yyyy") + ".txt", DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss") + " " + mensaje1 + Environment.NewLine);


            }
            catch (Exception ex)
            {

            }
        }
    }
}