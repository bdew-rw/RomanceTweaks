using RimWorld;
using System;
using Verse;

namespace RomanceTweaks
{
    public static class RomanceUtils
    {
        public static bool IsRomanticRelationship(PawnRelationDef def)
        {
            return def == PawnRelationDefOf.Lover || def == PawnRelationDefOf.Fiance || def == PawnRelationDefOf.Spouse;
        }

        public static bool IsRomanticExRelationship(PawnRelationDef def)
        {
            return def == PawnRelationDefOf.ExLover || def == PawnRelationDefOf.ExSpouse;
        }

        public static DirectPawnRelation FindRelation(Pawn pawn, Predicate<DirectPawnRelation> predicate)
        {
            return pawn.relations.DirectRelations.Find(predicate);
        }

        public static Pawn FindLover(Pawn pawn)
        {
            return FindRelation(pawn, x => IsRomanticRelationship(x.def) && !x.otherPawn.Dead)?.otherPawn;
        }

        public static bool IsSingle(Pawn pawn)
        {
            return FindLover(pawn) == null;
        }

        public static bool IsLover(Pawn a, Pawn b)
        {
            return FindLover(a) == b;
        }
    }
}