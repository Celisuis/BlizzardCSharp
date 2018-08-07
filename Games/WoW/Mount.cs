using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlizzardCSharp.Games.WoW
{
    public class Mount
    {
        public string Name { get; internal set; }

        public int SpellID { get; internal set; }

        public int CreatureID { get; internal set; }

        public int ItemID { get; internal set; }

        public int QualityID { get; internal set; }

        public string Icon { get; internal set; }

        public bool IsGroundMount { get; internal set; }

        public bool IsFlyingMount { get; internal set; }

        public bool IsAquaticMount { get; internal set; }

        public bool IsJumping { get; internal set; }

        public Mount(JObject MountObject)
        {
            Name = MountObject["name"].ToString();
            SpellID = int.Parse(MountObject["spellId"].ToString());
            CreatureID = int.Parse(MountObject["creatureId"].ToString());
            QualityID = int.Parse(MountObject["qualityId"].ToString());
            ItemID = int.Parse(MountObject["itemId"].ToString());
            Icon = MountObject["icon"].ToString();
            IsGroundMount = bool.Parse(MountObject["isGround"].ToString());
            IsFlyingMount = bool.Parse(MountObject["isFlying"].ToString());
            IsAquaticMount = bool.Parse(MountObject["isAquatic"].ToString());
            IsJumping = bool.Parse(MountObject["isJumping"].ToString());
        }
    }
}
