using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.IO;
using Terraria.ModLoader;

namespace BossControl
{
    class ConfigToucher
    {
        static string ConfigPath = Path.Combine(Main.SavePath, "Mod Configs", "Boss Controll" + ".json");
        private Dictionary<int, bool> npcInvincible = new Dictionary<int, bool>();
        static Preferences Configuration = new Preferences(ConfigPath);
        public static bool standardKillable = true;




        public Dictionary<int, bool> LoadConfig()
        {
            if (Configuration.Load())
            {
                Configuration.Get("StandardSpawnable", ref standardKillable);

                for (int i = 0; i < NPCLoader.NPCCount; i++)
                {
                    NPC npc = new NPC();

                    npc.SetDefaults(i);


                    if (npc.boss)
                    {
                        string a = npc.TypeName + "_is_Spawnable";
                        a = a.Replace(" ", "_");
                        bool temp = false;
                        try
                        {
                            if (!Configuration.Contains(a))
                            {
                                string temp2 = "_is_Spawnable";
                                string temp3 = npc.TypeName + temp2;
                                Configuration.Put(temp3, standardKillable);
                                Configuration.Save();
                            }

                            Configuration.Get(a, ref temp);
                            npcInvincible[npc.netID] = temp;
                        }
                        catch
                        {
                            //CreateConfig();

                            string temp2 = "_is_Spawnable";
                            string temp3 = npc.TypeName + temp2;
                            Configuration.Put(temp3, standardKillable);
                            Configuration.Save();

                            Configuration.Get(a, ref temp);
                            npcInvincible[npc.netID] = temp;
                        }
                    }
                }
            }
            else
            {
                CreateConfig();
                npcInvincible = LoadConfig();
            }


            return npcInvincible;



        }

        public void CheckConfig()
        {
            if (Configuration.Load())
            {

            }
            else
            {
                CreateConfig();
            }
        }

        static void CreateConfig()
        {
            Configuration.Clear();
            Configuration.Put("StandardSpawnable", standardKillable);


            string alpha = "_is_Spawnable";

            for (int i = 0; i < NPCLoader.NPCCount; i++)
            {
                NPC npc = new NPC();
                npc.SetDefaults(i);

                if (npc.boss)
                {
                    string beta = npc.TypeName + alpha;
                    beta = beta.Replace(" ", "_");
                    Configuration.Put(beta, standardKillable);
                }
            }
            Configuration.Save();

        }

    }
}
