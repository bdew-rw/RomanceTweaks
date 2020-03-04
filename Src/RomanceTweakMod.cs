using HugsLib;
using HugsLib.Settings;
using Verse;

namespace RomanceTweaks
{
    public class RomanceTweakMod : ModBase
    {
        // Having this in throws an exception at game start for me. // nugerumon
        /*public RomanceTweakMod() : base()
        {
            // This should be set automatically but for some reason isn't...
            Settings.EntryName = ModContentPack.Name;
        }//*/

        public override string ModIdentifier => "RomanceTweaks";

        internal static SettingHandle<bool> DebugMode;
        internal static SettingHandle<float> RomanceChanceModifier, RomanceChanceModifierSingle, RomanceSuccessModifier, BreakupChanceModifier;
        internal static SettingHandle<float> RomanceChanceModifierDifferentFaction;

        internal static SettingHandle<float> IncestModifier_Close;
        internal static SettingHandle<float> IncestModifier_Medium;
        internal static SettingHandle<float> IncestModifier_Far;

        public override void DefsLoaded()
        {
            DebugMode = Settings.GetHandle<bool>("DebugMode", Translator.Translate("RomanceTweaks.DebugMode"), null, false);

            RomanceChanceModifier = Settings.GetHandle<float>("romanceChanceModifier", Translator.Translate("RomanceTweaks.RomanceChanceModifier"), Translator.Translate("RomanceTweaks.RomanceChanceModifierDesc"), 1f);
            RomanceChanceModifierSingle = Settings.GetHandle<float>("romanceChanceModifierSingle", Translator.Translate("RomanceTweaks.RomanceChanceModifierSingle"), Translator.Translate("RomanceTweaks.RomanceChanceModifierSingleDesc"), 1f);
            RomanceChanceModifierDifferentFaction = Settings.GetHandle<float>("romanceChanceModifierDifferentFaction", Translator.Translate("RomanceTweaks.RomanceChanceModifierDifferentFaction"), Translator.Translate("RomanceTweaks.RomanceChanceModifierDifferentFactionDesc"), 1f);

            IncestModifier_Close = Settings.GetHandle<float>("IncestModifier_Close", Translator.Translate("RomanceTweaks.IncestModifier_Close"), Translator.Translate("RomanceTweaks.IncestModifier_Close_Desc"), 1f);
            IncestModifier_Medium = Settings.GetHandle<float>("IncestModifier_Medium", Translator.Translate("RomanceTweaks.IncestModifier_Medium"), Translator.Translate("RomanceTweaks.IncestModifier_Medium_Desc"), 1f);
            IncestModifier_Far = Settings.GetHandle<float>("IncestModifier_Far", Translator.Translate("RomanceTweaks.IncestModifier_Far"), Translator.Translate("RomanceTweaks.IncestModifier_Far_Desc"), 1f);

            RomanceSuccessModifier = Settings.GetHandle<float>("RomanceSuccessModifier", Translator.Translate("RomanceTweaks.RomanceSuccessModifier"), Translator.Translate("RomanceTweaks.RomanceSuccessModifier_Desc"), 1f);
            BreakupChanceModifier = Settings.GetHandle<float>("BreakupChanceModifier", Translator.Translate("RomanceTweaks.BreakupChanceModifier"), Translator.Translate("RomanceTweaks.BreakupChanceModifier_Desc"), 1f);
        }
    }
}