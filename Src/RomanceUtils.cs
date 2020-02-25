using RimWorld;
using Verse;

namespace RomanceTweaks
{
    public static class RomanceUtils
    {
        public static bool IsSingle(Pawn pawn)
        {
            return pawn.relations.GetFirstDirectRelationPawn(PawnRelationDefOf.Lover, x => !x.Dead) == null &&
                   pawn.relations.GetFirstDirectRelationPawn(PawnRelationDefOf.Fiance, x => !x.Dead) == null &&
                   pawn.relations.GetFirstDirectRelationPawn(PawnRelationDefOf.Spouse, x => !x.Dead) == null;
        }
    }
}