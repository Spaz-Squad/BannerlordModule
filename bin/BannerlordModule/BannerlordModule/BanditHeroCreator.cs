using System;
using Helpers;
using MountAndBlade.CampaignBehaviors;
using TaleWorlds.CampaignSystem;
using TaleWorlds.Core;
using TaleWorlds.Library;
using TaleWorlds.Localization;
using System.Collections.Generic;
using TaleWorlds.CampaignSystem.Actions;
using System.Linq;

namespace BannerlordModule
{
    /**
     * BanditHeroCreator is a static class that holds the method CreateNewBandit
     * which creates and returns a new hero which I describe as a bandit
     */
    public static class BanditHeroCreator
    {
        public static Hero CreateNewBandit(Game game)
        {
            CultureObject banditCulture = null;
            // Search for Vagabond Culture
            banditCulture = MBObjectManager.Instance.GetObjectTypeList<CultureObject>().FirstOrDefault(x => x.IsMainCulture && x.GetName().ToString() == "Vagabond");
            if (banditCulture != default(CultureObject))
            {
                // If its not found use default culture. Normally thats null culture
                InformationManager.DisplayMessage(new InformationMessage("DEFAULT CULTURE USED"));

            }

            CustomClan clan = new CustomClan("Bandit Clan", "Bandits", banditCulture); // creates custom clan, initializes it in custom clans constructor
                                                                                       //clan.AddClan(game); // Still causes Crashes

            //hero = game.ObjectManager.RegisterPresumedObject<Hero>(new Hero()); // Causes crashes, I don't think I can do this

            // CharacterObject lord creates a character object that a hero can be made from. 
            // Currently it uses the Occupation.Wanderer template, we will need to make new template for thsi
            CharacterObject lord = (from x in CharacterObject.Templates
                                        where x.Occupation == Occupation.Wanderer
                                        select x).GetRandomElement<CharacterObject>();

            // changes the lords name
            lord.Name = new TextObject("Bandit Lord Test", null);

            // Changes the lords culture
            lord.Culture = banditCulture;

            // creates a hero from the characterObject template. 
            // TODO Change clan add to HeroCreator field
            Hero hero = HeroCreator.CreateSpecialHero(lord, null, null, null, -1);
            //GiveGoldAction.ApplyBetweenCharacters(null, hero, 20000, true); // add later
            hero.Clan = clan.getClan(); // gives the hero the new clan

            // initializes and creates a kingdom using my custom kingdom class
            CustomKingdom kingdom = new CustomKingdom("Vagabond Kingdom", "Vagabond", banditCulture);
            // makes heroes clan join the faction
            hero.Clan.ClanJoinFaction(kingdom.getKingdom());

            //hero.ChangeState(Hero.CharacterStates.Active); // not sure what this does
            //AddCompanionAction.Apply(Clan.PlayerClan, hero); // Adds this hero to players clan
            //AddHeroToPartyAction.Apply(hero, MobileParty.MainParty, true); // use this to test if method works
            //CampaignEventDispatcher.Instance.OnHeroCreated(hero, false); // I believe this crashes
            return hero;
        }
    }
}
