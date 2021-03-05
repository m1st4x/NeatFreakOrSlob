using Verse;

namespace NeatFreakOrSlob
{
    class NeatFreakOrSlobSettings : ModSettings
    {
        public float globalPickupChance = .1f; // 10%
        public float globalDropChance = .05f;  // 5%
        public float neatPickupChance = .05f;  // 5%
        public float neatDropChance = .01f;    // 1%
        public float slobPickupChance = .4f;   // 40%
        public float slobDropChance = .2f;     // 20%
        public float neatBuffThreshold = 2;    // x > 2 : buff
        public float neatDebuffThreshold = 0;  // x < 0 : debuff
        public float slobBuffThreshold = -2;   // -2 < x < 0 : buff
        public float slobDebuffThreshold = 2;  // x > 2 : debuff
        public int neatVsSlobOffset = -20;     // relation malus

        public override void ExposeData()
        {
            base.ExposeData();
            Scribe_Values.Look(ref this.globalPickupChance, "globalPickupChance", .1f);
            Scribe_Values.Look(ref this.globalDropChance, "globalDropChance", .05f);
            Scribe_Values.Look(ref this.neatPickupChance, "neatPickupChance", .05f);
            Scribe_Values.Look(ref this.neatDropChance, "neatDropChance", .01f);
            Scribe_Values.Look(ref this.slobPickupChance, "slobPickupChance", .4f);
            Scribe_Values.Look(ref this.slobDropChance, "slobDropChance", .2f);
            Scribe_Values.Look(ref this.neatBuffThreshold, "neatBuffThreshold", 2);
            Scribe_Values.Look(ref this.neatDebuffThreshold, "neatDebuffThreshold", 0);
            Scribe_Values.Look(ref this.slobBuffThreshold, "slobBuffThreshold", -2);
            Scribe_Values.Look(ref this.slobDebuffThreshold, "slobDebuffThreshold", 2);
            Scribe_Values.Look(ref this.neatVsSlobOffset, "neatVsSlobOffset", -20);
        }
    }
}