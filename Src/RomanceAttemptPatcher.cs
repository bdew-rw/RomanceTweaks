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
            if (__result == 0) return __result;

            float mod = RomanceTweaksSettings.RomanceChanceModifier;
            string cats = "General";

            if (RomanceUtils.IsSingle(initiator) && RomanceUtils.IsSingle(recipient))
            {
                mod *= RomanceTweaksSettings.RomanceChanceModifierSingle;
                cats += ", Singles";
            }
            else if (!RomanceUtils.IsLover(initiator, recipient))
            {
                // If one of them isn't single, and they arent in a relationship it must be cheating
                mod *= RomanceTweaksSettings.RomanceChanceModifierCheating;
                cats += ", Cheating";
            }

            if (initiator.Faction != recipient.Faction)
            {
                mod *= RomanceTweaksSettings.RomanceChanceModifierFaction;
                cats += ", CrossFaction";
            }

            if (RomanceTweaksSettings.DebugMode)
                Log.Message($"[RomTw] Romance Chance {initiator.Name.ToStringShort} -> {recipient.Name.ToStringShort} : {__result} -> {__result * mod} [{cats}]");
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
            if (__result == 0) return __result;
            float mod = RomanceTweaksSettings.RomanceSuccessModifier;
            if (RomanceTweaksSettings.DebugMode)
                Log.Message($"[RomTw] Romance Success {initiator.Name.ToStringShort} -> {recipient.Name.ToStringShort} : {__result} -> {__result * mod}");
            return __result * mod;
        }
    }
}