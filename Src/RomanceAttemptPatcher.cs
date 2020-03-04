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
            if (initiator.Faction.def != recipient.Faction.def)
                mod *= RomanceTweakMod.RomanceChanceModifierDifferentFaction;

            // this can probably be done better than iterating over all relations
            float inc_num = 1f;
            foreach (PawnRelationDef def in initiator.GetRelations(recipient))
            {
                if (def == PawnRelationDefOf.Child ||
                    def == PawnRelationDefOf.HalfSibling ||
                    def == PawnRelationDefOf.Parent ||
                    def == PawnRelationDefOf.Sibling)
                {
                    // close relation, default attraction 0.03
                    inc_num = RomanceTweakMod.IncestModifier_Close;
                }
                else if (def == PawnRelationDefOf.Cousin ||
                    def == PawnRelationDefOf.Grandchild ||
                    def == PawnRelationDefOf.Grandparent ||
                    def == PawnRelationDefOf.NephewOrNiece ||
                    def == PawnRelationDefOf.UncleOrAunt)
                {
                    // medium relation, default attraction 0.25
                    inc_num = RomanceTweakMod.IncestModifier_Medium;
                }
                else if (def == PawnRelationDefOf.GreatGrandchild ||
                    def == PawnRelationDefOf.GreatGrandparent ||
                    def == PawnRelationDefOf.GranduncleOrGrandaunt ||
                    def == PawnRelationDefOf.Kin)
                // missing (no fields in PawnRelationDefOf:
                //  - GrandnephewOrGrandniece
                //  - CousinOnceRemoved
                //  - SecondCousin
                {
                    // far relation, default attraction 0.5
                    inc_num = RomanceTweakMod.IncestModifier_Far;
                }
            }
            mod *= inc_num;

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