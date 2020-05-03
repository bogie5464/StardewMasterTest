using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StardewValley;
using StardewModdingAPI;

namespace MasterTest
{
    public class ModEntry : Mod
    {
        public override void Entry(IModHelper helper)
        {
            helper.Events.GameLoop.DayStarted += GameLoop_DayStarted;
        }

        private void GameLoop_DayStarted(object sender, StardewModdingAPI.Events.DayStartedEventArgs e)
        {
            //Check and log the trues
            if (Game1.IsMasterGame)
            {
                this.Monitor.Log("isMasterGame was true this is not expected.", LogLevel.Warn);
            }

            if (Game1.player.uniqueMultiplayerID == Game1.MasterPlayer.uniqueMultiplayerID)
            {
                this.Monitor.Log("Unique multiplayer ID was the same this is not expected.", LogLevel.Warn);
            }

            if (Game1.player.name == Game1.MasterPlayer.name)
            {
                this.Monitor.Log("player.name was that same this is not expected.", LogLevel.Warn);
            }

            if (Context.IsMainPlayer)
            {
                this.Monitor.Log("SMAPI Context IsMainPlayer was true this is not expected.", LogLevel.Warn);
            }


            //Check and log the nots
            if (!Game1.IsMasterGame)
            {
                this.Monitor.Log("isMasterGame was true this is expected.");
            }

            if (Game1.player.uniqueMultiplayerID != Game1.MasterPlayer.uniqueMultiplayerID)
            {
                this.Monitor.Log("Unique multiplayer ID was the same this is expected.");
            }

            if (Game1.player.name != Game1.MasterPlayer.name)
            {
                this.Monitor.Log("player.name was that same this is expected.");
            }

            if (!Context.IsMainPlayer)
            {
                this.Monitor.Log("SMAPI Context IsMainPlayer was true this is expected.");
            }
        }
    }
}
