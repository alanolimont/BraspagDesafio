using BrasPag.Desafio.DataAccess;
using BrasPag.Desafio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BrasPag.Desafio.Controllers
{
    public class MdrController : ApiController
    {
        [HttpGet]
        public IHttpActionResult Get(String id = null) {
            try
            {
                var list = new FakeData().GetMdrAdquirentes();
                if (string.IsNullOrEmpty(id))
                {
                    return Json(list.Select(x => x.Value).ToList());
                }
                else if (list.ContainsKey(id))
                {
                    return Json(list.Where(x => x.Key == id).Select(x => x.Value).ToList());
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}
