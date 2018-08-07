using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlizzardCSharp.Games.Diablo
{
    public class Reagent
    {
        public int Quantity { get; internal set; }

        public Item Item { get; internal set; }

        public Reagent(JObject rawData)
        {
            if (rawData["quantity"] != null)
                Quantity = int.Parse(rawData["quantity"].ToString());
            if (rawData["item"] != null)
                Item = new Item(JObject.Parse(rawData["item"].ToString()));
        }
    }
}
