﻿using Assets.draco18s.artificer.game;
using Assets.draco18s.util;
using Koopakiller.Numerics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.draco18s.artificer.upgrades {
	class UpgradeCashValue : Upgrade {
		protected readonly float amount;
		public UpgradeCashValue(BigInteger upgradeCost, float amount, string saveName) : base(UpgradeType.QUEST_GOODS_VALUE, upgradeCost, "Quest Item Value +" + (amount * 100) + "%", saveName) {
			this.amount = amount;
		}

		public override void applyUpgrade() {
			base.applyUpgrade();
			UpgradeValueWrapper wrap;
			Main.instance.player.upgrades.TryGetValue(upgradeType, out wrap);
			((UpgradeFloatValue)wrap).value += amount;
		}
		public override void revokeUpgrade() {
			base.revokeUpgrade();
			UpgradeValueWrapper wrap;
			Main.instance.player.upgrades.TryGetValue(upgradeType, out wrap);
			((UpgradeFloatValue)wrap).value -= amount;
		}

		public override string getTooltip() {
			UpgradeValueWrapper wrap;
			Main.instance.player.upgrades.TryGetValue(upgradeType, out wrap);
			return "Increases the amount of cash gained from items given to quests by " + (amount * 100) + "%.\nThe base value is 0%, currently it is " + (((UpgradeFloatValue)wrap).value * 100) + "%, and with this upgrade it would be " + ((((UpgradeFloatValue)wrap).value + amount) * 100) + "%.\nDoes not apply to enchanted items, relics, or ingredients.";
			//return "Increases the amount of cash gained from items given to quests by " + (amount * 100) + "%, the base value is 0%, and with this upgrade it would be " + ((((UpgradeFloatValue)wrap).value + amount) * 100) + "%";
		}

		public override string getIconName() {
			return "upgrades/cash_value";
		}
	}
}
