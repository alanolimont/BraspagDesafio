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
    public class TransactionController : ApiController
    {
        [HttpPost]
        public IHttpActionResult Post([FromBody] MdrRequest request)
        {
            try
            {
                var msg = "";
                msg = ValidaRequest(request);

                if (!string.IsNullOrEmpty(msg))
                    return BadRequest(msg);

                var response = new MdrResponse();

                var list = new FakeData().GetMdrAdquirentes();

                if (list.ContainsKey(request.Adquirente))
                {
                    Mdr mdr = list[request.Adquirente];
                    double taxa = 0.0;


                    var taxaBandeira = mdr.Taxas.FirstOrDefault(x => x.Bandeira.Equals(request.Bandeira, StringComparison.InvariantCultureIgnoreCase));

                    if (taxaBandeira == null)
                    {
                        return BadRequest("Bandeira Não Encontrada");
                    }
                    if (request.Tipo.Equals("credito", StringComparison.InvariantCultureIgnoreCase))
                    {
                        taxa = taxaBandeira.Credito;
                    }
                    else if (request.Tipo.Equals("debito", StringComparison.InvariantCultureIgnoreCase))
                    {
                        taxa = taxaBandeira.Debito;
                    }
                    else
                    {
                        return BadRequest("Tipo de Transação Inválida");
                    }

                    response.ValorLiquido = request.Valor.Value - (request.Valor.Value * (taxa / 100));
                    if (response.ValorLiquido <= 0)
                    {
                        response.ValorLiquido = 0;
                    }
                    return Json(response);
                }
                else
                {
                    return BadRequest("Adquirente Não Encontrado");
                }
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        private static string ValidaRequest(MdrRequest request)
        {
            var msg = "";
            if (request == null)
                msg = "Request Inválido";
            if (!request.Valor.HasValue)
                msg = "Valor Não Informado";
            if (string.IsNullOrEmpty(request.Adquirente))
                msg = "Adquirente Não Informado";
            if (string.IsNullOrEmpty(request.Bandeira))
                msg = "Bandeira Não Informada";
            if (string.IsNullOrEmpty(request.Tipo))
                msg = "Tipo de Transição Não Informado";
            return msg;
        }
    }
}
