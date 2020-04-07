using System;
using Helpers;
using MountAndBlade.CampaignBehaviors;
using TaleWorlds.CampaignSystem;
using TaleWorlds.Core;
using TaleWorlds.Library;
using TaleWorlds.Localization;

namespace BannerlordModule
{
    public static class BanditHeroCreator
    {
        public static Hero CreateNewBandit(Game game)
        {
            int age = 35;
            CharacterObject newCharacter = CharacterObject.CreateFrom(CharacterObject.Find("future_bandit_lord_1"));
            Hero hero = new Hero();
            
            CampaignTime birthDay;

            birthDay = HeroHelper.GetRandomBirthDayForAge((float)age);
            
            newCharacter.HeroObject.BirthDay = birthDay;
            newCharacter.HeroObject.BornSettlement = SettlementHelper.FindRandomSettlement((Settlement x) => x.IsTown && x.Culture == newCharacter.Culture);
            //newCharacter.HeroObject.StaticBodyProperties = BodyProperties.GetRandomBodyProperties(template.IsFemale, template.GetBodyPropertiesMin(false), template.GetBodyPropertiesMax(), 0, MBRandom.RandomInt(), newCharacter.HairTags, newCharacter.BeardTags, newCharacter.TattooTags).StaticProperties;
            newCharacter.HeroObject.DynamicBodyProperties = new DynamicBodyProperties(newCharacter.HeroObject.Age, 0f, 0f);
            newCharacter.Name = new TextObject("{=!}spc", null);

            CultureObject banditCulture = null;

            foreach (CultureObject culture in game.ObjectManager.GetObjectTypeList<CultureObject>())
            {
                if(culture.GetName().ToString().Equals("Vagabond Culture"))
                {
                    banditCulture = culture;
                }
            }

            CustomClan clan = new CustomClan("Bandit Clan", "Bandits", banditCulture);
            clan.AddClan(game);

            newCharacter.HeroObject.Clan = clan.getClan();
            return newCharacter.HeroObject;
        }
    }
}
