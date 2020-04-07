using System;
using System.Collections.Generic;
using System.Linq;
using Helpers;
using TaleWorlds.Core;
using TaleWorlds.Library;
using TaleWorlds.Localization;
using TaleWorlds.CampaignSystem;

namespace BannerlordModule 
{
    public class BanditPartyScanner : CampaignBehaviorBase
    {

        public static int totalHeroesCreated = 0;

        public BanditPartyScanner(Game game)
        {
            this.game = game;
        }

        public override void RegisterEvents()
        {
            CampaignEvents.DailyTickEvent.AddNonSerializedListener(this, new Action(this.DailyTick));
        }

        public override void SyncData(IDataStore dataStore)
        { }

        public void DailyTick()
        {
            foreach (MobileParty mobileParty in MobileParty.All)
            {
                if (mobileParty.IsBandit)
                {
                    if (totalHeroesCreated < 1 && mobileParty.Party.NumberOfAllMembers >= 15)
                    {

                        InformationManager.DisplayMessage(new InformationMessage("NEW HERO BEGINNING"));

                        Hero bandit_hero = BanditHeroCreator.CreateNewBandit(game);
                        //AddHeroToLog(bandit_hero, false);
                        //mobileParty.Party.Owner = bandit_hero;

                        InformationManager.DisplayMessage(new InformationMessage("NEW HERO CREATED"));
                        totalHeroesCreated++;
                    }

                }
                /*
                if (mobileParty.Party.NumberOfAllMembers > 5)
                    {
                        InformationManager.DisplayMessage(new InformationMessage("Hello World!"));
                    }
                    */
            }
        }

        /*
         * Here it creates a bandit hero in the log
         */
        private void AddHeroToLog(Hero hero, bool isBorn)
        {
            LogEntry.AddLogEntry(new BanditHeroLogEntry(hero), CampaignTime.Now);
        }

        private Game game;
    }
}
