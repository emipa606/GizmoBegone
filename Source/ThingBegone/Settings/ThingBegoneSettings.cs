using System.Collections.Generic;
using Verse;

namespace ThingBegone.Settings;

public class ThingBegoneSettings : ModSettings
{
    public List<string> TerrainSaveData = [];

    public List<string> ThingSaveData = [];

    public override void ExposeData()
    {
        Scribe_Collections.Look(ref ThingSaveData, "hidenThings", LookMode.Value);
        Scribe_Collections.Look(ref TerrainSaveData, "hidenTerrain", LookMode.Value);
        base.ExposeData();
    }
}