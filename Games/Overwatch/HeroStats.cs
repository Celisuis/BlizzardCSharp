using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlizzardCSharp.Games.Overwatch
{
    public class HeroStats
    {
        #region Classes
        public class HeroAssists
        {
            public int DefensiveAssists { get; internal set; }

            public int AverageDefensiveAssists { get; internal set; }

            public int MostDefensiveAssistsInGame { get; internal set; }

            public int HealingDone { get; internal set; }

            public int AverageHealingDone { get; internal set; }

            public int MostHealingDoneInGame { get; internal set; }

            public int OffensiveAssists { get; internal set; }

            public int AverageOffensiveAssists { get; internal set; }

            public int MostOffensiveAssistsInGame { get; internal set; }

            public int TurretsDestroyed { get; internal set; }

            public int ReconAssists { get; internal set; }

            public int AverageReconAssists { get; internal set; }

            public int MostReconAssistsInGame { get; internal set; }

            public int TeleporterPadsDestroyed { get; internal set; }
            public HeroAssists(JObject rawData)
            {
                if (rawData["defensiveAssists"] != null)
                    DefensiveAssists = int.Parse(rawData["defensiveAssists"].ToString());
                if (rawData["defensiveAssistsAvgPer10Min"] != null)
                    AverageDefensiveAssists = int.Parse(rawData["defensiveAssistsAvgPer10Min"].ToString());
                if (rawData["defensiveAssistsMostInGame"] != null)
                    MostDefensiveAssistsInGame = int.Parse(rawData["defensiveAssistsMostInGame"].ToString());
                if (rawData["healingDone"] != null)
                    HealingDone = int.Parse(rawData["healingDone"].ToString());
                if (rawData["healingDoneAvgPer10Min"] != null)
                    AverageHealingDone = int.Parse(rawData["healingDoneAvgPer10Min"].ToString());
                if (rawData["healingDoneMostInGame"] != null)
                    MostHealingDoneInGame = int.Parse(rawData["healingDoneMostInGame"].ToString());
                if (rawData["offensiveAssists"] != null)
                    OffensiveAssists = int.Parse(rawData["offensiveAssists"].ToString());
                if (rawData["offensiveAssistsAvgPer10Min"] != null)
                    AverageOffensiveAssists = int.Parse(rawData["offensiveAssistsAvgPer10Min"].ToString());
                if (rawData["offensiveAssistsMostInGame"] != null)
                    MostOffensiveAssistsInGame = int.Parse(rawData["offensiveAssistsMostInGame"].ToString());
                if (rawData["turretsDestroyed"] != null)
                    TurretsDestroyed = int.Parse(rawData["turretsDestroyed"].ToString());
                if (rawData["reconAssists"] != null)
                    ReconAssists = int.Parse(rawData["reconAssists"].ToString());
                if (rawData["reconAssistsAvgPer10Min"] != null)
                    AverageReconAssists = int.Parse(rawData["reconAssistsAvgPer10Min"].ToString());
                if (rawData["reconAssistsMostInGame"] != null)
                    MostReconAssistsInGame = int.Parse(rawData["reconAssistsMostInGame"].ToString());
                if (rawData["teleporterPadsDestroyed"] != null)
                    TeleporterPadsDestroyed = int.Parse(rawData["teleporterPadsDestroyed"].ToString());


            }
        }

        public class HeroAverage
        {
            public int AverageOverallDamage { get; internal set; }

            public int AverageBarrierDamage { get; internal set; }

            public int AverageDeaths { get; internal set; }

            public int AverageEliminations { get; internal set; }

            public int AverageEliminationsPerLife { get; internal set; }

            public int AverageFinalBlows { get; internal set; }

            public int AverageHeroDamage { get; internal set; }

            public int AverageObjectiveKills { get; internal set; }

            public int AverageObjectiveTime { get; internal set; }

            public int AverageSoloKills { get; internal set; }

            public int AverageTimeOnFire { get; internal set; }

            public int AverageCriticalHits { get; internal set; }

            public int AverageMeleeFinalBlows { get; internal set; }

            public HeroAverage(JObject rawData)
            {
                if (rawData["allDamageDoneAvgPer10Min"] != null)
                    AverageOverallDamage = int.Parse(rawData["allDamageDoneAvgPer10Min"].ToString());
                if (rawData["barrierDamageDoneAvgPer10Min"] != null)
                    AverageBarrierDamage = int.Parse(rawData["barrierDamageDoneAvgPer10Min"].ToString());
                if (rawData["deathsAvgPer10Min"] != null)
                    AverageDeaths = int.Parse(rawData["deathsAvgPer10Min"].ToString());
                if (rawData["eliminationsAvgPer10Min"] != null)
                    AverageEliminations = int.Parse(rawData["eliminationsAvgPer10Min"].ToString());
                if (rawData["eliminationsPerLife"] != null)
                    AverageEliminationsPerLife = int.Parse(rawData["eliminationsPerLife"].ToString());
                if (rawData["finalBlowsAvgPer10Min"] != null)
                    AverageFinalBlows = int.Parse(rawData["finalBlowsAvgPer10Min"].ToString());
                if (rawData["heroDamageDoneAvgPer10Min"] != null)
                    AverageHeroDamage = int.Parse(rawData["heroDamageDoneAvgPer10Min"].ToString());
                if (rawData["objectiveKillsAvgPer10Min"] != null)
                    AverageObjectiveKills = int.Parse(rawData["objectiveKillsAvgPer10Min"].ToString());
                if (rawData["objectiveTimeAvgPer10Min"] != null)
                    AverageObjectiveTime = int.Parse(rawData["objectiveTimeAvgPer10Min"].ToString());
                if (rawData["soloKillsAvgPer10Min"] != null)
                    AverageSoloKills = int.Parse(rawData["soloKillsAvgPer10Min"].ToString());
                if (rawData["timeSpentOnFireAvgPer10Min"] != null)
                    AverageTimeOnFire = int.Parse(rawData["timeSpentOnFireAvgPer10Min"].ToString());
                if (rawData["criticalHitsAvgPer10Min"] != null)
                    AverageCriticalHits = int.Parse(rawData["criticalHitsAvgPer10Min"].ToString());
                if (rawData["meleeFinalBlowsAvgPer10Min"] != null)
                    AverageMeleeFinalBlows = int.Parse(rawData["meleeFinalBlowsAvgPer10Min"].ToString());
            }

        }

        public class HeroBest
        {
            public int BestOverallDamageDoneInGame { get; internal set; }

            public int BestOverallDamageDoneInLife { get; internal set; }

            public int BestBarrierDamageDoneInGame { get; internal set; }

            public int BestEliminationsDoneInGame { get; internal set; }

            public int BestEliminationsDoneInLife { get; internal set; }

            public int BestFinalBlowsDoneInGame { get; internal set; }

            public int BestHeroDamageDoneInGame { get; internal set; }

            public int BestHeroDamageDoneInLife { get; internal set; }

            public int BestKillStreak { get; internal set; }

            public int BestMultiKill { get; internal set; }

            public int BestObjectiveKillsDoneInGame { get; internal set; }

            public int BestObjectiveTimeDoneInGame { get; internal set; }

            public int BestSoloKillsDoneInGame { get; internal set; }

            public int BestTimeOnFire { get; internal set; }

            public string BestAccuracyInGame { get; internal set; }

            public int BestCriticalHitsInGame { get; internal set; }

            public int BestCriticalHitsInLife { get; internal set; }

            public int BestMeleeFinalBlowsInGame { get; internal set; }
            public HeroBest(JObject rawData)
            {
                if (rawData["allDamageDoneMostInGame"] != null)
                    BestOverallDamageDoneInGame = int.Parse(rawData["allDamageDoneMostInGame"].ToString());
                if (rawData["allDamageDoneMostInLife"] != null)
                    BestOverallDamageDoneInLife = int.Parse(rawData["allDamageDoneMostInLife"].ToString());
                if (rawData["barrierDamageDoneMostInGame"] != null)
                    BestBarrierDamageDoneInGame = int.Parse(rawData["barrierDamageDoneMostInGame"].ToString());
                if (rawData["eliminationsMostInGame"] != null)
                    BestEliminationsDoneInGame = int.Parse(rawData["eliminationsMostInGame"].ToString());
                if (rawData["eliminationsMostInLife"] != null)
                    BestEliminationsDoneInLife = int.Parse(rawData["eliminationsMostInLife"].ToString());
                if (rawData["finalBlowsMostInGame"] != null)
                    BestFinalBlowsDoneInGame = int.Parse(rawData["finalBlowsMostInGame"].ToString());
                if (rawData["heroDamageDoneMostInGame"] != null)
                    BestHeroDamageDoneInGame = int.Parse(rawData["heroDamageDoneMostInGame"].ToString());
                if (rawData["heroDamageDoneMostInLife"] != null)
                    BestHeroDamageDoneInLife = int.Parse(rawData["heroDamageDoneMostInLife"].ToString());
                if (rawData["killsStreakBest"] != null)
                    BestKillStreak = int.Parse(rawData["killsStreakBest"].ToString());
                if (rawData["multikillsBest"] != null)
                    BestMultiKill = int.Parse(rawData["multikillsBest"].ToString());
                if (rawData["objectiveKillsMostInGame"] != null)
                    BestObjectiveKillsDoneInGame = int.Parse(rawData["objectiveKillsMostInGame"].ToString());
                if (rawData["objectiveTimeMostInGame"] != null)
                    BestObjectiveTimeDoneInGame = int.Parse(rawData["objectiveTimeMostInGame"].ToString());
                if (rawData["soloKillsMostInGame"] != null)
                    BestSoloKillsDoneInGame = int.Parse(rawData["soloKillsMostInGame"].ToString());
                if (rawData["timeSpentOnFireMostInGame"] != null)
                    BestTimeOnFire = int.Parse(rawData["timeSpentOnFireMostInGame"].ToString());
                if (rawData["weaponAccuracyBestInGame"] != null)
                    BestAccuracyInGame = rawData["weaponAccuracyBestInGame"].ToString();
                if (rawData["criticalHitsMostInGame"] != null)
                    BestCriticalHitsInGame = int.Parse(rawData["criticalHitsMostInGame"].ToString());
                if (rawData["criticalHitsMostInLife"] != null)
                    BestCriticalHitsInLife = int.Parse(rawData["criticalHitsMostInGame"].ToString());
                if (rawData["meleeFinalBlowsMostInGame"] != null)
                    BestMeleeFinalBlowsInGame = int.Parse(rawData["meleeFinalBlowsMostInGame"].ToString());
            }
        }

        public class HeroCombat
        {
            public int TotalBarrierDamageDone { get; internal set; }

            public int TotalOverallDamageDone { get; internal set; }

            public int TotalDeaths { get; internal set; }

            public int TotalEliminations { get; internal set; }

            public int TotalFinalBlows { get; internal set; }

            public int TotalHeroDamageDone { get; internal set; }

            public int TotalMultiKills { get; internal set; }

            public int TotalObjectiveKills { get; internal set; }

            public string TotalObjectiveTime { get; internal set; }

            public int QuickMeleeAccuracy { get; internal set; }

            public int TotalSoloKills { get; internal set; }

            public string TotalTimeOnFire { get; internal set; }

            public string WeaponAccuracy { get; internal set; }

            public int TotalCriticalHits { get; internal set; }

            public string CriticalHitAccuracy { get; internal set; }

            public int TotalMeleeFinalBlows { get; internal set; }

            public int TotalEnvironmentKills { get; internal set; }
            public HeroCombat(JObject rawData)
            {
                if (rawData["barrierDamageDone"] != null)
                    TotalBarrierDamageDone = int.Parse(rawData["barrierDamageDone"].ToString());
                if (rawData["damageDone"] != null)
                    TotalOverallDamageDone = int.Parse(rawData["damageDone"].ToString());
                if (rawData["deaths"] != null)
                    TotalDeaths = int.Parse(rawData["deaths"].ToString());
                if (rawData["eliminations"] != null)
                    TotalEliminations = int.Parse(rawData["eliminations"].ToString());
                if (rawData["finalBlows"] != null)
                    TotalFinalBlows = int.Parse(rawData["finalBlows"].ToString());
                if (rawData["heroDamageDone"] != null)
                    TotalHeroDamageDone = int.Parse(rawData["heroDamageDone"].ToString());
                if (rawData["multikills"] != null)
                    TotalMultiKills = int.Parse(rawData["multikills"].ToString());
                if (rawData["objectiveKills"] != null)
                    TotalObjectiveKills = int.Parse(rawData["objectiveKills"].ToString());
                if (rawData["objectiveTime"] != null)
                    TotalObjectiveTime = rawData["objectiveTime"].ToString();
                if (rawData["quickMeleeAccuracy"] != null)
                    QuickMeleeAccuracy = int.Parse(rawData["quickMeleeAccuracy"].ToString());
                if (rawData["soloKills"] != null)
                    TotalSoloKills = int.Parse(rawData["soloKills"].ToString());
                if (rawData["timeSpentOnFire"] != null)
                    TotalTimeOnFire = rawData["timeSpentOnFire"].ToString();
                if (rawData["weaponAccuracy"] != null)
                    WeaponAccuracy = rawData["weaponAccuracy"].ToString();
                if (rawData["criticalHits"] != null)
                    TotalCriticalHits = int.Parse(rawData["criticalHits"].ToString());
                if (rawData["criticalHitsAccuracy"] != null)
                    CriticalHitAccuracy = rawData["criticalHitsAccuracy"].ToString();
                if (rawData["meleeFinalBlows"] != null)
                    TotalMeleeFinalBlows = int.Parse(rawData["meleeFinalBlows"].ToString());
                if (rawData["environmentalKills"] != null)
                    TotalEnvironmentKills = int.Parse(rawData["environmentalKills"].ToString());
            }
        }

        public class HeroSpecific
        {
            #region Ana
            public int TotalBioticGrenadeKills { get; internal set; }

            public int TotalEnemiesSlept { get; internal set; }

            public int AverageEnemiesSlept { get; internal set; }

            public int MostEnemiesSleptInGame { get; internal set; }

            public int TotalNanoBoostAssists { get; internal set; }

            public int AverageNanoBoostAssists { get; internal set; }

            public int MostNanoBoostAssistsInGame { get; internal set; }

            public int TotalNanoBoostsApplied { get; internal set; }

            public int AverageNanoBoostsApplied { get; internal set; }

            public int MostNanoBoostsInGame { get; internal set; }

            public string ScopedAccuracy { get; internal set; }

            public string BestScopedAccuracyInGame { get; internal set; }

            public int TotalSelfHealing { get; internal set; }

            public int AverageSelfHealing { get; internal set; }

            public int MostSelfHealingInGame { get; internal set; }

            public int UnscopedAccuracy { get; internal set; }

            public int BestUnscopedAccuracy { get; internal set; }

            #endregion

            #region Bastion
            public int TotalReconKills { get; internal set; }

            public int AverageReconKills { get; internal set; }

            public int MostReconKillsInGame { get; internal set; }

            public int TotalSentryKills { get; internal set; }

            public int AverageSentryKills { get; internal set; }

            public int MostSentryKillsInGame { get; internal set; }

            public int TotalTankKills { get; internal set; }

            public int AverageTankKills { get; internal set; }

            public int MostTankKillsInGame { get; internal set; }
            #endregion

            #region D.VA
            public int TotalDamageBlocked { get; internal set; }

            public int AverageDamageBlocked { get; internal set; }

            public int MostDamageBlockedInGame { get; internal set; }

            public int TotalMechDeaths { get; internal set; }

            public int TotalMechsCalled { get; internal set; }

            public int AverageMechsCalled { get; internal set; }

            public int MostMechsCalledInGame { get; internal set; }

            public int TotalSelfDestructKills { get; internal set; }

            public int AverageSelfDestructKills { get; internal set; }

            public int MostSelfDestructKillsInGame { get; internal set; }

            #endregion

            #region Doomfist
            public int TotalAbilityDamageDone { get; internal set; }

            public int AverageAbilityDamageDone { get; internal set; }

            public int MostAbilityDamageDoneInGame { get; internal set; }

            public int TotalShieldsCreated { get; internal set; }

            public int AverageShieldsCreated { get; internal set; }

            public int MostShieldsCreatedInGame { get; internal set; }
            #endregion

            #region Hanzo

            public int TotalDragonstrikeKills { get; internal set; }

            public int AverageDragonstrikeKills { get; internal set; }

            public int MostDragonstrikeKillsInGame { get; internal set; }

            #endregion

            #region Junkrat
            public int TotalConcussionMineKills { get; internal set; }

            public int AverageConcussionMineKills { get; internal set; }

            public int MostConcussionMineKillsInGame { get; internal set; }

            public int TotalEnemiesTrapped { get; internal set; }

            public int AverageEnemiesTrapped { get; internal set; }

            public int MostEnemiesTrappedInGame { get; internal set; }

            public int TotalRipTireKills { get; internal set; }

            public int AverageRipTireKills { get; internal set; }

            public int MostRipTireKillsInGame { get; internal set; }

            #endregion

            #region Lucio
            public int TotalSoundBarriersProvided { get; internal set; }

            public int AverageSoundBarriersProvided { get; internal set; }

            public int MostSoundBarriersProvidedInGame { get; internal set; }
            #endregion

            #region McCree
            public int TotalDeadEyeKills { get; internal set; }

            public int AverageDeadEyeKills { get; internal set; }

            public int MostDeadEyeKillsInGame { get; internal set; }
            #endregion

            #region Mei
            public int TotalBlizzardKills { get; internal set; }

            public int AverageBlizzardKills { get; internal set; }

            public int MostBlizzardKillsInGame { get; internal set; }

            public int TotalEnemiesFrozen { get; internal set; }

            public int AverageEnemiesFrozen { get; internal set; }

            public int MostEnemiesFrozenInGame { get; internal set; }


            #endregion

            #region Mercy
            public int TotalBlasterKills { get; internal set; }

            public int AverageBlasterKills { get; internal set; }

            public int MostBlasterKillsInGame { get; internal set; }

            public int TotalDamageAmplified { get; internal set; }

            public int AverageDamageAmplified { get; internal set; }

            public int MostDamageAmplifiedInGame { get; internal set; }

            public int TotalPlayersResurrected { get; internal set; }

            public int AveragePlayersResurrected { get; internal set; }

            public int MostPlayersResurrectedInGame { get; internal set; }
            #endregion

            #region Moira
            public int TotalCoalescenceHealing { get; internal set; }

            public int AverageCoalescenceHealing { get; internal set; }

            public int MostCoalescenceHealingInGame { get; internal set; }

            public int TotalCoalescenceKills { get; internal set; }

            public int AverageCoalescenceKills { get; internal set; }

            public int MostCoalescenceKillsInGame { get; internal set; }

            public int SecondaryFireAccuracy { get; internal set; }
            #endregion

            #region Orisa
            public int TotalSuperchargerAssists { get; internal set; }

            public int AverageSuperchargerAssists { get; internal set; }

            public int MostSuperchargerAssistsInGame { get; internal set; }
            #endregion

            #region Pharah
            public int TotalBarrageKills { get; internal set; }

            public int AverageBarrageKills { get; internal set; }

            public int MostBarrageKillsInGame { get; internal set; }

            public int TotalDirectRocketHits { get; internal set; }

            public int AverageDirectRocketHits { get; internal set; }

            public int MostDirectRocketHitsInGame { get; internal set; }
            #endregion

            #region Reinhardt

            public int TotalChargeKills { get; internal set; }

            public int AverageChargeKills { get; internal set; }

            public int MostChargeKillsInGame { get; internal set; }

            public int TotalEarthshatterKills { get; internal set; }

            public int AverageEarthshatterKills { get; internal set; }

            public int MostEarthshatterKillsInGame { get; internal set; }

            public int TotalFireStrikeKills { get; internal set; }

            public int AverageFireStrikeKills { get; internal set; }

            public int MostFireStrikeKillsInGame { get; internal set; }

            public int RocketHammerMeleeAccuracy { get; internal set; }

            #endregion

            #region Roadhog

            public int TotalEnemiesHooked { get; internal set; }

            public int AverageEnemiesHooked { get; internal set; }

            public int MostEnemiesHookedInGame { get; internal set; }

            public string HookAccuracy { get; internal set; }

            public string BestHookAccuracyInGame { get; internal set; }

            public int TotalHookAttempts { get; internal set; }

            public int TotalWholeHogKills { get; internal set; }

            public int AverageWholeHogKills { get; internal set; }

            public int MostWholeHogKillsInGame { get; internal set; }

            #endregion

            #region Soldier-76
            public int TotalBioticFieldHealingDone { get; internal set; }

            public int TotalBioticFieldsDeployed { get; internal set; }

            public int TotalHelixRocketKills { get; internal set; }

            public int AverageHelixRocketKills { get; internal set; }

            public int MostHelixRocketKillsInGame { get; internal set; }

            public int TotalTacticalVisorKills { get; internal set; }

            public int AverageTacticalVisorKills { get; internal set; }

            public int MostTacticalVisorKillsInGame { get; internal set; }
            #endregion

            #region Sombra
            public int TotalEnemiesEmped { get; internal set; }

            public int AverageEnemiesEmped { get; internal set; }

            public int MostEnemiesEmpedInGame { get; internal set; }

            public int TotalEnemiesHacked { get; internal set; }

            public int AverageEnemiesHacked { get; internal set; }

            public int MostEnemiesHackedInGame { get; internal set; }
            #endregion

            #region Symmetra
            public int TotalPlayersTeleported { get; internal set; }

            public int AveragePlayersTeleported { get; internal set; }

            public int MostPlayersTeleportedInGame { get; internal set; }

            public int TotalSentryTurretKills { get; internal set; }

            public int AverageSentryTurretKills { get; internal set; }

            public int MostSentryTurretKillsInGame { get; internal set; }
            #endregion

            #region Torbjorn
            public int TotalArmorPacksCreated { get; internal set; }

            public int AverageArmorPacksCreated { get; internal set; }

            public int MostArmorPacksCreatedInGame { get; internal set; }

            public int TotalMoltenCoreKills { get; internal set; }

            public int AverageMoltenCoreKills { get; internal set; }

            public int MostMoltenCoreKillsInGame { get; internal set; }

            public int TotalTorbjornKills { get; internal set; }

            public int AverageTorbjornKills { get; internal set; }

            public int MostTorbjornKillsInGame { get; internal set; }

            public int TotalTurretKills { get; internal set; }

            public int AverageTurretKills { get; internal set; }

            public int MostTurretKillsInGame { get; internal set; }
            #endregion

            #region Tracer
            public int TotalHealthRecovered { get; internal set; }

            public int AverageHealthRecovered { get; internal set; }

            public int MostHealthRecoveredInGame { get; internal set; }

            public int TotalPulseBombsAttached { get; internal set; }

            public int AveragePulseBombsAttached { get; internal set; }

            public int MostPulseBombsAttachedInGame { get; internal set; }

            public int TotalPulseBombKills { get; internal set; }

            public int AveragePulseBombKills { get; internal set; }

            public int MostPulseBombKillsInGame { get; internal set; }


            #endregion

            #region Widowmaker
            public int TotalScopedCriticalHits { get; internal set; }

            public int AverageScopedCriticalHits { get; internal set; }

            public int MostScopedCriticalHitsInGame { get; internal set; }

            public int TotalVenomMineKills { get; internal set; }

            public int AverageVenomMineKills { get; internal set; }

            public int MostVenomMineKillsInGame { get; internal set; }
            #endregion

            #region Winston
            public int TotalJumpPackKills { get; internal set; }

            public int AverageJumpPackKills { get; internal set; }

            public int MostJumpPacksInGame { get; internal set; }

            public int TotalMeleeKills { get; internal set; }

            public int AverageMeleeKills { get; internal set; }

            public int MostMeleeKillsInGame { get; internal set; }

            public int TotalPlayersKnockedBack { get; internal set; }

            public int AveragePlayersKnockedBack { get; internal set; }

            public int MostPlayersKnockedBackInGame { get; internal set; }

            public int TotalPrimalRageKills { get; internal set; }

            public int AveragePrimalRageKills { get; internal set; }

            public int MostPrimalRageKillsInGame { get; internal set; }

            public int TeslaCannonAccuracy { get; internal set; }
            #endregion

            #region Zarya
            public double AverageEnergy { get; internal set; }

            public double BestAverageEnergyInGame { get; internal set; }

            public int TotalGravitonSurgeKills { get; internal set; }

            public int AverageGravitonSurgeKills { get; internal set; }

            public int MostGravitonSurgeKillsInGame { get; internal set; }

            public int PrimaryFireAccuracy { get; internal set; }

            public int TotalProjectedBarriersApplied { get; internal set; }

            public int AverageProjectedBarriersApplied { get; internal set; }

            public int MostProjectedBarriersAppliedInGame { get; internal set; }
            #endregion

            #region Zenyatta
            public int TotalTranscendenceHealing { get; internal set; }

            public int MostTranscendenceHealingInGame { get; internal set; }
            #endregion

            public HeroSpecific(JObject rawData)
            {
                #region Ana
                if (rawData["bioticGrenadeKills"] != null)
                    TotalBioticGrenadeKills = int.Parse(rawData["bioticGrenadeKills"].ToString());
                if (rawData["enemiesSlept"] != null)
                    TotalEnemiesSlept = int.Parse(rawData["enemiesSlept"].ToString());
                if (rawData["enemiesSleptAvgPer10Min"] != null)
                    AverageEnemiesSlept = int.Parse(rawData["enemiesSleptAvgPer10Min"].ToString());
                if (rawData["enemiesSleptMostInGame"] != null)
                    MostEnemiesSleptInGame = int.Parse(rawData["enemiesSleptMostInGame"].ToString());
                if (rawData["nanoBoostAssists"] != null)
                    TotalNanoBoostAssists = int.Parse(rawData["nanoBoostAssists"].ToString());
                if (rawData["nanoBoostAssistsAvgPer10Min"] != null)
                    AverageNanoBoostAssists = int.Parse(rawData["nanoBoostAssistsAvgPer10Min"].ToString());
                if (rawData["nanoBoostAssistsMostInGame"] != null)
                    MostNanoBoostAssistsInGame = int.Parse(rawData["nanoBoostAssistsMostInGame"].ToString());
                if (rawData["nanoBoostsApplied"] != null)
                    TotalNanoBoostsApplied = int.Parse(rawData["nanoBoostsApplied"].ToString());
                if (rawData["nanoBoostsAppliedAvgPer10Min"] != null)
                    AverageNanoBoostsApplied = int.Parse(rawData["nanoBoostsAppliedAvgPer10Min"].ToString());
                if (rawData["nanoBoostsAppliedMostInGame"] != null)
                    MostNanoBoostsInGame = int.Parse(rawData["nanoBoostsAppliedMostInGame"].ToString());
                if (rawData["scopedAccuracy"] != null)
                    ScopedAccuracy = rawData["scopedAccuracy"].ToString();
                if (rawData["scopedAccuracyBestInGame"] != null)
                    BestScopedAccuracyInGame = rawData["scopedAccuracyBestInGame"].ToString();
                if (rawData["selfHealing"] != null)
                    TotalSelfHealing = int.Parse(rawData["selfHealing"].ToString());
                if (rawData["selfHealingAvgPer10Min"] != null)
                    AverageSelfHealing = int.Parse(rawData["selfHealingAvgPer10Min"].ToString());
                if (rawData["selfHealingMostInGame"] != null)
                    MostSelfHealingInGame = int.Parse(rawData["selfHealingMostInGame"].ToString());
                if (rawData["unscopedAccuracy"] != null)
                    UnscopedAccuracy = int.Parse(rawData["unscopedAccuracy"].ToString());
                if (rawData["unscopedAccuracyBestInGame"] != null)
                    BestUnscopedAccuracy = int.Parse(rawData["unscopedAccuracyBestInGame"].ToString());
                #endregion

                #region Bastion
                if (rawData["reconKills"] != null)
                    TotalReconKills = int.Parse(rawData["reconKills"].ToString());
                if (rawData["reconKillsAvgPer10Min"] != null)
                    AverageReconKills = int.Parse(rawData["reconKillsAvgPer10Min"].ToString());
                if (rawData["reconKillsMostInGame"] != null)
                    MostReconKillsInGame = int.Parse(rawData["reconKillsMostInGame"].ToString());
                if (rawData["sentryKills"] != null)
                    TotalSentryKills = int.Parse(rawData["sentryKills"].ToString());
                if (rawData["sentryKillsAvgPer10Min"] != null)
                    AverageSentryKills = int.Parse(rawData["sentryKillsAvgPer10Min"].ToString());
                if (rawData["sentryKillsMostInGame"] != null)
                    MostSentryKillsInGame = int.Parse(rawData["sentryKillsMostInGame"].ToString());
                if (rawData["tankKills"] != null)
                    TotalTankKills = int.Parse(rawData["tankKills"].ToString());
                if (rawData["tankKillsAvgPer10Min"] != null)
                    AverageTankKills = int.Parse(rawData["tankKillsAvgPer10Min"].ToString());
                if (rawData["tankKillsMostInGame"] != null)
                    MostTankKillsInGame = int.Parse(rawData["tankKillsMostInGame"].ToString());
                #endregion

                #region D.Va
                if (rawData["damageBlocked"] != null)
                    TotalDamageBlocked = int.Parse(rawData["damageBlocked"].ToString());
                if (rawData["damageBlockedAvgPer10Min"] != null)
                    AverageDamageBlocked = int.Parse(rawData["damageBlockedAvgPer10Min"].ToString());
                if (rawData["damageBlockedMostInGame"] != null)
                    MostDamageBlockedInGame = int.Parse(rawData["damageBlockedMostInGame"].ToString());
                if (rawData["mechDeaths"] != null)
                    TotalMechDeaths = int.Parse(rawData["mechDeaths"].ToString());
                if (rawData["mechsCalled"] != null)
                    TotalMechsCalled = int.Parse(rawData["mechsCalled"].ToString());
                if (rawData["mechsCalledAvgPer10Min"] != null)
                    AverageMechsCalled = int.Parse(rawData["mechsCalledAvgPer10Min"].ToString());
                if (rawData["mechsCalledMostInGame"] != null)
                    MostMechsCalledInGame = int.Parse(rawData["mechsCalledMostInGame"].ToString());
                if (rawData["selfDestructKills"] != null)
                    TotalSelfDestructKills = int.Parse(rawData["selfDestructKills"].ToString());
                if (rawData["selfDestructKillsAvgPer10Min"] != null)
                    AverageSelfDestructKills = int.Parse(rawData["selfDestructKillsAvgPer10Min"].ToString());
                if (rawData["selfDestructKillsMostInGame"] != null)
                    MostSelfDestructKillsInGame = int.Parse(rawData["selfDestructKillsMostInGame"].ToString());

                #endregion

                #region Doomfist
                if (rawData["abilityDamageDone"] != null)
                    TotalAbilityDamageDone = int.Parse(rawData["abilityDamageDone"].ToString());
                if (rawData["abilityDamageDoneAvgPer10Min"] != null)
                    AverageAbilityDamageDone = int.Parse(rawData["abilityDamageDoneAvgPer10Min"].ToString());
                if (rawData["abilityDamageDoneMostInGame"] != null)
                    MostAbilityDamageDoneInGame = int.Parse(rawData["abilityDamageDoneMostInGame"].ToString());
                if (rawData["shieldsCreated"] != null)
                    TotalShieldsCreated = int.Parse(rawData["shieldsCreated"].ToString());
                if (rawData["shieldsCreatedAvgPer10Min"] != null)
                    AverageShieldsCreated = int.Parse(rawData["shieldsCreatedAvgPer10Min"].ToString());
                if (rawData["shieldsCreatedMostInGame"] != null)
                    MostShieldsCreatedInGame = int.Parse(rawData["shieldsCreatedMostInGame"].ToString());
                #endregion

                #region Hanzo
                if (rawData["dragonstrikeKills"] != null)
                    TotalDragonstrikeKills = int.Parse(rawData["dragonstrikeKills"].ToString());
                if (rawData["dragonstrikeKillsAvgPer10Min"] != null)
                    AverageDragonstrikeKills = int.Parse(rawData["dragonstrikeKillsAvgPer10Min"].ToString());
                if (rawData["dragonstrikeKillsMostInGame"] != null)
                    MostDragonstrikeKillsInGame = int.Parse(rawData["dragonstrikeKillsMostInGame"].ToString());
                #endregion

                #region Junkrat
                if (rawData["concussionMineKills"] != null)
                    TotalConcussionMineKills = int.Parse(rawData["concussionMineKills"].ToString());
                if (rawData["concussionMineKillsAvgPer10Min"] != null)
                    AverageConcussionMineKills = int.Parse(rawData["concussionMineKillsAvgPer10Min"].ToString());
                if (rawData["concussionMineKillsMostInGame"] != null)
                    MostConcussionMineKillsInGame = int.Parse(rawData["concussionMineKillsAvgPer10Min"].ToString());
                if (rawData["enemiesTrapped"] != null)
                    TotalEnemiesTrapped = int.Parse(rawData["enemiesTrapped"].ToString());
                if (rawData["enemiesTrappedAvgPer10Min"] != null)
                    AverageEnemiesTrapped = int.Parse(rawData["enemiesTrappedAvgPer10Min"].ToString());
                if (rawData["enemiesTrappedMostInGame"] != null)
                    MostEnemiesTrappedInGame = int.Parse(rawData["enemiesTrappedMostInGame"].ToString());
                if (rawData["ripTireKills"] != null)
                    TotalRipTireKills = int.Parse(rawData["ripTireKills"].ToString());
                if (rawData["ripTireKillsAvgPer10Min"] != null)
                    AverageRipTireKills = int.Parse(rawData["ripTireKillsAvgPer10Min"].ToString());
                if (rawData["ripTireKillsMostInGame"] != null)
                    MostRipTireKillsInGame = int.Parse(rawData["ripTireKillsMostInGame"].ToString());

                #endregion

                #region Lucio
                if (rawData["soundBarriersProvided"] != null)
                    TotalSoundBarriersProvided = int.Parse(rawData["soundBarriersProvided"].ToString());
                if (rawData["soundBarriersProvidedAvgPer10Min"] != null)
                    AverageSoundBarriersProvided = int.Parse(rawData["soundBarriersProvidedAvgPer10Min"].ToString());
                if (rawData["soundBarriersProvidedMostInGame"] != null)
                    MostSoundBarriersProvidedInGame = int.Parse(rawData["soundBarriersProvidedMostInGame"].ToString());
                #endregion

                #region McCree
                if (rawData["deadEyeKills"] != null)
                    TotalDeadEyeKills = int.Parse(rawData["deadEyeKills"].ToString());
                if (rawData["deadEyeKillsAvgPer10Min"] != null)
                    AverageDeadEyeKills = int.Parse(rawData["deadEyeKillsAvgPer10Min"].ToString());
                if (rawData["deadEyeKillsMostInGame"] != null)
                    MostDeadEyeKillsInGame = int.Parse(rawData["deadEyeKillsMostInGame"].ToString());
                #endregion

                #region Mei
                if (rawData["blizzardKills"] != null)
                    TotalBlizzardKills = int.Parse(rawData["blizzardKills"].ToString());
                if (rawData["blizzardKillsAvgPer10Min"] != null)
                    AverageBlizzardKills = int.Parse(rawData["blizzardKillsAvgPer10Min"].ToString());
                if (rawData["blizzardKillsMostInGame"] != null)
                    MostBlizzardKillsInGame = int.Parse(rawData["blizzardKillsMostInGame"].ToString());
                if (rawData["enemiesFrozen"] != null)
                    TotalEnemiesFrozen = int.Parse(rawData["enemiesFrozen"].ToString());
                if (rawData["enemiesFrozenAvgPer10Min"] != null)
                    AverageEnemiesFrozen = int.Parse(rawData["enemiesFrozenAvgPer10Min"].ToString());
                if (rawData["enemiesFrozenMostInGame"] != null)
                    MostEnemiesFrozenInGame = int.Parse(rawData["enemiesFrozenMostInGame"].ToString());
                #endregion

                #region Mercy
                if (rawData["blasterKills"] != null)
                    TotalBlasterKills = int.Parse(rawData["blasterKills"].ToString());
                if (rawData["blasterKillsAvgPer10Min"] != null)
                    AverageBlasterKills = int.Parse(rawData["blasterKillsAvgPer10Min"].ToString());
                if (rawData["blasterKillsMostInGame"] != null)
                    MostBlasterKillsInGame = int.Parse(rawData["blasterKillsMostInGame"].ToString());
                if (rawData["damageAmplified"] != null)
                    TotalDamageAmplified = int.Parse(rawData["damageAmplified"].ToString());
                if (rawData["damageAmplifiedAvgPer10Min"] != null)
                    AverageDamageAmplified = int.Parse(rawData["damageAmplifiedAvgPer10Min"].ToString());
                if (rawData["damageAmplifiedMostInGame"] != null)
                    MostDamageAmplifiedInGame = int.Parse(rawData["damageAmplifiedMostInGame"].ToString());
                if (rawData["playersResurrected"] != null)
                    TotalPlayersResurrected = int.Parse(rawData["playersResurrected"].ToString());
                if (rawData["playersResurrectAvgPer10Min"] != null)
                    AveragePlayersResurrected = int.Parse(rawData["playersResurrectedAvgPer10Min"].ToString());
                if (rawData["playersResurrectedMostInGame"] != null)
                    MostPlayersResurrectedInGame = int.Parse(rawData["playersResurrectedMostInGame"].ToString());
                #endregion

                #region Moira
                if (rawData["coalescenceHealing"] != null)
                    TotalCoalescenceHealing = int.Parse(rawData["coalescenceHealing"].ToString());
                if (rawData["coalescenceHealingAvgPer10Min"] != null)
                    AverageCoalescenceHealing = int.Parse(rawData["coalescenceHealingAvgPer10Min"].ToString());
                if (rawData["coalescenceHealingMostInGame"] != null)
                    MostCoalescenceHealingInGame = int.Parse(rawData["coalescenceHealingMostInGame"].ToString());
                if (rawData["coalescenceKills"] != null)
                    TotalCoalescenceKills = int.Parse(rawData["coalescenceKills"].ToString());
                if (rawData["coalescenceKillsAvgPer10Min"] != null)
                    AverageCoalescenceKills = int.Parse(rawData["coalescenceKillsAvgPer10Min"].ToString());
                if (rawData["coalescenceKillsMostInGame"] != null)
                    MostCoalescenceKillsInGame = int.Parse(rawData["coalescenceKillsMostInGame"].ToString());
                if (rawData["secondaryFireAccuracy"] != null)
                    SecondaryFireAccuracy = int.Parse(rawData["secondaryFireAccuracy"].ToString());
                #endregion

                #region Orisa
                if (rawData["superchargerAssists"] != null)
                    TotalSuperchargerAssists = int.Parse(rawData["superchargerAssists"].ToString());
                if (rawData["superchargerAssistsAvgPer10Min"] != null)
                    AverageSuperchargerAssists = int.Parse(rawData["superchargerAssistsAvgPer10Min"].ToString());
                if (rawData["superchargerAssistsMostInGame"] != null)
                    MostSuperchargerAssistsInGame = int.Parse(rawData["superchargerAssistsMostInGame"].ToString());
                #endregion

                #region Pharah
                if (rawData["barrageKills"] != null)
                    TotalBarrageKills = int.Parse(rawData["barrageKills"].ToString());
                if (rawData["barrageKillsAvgPer10Min"] != null)
                    AverageBarrageKills = int.Parse(rawData["barrageKillsAvgPer10Min"].ToString());
                if (rawData["barrageKillsMostInGame"] != null)
                    MostBarrageKillsInGame = int.Parse(rawData["barrageKillsMostInGame"].ToString());
                if (rawData["rocketDirectHits"] != null)
                    TotalDirectRocketHits = int.Parse(rawData["rocketDirectHits"].ToString());
                if (rawData["rocketDirectHitsAvgPer10Min"] != null)
                    AverageDirectRocketHits = int.Parse(rawData["rocketDirectHitsAvgPer10Min"].ToString());
                if (rawData["rocketDirectHitsMostInGame"] != null)
                    MostDirectRocketHitsInGame = int.Parse(rawData["rocketDirectHitsMostInGame"].ToString());
                #endregion

                #region Reinhardt
                if (rawData["chargeKills"] != null)
                    TotalChargeKills = int.Parse(rawData["chargeKills"].ToString());
                if (rawData["chargeKillsAvgPer10Min"] != null)
                    AverageChargeKills = int.Parse(rawData["chargeKillsAvgPer10Min"].ToString());
                if (rawData["chargeKillsMostInGame"] != null)
                    MostChargeKillsInGame = int.Parse(rawData["chargeKillsMostInGame"].ToString());
                if (rawData["earthshatterKills"] != null)
                    TotalEarthshatterKills = int.Parse(rawData["earthshatterKills"].ToString());
                if (rawData["earthshatterKillsAvgPer10Min"] != null)
                    AverageEarthshatterKills = int.Parse(rawData["earthshatterKillsAvgPer10Min"].ToString());
                if (rawData["earthshatterKillsMostInGame"] != null)
                    MostEarthshatterKillsInGame = int.Parse(rawData["earthshatterKillsAvgPer10Min"].ToString());
                if (rawData["fireStrikeKills"] != null)
                    TotalFireStrikeKills = int.Parse(rawData["fireStrikeKills"].ToString());
                if (rawData["fireStrikeKillsAvgPer10Min"] != null)
                    AverageFireStrikeKills = int.Parse(rawData["fireStrikeKillsAvgPer10Min"].ToString());
                if (rawData["fireStrikeKillsMostInGame"] != null)
                    MostFireStrikeKillsInGame = int.Parse(rawData["fireStrikeKillsMostInGame"].ToString());
                if (rawData["rocketHammerMeleeAccuracy"] != null)
                    RocketHammerMeleeAccuracy = int.Parse(rawData["rocketHammerMeleeAccuracy"].ToString());
                #endregion

                #region Roadhog
                if (rawData["enemiesHooked"] != null)
                    TotalEnemiesHooked = int.Parse(rawData["enemiesHooked"].ToString());
                if (rawData["enemiesHookedAvgPer10Min"] != null)
                    AverageEnemiesHooked = int.Parse(rawData["enemiesHookedAvgPer10Min"].ToString());
                if (rawData["enemiesHookedMostInGame"] != null)
                    MostEnemiesHookedInGame = int.Parse(rawData["enemiesHookedMostInGame"].ToString());
                if (rawData["hookAccuracy"] != null)
                    HookAccuracy = rawData["hookAccuracy"].ToString();
                if (rawData["hookAccuracyBestInGame"] != null)
                    BestHookAccuracyInGame = rawData["hookAccuracyBestInGame"].ToString();
                if (rawData["hooksAttempted"] != null)
                    TotalHookAttempts = int.Parse(rawData["hooksAttempted"].ToString());
                if (rawData["wholeHogKills"] != null)
                    TotalWholeHogKills = int.Parse(rawData["wholeHogKills"].ToString());
                if (rawData["wholeHogKillsAvgPer10Min"] != null)
                    AverageWholeHogKills = int.Parse(rawData["wholeHogKillsAvgPer10Min"].ToString());
                if (rawData["wholeHogKillsMostInGame"] != null)
                    MostWholeHogKillsInGame = int.Parse(rawData["wholeHogKillsMostInGame"].ToString());
                #endregion

                #region Soldier-76
                if (rawData["bioticFieldHealingDone"] != null)
                    TotalBioticFieldHealingDone = int.Parse(rawData["bioticFieldHealingDone"].ToString());
                if (rawData["bioticFieldsDeployed"] != null)
                    TotalBioticFieldsDeployed = int.Parse(rawData["bioticFieldsDeployed"].ToString());
                if (rawData["helixRocketKills"] != null)
                    TotalHelixRocketKills = int.Parse(rawData["helixRocketKills"].ToString());
                if (rawData["helixRocketKillsAvgPer10Min"] != null)
                    AverageHelixRocketKills = int.Parse(rawData["helixRocketKillsAvgPer10Min"].ToString());
                if (rawData["helixRocketKillsMostInGame"] != null)
                    MostHelixRocketKillsInGame = int.Parse(rawData["helixRocketKillsMostInGame"].ToString());
                if (rawData["tacticalVisorKills"] != null)
                    TotalTacticalVisorKills = int.Parse(rawData["tacticalVisorKills"].ToString());
                if (rawData["tacticalVisorKillsAvgPer10Min"] != null)
                    AverageTacticalVisorKills = int.Parse(rawData["tacticalVisorKillsAvgPer10Min"].ToString());
                if (rawData["tacticalVisorKillsMostInGame"] != null)
                    MostTacticalVisorKillsInGame = int.Parse(rawData["tacticalVisorKillsMostInGame"].ToString());
                #endregion

                #region Sombra
                if (rawData["enemiesEmpd"] != null)
                    TotalEnemiesEmped = int.Parse(rawData["enemiesEmpd"].ToString());
                if (rawData["enemiesEmpdAvgPer10Min"] != null)
                    AverageEnemiesEmped = int.Parse(rawData["enemiesEmpdAvgPer10Min"].ToString());
                if (rawData["enemiesEmpdMostInGame"] != null)
                    MostEnemiesEmpedInGame = int.Parse(rawData["enemiesEmpdMostInGame"].ToString());
                if (rawData["enemiesHacked"] != null)
                    TotalEnemiesHacked = int.Parse(rawData["enemiesHacked"].ToString());
                if (rawData["enemiesHackedAvgPer10Min"] != null)
                    AverageEnemiesHacked = int.Parse(rawData["enemiesHackedAvgPer10Min"].ToString());
                if (rawData["enemiesHackedMostInGame"] != null)
                    MostEnemiesHackedInGame = int.Parse(rawData["enemiesHackedMostInGame"].ToString());

                #endregion

                #region Symmetra
                if (rawData["playersTeleported"] != null)
                    TotalPlayersTeleported = int.Parse(rawData["playersTeleported"].ToString());
                if (rawData["playersTeleportedAvgPer10Min"] != null)
                    AveragePlayersTeleported = int.Parse(rawData["playersTeleportedAvgPer10Min"].ToString());
                if (rawData["playersTeleportedMostInGame"] != null)
                    MostPlayersTeleportedInGame = int.Parse(rawData["playersTeleportedMostInGame"].ToString());
                if (rawData["sentryTurretsKills"] != null)
                    TotalSentryTurretKills = int.Parse(rawData["sentryTurretsKills"].ToString());
                if (rawData["sentryTurretsKillsAvgPer10Min"] != null)
                    AverageSentryTurretKills = int.Parse(rawData["sentryTurretsKillsAvgPer10Min"].ToString());
                if (rawData["sentryTurretsKillsMostInGame"] != null)
                    MostSentryTurretKillsInGame = int.Parse(rawData["sentryTurretsKillsMostInGame"].ToString());
                #endregion

                #region Torbjorn
                if (rawData["armorPacksCreated"] != null)
                    TotalArmorPacksCreated = int.Parse(rawData["armorPacksCreated"].ToString());
                if (rawData["armorPacksCreatedAvgPer10Min"] != null)
                    AverageArmorPacksCreated = int.Parse(rawData["armorPacksCreatedAvgPer10Min"].ToString());
                if (rawData["armorPacksCreatedMostInGame"] != null)
                    MostArmorPacksCreatedInGame = int.Parse(rawData["armorPacksCreatedMostInGame"].ToString());
                if (rawData["moltenCoreKills"] != null)
                    TotalMoltenCoreKills = int.Parse(rawData["moltenCoreKills"].ToString());
                if (rawData["moltenCoreKillsAvgPer10Min"] != null)
                    AverageMoltenCoreKills = int.Parse(rawData["moltenCoreKillsAvgPer10Min"].ToString());
                if (rawData["moltenCoreKillsMostInGame"] != null)
                    MostMoltenCoreKillsInGame = int.Parse(rawData["moltenCoreKillsMostInGame"].ToString());
                if (rawData["torbjornKills"] != null)
                    TotalTorbjornKills = int.Parse(rawData["torbjornKills"].ToString());
                if (rawData["torbjornKillsAvgPer10Min"] != null)
                    AverageTorbjornKills = int.Parse(rawData["torbjornKillsAvgPer10Min"].ToString());
                if (rawData["torbjornKillsMostInGame"] != null)
                    MostTorbjornKillsInGame = int.Parse(rawData["torbjornKillsMostInGame"].ToString());
                if (rawData["turretsKills"] != null)
                    TotalTurretKills = int.Parse(rawData["turretsKills"].ToString());
                if (rawData["turretsKillsAvgPer10Min"] != null)
                    AverageTurretKills = int.Parse(rawData["turretsKillsAvgPer10Min"].ToString());
                if (rawData["turretsKillsMostInGame"] != null)
                    MostTurretKillsInGame = int.Parse(rawData["turretsKillsMostInGame"].ToString());


                #endregion

                #region Tracer
                if (rawData["healthRecovered"] != null)
                    TotalHealthRecovered = int.Parse(rawData["healthRecovered"].ToString());
                if (rawData["healthRecoveredAvgPer10Min"] != null)
                    AverageHealthRecovered = int.Parse(rawData["healthRecoveredAvgPer10Min"].ToString());
                if (rawData["healthRecoveredMostInGame"] != null)
                    MostHealthRecoveredInGame = int.Parse(rawData["healthRecoveredMostInGame"].ToString());
                if (rawData["pulseBombsAttached"] != null)
                    TotalPulseBombsAttached = int.Parse(rawData["pulseBombsAttached"].ToString());
                if (rawData["pulseBombsAttachedAvgPer10Min"] != null)
                    AveragePulseBombsAttached = int.Parse(rawData["pulseBombsAttachedAvgPer10Min"].ToString());
                if (rawData["pulseBombsAttachedMostInGame"] != null)
                    MostPulseBombsAttachedInGame = int.Parse(rawData["pulseBombsAttachedMostInGame"].ToString());
                if (rawData["pulseBombsKills"] != null)
                    TotalPulseBombKills = int.Parse(rawData["pulseBombsKills"].ToString());
                if (rawData["pulseBombsKillsAvgPer10Min"] != null)
                    AveragePulseBombKills = int.Parse(rawData["pulseBombsKillsAvgPer10Min"].ToString());
                if (rawData["pulseBombsKillsMostInGame"] != null)
                    MostPulseBombKillsInGame = int.Parse(rawData["pulseBombsKillsMostInGame"].ToString());

                #endregion

                #region Widowmaker
                if (rawData["scopedCriticalHits"] != null)
                    TotalScopedCriticalHits = int.Parse(rawData["scopedCriticalHits"].ToString());
                if (rawData["scopedCriticalHitsAvgPer10Min"] != null)
                    AverageScopedCriticalHits = int.Parse(rawData["scopedCriticalHitsAvgPer10Min"].ToString());
                if (rawData["scopedCriticalHitsMostInGame"] != null)
                    MostScopedCriticalHitsInGame = int.Parse(rawData["scopedCriticalHitsMostInGame"].ToString());
                if (rawData["venomMineKills"] != null)
                    TotalVenomMineKills = int.Parse(rawData["venomMineKills"].ToString());
                if (rawData["venomMineKillsAvgPer10Min"] != null)
                    AverageVenomMineKills = int.Parse(rawData["venomMineKillsAvgPer10Min"].ToString());
                if (rawData["venomMineKillsMostInGame"] != null)
                    MostVenomMineKillsInGame = int.Parse(rawData["venomMineKillsMostInGame"].ToString());
                #endregion

                #region Winston
                if (rawData["jumpPackKills"] != null)
                    TotalJumpPackKills = int.Parse(rawData["jumpPackKills"].ToString());
                if (rawData["jumpPackKillsAvgPer10Min"] != null)
                    AverageJumpPackKills = int.Parse(rawData["jumpPackKillsAvgPer10Min"].ToString());
                if (rawData["jumpPackKillsMostInGame"] != null)
                    MostJumpPacksInGame = int.Parse(rawData["jumpPackKillsMostInGame"].ToString());
                if (rawData["meleeKills"] != null)
                    TotalMeleeKills = int.Parse(rawData["meleeKills"].ToString());
                if (rawData["meleeKillsAvgPer10Min"] != null)
                    AverageMeleeKills = int.Parse(rawData["meleeKillsAvgPer10Min"].ToString());
                if (rawData["meleeKillsMostInGame"] != null)
                    MostMeleeKillsInGame = int.Parse(rawData["meleeKillsMostInGame"].ToString());
                if (rawData["playersKnockedBack"] != null)
                    TotalPlayersKnockedBack = int.Parse(rawData["playersKnockedBack"].ToString());
                if (rawData["playersKnockedBackAvgPer10Min"] != null)
                    AveragePlayersKnockedBack = int.Parse(rawData["playersKnockedBackAvgPer10Min"].ToString());
                if (rawData["playersKnockedBackMostInGame"] != null)
                    MostPlayersKnockedBackInGame = int.Parse(rawData["playersKnockedBackMostInGame"].ToString());
                if (rawData["primalRageKills"] != null)
                    TotalPrimalRageKills = int.Parse(rawData["primalRageKills"].ToString());
                if (rawData["primalRageKillsAvgPer10Min"] != null)
                    AveragePrimalRageKills = int.Parse(rawData["primalRageKillsAvgPer10Min"].ToString());
                if (rawData["primalRageKillsMostInGame"] != null)
                    MostPrimalRageKillsInGame = int.Parse(rawData["primalRageKillsMostInGame"].ToString());


                #endregion

                #region Zarya
                if (rawData["averageEnergy"] != null)
                    AverageEnergy = double.Parse(rawData["averageEnergy"].ToString());
                if (rawData["averageEnergyBestInGame"] != null)
                    BestAverageEnergyInGame = double.Parse(rawData["averageEnergyBestInGame"].ToString());
                if (rawData["gravitonSurgeKills"] != null)
                    TotalGravitonSurgeKills = int.Parse(rawData["gravitonSurgeKills"].ToString());
                if (rawData["gravitonSurgeKillsAvgPer10Min"] != null)
                    AverageGravitonSurgeKills = int.Parse(rawData["gravitonSurgeKillsAvgPer10Min"].ToString());
                if (rawData["gravitonSurgeKillsMostInGame"] != null)
                    MostGravitonSurgeKillsInGame = int.Parse(rawData["gravitonSurgeKillsMostInGame"].ToString());
                if (rawData["primaryFireAccuracy"] != null)
                    PrimaryFireAccuracy = int.Parse(rawData["primaryFireAccuracy"].ToString());
                if (rawData["projectedBarriersApplied"] != null)
                    TotalProjectedBarriersApplied = int.Parse(rawData["projectedBarriersApplied"].ToString());
                if (rawData["projectedBarriersAppliedAvgPer10Min"] != null)
                    AverageProjectedBarriersApplied = int.Parse(rawData["projectedBarriersAppliedAvgPer10Min"].ToString());
                if (rawData["projectedBarriersAppliedMostInGame"] != null)
                    MostProjectedBarriersAppliedInGame = int.Parse(rawData["projectedBarriersAppliedMostInGame"].ToString());


                #endregion

                #region Zenyatta
                if (rawData["transcendenceHealing"] != null)
                    TotalTranscendenceHealing = int.Parse(rawData["transcendenceHealing"].ToString());
                if (rawData["transcendenceHealingBest"] != null)
                    MostTranscendenceHealingInGame = int.Parse(rawData["transcendenceHealingBest"].ToString());
                #endregion
            }
        }

        public class HeroGame
        {
            public int GamesWon { get; internal set; }

            public string TimePlayed { get; internal set; }

            public HeroGame(JObject rawData)
            {
                if (rawData["gamesWon"] != null)
                    GamesWon = int.Parse(rawData["gamesWon"].ToString());
                if (rawData["timePlayed"] != null)
                    TimePlayed = rawData["timePlayed"].ToString();
            }
        }

        public class MatchAwards
        {
            public int Cards { get; internal set; }

            public int TotalOverallMedals { get; internal set; }

            public int TotalBronzeMedals { get; internal set; }

            public int TotalSilverMedals { get; internal set; }

            public int TotalGoldMedals { get; internal set; }

            public MatchAwards(JObject rawData)
            {
                if (rawData["cards"] != null)
                    Cards = int.Parse(rawData["cards"].ToString());
                if (rawData["medals"] != null)
                    TotalOverallMedals = int.Parse(rawData["medals"].ToString());
                if (rawData["medalsBronze"] != null)
                    TotalBronzeMedals = int.Parse(rawData["medalsBronze"].ToString());
                if (rawData["medalsSilver"] != null)
                    TotalSilverMedals = int.Parse(rawData["medalsSilver"].ToString());
                if (rawData["medalsGold"] != null)
                    TotalGoldMedals = int.Parse(rawData["medalsGold"].ToString());

            }
        }

        public class Miscellaneous
        {
            #region Brigitte
            public int TotalArmorProvided { get; internal set; }

            public int AverageArmorProvided { get; internal set; }

            public int MostArmorProvidedInGame { get; internal set; }
            #endregion
            #region Hanzo
            public int TotalStormArrowKills { get; internal set; }

            public int AverageStormArrowKills { get; internal set; }

            public int MostStormArrowKillsInGame { get; internal set; }
            #endregion

            #region Winston
            public int TotalTeslaCannonKills { get; internal set; }
            #endregion

            public Miscellaneous(JObject rawData)
            {
                #region Brigitte
                if (rawData["armorProvided"] != null)
                    TotalArmorProvided = int.Parse(rawData["armorProvided"].ToString());
                if (rawData["armorProvidedAvgPer10Min"] != null)
                    AverageArmorProvided = int.Parse(rawData["armorProvidedAvgPer10Min"].ToString());
                if (rawData["armorProvidedMostInGame"] != null)
                    MostArmorProvidedInGame = int.Parse(rawData["armorProvidedMostInGame"].ToString());
                #endregion
                #region Hanzo
                if (rawData["stormArrowKills"] != null)
                    TotalStormArrowKills = int.Parse(rawData["stormArrowKills"].ToString());
                if (rawData["stormArrowKillsAvgPer10Min"] != null)
                    AverageStormArrowKills = int.Parse(rawData["stormArrowKillsAvgPer10Min"].ToString());
                if (rawData["stormArrowKillsMostInGame"] != null)
                    MostStormArrowKillsInGame = int.Parse(rawData["stormArrowKillsMostInGame"].ToString());
                #endregion

                #region Winston
                if (rawData["weaponKills"] != null)
                    TotalTeslaCannonKills = int.Parse(rawData["weaponKills"].ToString());
                #endregion
            }
        }

        #endregion
        public HeroAssists Assists { get; internal set; }

        public HeroAverage Average { get; internal set; }

        public HeroBest Best { get; internal set; }

        public HeroCombat Combat { get; internal set; }

        public HeroSpecific Specific { get; internal set; }

        public HeroGame Game { get; internal set; }

        public MatchAwards Awards { get; internal set; }

        public Miscellaneous Misc { get; internal set; }

        public HeroStats(JObject rawData)
        {
            if (rawData["assists"] != null)
                Assists = new HeroAssists(JObject.Parse(rawData["assists"].ToString()));
            if (rawData["average"] != null)
                Average = new HeroAverage(JObject.Parse(rawData["average"].ToString()));
            if (rawData["best"] != null)
                Best = new HeroBest(JObject.Parse(rawData["best"].ToString()));
            if (rawData["combat"] != null)
                Combat = new HeroCombat(JObject.Parse(rawData["combat"].ToString()));
            if (rawData["heroSpecific"] != null)
                Specific = new HeroSpecific(JObject.Parse(rawData["heroSpecific"].ToString()));
            if (rawData["game"] != null)
                Game = new HeroGame(JObject.Parse(rawData["game"].ToString()));
            if (rawData["matchAwards"] != null)
                Awards = new MatchAwards(JObject.Parse(rawData["matchAwards"].ToString()));
            if (rawData["miscellaneous"] != null)
                Misc = new Miscellaneous(JObject.Parse(rawData["miscellaneous"].ToString()));
        }

    }
}

