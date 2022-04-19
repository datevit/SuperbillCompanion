using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuperbillCompanion.Models
{
    /// <summary>
    /// Rappresenta una associazione tra utente, e cluster
    /// </summary>
    public class UserTenant
    {
        /// <summary>
        /// Identificativo dell'associazione
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// Identificativo dell'ambiente dati dell'utente nella Suite
        /// </summary>
        public string CodiceAmbienteDati { get; set; }
        /// <summary>
        /// Descrizione dell'ambiente dati nella Suite
        /// </summary>
        public string DescrizioneAmbienteDati { get; set; }
        /// <summary>
        /// Indirizzo del cluster
        /// </summary>
        public string ClusterAddress { get; set; }
    }
}
