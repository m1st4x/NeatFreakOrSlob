using Verse;

namespace NeatFreakOrSlob
{
    class NeatFreakOrSlobSettings : ModSettings
    {
        public float globalPickupChance = 0.1f; // 10%
        public float globalDropChance = 0.05f;  // 5%
        public float neatPickupChance = 0.05f;  // 5%
        public float neatDropChance = 0.01f;    // 1%
        public float slobPickupChance = 0.2f;   // 20%
        public float slobDropChance = 0.1f;     // 10%
        public float neatBuffThreshold = 2f;    // x > 2 : buff        
        public float neatDebuffThreshold = 0f;  // x < 0 : debuff
        public float slobBuffThreshold = -2f;   // -2 < x < 0 : buff        
        public float slobDebuffThreshold = 2f;  // x > 2 : debuff
        public int neatVsSlobOffset = -20;      // relation malus

        public override void ExposeData()
        {
            base.ExposeData();
            Scribe_Values.Look(ref this.globalPickupChance, "globalPickupChance", 0.1f);
            Scribe_Values.Look(ref this.globalDropChance, "globalDropChance", 0.05f);
            Scribe_Values.Look(ref this.neatPickupChance, "neatPickupChance", 0.05f);
            Scribe_Values.Look(ref this.neatDropChance, "neatDropChance", 0.01f);
            Scribe_Values.Look(ref this.slobPickupChance, "slobPickupChance", 0.2f);
            Scribe_Values.Look(ref this.slobDropChance, "slobDropChance", 0.1f);
            Scribe_Values.Look(ref this.neatBuffThreshold, "neatBuffThreshold", 2f);
            Scribe_Values.Look(ref this.neatDebuffThreshold, "neatDebuffThreshold", 0f);
            Scribe_Values.Look(ref this.slobBuffThreshold, "slobBuffThreshold", -2f);
            Scribe_Values.Look(ref this.slobDebuffThreshold, "slobDebuffThreshold", 2f);
            Scribe_Values.Look(ref this.neatVsSlobOffset, "neatVsSlobOffset");
        }
    }
}