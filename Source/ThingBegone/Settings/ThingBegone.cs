using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using UnityEngine;
using Verse;

namespace ThingBegone.Settings
{
    // Token: 0x02000004 RID: 4
    internal class ThingBegone : Mod
    {
        // Token: 0x04000008 RID: 8
        private readonly Listing_Standard listing_LowerContent = new Listing_Standard();

        // Token: 0x04000007 RID: 7
        private readonly Listing_Standard listing_UpperBar = new Listing_Standard();

        // Token: 0x04000009 RID: 9
        private readonly SwitchWidget switchWidget = new SwitchWidget();

        // Token: 0x04000005 RID: 5
        private readonly IEnumerable<TerrainDef> terrainDef_Enum = DefDatabase<TerrainDef>.AllDefs;

        // Token: 0x04000004 RID: 4
        private readonly IEnumerable<ThingDef> thingDef_Enum = DefDatabase<ThingDef>.AllDefs;

        // Token: 0x04000010 RID: 16
        private float rectHeight;

        // Token: 0x0400000D RID: 13
        private bool runFlag = true;

        // Token: 0x0400000E RID: 14
        private bool runFlagEnd = true;

        // Token: 0x04000006 RID: 6
        private Vector2 scrollPos = new Vector2(0f, 0f);

        // Token: 0x0400000A RID: 10
        private string searchInput = "";

        // Token: 0x04000003 RID: 3
        public ThingBegoneSettings settings;

        // Token: 0x0400000C RID: 12
        private IList<Vector2> terrainVectList;

        // Token: 0x0400000B RID: 11
        private IList<Vector2> thingVectList;

        // Token: 0x0400000F RID: 15
        private float widthFix;

        // Token: 0x06000007 RID: 7 RVA: 0x000023E8 File Offset: 0x000005E8
        public ThingBegone(ModContentPack content) : base(content)
        {
            settings = GetSettings<ThingBegoneSettings>();
        }

        // Token: 0x06000006 RID: 6 RVA: 0x000023E0 File Offset: 0x000005E0
        public override string SettingsCategory()
        {
            return "Gizmo Begone!";
        }

        // Token: 0x06000008 RID: 8 RVA: 0x00002488 File Offset: 0x00000688
        public override void DoSettingsWindowContents(Rect rect)
        {
            List<ThingDef> filteredThingDef;
            List<TerrainDef> filteredTerrainDef;
            if (searchInput.Length <= 0)
            {
                filteredThingDef = (from t in thingDef_Enum
                    where t.designationCategory != null
                    select t).ToList();
                filteredTerrainDef = (from t in terrainDef_Enum
                    where t.designationCategory != null
                    select t).ToList();
            }
            else
            {
                filteredThingDef = (from t in thingDef_Enum
                    where t.designationCategory != null
                    where t.label.IndexOf(searchInput, StringComparison.OrdinalIgnoreCase) >= 0
                    select t).ToList();
                filteredTerrainDef = (from t in terrainDef_Enum
                    where t.designationCategory != null
                    where t.label.IndexOf(searchInput, StringComparison.OrdinalIgnoreCase) >= 0
                    select t).ToList();
            }

            if (!filteredThingDef.NullOrEmpty())
            {
                thingVectList = Tool.SetVectorCount(filteredThingDef.Count);
                if (thingVectList.Last().y > rect.height - 70f && runFlag)
                {
                    rectHeight = thingVectList.Last().y + 150f;
                    widthFix = 16f;
                    runFlag = false;
                }
            }

            if (!filteredTerrainDef.NullOrEmpty())
            {
                terrainVectList = Tool.SetVectorCount(filteredThingDef.Count, filteredTerrainDef.Count);
                if (terrainVectList.Last().y > rect.height - 70f && runFlagEnd)
                {
                    rectHeight = terrainVectList.Last().y + 150f;
                    widthFix = 16f;
                    runFlagEnd = false;
                }
            }

            var upperBarRect = new Rect(rect.x, rect.y, rect.width, 70f);
            var lowerContentRect = new Rect(rect.x, upperBarRect.height + 5f, rect.width - widthFix,
                Math.Abs(rectHeight - upperBarRect.height));
            var lowerContentRectScroll = new Rect(rect.x, upperBarRect.height + 5f, rect.width,
                rect.height - upperBarRect.height);
            listing_UpperBar.Begin(upperBarRect);
            var a = Text.CalcSize("Search:").x;
            var b = Text.CalcSize("Clear").x;
            var c = Text.CalcSize("Hide all").x;
            var d = Text.CalcSize("Unhide all").x;
            Widgets.Label(new Rect(0f, 0f, a, 22f), "Search:");
            searchInput = Widgets.TextField(new Rect(a + 6f, 0f, 200f, 22f), searchInput, 200,
                new Regex("^[a-zA-Z0-9 ]*$"));
            if (Widgets.ButtonText(new Rect(a + 212f, 0f, b + 12f, 22f), "Clear"))
            {
                searchInput = "";
            }

            Widgets.DrawLineVertical(a + b + 228f, 0f, 21f);
            if (Widgets.ButtonText(new Rect(a + b + 234f, 0f, c + 12f, 22f), "Hide all"))
            {
                foreach (var thing in filteredThingDef)
                {
                    if (thing.designationCategory.defName.Equals("ID1924"))
                    {
                        continue;
                    }

                    thing.designationCategory = new DesignationCategoryDef
                    {
                        defName = "ID1924"
                    };
                    switchWidget.thingSaveData.Add(thing.defName);
                }

                foreach (var terrain in filteredTerrainDef)
                {
                    if (terrain.designationCategory.defName.Equals("ID1924"))
                    {
                        continue;
                    }

                    terrain.designationCategory = new DesignationCategoryDef
                    {
                        defName = "ID1924"
                    };
                    switchWidget.terrainSaveData.Add(terrain.defName);
                }
            }

            if (Widgets.ButtonText(new Rect(a + b + c + 249f, 0f, d + 12f, 22f), "Unhide all"))
            {
                foreach (var thing2 in filteredThingDef)
                {
                    if (!thing2.designationCategory.defName.Equals("ID1924"))
                    {
                        continue;
                    }

                    thing2.designationCategory = new DesignationCategoryDef
                    {
                        defName = "Temp"
                    };
                    switchWidget.thingSaveData.Remove(thing2.defName);
                }

                foreach (var terrain2 in filteredTerrainDef)
                {
                    if (!terrain2.designationCategory.defName.Equals("ID1924"))
                    {
                        continue;
                    }

                    terrain2.designationCategory = new DesignationCategoryDef
                    {
                        defName = "Temp"
                    };
                    switchWidget.terrainSaveData.Remove(terrain2.defName);
                }
            }

            listing_UpperBar.GapLine(55f);
            listing_UpperBar.End();
            Widgets.BeginScrollView(lowerContentRectScroll, ref scrollPos, lowerContentRect);
            listing_LowerContent.Begin(lowerContentRect);
            foreach (var thing3 in filteredThingDef.Zip(thingVectList, Tuple.Create))
            {
                switchWidget.Button(thing3.Item1, thing3.Item2);
            }

            foreach (var terrain3 in filteredTerrainDef.Zip(terrainVectList, Tuple.Create))
            {
                switchWidget.Button(terrain3.Item1, terrain3.Item2);
            }

            listing_LowerContent.End();
            Widgets.EndScrollView();
        }

        // Token: 0x06000009 RID: 9 RVA: 0x00002C08 File Offset: 0x00000E08
        public override void WriteSettings()
        {
            settings.thingSaveData = (from t in switchWidget.thingSaveData
                where t.Length > 0
                select t).ToList();
            settings.terrainSaveData = (from t in switchWidget.terrainSaveData
                where t.Length > 0
                select t).ToList();
            base.WriteSettings();
        }
    }
}