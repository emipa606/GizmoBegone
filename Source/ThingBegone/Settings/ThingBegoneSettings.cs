using System;
using System.Collections.Generic;
using Verse;

namespace ThingBegone.Settings
{
    // Token: 0x02000005 RID: 5
    public class ThingBegoneSettings : ModSettings
    {
        // Token: 0x04000012 RID: 18
        public List<string> terrainSaveData = new List<string>();

        // Token: 0x04000011 RID: 17
        public List<string> thingSaveData = new List<string>();

        // Token: 0x0600000C RID: 12 RVA: 0x00002CCF File Offset: 0x00000ECF
        public override void ExposeData()
        {
            Scribe_Collections.Look(ref thingSaveData, "hidenThings", LookMode.Value, Array.Empty<object>());
            Scribe_Collections.Look(ref terrainSaveData, "hidenTerrain", LookMode.Value, Array.Empty<object>());
            base.ExposeData();
        }
    }
}