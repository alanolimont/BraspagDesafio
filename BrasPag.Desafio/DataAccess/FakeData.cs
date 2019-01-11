using BrasPag.Desafio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BrasPag.Desafio.DataAccess
{
    public class FakeData
    {
        public Dictionary<string, Mdr> GetMdrAdquirentes()
        {
            Dictionary<string,Mdr> list = new Dictionary<string, Mdr>();
            //Adquirente A
            list.Add("A",new Mdr()
            {
                Adquirente = "Adquirente A",
                Taxas = new List<Taxa>() {
                        new Taxa() {
                            Bandeira = "Visa",
                            Credito=2.25,
                            Debito=2.00
                        },
                        new Taxa() {
                            Bandeira = "Master",
                            Credito=2.35,
                            Debito=1.98
                        }
                }
            });
            //Adquirente B
            list.Add("B", new Mdr()
            {
                Adquirente = "Adquirente B",
                Taxas = new List<Taxa>() {
                        new Taxa() {
                            Bandeira = "Visa",
                            Credito=2.50,
                            Debito=2.08
                        },
                        new Taxa() {
                            Bandeira = "Master",
                            Credito=2.65,
                            Debito=1.75
                        }
                }
            });
            //Adquirente C
            list.Add("C", new Mdr()
            {
                Adquirente = "Adquirente C",
                Taxas = new List<Taxa>() {
                        new Taxa() {
                            Bandeira = "Visa",
                            Credito=2.75,
                            Debito=2.16
                        },
                        new Taxa() {
                            Bandeira = "Master",
                            Credito=3.10,
                            Debito=1.58
                        }
                }
            });
            return list;
        }
    }
}