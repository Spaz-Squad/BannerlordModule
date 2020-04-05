using System;
using TaleWorlds.Core;
using TaleWorlds.Localization;
using TaleWorlds.MountAndBlade;

namespace BannerlordModule
{
    public class MySubModule : MBSubModuleBase
    {
        protected override void OnSubModuleLoad()
        {
            Module.CurrentModule.AddInitialStateOption(new InitialStateOption("Message",
            new TextObject("Message", null),
            9990, () => { InformationManager.DisplayMessage(new InformationMessage("Hello World!")); }, false));
        }
    }
}
