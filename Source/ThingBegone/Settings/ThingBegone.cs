using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Mlie;
using UnityEngine;
using Verse;

namespace ThingBegone.Settings;

internal class ThingBegone : Mod
{
    private static string currentVersion;
    private readonly Listing_Standard listingLowerContent = new();

    private readonly Listing_Standard listingUpperBar = new();

    private readonly ThingBegoneSettings settings;

    private readonly SwitchWidget switchWidget = new();

    private readonly IEnumerable<TerrainDef> terrainDefEnum = DefDatabase<TerrainDef>.AllDefs;

    private readonly IEnumerable<ThingDef> thingDefEnum = DefDatabase<ThingDef>.AllDefs;

    private float rectHeight;

    private bool runFlag = true;

    private bool runFlagEnd = true;

    private Vector2 scrollPos = new(0f, 0f);

    private string searchInput = "";

    private IList<Vector2> terrainVectList;

    private IList<Vector2> thingVectList;

    private float widthFix;

    public ThingBegone(ModContentPack content) : base(content)
    {
        settings = GetSettings<ThingBegoneSettings>();
        currentVersion =
            VersionFromManifest.GetVersionFromModMetaData(content.ModMetaData);
    }

    public override string SettingsCategory()
    {
        return "Gizmo Begone!";
    }

    public override void DoSettingsWindowContents(Rect rect)
    {
        List<ThingDef> filteredThingDef;
        List<TerrainDef> filteredTerrainDef;
        if (searchInput.Length <= 0)
        {
            filteredThingDef = (from t in thingDefEnum
                where t.designationCategory != null
                select t).ToList();
            filteredTerrainDef = (from t in terrainDefEnum
                where t.designationCategory != null
                select t).ToList();
        }
        else
        {
            filteredThingDef = (from t in thingDefEnum
                where t.designationCategory != null
                where t.label.IndexOf(searchInput, StringComparison.OrdinalIgnoreCase) >= 0 ||
                      t.modContentPack?.Name.IndexOf(searchInput, StringComparison.OrdinalIgnoreCase) >= 0
                select t).ToList();
            filteredTerrainDef = (from t in terrainDefEnum
                where t.designationCategory != null
                where t.label.IndexOf(searchInput, StringComparison.OrdinalIgnoreCase) >= 0 ||
                      t.modContentPack?.Name.IndexOf(searchInput, StringComparison.OrdinalIgnoreCase) >= 0
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
        listingUpperBar.Begin(upperBarRect);
        var a = Text.CalcSize("GiBe.Search".Translate()).x;
        var b = Text.CalcSize("GiBe.Clear".Translate()).x;
        var c = Text.CalcSize("GiBe.Hide".Translate()).x;
        var d = Text.CalcSize("GiBe.Unhide".Translate()).x;
        Widgets.Label(new Rect(0f, 0f, a, 22f), "GiBe.Search".Translate());
        searchInput = Widgets.TextField(new Rect(a + 6f, 0f, 200f, 22f), searchInput, 200,
            new Regex("^[a-zA-Z0-9 ]*$"));
        if (Widgets.ButtonText(new Rect(a + 212f, 0f, b + 12f, 22f), "GiBe.Clear".Translate()))
        {
            searchInput = "";
        }

        Widgets.DrawLineVertical(a + b + 228f, 0f, 21f);
        if (Widgets.ButtonText(new Rect(a + b + 234f, 0f, c + 12f, 22f), "GiBe.Hide".Translate()))
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
                switchWidget.ThingSaveData.Add(thing.defName);
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
                switchWidget.TerrainSaveData.Add(terrain.defName);
            }
        }

        if (Widgets.ButtonText(new Rect(a + b + c + 249f, 0f, d + 12f, 22f), "GiBe.Unhide".Translate()))
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
                switchWidget.ThingSaveData.Remove(thing2.defName);
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
                switchWidget.TerrainSaveData.Remove(terrain2.defName);
            }
        }

        if (currentVersion != null)
        {
            GUI.contentColor = Color.gray;
            Widgets.Label(new Rect(a + b + c + d + 280f, 0f, 250f, 22f),
                "GiBe.CurrentModVersion".Translate(currentVersion));
            GUI.contentColor = Color.white;
        }

        listingUpperBar.GapLine(55f);
        listingUpperBar.End();
        Widgets.BeginScrollView(lowerContentRectScroll, ref scrollPos, lowerContentRect);
        listingLowerContent.Begin(lowerContentRect);
        foreach (var thing3 in filteredThingDef.Zip(thingVectList, Tuple.Create))
        {
            switchWidget.Button(thing3.Item1, thing3.Item2);
        }

        foreach (var terrain3 in filteredTerrainDef.Zip(terrainVectList, Tuple.Create))
        {
            switchWidget.Button(terrain3.Item1, terrain3.Item2);
        }


        listingLowerContent.End();
        Widgets.EndScrollView();
    }

    public override void WriteSettings()
    {
        settings.ThingSaveData = (from t in switchWidget.ThingSaveData
            where t.Length > 0
            select t).ToList();
        settings.TerrainSaveData = (from t in switchWidget.TerrainSaveData
            where t.Length > 0
            select t).ToList();
        base.WriteSettings();
    }
}