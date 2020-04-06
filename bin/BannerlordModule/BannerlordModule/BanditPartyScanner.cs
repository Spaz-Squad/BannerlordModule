using System;
using System.Collections.Generic;
using System.Linq;
using Helpers;
using TaleWorlds.CampaignSystem.Actions;
using TaleWorlds.CampaignSystem.Barterables;
using TaleWorlds.CampaignSystem.CharacterDevelopment.Managers;
using TaleWorlds.Core;
using TaleWorlds.Library;
using TaleWorlds.Localization;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.SandBox.CampaignBehaviors;

namespace BannerlordModule 
{
    public class BanditPartyScanner : CampaignBehaviorBase
    {
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
                if (mobileParty.IsBandit && mobileParty.IsPartyTradeActive)
                {
                    //mobileParty.PartyTradeGold = (int)((double)mobileParty.PartyTradeGold * 0.95 + (double)(50f * (float)mobileParty.Party.MemberRoster.TotalManCount * 0.05f));
                    if (mobileParty.Party.NumberOfAllMembers > 30 && mobileParty.MapEvent != null)
                    {

                        Hero bandit_hero = new Hero();
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
    }
}
