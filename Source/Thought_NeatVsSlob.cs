using RimWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeatFreakOrSlob
{
    class Thought_NeatVsSlob : Thought_SituationalSocial
    {
        public override float OpinionOffset()
        {
            return NeatFreakOrSlobMod.settings.neatVsSlobOffset;
        }
    }
}