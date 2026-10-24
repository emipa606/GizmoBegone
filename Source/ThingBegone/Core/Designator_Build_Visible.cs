using HarmonyLib;
using RimWorld;
using Verse;

namespace ThingBegone.Core;

[HarmonyPatch(typeof(Designator_Build), nameof(Designator_Build.Visible), MethodType.Getter)]
public static class Designator_Build_Visible
{
    public static void Postfix(ref bool __result, BuildableDef ___entDef)
    {
        if (__result && ___entDef?.designationCategory?.defName.Equals("ID1924") == true)
        {
            __result = false;
        }
    }
}