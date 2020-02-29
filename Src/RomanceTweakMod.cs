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
        internal static SettingHandle<float> RomanceChanceModifier, RomanceChanceModifierSingle, RomanceSuccessModifier, BreakupChanceModifier;

        public override void DefsLoaded()
        {
            DebugMode = Settings.GetHandle("DebugMode", "RomanceTweaks.DebugMode".Translate(), null, false);
            RomanceChanceModifier = Settings.GetHandle("romanceChanceModifier", "RomanceTweaks.RomanceChanceModifier".Translate(), null, 1f);
            RomanceChanceModifierSingle = Settings.GetHandle("romanceChanceModifierSingle", "RomanceTweaks.RomanceChanceModifierSingle".Translate(), null, 1f);
            RomanceSuccessModifier = Settings.GetHandle("RomanceSuccessModifier", "RomanceTweaks.RomanceSuccessModifier".Translate(), null, 1f);
            BreakupChanceModifier = Settings.GetHandle("BreakupChanceModifier", "RomanceTweaks.BreakupChanceModifier".Translate(), null, 1f);
        }
    }
}