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
            //CharacterObject newCharacter = CharacterObject.CreateFrom(CharacterObject.Find("future_bandit_lord_1"));
            //Hero hero;
            
            CampaignTime birthDay;

            birthDay = HeroHelper.GetRandomBirthDayForAge((float)age);

            //newCharacter.HeroObject.BirthDay = birthDay;
            //newCharacter.HeroObject.BornSettlement = SettlementHelper.FindRandomSettlement((Settlement x) => x.IsTown && x.Culture == newCharacter.Culture);
            //newCharacter.HeroObject.StaticBodyProperties = BodyProperties.GetRandomBodyProperties(template.IsFemale, template.GetBodyPropertiesMin(false), template.GetBodyPropertiesMax(), 0, MBRandom.RandomInt(), newCharacter.HairTags, newCharacter.BeardTags, newCharacter.TattooTags).StaticProperties;
            //newCharacter.HeroObject.DynamicBodyProperties = new DynamicBodyProperties(newCharacter.HeroObject.Age, 0f, 0f);
            //newCharacter.Name = new TextObject("{=!}spc", null);

            CultureObject banditCulture = null;

            banditCulture = MBObjectManager.Instance.GetObjectTypeList<CultureObject>().FirstOrDefault(x => x.IsMainCulture && x.GetName().ToString() == "Parzival's Regime");
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
            //CustomClan clan = new CustomClan("Bandit Clan", "Bandits", banditCulture);
            //clan.AddClan(game);

            //newCharacter.HeroObject.Clan = clan.getClan();
            //hero = game.ObjectManager.RegisterPresumedObject<Hero>(new Hero());

            Hero hero = null;
            CharacterObject lord = (from x in CharacterObject.Templates
                                        where x.Occupation == Occupation.Wanderer
                                        select x).GetRandomElement<CharacterObject>();
            //Settlement randomElement = (from settlement in Settlement.All
            //                            where settlement.Culture == lord.Culture && settlement.IsTown
             //                           select settlement).GetRandomElement<Settlement>();
            //Hero hero = HeroCreator.CreateSpecialHero(lord, randomElement, null, null, -1);
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
