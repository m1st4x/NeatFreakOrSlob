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

            Harmony.DEBUG = true;
            new Harmony("m1st4x.NeatFreakOrSlob").PatchAll();
        }

        public override string SettingsCategory() => "NeatFreakOrSlob";

        public override void DoSettingsWindowContents(Rect inRect)
        {
            Listing_Standard listing_Standard = new Listing_Standard();
            listing_Standard.Begin(inRect);
            listing_Standard.Label("vanilla filth pickup chance is 5% (0.05), filth drop chance is 10% (0.1)");
            listing_Standard.TextFieldNumericLabeled("filth pickup chance ", ref settings.globalPickupChance, ref buf1);
            listing_Standard.TextFieldNumericLabeled("filth drop chance ", ref settings.globalDropChance, ref buf2);
            listing_Standard.Gap();
            listing_Standard.TextFieldNumericLabeled("neat freak filth pickup chance ", ref settings.neatPickupChance, ref buf3);
            listing_Standard.TextFieldNumericLabeled("neat freak filth drop chance ", ref settings.neatDropChance, ref buf4);
            listing_Standard.Gap();
            listing_Standard.TextFieldNumericLabeled("slob filth pickup chance ", ref settings.slobPickupChance, ref buf5);
            listing_Standard.TextFieldNumericLabeled("slob filth drop chance ", ref settings.slobDropChance, ref buf6);
            listing_Standard.Gap();
            listing_Standard.TextFieldNumericLabeled("neat freak vs slob relation offset ", ref settings.neatVsSlobOffset, ref buf7);
            listing_Standard.GapLine();
            listing_Standard.Label("mood (de)buffs based on room cleanliness:");
            listing_Standard.TextFieldNumericLabeled("neat freak buff threshold ", ref settings.neatBuffThreshold, ref buf8);
            listing_Standard.TextFieldNumericLabeled("neat freak debuff threshold ", ref settings.neatBuffThreshold, ref buf9);
            listing_Standard.Gap();
            listing_Standard.TextFieldNumericLabeled("slob buff threshold ", ref settings.slobBuffThreshold, ref buf10);
            listing_Standard.TextFieldNumericLabeled("slob debuff threshold ", ref settings.slobDebuffThreshold, ref buf11);
            listing_Standard.End();

            settings.Write();
        }
    }
}