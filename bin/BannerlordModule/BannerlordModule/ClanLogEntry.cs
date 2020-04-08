using System;
using Helpers;
using TaleWorlds.Core;
using TaleWorlds.Localization;
using TaleWorlds.SaveSystem;
using TaleWorlds.CampaignSystem;

namespace BannerlordModule
{
    class ClanLogEntry : LogEntry, IEncyclopediaLog, IChatNotification
    {
        public bool IsVisibleNotification => throw new NotImplementedException();

        public TextObject GetEncyclopediaText()
        {
            throw new NotImplementedException();
        }

        public TextObject GetNotificationText()
        {
            throw new NotImplementedException();
        }

        public bool IsVisibleInEncyclopediaPageOf<T>(T obj) where T : MBObjectBase
        {
            throw new NotImplementedException();
        }
    }
}
