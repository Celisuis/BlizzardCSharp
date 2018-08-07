using BlizzardCSharp.Helpers;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlizzardCSharp.Games.Overwatch
{
    public class Hero
    {
        public string Name { get; internal set; }

        public string Role { get; internal set; }

        public int DifficultyRating { get; internal set; }

        public string Description { get; internal set; }

        public Image Portrait { get; internal set; }

        public string PortraitPath { get; internal set; }

        public List<Ability> Abilities { get; internal set; }

        public Story Story { get; internal set; }

        public Hero(JObject rawData)
        {
            if (rawData["name"] != null)
                Name = rawData["name"].ToString();
            if (rawData["role"] != null)
                Role = rawData["role"].ToString();
            if (rawData["difficulty"] != null)
                DifficultyRating = int.Parse(rawData["difficulty"].ToString());
            if (rawData["description"] != null)
                Description = rawData["description"].ToString();
            if(rawData["portrait"] != null)
            {
                PortraitPath = rawData["portrait"].ToString();
                Portrait = ImageHelper.RetrieveImage(PortraitPath);
            }
            if(rawData["abilities"] != null && rawData["abilities"].HasValues)
            {
                Abilities = new List<Ability>();

                foreach(JObject abilityObj in rawData["abilities"])
                {
                    Ability ability = new Ability(abilityObj);
                    Abilities.Add(ability);
                }
            }
            if (rawData["story"] != null)
                Story = new Story(JObject.Parse(rawData["story"].ToString()));

        }
    }
}
