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
    public static class BanditHeroCreator
    {
        public static Hero CreateNewBandit(Game game)
        {
            int age = 35;
            
            CampaignTime birthDay;

            birthDay = HeroHelper.GetRandomBirthDayForAge((float)age);

            CultureObject banditCulture = null;

            banditCulture = MBObjectManager.Instance.GetObjectTypeList<CultureObject>().FirstOrDefault(x => x.IsMainCulture && x.GetName().ToString() == "Vagabond");
            if (banditCulture != default(CultureObject))
            {

                InformationManager.DisplayMessage(new InformationMessage("DEFAULT CULTURE USED"));

            }
            if (banditCulture != null)
            {
                InformationManager.DisplayMessage(new InformationMessage(banditCulture.GetName().ToString()));
            } else
            {
                InformationManager.DisplayMessage(new InformationMessage("CULTURE IS NULL"));

            }
            CustomClan clan = new CustomClan("Bandit Clan", "Bandits", banditCulture);
            //clan.AddClan(game);

            //newCharacter.HeroObject.Clan = clan.getClan();
            //hero = game.ObjectManager.RegisterPresumedObject<Hero>(new Hero());

            CharacterObject lord = (from x in CharacterObject.Templates
                                        where x.Occupation == Occupation.Wanderer
                                        select x).GetRandomElement<CharacterObject>();
            lord.Name = new TextObject("Bandit Lord Test", null);
            lord.Culture = banditCulture;
            Hero hero = HeroCreator.CreateSpecialHero(lord, null, null, null, -1);
            //GiveGoldAction.ApplyBetweenCharacters(null, hero, 20000, true);
            //hero.HasMet = true;
            //hero.Clan = clan.getClan();
            //hero.ChangeState(Hero.CharacterStates.Active);
            //AddCompanionAction.Apply(Clan.PlayerClan, hero);
            //AddHeroToPartyAction.Apply(hero, MobileParty.MainParty, true);
            //CampaignEventDispatcher.Instance.OnHeroCreated(hero, false);
            return hero;





            //return newCharacter.HeroObject;
        }
    }
}
