using System;
using System.Web.Mvc;
using WEB.Ecommerce.Data;
using WEB.Ecommerce.Models;

namespace WEB.Ecommerce.Models
{
    public class LogAttribute : ActionFilterAttribute
    {
        private DataContexto _db = new DataContexto();

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            Log novo = new Log
            {
                OperationDate = DateTime.Now,
                Action = filterContext.ActionDescriptor.ActionName,
                Machine = filterContext.HttpContext.Server.MachineName,
                //User = filterContext.HttpContext.User.Identity.Name,
                Message = "Mensagem."
            };

            _db.Logs.Add(novo);
            _db.SaveChanges();
        }
    }
}