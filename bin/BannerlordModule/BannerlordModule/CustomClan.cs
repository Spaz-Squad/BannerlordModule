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
    class CustomClan
    {

        public CustomClan(String name, String informalName, CultureObject culture)
        {
            this.name = name;
            this.informalName = informalName;
            this.culture = culture;
            this.banner = Banner.CreateRandomClanBanner();

            this.clan = new Clan();
            clan.InitializeClan(new TextObject(name, null), new TextObject(informalName, null), culture, banner);
        }

        public void AddClan(Game game)
        {
            this.clan = game.ObjectManager.RegisterPresumedObject<Clan>(new Clan());
        }

        public Clan getClan()
        {
            return clan;
        }

        private String name;
        private String informalName;
        private CultureObject culture;
        private Banner banner;
        private Clan clan;
    }
}
