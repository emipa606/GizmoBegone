using HarmonyLib;
using RimWorld;
using Verse;

namespace ThingBegone.Core
{
    // Token: 0x02000006 RID: 6
    [HarmonyPatch(typeof(Designator_Build), "Visible", MethodType.Getter)]
    public class Designator_Build_Patch
    {
        // Token: 0x0600000E RID: 14 RVA: 0x00002D28 File Offset: 0x00000F28
        private static void Postfix(ref bool __result, BuildableDef ___entDef)
        {
            if (__result && ___entDef.designationCategory.defName.Equals("ID1924"))
            {
                __result = false;
            }
        }
    }
}