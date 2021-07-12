using HugsLib;
using HugsLib.Settings;
using Verse;

namespace RomanceTweaks
{
    public class RomanceTweakMod : ModBase
    {
        public RomanceTweakMod() : base()
        {
            // This should be set automatically but for some reason isn't...
            Settings.EntryName = ModContentPack.Name;
        }

        public override string ModIdentifier => "RomanceTweaks";

        internal static SettingHandle<bool> DebugMode;
        internal static SettingHandle<float> RomanceChanceModifier, RomanceChanceModifierSingle, RomanceChanceModifierCheating, RomanceChanceModifierFaction, 
            RomanceSuccessModifier, BreakupChanceModifier;

        public override void DefsLoaded()
        {
            DebugMode = Settings.GetHandle("DebugMode", "RomanceTweaks.DebugMode".Translate(), null, false);
            RomanceChanceModifier = Settings.GetHandle("RomanceChanceModifier", "RomanceTweaks.RomanceChanceModifier".Translate(), "RomanceTweaks.RomanceChanceModifier.Desc".Translate(), 1f);
            RomanceChanceModifierSingle = Settings.GetHandle("RomanceChanceModifierSingle", "RomanceTweaks.RomanceChanceModifierSingle".Translate(), "RomanceTweaks.RomanceChanceModifierSingle.Desc".Translate(), 1f);
            RomanceChanceModifierCheating = Settings.GetHandle("RomanceChanceModifierCheating", "RomanceTweaks.RomanceChanceModifierCheating".Translate(), "RomanceTweaks.RomanceChanceModifierCheating.Desc".Translate(), 1f);
            RomanceChanceModifierFaction = Settings.GetHandle("RomanceChanceModifierFaction", "RomanceTweaks.RomanceChanceModifierFaction".Translate(), "RomanceTweaks.RomanceChanceModifierFaction.Desc".Translate(), 1f);
            RomanceSuccessModifier = Settings.GetHandle("RomanceSuccessModifier", "RomanceTweaks.RomanceSuccessModifier".Translate(), "RomanceTweaks.RomanceSuccessModifier.Desc".Translate(), 1f);
            BreakupChanceModifier = Settings.GetHandle("BreakupChanceModifier", "RomanceTweaks.BreakupChanceModifier".Translate(), "RomanceTweaks.BreakupChanceModifier.Desc".Translate(), 1f);
        }
    }
}