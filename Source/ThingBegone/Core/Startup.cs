using System;
using System.Collections.Generic;
using HarmonyLib;
using ThingBegone.Settings;
using Verse;

namespace ThingBegone.Core
{
    // Token: 0x02000007 RID: 7
    [StaticConstructorOnStartup]
    public class Startup
    {
        // Token: 0x06000011 RID: 17 RVA: 0x00002D80 File Offset: 0x00000F80
        static Startup()
        {
            var harmony = new Harmony("com.Rimworld.Mod.ThingBegone!");
            harmony.PatchAll();
            IEnumerable<string> thingSaveData = LoadedModManager.GetMod<Settings.ThingBegone>()
                .GetSettings<ThingBegoneSettings>().thingSaveData;
            IEnumerable<string> terrainSaveData = LoadedModManager.GetMod<Settings.ThingBegone>()
                .GetSettings<ThingBegoneSettings>().terrainSaveData;
            foreach (var defName in thingSaveData)
            {
                try
                {
                    ThingDef.Named(defName).designationCategory = new DesignationCategoryDef
                    {
                        defName = "ID1924"
                    };
                }
                catch (Exception)
                {
                    // ignored
                }
            }

            foreach (var defName2 in terrainSaveData)
            {
                try
                {
                    TerrainDef.Named(defName2).designationCategory = new DesignationCategoryDef
                    {
                        defName = "ID1924"
                    };
                }
                catch (Exception)
                {
                    // ignored
                }
            }
        }
    }
}