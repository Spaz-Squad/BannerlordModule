using System;
using TaleWorlds.Core;
using TaleWorlds.Localization;
using TaleWorlds.MountAndBlade;
using TaleWorlds.CampaignSystem;

namespace BannerlordModule
{
    public class Main : MBSubModuleBase
    {
        protected override void OnSubModuleLoad()
        {
            Module.CurrentModule.AddInitialStateOption(new InitialStateOption("Message",
            new TextObject("Message", null),
            9990, () => { InformationManager.DisplayMessage(new InformationMessage("Hello World!")); }, false));
        }

        protected override void OnGameStart(Game game, IGameStarter gameStarterObject)
        {
            Campaign campaign = game.GameType as Campaign;
            bool flag = campaign == null;
            if (!flag)
            {
                CampaignGameStarter gameInitializer = (CampaignGameStarter)gameStarterObject;
                this.AddBehaviors(gameInitializer);
                this.AddGameModels(gameInitializer);
            }
        }

        // Token: 0x06000002 RID: 2 RVA: 0x0000208B File Offset: 0x0000028B
        private void AddGameModels(CampaignGameStarter gameInitializer)
        {
        }

        // Token: 0x06000003 RID: 3 RVA: 0x0000208E File Offset: 0x0000028E
        protected override void OnApplicationTick(float dt)
        {
            Console.WriteLine("DO SMTH");
            base.OnApplicationTick(dt);
        }

        // Token: 0x06000004 RID: 4 RVA: 0x000020A4 File Offset: 0x000002A4
        private void AddBehaviors(CampaignGameStarter gameInitializer)
        {
            gameInitializer.AddBehavior(new BanditPartyScanner());
        }
    }
}
