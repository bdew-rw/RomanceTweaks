using HarmonyLib;
using RimWorld;
using Verse;

namespace RomanceTweaks
{
    [HarmonyPatch(typeof(InteractionWorker_RomanceAttempt), "RandomSelectionWeight")]
    [HarmonyAfter("HugsLib.Psychology")]
    // ReSharper disable once UnusedMember.Global
    public class RomanceAttemptRandomSelectionWeightPatcher
    {
        // ReSharper disable once InconsistentNaming
        // ReSharper disable once UnusedMember.Global
        public static float Postfix(float __result, Pawn initiator, Pawn recipient)
        {
            float mod = RomanceTweakMod.RomanceChanceModifier;
            if (RomanceUtils.IsSingle(initiator) && RomanceUtils.IsSingle(recipient))
                mod *= RomanceTweakMod.RomanceChanceModifierSingle;
            if (RomanceTweakMod.DebugMode)
                Log.Message($"[RomTw] Romance Chance {initiator.Name.ToStringShort} -> {recipient.Name.ToStringShort} : {__result} -> {__result * mod}");
            return __result * mod;
        }
    }

    [HarmonyPatch(typeof(InteractionWorker_RomanceAttempt), "SuccessChance")]
    [HarmonyAfter("HugsLib.Psychology")]
    // ReSharper disable once UnusedMember.Global
    public class RomanceAttemptSuccessChancePatcher
    {
        // ReSharper disable once InconsistentNaming
        // ReSharper disable once UnusedMember.Global
        public static float Postfix(float __result, Pawn initiator, Pawn recipient)
        {
            float mod = RomanceTweakMod.RomanceSuccessModifier;
            if (RomanceTweakMod.DebugMode)
                Log.Message($"[RomTw] Romance Success {initiator.Name.ToStringShort} -> {recipient.Name.ToStringShort} : {__result} -> {__result * mod}");
            return __result * mod;
        }
    }
}