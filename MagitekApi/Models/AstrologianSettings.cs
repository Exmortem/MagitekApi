﻿using MagitekApi.Enumerations;

namespace MagitekApi.Models
{
    public class AstrologianSettings : MagitekSettings
    {
        public bool PrioritizeTankBusters { get; set; }
        public bool DoTankBusters { get; set; }
        public bool Malefic { get; set; }
        public bool InterruptHealing { get; set; }
        public float InterruptHealingHealthPercent { get; set; }
        public bool DoDamage { get; set; }
        public int DotHealthMinimum { get; set; }
        public float DotHealthMinimumPercent { get; set; }
        public int DotRefreshSeconds { get; set; }
        public bool UseTimeTillDeathForDots { get; set; }
        public int DontDotIfEnemyDyingWithin { get; set; }
        public bool Combust { get; set; }
        public bool Gravity { get; set; }
        public int GravityEnemies { get; set; }
        public bool Break { get; set; }
        public bool BreakSoloOnly { get; set; }
        public float BreakHealthPercent { get; set; }
        public float MinimumManaPercentToDoDamage { get; set; }
        public bool ClericStance { get; set; }
        public bool Lightspeed { get; set; }
        public float LightspeedHealthPercent { get; set; }
        public bool LightspeedTankOnly { get; set; }
        public AstrologianSect SectWithNoPairing { get; set; }
        public AstrologianSect SectWhenPairedWithWhm { get; set; }
        public AstrologianSect SectWhenPairedWithSch { get; set; }
        public AstrologianSectWithOpposite SectWhenPairedWithAst { get; set; }
        public bool DontBuffIfYouHaveOneAlready { get; set; }
        public bool PresenceOfMind { get; set; }
        public float PresenceOfMindHealthPercent { get; set; }
        public bool PresenceOfMindTankOnly { get; set; }
        public int PresenceOfMindNeedHealing { get; set; }
        public bool Largesse { get; set; }
        public float LargesseHealthPercent { get; set; }
        public bool LargesseTankOnly { get; set; }
        public int LargesseNeedHealing { get; set; }
        public bool LucidDreaming { get; set; }
        public float LucidDreamingManaPercent { get; set; }
        public bool Protect { get; set; }
        public bool ProtectInCombat { get; set; }
        public bool EyeForAnEye { get; set; }
        public float EyeForAnEyeHpPercent { get; set; }
        public bool Synastry { get; set; }
        public float SynastryHealthPercent { get; set; }
        public bool SynastryTankOnly { get; set; }
        public bool Ascend { get; set; }
        public bool AscendSwiftcast { get; set; }
        public bool EssentialDignity { get; set; }
        public bool EssentialDignityTankOnly { get; set; }
        public float EssentialDignityHealthPercent { get; set; }
        public bool Helios { get; set; }
        public int HeliosAllies { get; set; }
        public float HeliosHealthPercent { get; set; }
        public bool DiurnalHelios { get; set; }
        public int DiurnalHeliosAllies { get; set; }
        public float DiurnalHeliosHealthPercent { get; set; }
        public bool NocturnalHelios { get; set; }
        public int NocturnalHeliosAllies { get; set; }
        public float NocturnalHeliosHealthPercent { get; set; }
        public bool DiurnalBenefic { get; set; }
        public bool DiurnalBeneficOnTanks { get; set; }
        public bool DiurnalBeneficOnHealers { get; set; }
        public bool DiurnalBeneficOnDps { get; set; }
        public bool DiurnalBeneficKeepUpOnTanks { get; set; }
        public bool DiurnalBeneficKeepUpOnHealers { get; set; }
        public bool DiurnalBeneficKeepUpOnDps { get; set; }
        public float DiurnalBeneficHealthPercent { get; set; }
        public bool DiurnalBeneficWhileMoving { get; set; }
        public float DiurnalBeneficWhileMovingMinMana { get; set; }
        public bool DiurnalBeneficDontBeneficUnlessUnderTank { get; set; }
        public bool DiurnalBeneficDontBeneficUnlessUnderHealer { get; set; }
        public bool DiurnalBeneficDontBeneficUnlessUnderDps { get; set; }
        public float DiurnalBeneficDontBeneficUnlessUnderHealth { get; set; }
        public bool NocturnalBenefic { get; set; }
        public bool NocturnalBeneficOnTanks { get; set; }
        public bool NocturnalBeneficOnHealers { get; set; }
        public bool NocturnalBeneficOnDps { get; set; }
        public bool NocturnalBeneficKeepUpOnTanks { get; set; }
        public bool NocturnalBeneficKeepUpOnHealers { get; set; }
        public bool NocturnalBeneficKeepUpOnDps { get; set; }
        public float NocturnalBeneficHealthPercent { get; set; }
        public bool NocturnalBeneficWhileMoving { get; set; }
        public float NocturnalBeneficWhileMovingMinMana { get; set; }
        public bool Benefic { get; set; }
        public float BeneficHealthPercent { get; set; }
        public bool Benefic2 { get; set; }
        public float Benefic2HealthPercent { get; set; }
        public bool Benefic2AlwaysWithEnhancedBenefic2 { get; set; }
        public bool CollectiveUnconscious { get; set; }
        public int CollectiveUnconsciousAllies { get; set; }
        public float CollectiveUnconsciousHealth { get; set; }
        public bool Dispel { get; set; }
        public bool DispelOnlyAbove { get; set; }
        public float DispelOnlyAboveHealth { get; set; }
        public bool AutomaticallyDispelAnythingThatsDispellable { get; set; }
        public bool IgnoreAlliance { get; set; }
        public bool HealAllianceHealers { get; set; }
        public bool HealAllianceTanks { get; set; }
        public bool HealAllianceDps { get; set; }
        public bool ResAllianceHealers { get; set; }
        public bool ResAllianceTanks { get; set; }
        public bool ResAllianceDps { get; set; }
        public bool HealAllianceOnlyBenefic { get; set; }
        public bool HealPartyMembersPets { get; set; }
        public bool HealPartyMembersPetsTitanOnly { get; set; }
        public bool DrawCards { get; set; }
        public bool Disable { get; set; }
        public bool Malefic3 { get; set; }
        public bool PvpEssentialDignity { get; set; }
        public bool PvpEssentialDignityTankOnly { get; set; }
        public float PvpEssentialDignityHealthPercent { get; set; }
        public bool Purify { get; set; }
        public bool AutomaticallyPurifyAnythingThatsDispellable { get; set; }
        public bool PurifyOnlyAbove { get; set; }
        public float PurifyOnlyAboveHealth { get; set; }
        public bool Muse { get; set; }
        public float MuseManaPercent { get; set; }
        public bool PvpLightspeed { get; set; }
        public bool PvpLightspeedTankOnly { get; set; }
        public float PvpLightspeedHealthPercent { get; set; }
        public bool PvpSynastry { get; set; }
        public bool PvpSynastryTankOnly { get; set; }
        public float PvpSynastryHealthPercent { get; set; }
        public bool Deorbit { get; set; }
        public float DeorbitHealthPercent { get; set; }
        public bool DeborbitOnlyIfTargetedByHostile { get; set; }
        public bool EmpyreanRain { get; set; }
        public float EmpyreanRainHealthPercent { get; set; }
        public int EmpyreanRainAllies { get; set; }
        public bool Recuperate { get; set; }
        public float RecuperateHealthPercent { get; set; }
        public bool PvpBenefic { get; set; }
        public float PvpBeneficHealthPercent { get; set; }
        public bool PvpBenefic2 { get; set; }
        public float PvpBenefic2HealthPercent { get; set; }
        public bool Benefic2AlwaysWithAbridged { get; set; }
        public bool Concentrate { get; set; }
        public int ConcentrateEnemiesTargeting { get; set; }
        public float ConcentrateHealthPercent { get; set; }
        public bool Safeguard { get; set; }
        public int SafeguardEnemiesTargeting { get; set; }
        public float SafeguardHealthPercent { get; set; }
    }
}