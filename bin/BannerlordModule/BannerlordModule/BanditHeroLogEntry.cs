using System;
using Helpers;
using TaleWorlds.Core;
using TaleWorlds.Localization;
using TaleWorlds.SaveSystem;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.Encyclopedia;



namespace BannerlordModule
{
    class BanditHeroLogEntry : LogEntry, IEncyclopediaLog, IChatNotification
    {

        public bool IsVisibleNotification
        {
            get
            {
                return true;
            }
        }

        public override ChatNotificationType NotificationType
        {
            get
            {
                return base.PoliticalNotification(this.banditHero.Clan);
            }
        }

        public TextObject GetNotificationText()
        {
            return this.GetEncyclopediaText();
        }

        public bool IsVisibleInEncyclopediaPageOf<T>(T obj) where T : MBObjectBase
        {
            return obj == this.banditHero;
        }

        public BanditHeroLogEntry(Hero banditHero)
        {
            this.banditHero = banditHero;
        }

        public TextObject GetEncyclopediaText()
        {
            TextObject textObject = GameTexts.FindText("str_notification_character_born", null);
            StringHelpers.SetCharacterProperties("HERO", this.banditHero.CharacterObject, null, textObject);
            StringHelpers.SetCharacterProperties("MOTHER", this.banditHero.Mother.CharacterObject, null, textObject);
            StringHelpers.SetCharacterProperties("FATHER", this.banditHero.Father.CharacterObject, null, textObject);
            return textObject;
        }

        public override string ToString()
        {
            return this.GetEncyclopediaText().ToString();
        }

        [SaveableField(100)]
        public readonly Hero banditHero;
    }
}
