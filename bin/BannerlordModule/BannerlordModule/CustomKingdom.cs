using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using Helpers;
using TaleWorlds.CampaignSystem.Actions;
using TaleWorlds.CampaignSystem.CharacterDevelopment.Managers;
using TaleWorlds.Core;
using TaleWorlds.Library;
using TaleWorlds.Localization;
using TaleWorlds.SaveSystem;
using TaleWorlds.CampaignSystem;

namespace BannerlordModule
{
    class CustomKingdom
    {

        public CustomKingdom(String name, String informalName, CultureObject culture)
        {
            this.name = name;
            this.informalName = informalName;
            this.culture = culture;
            this.banner = Banner.CreateRandomClanBanner();
            this.kingdomColor1 = 7468453;
            this.kingdomColor2 = 7461621;

            kingdom = new Kingdom();
            kingdom.InitializeKingdom(new TextObject(name), new TextObject(informalName), culture, banner, kingdomColor1, kingdomColor2);
        }

        public Kingdom getKingdom()
        {
            return kingdom;
        }

        private String name;
        private String informalName;
        private CultureObject culture;
        private Banner banner;
        private uint kingdomColor1;
        private uint kingdomColor2;

        private Kingdom kingdom;
    }
}
