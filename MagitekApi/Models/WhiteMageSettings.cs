﻿using System.ComponentModel.DataAnnotations.Schema;

namespace MagitekApi.Models
{
    [Table("WhiteMageSettings")]
    public class WhiteMageSettings : MagitekSettings
    {  
        public bool PrioritizeTankBusters { get; set; }
        public bool DoTankBusters { get; set; }
        public bool ClericStance { get; set; }       
        public bool Stone { get; set; }
        public bool InterruptHealing { get; set; }
        public float InterruptHealingHealthPercent { get; set; }
        public bool Raise { get; set; }
        public bool RaiseSwiftcast { get; set; }
        public bool Asylum { get; set; }
        public int AsylumAllies { get; set; }
        public float AsylumHealthPercent { get; set; }
        public bool Assize { get; set; }
        public bool AssizeHealOnly { get; set; }
        public int AssizeAllies { get; set; }
        public float AssizeHealthPercent { get; set; }
        public bool Tetragrammaton { get; set; }
        public bool TetragrammatonTankOnly { get; set; }
        public float TetragrammatonHealthPercent { get; set; }
        public bool Cure3 { get; set; }
        public float Cure3HealthPercent { get; set; }
        public int Cure3Allies { get; set; }
        public bool Benediction { get; set; }
        public bool BenedictionTankOnly { get; set; }
        public float BenedictionHealthPercent { get; set; }
        public bool Medica { get; set; }
        public int MedicaAllies { get; set; }
        public float MedicaHealthPercent { get; set; }
        public bool Medica2 { get; set; }
        public int Medica2Allies { get; set; }
        public float Medica2HealthPercent { get; set; }
        public bool Regen { get; set; }
        public bool RegenOnTanks { get; set; }
        public bool RegenOnHealers { get; set; }
        public bool RegenOnDps { get; set; }
        public bool RegenKeepUpOnTanks { get; set; }
        public bool RegenKeepUpOnHealers { get; set; }
        public bool RegenKeepUpOnDps { get; set; }
        public float RegenHealthPercent { get; set; }
        public bool RegenDontCureUnlessUnderTank { get; set; }
        public bool RegenDontCureUnlessUnderHealer { get; set; }
        public bool RegenDontCureUnlessUnderDps { get; set; }
        public float RegenDontCureUnlessUnderHealth { get; set; }
        public bool Cure { get; set; }
        public float CureHealthPercent { get; set; }
        public bool Cure2 { get; set; }
        public float Cure2HealthPercent { get; set; }
        public bool AssizeForMana { get; set; }
        public float AssizeManaPercent { get; set; }
        public bool DontBuffIfYouHaveOneAlready { get; set; }
        public bool PresenceOfMind { get; set; }
        public float PresenceOfMindHealthPercent { get; set; }
        public bool PresenceOfMindTankOnly { get; set; }
        public int PresenceOfMindNeedHealing { get; set; }
        public bool Largesse { get; set; }
        public float LargesseHealthPercent { get; set; }
        public bool LargesseTankOnly { get; set; }
        public int LargesseNeedHealing { get; set; }
        public bool Dispel { get; set; }
        public bool DispelOnlyAbove { get; set; }
        public float DispelOnlyAboveHealth { get; set; }
        public bool LucidDreaming { get; set; }
        public float LucidDreamingManaPercent { get; set; }
        public bool Protect { get; set; }
        public bool ProtectInCombat { get; set; }
        public bool EyeForAnEye { get; set; }
        public float EyeForAnEyeHpPercent { get; set; }
        public float MinimumManaPercentToDoDamage { get; set; }
        public bool DoDamage { get; set; }
        public bool AssizeDamage { get; set; }
        public bool AssizeOnlyBelow90Mana { get; set; }
        public int AssizeEnemies { get; set; }
        public int DotHealthMinimum { get; set; }
        public float DotHealthMinimumPercent { get; set; }
        public int DotRefreshSeconds { get; set; }
        public bool Aero { get; set; }
        public bool Aero3 { get; set; }
        public int Aero3Enemies { get; set; }
        public bool Holy { get; set; }
        public int HolyEnemies { get; set; }
        public bool FluidAura { get; set; }
        public bool UseTimeTillDeathForDots { get; set; }
        public int DontDotIfEnemyDyingWithin { get; set; }
        public bool IgnoreAlliance { get; set; }
        public bool HealAllianceHealers { get; set; }
        public bool HealAllianceTanks { get; set; }
        public bool HealAllianceDps { get; set; }
        public bool ResAllianceHealers { get; set; }
        public bool ResAllianceTanks { get; set; }
        public bool ResAllianceDps { get; set; }
        public bool HealAllianceOnlyCure { get; set; }
        public bool HealPartyMembersPets { get; set; }
        public bool HealPartyMembersPetsTitanOnly { get; set; }
        public bool ThinAir { get; set; }
        public bool ThinAirBeforeSwiftcastRaise { get; set; }
        public bool ThinAirBeforeHoly { get; set; }
        public bool ThinAirBeforeCure3 { get; set; }
        public bool AutomaticallyDispelAnythingThatsDispellable { get; set; }
        public bool DivineBenison { get; set; }
        public bool PlenaryIndulgence { get; set; }
        public int PlenaryIndulgenceConfessions { get; set; }
        public int PlenaryIndulgenceAllysWithConfessions { get; set; }
        public float PlenaryIndulgenceHealthPercent { get; set; }
        public bool StopDpsIfPartyMemberBelow { get; set; }
        public float StopDpsIfPartyMemberBelowHealthPercent { get; set; }
    }
}
