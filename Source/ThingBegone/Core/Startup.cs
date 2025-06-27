using System;
using System.Collections.Generic;
using HarmonyLib;
using ThingBegone.Settings;
using Verse;

namespace ThingBegone.Core;

[StaticConstructorOnStartup]
public class Startup
{
    static Startup()
    {
        var harmony = new Harmony("com.Rimworld.Mod.ThingBegone!");
        harmony.PatchAll();
        IEnumerable<string> thingSaveData = LoadedModManager.GetMod<Settings.ThingBegone>()
            .GetSettings<ThingBegoneSettings>().ThingSaveData;
        IEnumerable<string> terrainSaveData = LoadedModManager.GetMod<Settings.ThingBegone>()
            .GetSettings<ThingBegoneSettings>().TerrainSaveData;
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