using System.Collections.Generic;
using UnityEngine;
using Verse;

namespace ThingBegone.Settings;

public class SwitchWidget
{
    public readonly List<string> TerrainSaveData = [];

    public readonly List<string> ThingSaveData = [];

    public void Button(ThingDef thing, Vector2 vector)
    {
        if (!thing.designationCategory.defName.Equals("ID1924"))
        {
            if (Widgets.ButtonText(new Rect(vector, new Vector2(209.75f, 24f)), thing.label))
            {
                thing.designationCategory = new DesignationCategoryDef
                {
                    defName = "ID1924"
                };
                ThingSaveData.Add(thing.defName);
            }

            Widgets.DrawBoxSolid(new Rect(vector, new Vector2(209.75f, 24f)), new Color(0f, 0.55f, 0f, 0.35f));
        }
        else
        {
            if (Widgets.ButtonText(new Rect(vector, new Vector2(209.75f, 24f)), thing.label))
            {
                thing.designationCategory = new DesignationCategoryDef
                {
                    defName = "Temp"
                };
                ThingSaveData.Remove(thing.defName);
            }

            Widgets.DrawBoxSolid(new Rect(vector, new Vector2(209.75f, 24f)), new Color(0.6f, 0f, 0f, 0.35f));
        }

        TooltipHandler.TipRegion(new Rect(vector, new Vector2(209.75f, 24f)), thing.modContentPack?.Name);
    }

    public void Button(TerrainDef terrain, Vector2 vector)
    {
        if (!terrain.designationCategory.defName.Equals("ID1924"))
        {
            if (Widgets.ButtonText(new Rect(vector, new Vector2(209.75f, 24f)), terrain.label))
            {
                terrain.designationCategory = new DesignationCategoryDef
                {
                    defName = "ID1924"
                };
                TerrainSaveData.Add(terrain.defName);
            }

            Widgets.DrawBoxSolid(new Rect(vector, new Vector2(209.75f, 24f)), new Color(0f, 0.55f, 0f, 0.35f));
        }
        else
        {
            if (Widgets.ButtonText(new Rect(vector, new Vector2(209.75f, 24f)), terrain.label))
            {
                terrain.designationCategory = new DesignationCategoryDef
                {
                    defName = "Temp"
                };
                TerrainSaveData.Remove(terrain.defName);
            }

            Widgets.DrawBoxSolid(new Rect(vector, new Vector2(209.75f, 24f)), new Color(0.6f, 0f, 0f, 0.35f));
        }

        TooltipHandler.TipRegion(new Rect(vector, new Vector2(209.75f, 24f)), terrain.modContentPack?.Name);
    }
}