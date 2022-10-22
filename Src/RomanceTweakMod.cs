using HarmonyLib;
using RimWorld;
using System;
using System.Reflection.Emit;
using UnityEngine;
using Verse;
using Verse.Sound;

namespace RomanceTweaks
{
    public class RomanceTweaksSettings : ModSettings
    {
        public static bool DebugMode = false;
        public static float RomanceChanceModifier = 1;
        public static float RomanceChanceModifierSingle = 1;
        public static float RomanceChanceModifierCheating = 1;
        public static float RomanceChanceModifierFaction = 1;
        public static float RomanceSuccessModifier = 1;
        public static float BreakupChanceModifier = 1;

        public override void ExposeData()
        {
            Scribe_Values.Look(ref DebugMode, "DebugMode", false);
            Scribe_Values.Look(ref RomanceChanceModifier, "RomanceChanceModifier", 1f);
            Scribe_Values.Look(ref RomanceChanceModifierSingle, "RomanceChanceModifierSingle", 1f);
            Scribe_Values.Look(ref RomanceChanceModifierCheating, "RomanceChanceModifierCheating", 1f);
            Scribe_Values.Look(ref RomanceChanceModifierFaction, "RomanceChanceModifierFaction", 1f);
            Scribe_Values.Look(ref RomanceSuccessModifier, "RomanceSuccessModifier", 1f);
            Scribe_Values.Look(ref BreakupChanceModifier, "BreakupChanceModifier", 1f);
            base.ExposeData();
        }
    }

    public class RomanceTweakMod : Mod
    {
        public readonly RomanceTweaksSettings settings;

        public RomanceTweakMod(ModContentPack content) : base(content)
        {
            this.settings = GetSettings<RomanceTweaksSettings>();
            var harmony = new Harmony("BDew.RomanceTweaks");
            harmony.PatchAll();
            Log.Message("Romance Tweaks loaded");
        }

        private static void AddSettingsNumberLine(Listing_Standard listing, string name, ref float val, float min, float max)
        {
            var rect = listing.GetRect(30f);
            
            var rectLabel = rect.LeftPart(0.5f).Rounded();
            var rectRight = rect.RightPart(0.5f).Rounded();
            var rectField = rectRight.LeftPart(0.25f).Rounded();
            var rectSlider = rectRight.RightPart(0.7f).Rounded();

            Text.Anchor = TextAnchor.MiddleLeft;

            TooltipHandler.TipRegion(rect, $"RomanceTweaks.{name}.Desc".Translate());

            Widgets.Label(rectLabel, $"RomanceTweaks.{name}".Translate());
            
            string buffer = $"{val:F2}";
            Widgets.TextFieldNumeric<float>(rectField, ref val, ref buffer, min, max);

            Text.Anchor = TextAnchor.UpperLeft;

            float num = Widgets.HorizontalSlider(rectSlider, val, min, max, middleAlignment: true);
            
            if (num != val)
            {
                SoundDefOf.DragSlider.PlayOneShotOnCamera();
                val = num;
            }

            listing.Gap(2f);
        }

        public override void DoSettingsWindowContents(Rect inRect)
        {
            Listing_Standard listing = new Listing_Standard();
            listing.Begin(inRect);

            listing.CheckboxLabeled("RomanceTweaks.DebugMode".Translate(), ref RomanceTweaksSettings.DebugMode);

            AddSettingsNumberLine(listing, "RomanceChanceModifier", ref RomanceTweaksSettings.RomanceChanceModifier, 0, 10);
            AddSettingsNumberLine(listing, "RomanceChanceModifierSingle", ref RomanceTweaksSettings.RomanceChanceModifierSingle, 0, 10);
            AddSettingsNumberLine(listing, "RomanceChanceModifierCheating", ref RomanceTweaksSettings.RomanceChanceModifierCheating, 0, 10);
            AddSettingsNumberLine(listing, "RomanceChanceModifierFaction", ref RomanceTweaksSettings.RomanceChanceModifierFaction, 0, 10);
            AddSettingsNumberLine(listing, "RomanceSuccessModifier", ref RomanceTweaksSettings.RomanceSuccessModifier, 0, 10);
            AddSettingsNumberLine(listing, "BreakupChanceModifier", ref RomanceTweaksSettings.BreakupChanceModifier, 0, 10);

            listing.End();

            base.DoSettingsWindowContents(inRect);
        }

        public override string SettingsCategory()
        {
            return "RomanceTweaks.Name".Translate();
        }
    }
}