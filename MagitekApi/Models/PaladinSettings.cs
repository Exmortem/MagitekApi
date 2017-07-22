﻿namespace MagitekApi.Models
{
    public class PaladinSettings : MagitekSettings
    {
        public float RestHealthPercent { get; set; }
        public bool SwordOathInOtMode { get; set; }
        public bool TankMode { get; set; }
        public bool Fracture { get; set; }
        public bool SwordOath { get; set; }
        public bool Stoneskin { get; set; }
        public bool PriorityRa { get; set; }
        public float RiotBladeMinMana { get; set; }
        public bool PriorityMp { get; set; }
        public int RefreshStrenghtDown { get; set; }
        public int RefreshGoringBlade { get; set; }
        public int HealthSetting { get; set; }
        public float HealthSettingPercent { get; set; }
        public bool TotalEclipse { get; set; }
        public float TotalEclipseMinimumTp { get; set; }
        public int TotalEclipseEnemies { get; set; }
        public bool HolySpirit { get; set; }
        public bool AlwaysHolySpiritWithBuff { get; set; }
        public bool HolySpiritWhenOutOfMeleeRange { get; set; }
        public bool Requiescat { get; set; }
        public bool UseFlash { get; set; }
        public int FlashEnemies { get; set; }
        public int FlashOnPull { get; set; }
        public bool UseInterval { get; set; }
        public int FlashAfterSeconds { get; set; }
        public bool UseTotalEclipseOnPullOverFlash { get; set; }
        public bool UseProvoke { get; set; }
        public bool UseShieldLob { get; set; }
        public bool ShieldLobToPull { get; set; }
        public bool ShieldLobLostAggro { get; set; }
        public bool ShieldLobToPullExtraEnemies { get; set; }
        public float ShieldLobMinTpPercent { get; set; }
        public bool Ultimatum { get; set; }
        public int UltimatumWhenEnemiesAreNotTargettingYou { get; set; }
        public int UltimatumOnlySecondsAfterStartingCombat { get; set; }
        public bool UseDefensive { get; set; }
        public bool UseCover { get; set; }
        public bool UseCoverHealer { get; set; }
        public float UseCoverHealerHp { get; set; }
        public bool UseCoverDps { get; set; }
        public float UseCoverDpsHp { get; set; }
        public int MaxDefensiveAtOnce { get; set; }
        public int MaxDefensiveUnderHp { get; set; }
        public float MoreDefensivesHp { get; set; }
        public bool HallowGround { get; set; }
        public float HallowGroundHp { get; set; }
        public bool Bulwark { get; set; }
        public float BulwarkHp { get; set; }
        public bool Convalescence { get; set; }
        public float ConvalescenceHp { get; set; }
        public bool Sentinel { get; set; }
        public float SentinelHp { get; set; }
        public bool Anticipation { get; set; }
        public float AnticipationHp { get; set; }
        public bool Rampart { get; set; }
        public float RampartHp { get; set; }
        public bool UseSpecialDefensive { get; set; }
        public bool BloodBath { get; set; }
        public float BloodbathHp { get; set; }
        public bool DivineVeil { get; set; }
        public float DivineVeilHp { get; set; }
        public bool Awareness { get; set; }
        public float AwarenessHp { get; set; }
        public bool Sheltron { get; set; }
        public float SheltronHp { get; set; }
        public bool TemperedWill { get; set; }
        public bool UseTankBusters { get; set; }
        public bool UseDefensivesOnlyOnTankBusters { get; set; }
        public bool SpiritsWithin { get; set; }
        public float SpiritsWithinOnlyAboveHealth { get; set; }
        public bool InterventionOnNearbyPartyMember { get; set; }
        public float InterventionOnNearbyPartyMemberHealth { get; set; }
        public bool InterventionOnNearbyPartyMemberOnlyRampartOrSentinel { get; set; }
        public bool InterventionOnNearbyPartyMemberAlwaysWithRampartOrSentinel { get; set; }
        public bool Interrupt { get; set; }
        public bool ShieldBash { get; set; }
        public bool UseClemency { get; set; }
        public bool UseClemencyHealer { get; set; }
        public float UseClemencyHealerHp { get; set; }
        public bool UseClemencyDps { get; set; }
        public float UseClemencyDpsHp { get; set; }
        public bool UseClemencySelf { get; set; }
        public float UseClemencySelfHp { get; set; }
        public float MinMpClemency { get; set; }
        public bool Testudo { get; set; }
        public int TestudoAllies { get; set; }
        public float TestudoHealth { get; set; }
        public bool PushBack { get; set; }
        public bool GlorySlash { get; set; }
        public bool FullSwing { get; set; }
    }
}