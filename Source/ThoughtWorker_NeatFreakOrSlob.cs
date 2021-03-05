using RimWorld;
using Verse;

namespace NeatFreakOrSlob
{
    public class ThoughtWorker_NeatFreakOrSlob : ThoughtWorker
    {
        protected override ThoughtState CurrentStateInternal(Pawn p)
        {
            if (p.story.traits.HasTrait(TraitDef.Named("NeatFreak")))
            {
                if (p.CurJobDef == JobDefOf.Clean)
                    return ThoughtState.ActiveAtStage(0); // while cleaning: +6 mood buff

                float cleanliness = p.GetRoom().GetStat(RoomStatDefOf.Cleanliness);
                if (cleanliness < NeatFreakOrSlobMod.settings.neatDebuffThreshold)
                    return ThoughtState.ActiveAtStage(1); // room too dirty: -6 mood debuff

                else if (cleanliness > NeatFreakOrSlobMod.settings.neatBuffThreshold)
                    return ThoughtState.ActiveAtStage(2); // room very clean: +3 mood buff
            }
            if (p.story.traits.HasTrait(TraitDef.Named("Slob")))
            {
                if (p.CurJobDef == JobDefOf.Clean)
                    return ThoughtState.ActiveAtStage(0); // while cleaning: -12 mood debuff

                float cleanliness = p.GetRoom().GetStat(RoomStatDefOf.Cleanliness);
                if (cleanliness < 0 && cleanliness > NeatFreakOrSlobMod.settings.slobBuffThreshold)
                    return ThoughtState.ActiveAtStage(1); // room slightly dirty: +3 mood buff

                else if (cleanliness > NeatFreakOrSlobMod.settings.slobDebuffThreshold)
                    return ThoughtState.ActiveAtStage(2); // room too sterile: -3 mood debuff
            }
            return ThoughtState.Inactive;
        }

        protected override ThoughtState CurrentSocialStateInternal(Pawn p, Pawn other)
        {
            if (!p.RaceProps.Humanlike)
                return false;

            if (!RelationsUtility.PawnsKnowEachOther(p, other))
                return false;

            if (p.story.traits.HasTrait(TraitDef.Named("NeatFreak")) && other.story.traits.HasTrait(TraitDef.Named("Slob")))
                return true;

            if (p.story.traits.HasTrait(TraitDef.Named("Slob")) && other.story.traits.HasTrait(TraitDef.Named("NeatFreak")))
                return true;

            return false;
        }
    }
}
