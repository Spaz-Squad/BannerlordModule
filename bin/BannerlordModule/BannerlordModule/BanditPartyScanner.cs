﻿using System;
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

        public BanditPartyScanner(Game game)
        {
            this.game = game;
        }

        public override void RegisterEvents()
        {
            CampaignEvents.HeroCreated.AddNonSerializedListener(this, new Action<Hero, bool>(this.HeroCreated));
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
                    if (mobileParty.Party.NumberOfAllMembers >= 15)
                    {

                        InformationManager.DisplayMessage(new InformationMessage("NEW HERO BEGINNING"));

                        // TODO CREATE A RANDOM HERO GENERATOR FOR BANDIT HEROES... 
                        Hero bandit_hero = BanditHeroCreator.CreateNewBandit(game);
                        HeroCreated(bandit_hero, false);
                        mobileParty.Party.Owner = bandit_hero;

                        InformationManager.DisplayMessage(new InformationMessage("NEW HERO CREATED"));

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
         * Here it creates a bandit hero
         */
        private void HeroCreated(Hero hero, bool isBornNaturally)
        {
            LogEntry.AddLogEntry(new BanditHeroLogEntry(hero), CampaignTime.Now);
        }

        private Game game;
    }
}
