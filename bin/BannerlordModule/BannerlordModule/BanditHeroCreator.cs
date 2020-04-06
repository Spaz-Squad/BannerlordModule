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
        private static Hero CreateNewHero(CharacterObject template, int age = -1)
        {
            
            CharacterObject newCharacter = CharacterObject.CreateFrom(CharacterObject.Find("dead_bandit_lord_1"));
            Hero hero = HeroCreator.CreateSpecialHero(newCharacter);
            CampaignTime birthDay;
            if (age == -1)
            {
                birthDay = HeroHelper.GetRandomBirthDayForAge((float)(Campaign.Current.Models.AgeModel.HeroComesOfAge + MBRandom.RandomInt(30)));
            }
            else if (age == 0)
            {
                birthDay = CampaignTime.Now;
            }
            else
            {
                birthDay = HeroHelper.GetRandomBirthDayForAge((float)age);
            }
            newCharacter.HeroObject.BirthDay = birthDay;
            newCharacter.HeroObject.BornSettlement = SettlementHelper.FindRandomSettlement((Settlement x) => x.IsTown && x.Culture == newCharacter.Culture);
            newCharacter.HeroObject.StaticBodyProperties = BodyProperties.GetRandomBodyProperties(template.IsFemale, template.GetBodyPropertiesMin(false), template.GetBodyPropertiesMax(), 0, MBRandom.RandomInt(), newCharacter.HairTags, newCharacter.BeardTags, newCharacter.TattooTags).StaticProperties;
            newCharacter.HeroObject.DynamicBodyProperties = new DynamicBodyProperties(newCharacter.HeroObject.Age, 0f, 0f);
            newCharacter.Name = new TextObject("{=!}spc", null);
            newCharacter.HeroObject.Clan = CampaignData.NeutralFaction;
            return newCharacter.HeroObject;
        }
    }
}
