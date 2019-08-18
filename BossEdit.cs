using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;

namespace BossControl
{
    class BossEdit : GlobalNPC
    {
        static Dictionary<int, bool> npcInvincible;
        static ConfigToucher Karl = new ConfigToucher();



        public override bool PreAI(NPC npc)
        {
            if(npcInvincible == null)
            {
                npcInvincible = Karl.LoadConfig();
            }

            if(npc.boss)
            {
                if (!npcInvincible[npc.netID]) 
                {
                    npc.dontTakeDamage = true;
                    npc.lifeMax = npc.lifeMax * 10;
                    npc.lifeRegen = npc.lifeMax / 2;
                    npc.active = false;
                }
            }




            return base.PreAI(npc);
        }

        /*public void ReloadConfig()
        {
            if (npcInvincible != null)
            {
                npcInvincible = Karl.LoadConfig();
            }
        }*/


    }
}
