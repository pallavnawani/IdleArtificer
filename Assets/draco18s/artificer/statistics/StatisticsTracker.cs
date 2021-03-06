﻿using Koopakiller.Numerics;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace Assets.draco18s.artificer.statistics {
	public static class StatisticsTracker {
		private static List<IStat> allStatistics = new List<IStat>();
		private static List<StatAchievement> allAchievements = new List<StatAchievement>();

		#region stat list
		public static readonly StatBint numClicks = new StatBint("numClicks").register();
		public static readonly StatBase moneyMagnitude = new StatHighscore("moneyMagnitude").register();
		public static readonly StatBint lastResetRenownGain = new StatBint("lastResetRenownGain").register().setHidden();
		public static readonly StatBint lifetimeMoney = new StatBint("lifetimeMoney").register();
		public static readonly StatBint lifetimeRenown = new StatBint("lifetimeRenown").register();
		public static readonly StatBase totalTimePlayed = new StatTimeSpan("totalTimePlayed").register();
		public static readonly StatBase timeCounter = new StatBase("timeCounter").register().setHidden();
		public static readonly StatBase lastSavedTime = new StatBase("lastSavedTime").register().setHidden();
		public static readonly StatBase lastDailyLogin = new StatBase("lastDailyLogin").register().setHidden();
		public static readonly StatBase sequentialDaysPlayed = new StatLogin("sequentialDaysPlayed").register();
		public static readonly StatBase vendorsPurchased = new StatHighscore("vendorsPurchased", EnumResetType.GUILDMASTER).register();
		public static readonly StatBase apprenticesPurchased = new StatHighscore("apprenticesPurchased", EnumResetType.GUILDMASTER).register();
		public static readonly StatBase journeymenPurchased = new StatHighscore("journeymenPurchased", EnumResetType.GUILDMASTER).register();
		public static readonly StatBint appClicks = new StatBint("appClicks").register();
		public static readonly StatBase minQuestDifficulty = new StatResetable("minQuestDifficulty").setInitialValue(0).register();
		public static readonly StatBase maxQuestDifficulty = new StatResetable("maxQuestDifficulty").setInitialValue(3).register();
		public static readonly StatBase questsCompleted = new StatHighscore("questsCompleted").register();
		public static readonly StatBase questsCompletedEver = new StatBase("questsCompletedEver").register();
		public static readonly StatBase relicsMade = new StatBase("relicsMade").register();
		public static readonly StatBase relicsIdentified = new StatHighscore("relicsIdentified", EnumResetType.GUILDMASTER).register();
		public static readonly StatBase relicAntiquity = new StatHighscore("relicAntiquity", EnumResetType.MANUAL).register();
		public static readonly StatBase guildmastersElected = new StatBase("guildmastersElected").register();
		public static readonly StatBase timeSinceLastWar = new StatBase("timeSinceLastWar").register().setHidden();
		//total play duration
		#endregion
		#region achieve list
		public static readonly StatAchievement unlockedQuesting = new StatAchievement("unlockedQuesting").register();
		public static readonly StatAchievement unlockedGuild = new StatAchievement("unlockedGuild").register();
		public static readonly StatAchievement unlockedResearch = new StatAchievement("unlockedResearch").register();
		public static readonly StatAchievement unlockedEnchanting = new StatAchievement("unlockedEnchanting").register();
		public static readonly StatAchievement clicksAch = new AchievementMulti("clicksAch", numClicks, new object[] { 1000, 2000, 4000, 8000, 16000, 32000, 100000, 250000, 500000, 1000000 }).register();
		public static readonly StatAchievement sequentialLogin = new AchievementMulti("sequentialLogin", sequentialDaysPlayed, new object[] { 5, 10, 15, 30, 60, 90, 120, 180, 270, 365 }).register();
		public static readonly StatAchievement allQuestsUnlocked = new StatAchievement("allQuestsUnlocked").register();
		public static readonly StatAchievement firstQuestCompleted = new StatAchievement("firstQuestCompleted").register();
		public static readonly StatAchievement twentiethQuestCompleted = new StatAchievement("twentiethQuestCompleted").register().setHidden();
		public static readonly StatAchievement questsCompletedAch = new AchievementMulti("questsCompleted", questsCompletedEver, new object[] { 1, 20, 50, 100, 500, 1000, 2000, 4000, 10000, 100000 }).register();
		public static readonly StatAchievement relicFromGenie = new StatAchievement("relicFromGenie").register().setSecret();
		public static readonly StatAchievement relicHoarder = new StatAchievement("relicHoarder").register().setSecret();
		public static readonly StatAchievement defeatKraken = new StatAchievement("defeatKraken").register().setSecret();
		public static readonly StatAchievement impressiveAntiquity = new StatAchievement("impressiveAntiquity").register();
		public static readonly StatAchievement firstEnchantment = new StatAchievement("firstEnchantment").register();
		public static readonly StatAchievement firstGuildmaster = new StatAchievement("firstGuildmaster").register();
		public static readonly StatAchievement allCashUpgrades = new StatAchievement("allCashUpgrades").register();
		public static readonly StatAchievement allRenownUpgrades = new StatAchievement("allRenownUpgrades").register();
		public static readonly StatAchievement vendorsPurchasedAch = new AchievementMulti("vendorsPurchasedAch", vendorsPurchased, new object[] { 10, 25, 50, 75, 100, 150, 200, 250, 500, 1000 }).register();
		public static readonly StatAchievement apprenticesPurchasedAch = new AchievementMulti("apprenticesPurchasedAch", apprenticesPurchased, new object[] { 1, 3, 5, 10, 25, 50, 75, 90, 95, 100 }).register();
		public static readonly StatAchievement journeymenPurchasedAch = new AchievementMulti("journeymenPurchasedAch", journeymenPurchased, new object[] { 1, 3, 5, 10, 25, 50, 75, 90, 95, 100 }).register();
		public static readonly StatAchievement guildmastersElectedAch = new AchievementMulti("guildmastersElectedAch", guildmastersElected, new object[] { 1, 2, 4, 8, 16, 32, 64, 128, 256, 512 }).register().setSecret();
		#endregion
		//unlocked all quests
		//built all buildings - have ever built x
		//hired vendors
		//cash magnitude
		//craft all enchantments - have ever crafted x
		//relic notoriety
		//relic antiquity
		//find/identify a relic
		//resource value given to quests
		//days played


		public static void register(IStat stat) {
			stat.ID = allStatistics.Count;
			allStatistics.Add(stat);
		}

		public static void register(StatAchievement stat) {
			stat.ID = allAchievements.Count;
			allAchievements.Add(stat);
		}

		public static void newLevelReset() {
			foreach(IStat stat in allStatistics) {
				if(stat.shouldResetOnNewLevel) {
					stat.resetValue();
				}
			}
		}

		public static void newGuildmasterReset() {
			foreach(IStat stat in allStatistics) {
				if(stat.shouldResetOnNewGuildmaster) {
					stat.resetValue();
				}
			}
		}

		public static void serializeAllStats(ref SerializationInfo info, ref StreamingContext context) {
			foreach(IStat s in allStatistics) {
				info.AddValue(s.statName, s.serializedValue);
				if(s is StatHighscore) {
					info.AddValue(s.statName + "_best", ((StatHighscore)s).value);
				}
			}
			foreach(StatAchievement s in allAchievements) {
				info.AddValue(s.achieveName, s.isAchieved());
			}
		}

		public static void deserializeAllStats(ref SerializationInfo info, ref StreamingContext context) {
			SerializationInfoEnumerator infoEnum = info.GetEnumerator();
			Hashtable values = new Hashtable();
			while(infoEnum.MoveNext()) {
				SerializationEntry val = infoEnum.Current;
				values.Add(val.Name, val.Value);
			}
			foreach(IStat s in allStatistics) {
				if(values.Contains(s.statName)) {
					s.setValue(values[s.statName]);
				}
				if(s is StatHighscore && values.Contains(s.statName + "_best")) {
					((StatHighscore)s).setBestValue((int)values[s.statName + "_best"]);
					//info.AddValue(s.statName + "_best", s.serializedValue);
				}
				//s.setValue(info.GetInt32(s.statName));
			}
			foreach(StatAchievement s in allAchievements) {
				if(values.Contains(s.achieveName)) {
					if((bool)values[s.achieveName]) s.setAchieved();
				}
				/*if(info.GetBoolean(s.achieveName)) {
					s.setAchieved();
				}*/
			}
		}

		public static IEnumerator<StatAchievement> getAchievementsList() {
			return allAchievements.GetEnumerator();
		}

		public static IEnumerator<IStat> getStatsList() {
			return allStatistics.GetEnumerator();
		}

		public static void HardReset() {
			foreach(IStat stat in allStatistics) {
				stat.resetValue();
				if(stat is StatHighscore) {
					((StatHighscore)stat).setBestValue(0);
				}
			}
			foreach(StatAchievement s in allAchievements) {
				s.setUnachieved();
			}
		}
	}
}
