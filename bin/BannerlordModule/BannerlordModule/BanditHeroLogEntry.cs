using System;
using Helpers;
using TaleWorlds.Core;
using TaleWorlds.Localization;
using TaleWorlds.SaveSystem;
using TaleWorlds.CampaignSystem;



namespace BannerlordModule
{
    /**
     * BanditHeroLogEntry was supposed to create a Encyclopedia page for the hero, but I understand now that they are automatically put on there 
     * without the call of this method, and that this method causes a crash. So now I am looking into other ways to do this better, and most importantly
     * to edit the encyclopedia pages for my new heroes.
     */
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
