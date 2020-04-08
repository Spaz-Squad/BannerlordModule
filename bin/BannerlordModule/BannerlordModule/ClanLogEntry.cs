using System;
using Helpers;
using TaleWorlds.Core;
using TaleWorlds.Localization;
using TaleWorlds.SaveSystem;
using TaleWorlds.CampaignSystem;

namespace BannerlordModule
{
    /*
     * ClanlogEntry was supposed to create a Encyclopedia page for the clan, but I understand now that they are automatically put on there
     * without the call of this method, and that this method causes a crash. So now I am looking into other ways to do this better, and most importantly
     * to edit the encyclopedia pages for my new clans.
     */
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
