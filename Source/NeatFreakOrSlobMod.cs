using HarmonyLib;
using UnityEngine;
using Verse;

namespace NeatFreakOrSlob
{
    class NeatFreakOrSlobMod : Mod
    {
        public static NeatFreakOrSlobSettings settings;

        private string buf1, buf2, buf3, buf4, buf5, buf6, buf7, buf8, buf9, buf10, buf11;

        public NeatFreakOrSlobMod(ModContentPack content) : base(content)
        {
            settings = GetSettings<NeatFreakOrSlobSettings>();

            //Harmony.DEBUG = true;
            new Harmony("m1st4x.NeatFreakOrSlob").PatchAll();
        }

        public override string SettingsCategory() => "NeatFreakOrSlob";

        public override void DoSettingsWindowContents(Rect inRect)
        {
            Listing_Standard listing_Standard = new Listing_Standard();
            listing_Standard.Begin(inRect);
            listing_Standard.Label("vanilla filth pickup chance is 10% (0.1), filth drop chance is 5% (0.05), changes apply to all pawns on the map!");
            listing_Standard.TextFieldNumericLabeled("filth pickup chance ", ref settings.globalPickupChance, ref buf1, 0, 1);
            listing_Standard.TextFieldNumericLabeled("filth drop chance ", ref settings.globalDropChance, ref buf2, 0, 1);
            listing_Standard.GapLine();
            listing_Standard.Label("neat freak and slob chances:");
            listing_Standard.TextFieldNumericLabeled("neat freak filth pickup chance ", ref settings.neatPickupChance, ref buf3, 0, 1);
            listing_Standard.TextFieldNumericLabeled("neat freak filth drop chance ", ref settings.neatDropChance, ref buf4, 0, 1);
            listing_Standard.Gap();
            listing_Standard.TextFieldNumericLabeled("slob filth pickup chance ", ref settings.slobPickupChance, ref buf5, 0, 1);
            listing_Standard.TextFieldNumericLabeled("slob filth drop chance ", ref settings.slobDropChance, ref buf6, 0, 1);
            listing_Standard.Gap();
            listing_Standard.TextFieldNumericLabeled("neat freak vs. slob relation offset ", ref settings.neatVsSlobOffset, ref buf7, -100, 100);
            listing_Standard.GapLine();
            listing_Standard.Label("neat freak and slob mood (de)buffs based on room cleanliness:");
            listing_Standard.TextFieldNumericLabeled("neat freak buff threshold ", ref settings.neatBuffThreshold, ref buf8, -10, 10);
            listing_Standard.TextFieldNumericLabeled("neat freak debuff threshold ", ref settings.neatDebuffThreshold, ref buf9, -10, 10);
            listing_Standard.Gap();
            listing_Standard.TextFieldNumericLabeled("slob buff threshold ", ref settings.slobBuffThreshold, ref buf10, -10, 10);
            listing_Standard.TextFieldNumericLabeled("slob debuff threshold ", ref settings.slobDebuffThreshold, ref buf11, -10, 10);
            listing_Standard.End();

            settings.Write();
        }
    }
}