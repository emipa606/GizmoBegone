using HarmonyLib;
using RimWorld;
using Verse;

namespace ThingBegone.Core;

[HarmonyPatch(typeof(Designator_Build), nameof(Designator_Build.Visible), MethodType.Getter)]
public class Designator_Build_Visible
{
    private static void Postfix(ref bool __result, BuildableDef ___entDef)
    {
        if (__result && ___entDef.designationCategory.defName.Equals("ID1924"))
        {
            __result = false;
        }
    }
}