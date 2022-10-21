using System;
using System.Collections.Generic;
using Verse;

namespace ThingBegone.Settings;

public class ThingBegoneSettings : ModSettings
{
    public List<string> terrainSaveData = new List<string>();

    public List<string> thingSaveData = new List<string>();

    public override void ExposeData()
    {
        Scribe_Collections.Look(ref thingSaveData, "hidenThings", LookMode.Value, Array.Empty<object>());
        Scribe_Collections.Look(ref terrainSaveData, "hidenTerrain", LookMode.Value, Array.Empty<object>());
        base.ExposeData();
    }
}