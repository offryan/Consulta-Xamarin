using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;//

namespace Consultas
{
    public class Market
    {
        [JsonProperty(PropertyName = "currencies")]
        public Currency currency { get; set; }
        public Market()
        {
            this.currency = new Currency();
        }
    }
}
