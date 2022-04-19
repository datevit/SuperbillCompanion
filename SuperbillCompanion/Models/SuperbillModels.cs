using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuperbillCompanion.Models
{
    public class Ditta
    {
        public int IDElemento { get; set; }
        public string Codice { get; set; }
        public string Descrizione { get; set; }
    }

    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class Documento
    {
        public int ID { get; set; }
        public DateTime DataDocumento { get; set; }
        public string NumeroDocumento { get; set; }
        public int StatoDocumento { get; set; }
        public int IDCliente { get; set; }
        public string Denominazione { get; set; }
        public decimal Imponibile { get; set; }
        public decimal IVA { get; set; }
        public decimal Totale { get; set; }
        public int? StatoInvio { get; set; }
        public DateTime LastUpdate { get; set; }
    }

    public class PageResults<T>
    {
        public int TotalCount { get; set; }
        public int PageCount { get; set; }
        public int Page { get; set; }
        public IEnumerable<T> Items { get; set; }
    }

    public class RequestViewModel
    {
        public string ApiKey { get; set; }
        public string TenantId { get; set; }

        public int? IdElemento { get; set; }

    }

}
