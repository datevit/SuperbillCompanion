using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SuperbillCompanion.Models
{
    public class SettingsViewModel
    {
        [Required(AllowEmptyStrings = false)]
        public string AuthKey { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string TenantId { get; set; }

        public IEnumerable<UserTenant> Tenants { get; set; }
    }
}
