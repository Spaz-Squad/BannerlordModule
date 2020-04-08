using System;
using TaleWorlds.Core;
using TaleWorlds.Localization;
using TaleWorlds.MountAndBlade;
using TaleWorlds.CampaignSystem;
using TaleWorlds.Library;


namespace BannerlordModule
{

    /**
     * This is the main class for my submodule.
     * It runs OnGameStart() which retrieves the Game object, and tells the game about the BanditPartyScanner() Object
     */
    public class Main : MBSubModuleBase
    {        
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

        // Token: 0x06000004 RID: 4 RVA: 0x000020A4 File Offset: 0x000002A4
        private void AddBehaviors(CampaignGameStarter gameInitializer)
        {
            gameInitializer.AddBehavior(new BanditPartyScanner(game));
        }

        public override void OnGameInitializationFinished(Game game)
        {
                this.game = game;
            
        }

        private Game game;

    }
}
