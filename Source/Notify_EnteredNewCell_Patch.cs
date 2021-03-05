using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;
using HarmonyLib;
using RimWorld;
using Verse;

namespace NeatFreakOrSlob
{
	[HarmonyPatch(typeof(Pawn_FilthTracker))]
	[HarmonyPatch("Notify_EnteredNewCell")]
	public static class Notify_EnteredNewCell_Patch
	{
		static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
		{
			MethodInfo getFilthPickupChance = AccessTools.Method(
				typeof(Notify_EnteredNewCell_Patch), 
				nameof(Notify_EnteredNewCell_Patch.GetFilthPickupChance));

			MethodInfo getFilthDropChance = AccessTools.Method(
				typeof(Notify_EnteredNewCell_Patch), 
				nameof(Notify_EnteredNewCell_Patch.GetFilthDropChance));

			bool first = true;

			var codes = new List<CodeInstruction>(instructions);
			for (var i = 0; i < codes.Count; i++)
			{
				if (codes[i].opcode == OpCodes.Ldc_R4 && codes[i + 1].opcode == OpCodes.Bge_Un_S)
				{
					yield return new CodeInstruction(OpCodes.Ldarg_0);
					yield return new CodeInstruction(OpCodes.Ldfld, AccessTools.Field(typeof(Pawn_FilthTracker), name: "pawn"));						
					yield return new CodeInstruction(OpCodes.Call, first ? getFilthPickupChance : getFilthDropChance);
					first = false;
				}
				else
					yield return codes[i];
			}
		}

		private static float GetFilthPickupChance(Pawn pawn)
		{
			float chance = NeatFreakOrSlobMod.settings.globalPickupChance;

			if (pawn.story == null) return chance;

			if (pawn.story.traits.HasTrait(TraitDef.Named("Slob")))
				chance = NeatFreakOrSlobMod.settings.slobPickupChance;

			if (pawn.story.traits.HasTrait(TraitDef.Named("NeatFreak")))
				chance = NeatFreakOrSlobMod.settings.neatPickupChance;

			return chance;
		}

		private static float GetFilthDropChance(Pawn pawn)
		{
			float chance = NeatFreakOrSlobMod.settings.globalDropChance;

			if (pawn.story == null) return chance;

			if (pawn.story.traits.HasTrait(TraitDef.Named("Slob")))
				chance = NeatFreakOrSlobMod.settings.slobDropChance;

			if (pawn.story.traits.HasTrait(TraitDef.Named("NeatFreak")))
				chance = NeatFreakOrSlobMod.settings.neatDropChance;

			return chance;
		}
	}
}