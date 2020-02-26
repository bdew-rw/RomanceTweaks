using Harmony;
using RimWorld;
using Verse;

namespace RomanceTweaks
{
    [HarmonyPatch(typeof(InteractionWorker_Breakup), "RandomSelectionWeight")]
    // ReSharper disable once UnusedMember.Global
    public class BreakupRandomSelectionWeightPatcher
    {
        // ReSharper disable once InconsistentNaming
        // ReSharper disable once UnusedMember.Global
        public static float Postfix(float __result, Pawn initiator, Pawn recipient)
        {
            float mod = RomanceTweakMod.BreakupChanceModifier;
            if (RomanceTweakMod.DebugMode)
                Log.Message($"[RomTw] Breakup Chance {initiator.Name.ToStringShort} -> {recipient.Name.ToStringShort} : {__result} -> {__result * mod}");
            return __result * mod;
        }
    }
}