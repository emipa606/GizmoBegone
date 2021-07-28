using System.Collections.Generic;
using UnityEngine;
using Verse;

namespace ThingBegone.Settings
{
    // Token: 0x02000002 RID: 2
    public class SwitchWidget
    {
        // Token: 0x04000002 RID: 2
        public List<string> terrainSaveData = new List<string>();

        // Token: 0x04000001 RID: 1
        public List<string> thingSaveData = new List<string>();

        // Token: 0x06000001 RID: 1 RVA: 0x00002050 File Offset: 0x00000250
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
                    thingSaveData.Add(thing.defName);
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
                    thingSaveData.Remove(thing.defName);
                }

                Widgets.DrawBoxSolid(new Rect(vector, new Vector2(209.75f, 24f)), new Color(0.6f, 0f, 0f, 0.35f));
            }
        }

        // Token: 0x06000002 RID: 2 RVA: 0x00002190 File Offset: 0x00000390
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
                    terrainSaveData.Add(terrain.defName);
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
                    terrainSaveData.Remove(terrain.defName);
                }

                Widgets.DrawBoxSolid(new Rect(vector, new Vector2(209.75f, 24f)), new Color(0.6f, 0f, 0f, 0.35f));
            }
        }
    }
}