using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlizzardCSharp.Games.Diablo
{
    public class Artisan
    {
        public class ArtisanTraining
        {
            public class Tier
            {
                public int Number { get; internal set; }

                public List<Recipe> TrainedRecipes { get; internal set; }

                public List<Recipe> TaughtRecipes { get; internal set; }

                public Tier(JObject rawData)
                {
                    if (rawData["tier"] != null)
                        Number = int.Parse(rawData["tier"].ToString());
                    if (rawData["trainedRecipes"] != null && rawData["trainedRecipes"].HasValues)
                    {
                        TrainedRecipes = new List<Recipe>();
                        foreach (JObject recipeObject in rawData["trainedRecipes"])
                        {
                            Recipe recipe = new Recipe(recipeObject);

                            TrainedRecipes.Add(recipe);
                        }
                    }
                    if (rawData["taughtRecipes"] != null && rawData["taughtRecipes"].HasValues)
                    {
                        TaughtRecipes = new List<Recipe>();
                        foreach (JObject recipeObject in rawData["taughtRecipes"])
                        {
                            Recipe recipe = new Recipe(recipeObject);
                            TaughtRecipes.Add(recipe);
                        }
                    }
                }
            }

            public List<Tier> Tiers { get; internal set; }

            public ArtisanTraining(JObject rawData)
            {
                if (rawData["tiers"] != null && rawData["tiers"].HasValues)
                {
                    Tiers = new List<Tier>();

                    foreach (JObject tierObject in rawData["tiers"])
                    {
                        Tier tier = new Tier(tierObject);
                        Tiers.Add(tier);
                    }
                }
            }
        }

        public string Slug { get; internal set; }

        public string Name { get; internal set; }

        public string Portrait { get; internal set; }

        public ArtisanTraining Training { get; internal set; }

        public Artisan(JObject rawData)
        {
            if (rawData["slug"] != null)
                Slug = rawData["slug"].ToString();
            if (rawData["name"] != null)
                Name = rawData["name"].ToString();
            if (rawData["portrait"] != null)
                Portrait = rawData["portrait"].ToString();
            if (rawData["training"] != null)
                Training = new ArtisanTraining(JObject.Parse(rawData["training"].ToString()));
        }

    }
}

