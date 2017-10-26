﻿using Assets.draco18s.artificer.game;
using Koopakiller.Numerics;
using System;
using System.Xml;
using System.Xml.Linq;
using UnityEngine;

namespace Assets.draco18s.artificer.statistics {
	public class StatBint : IStat {
		private string _statName;
		private string _description;
		public string statName {
			get { return _statName; }
			set { _statName = value; }
		}
		public string description {
			get { return _description; }
			set { _description = value; }
		}
		public readonly bool shouldResetOnNewLevel;
		protected bool shouldReadAsFloat = false;
		private int dispOrd = -1;
		public int displayOrder {
			get { return dispOrd; }
			set { }
		}
		public virtual BigInteger value {
			get {
				return statValue;
			}
			set {

			}
		}

		public object serializedValue {
			get {
				return value.ToString();
			}
		}
		public virtual BigRational floatValue {
			get {
				return ((BigRational)statValue) / 10000;
			}
			set {

			}
		}
		public int ID {
			get {
				return idVal;
			}
			set {
				if(idVal == -1) {
					idVal = value;
				}
			}
		}
		public bool isHidden { get; set; }

		public virtual string getDisplay() {
			return Main.AsCurrency(shouldReadAsFloat?value/1000:value,12);
			//return (shouldReadAsFloat ? floatValue.ToDecimalString(3) : value.ToString(10,true));
		}

		protected BigInteger statValue;
		protected int idVal = -1;

		public StatBint(string name) {
			statName = "stat." + name + ".name";
			description = "stat." + name + ".desc";
			statValue = 0;
			shouldResetOnNewLevel = false;
		}

		protected StatBint(string name, bool resets) : this(name) {
			shouldResetOnNewLevel = resets;
		}

		/// <summary>
		/// Updates the statistic, handles checking if the game is in Editor testing mode.
		/// </summary>
		/// <param name="v">Amount to add</param>
		public virtual void addValue(BigInteger v) {
			statValue += v;
		}

		public virtual void addValue(BigRational v) {
			shouldReadAsFloat = true;
			addValue(v * 10000);
		}

		public virtual void setValue(BigInteger v) {
			statValue = v;
		}

		public virtual void setValue(object v) {
			if(v is BigInteger)
				statValue = (BigInteger)v;
			if(v is BigRational)
				statValue = (BigInteger)v;
			if(v is int)
				statValue = (int)v;
			if(v is string)
				statValue = BigInteger.Parse((string)v);
		}

		public virtual void resetValue() {
			statValue = 0;
		}

		public StatBint register() {
			StatisticsTracker.register(this);
			return this;
		}

		public StatBint setHidden() {
			isHidden = true;
			return this;
		}

		public bool isGreaterThan(object v) {
			if(v is BigInteger)
				return value >= (BigInteger)v;
			if(v is BigRational || v is float)
				return value / 1000 >= (BigRational)v;
			if(v is int) {
				return value >= (int)v;
			}
			return false;
		}
	}
}