using System.Collections.Generic;
using Verse;

namespace ThingBegone.Settings;

public class ThingBegoneSettings : ModSettings
{
    public List<string> terrainSaveData = [];

    public List<string> thingSaveData = [];

    public override void ExposeData()
    {
        Scribe_Collections.Look(ref thingSaveData, "hidenThings", LookMode.Value, []);
        Scribe_Collections.Look(ref terrainSaveData, "hidenTerrain", LookMode.Value, []);
        base.ExposeData();
    }
}