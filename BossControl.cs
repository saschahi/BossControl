using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ModLoader;
using Terraria;
using Terraria.ID;

namespace BossControl
{
	public class BossControl : Mod
	{
        static ConfigToucher Karl = new ConfigToucher();


        public BossControl()
		{
            
		}


        public override void PostAddRecipes()
        {
            Karl.CheckConfig();
            Karl.LoadConfig();

        }
        public override void Close()
        {

        }

    }
}