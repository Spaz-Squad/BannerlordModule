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
        // Currently only here for testing. TotalHeroesCreated lets me limit number of heroes created by the loop to 1
        public static int totalHeroesCreated = 0;

        /**
         * The constructor for BanditPartyScanner only requires a handle on Game, which it saves for later in a field
         */
        public BanditPartyScanner(Game game)
        {
            this.game = game;
        }

        /**
         * Adds my DailyTick function to the Games DailyTick loop
         */
        public override void RegisterEvents()
        {
            CampaignEvents.DailyTickEvent.AddNonSerializedListener(this, new Action(this.DailyTick));
        }

        public override void SyncData(IDataStore dataStore)
        { }

        /**
         * Daily Tick runs on every day tick
         * It checks every mobileParty to see if they are a bandit party
         * if so it checks to see if we have made a new hero yet and if the party has enough members
         * then it displays a message saying that it is creating the hero, it creates the hero by calling
         * BanditHeroCreator.CreateNewBandit and then it displays a new message
         */
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
                        //AddHeroToLog(bandit_hero); // Currently causes crash
                        //mobileParty.Party.Owner = bandit_hero; // unknown what this does still. I want it to make it the bandit parties leader

                        InformationManager.DisplayMessage(new InformationMessage("NEW HERO CREATED"));
                        totalHeroesCreated++;
                    }

                }
            }
        }

        /*
         * Here it creates a bandit hero in the log
         */
        private void AddHeroToLog(Hero hero)
        {
            LogEntry.AddLogEntry(new BanditHeroLogEntry(hero), CampaignTime.Now);
        }

        private Game game;
    }
}
