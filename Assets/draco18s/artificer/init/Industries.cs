﻿using UnityEngine;
using System.Collections;
using Assets.draco18s.artificer.items;
using Assets.draco18s.artificer.quests.requirement;
using Assets.draco18s.util;
using Koopakiller.Numerics;
using System;

namespace Assets.draco18s.artificer.init {
	public class Industries {
		public static readonly Industry WOOD =				new Industry("wood",									  10, 1, 1, Scalar._0_RAW).addReqType(RequirementType.WOOD).setMaxStackSize(10).setStackSizeForQuest(7).setConsumable(true);//wood
		public static readonly Industry CHARCOAL =			new Industry("charcoal",								  50, 5, 1, Scalar._1_REFINED, new IndustryInput(WOOD, 2)).setDisallowedForQuests().setMaxStackSize(5);//charcoal
		public static readonly Industry TORCHES =			new Industry("torches",								     250, 5, 4, Scalar._2_SIMPLE, new IndustryInput(WOOD, 1), new IndustryInput(CHARCOAL, 1)).addReqType(RequirementType.LIGHT).setConsumable(true).setMaxStackSize(5).setStackSizeForQuest(2);//torches
		public static readonly Industry RED_BERRIES =		new Industry("red_berries",								1250, 2, 10, Scalar._0_RAW).addAidType(AidType.HEALING_TINY).addReqType(RequirementType.HERB).setConsumable(true).setMaxStackSize(10).setVendorSizeMulti(5).setStackSizeForQuest(5);//red berries
		public static readonly Industry BLUE_BERRIES =		new Industry("blue_berries",							1250, 2, 10, Scalar._0_RAW).addAidType(AidType.MANA_TINY).addReqType(RequirementType.HERB).setConsumable(true).setMaxStackSize(10).setVendorSizeMulti(5).setStackSizeForQuest(5);//blue berries
		public static readonly Industry LEATHER =			new Industry("leather",									6000, 16, 3, Scalar._0_RAW).addAidType(AidType.LIGHT_ARMOR).setConsumable(true).addReqType(RequirementType.LEATHER).setMaxStackSize(5).setStackSizeForQuest(5);//leather
		public static readonly Industry LEATHER_BOOTS =		new Industry("leather_boots",						   12000, 100, 1, Scalar._2_SIMPLE, new IndustryInput(LEATHER, 3)).addAidType(AidType.LIGHT_ARMOR).setMaxStackSize(1).setIsViableRelic(true).setEquipType(ItemEquipType.BOOTS).setStackSizeForQuest(1).setEffectiveness(0.2f);//leather boots
		public static readonly Industry ARMOR_LEATHER =		new Industry("leather_armor",						   25000, 400, 1, Scalar._2_SIMPLE, new IndustryInput(LEATHER, 12)).addAidType(AidType.LIGHT_ARMOR).setMaxStackSize(1).setIsViableRelic(true).setEquipType(ItemEquipType.ARMOR).setStackSizeForQuest(1);//leather armor
		public static readonly Industry SIMPLE_TOOLS =		new Industry("simple_tools",						   50000, 300, 2, Scalar._1_REFINED, new IndustryInput(WOOD, 1)).addReqType(RequirementType.TOOLS).setConsumable(true).setMaxStackSize(10).setStackSizeForQuest(3);//simple tools
		public static readonly Industry QUARTERSTAFF =		new Industry("quarterstaff",						  100000, 800, 1, Scalar._1_REFINED, new IndustryInput(WOOD, 2)).addAidType(AidType.WEAPON).setConsumable(true).setMaxStackSize(10).setStackSizeForQuest(3).setEffectiveness(0.75f);//quarterstaff
		public static readonly Industry LIGHT_CROSSBOW =	new Industry("light_crossbow",						  200000, 1600, 1, Scalar._1_REFINED, new IndustryInput(WOOD, 2), new IndustryInput(LEATHER, 1)).addAidType(AidType.RANGED_WEAPON).setConsumable(true).setMaxStackSize(20).setStackSizeForQuest(3).setEffectiveness(0.75f);//light crossbow
		public static readonly Industry GLASS =				new Industry("glass",								  400000, 3200, 1, Scalar._0_RAW).setMaxStackSize(1).setDisallowedForQuests();//glass
		public static readonly Industry GLASS_PHIAL =		new Industry("glass_phial",							 1600000, 1200, 5, Scalar._1_REFINED, new IndustryInput(GLASS, 1)).setDisallowedForQuests().setMaxStackSize(4);//glass phial
		public static readonly Industry NIGHTSHADE =		new Industry("nightshade",							 6400000, 1500, 5, Scalar._0_RAW).addReqType(RequirementType.POISON_DAMAGE).addReqType(RequirementType.HERB).setConsumable(true).setMaxStackSize(10).setVendorSizeMulti(5).setStackSizeForQuest(5);
		public static readonly Industry POT_SM_HEALTH =		new Industry("health_potion",						12500000, 15000, 1, Scalar._2_SIMPLE, new IndustryInput(GLASS_PHIAL, 1), new IndustryInput(RED_BERRIES, 3)).addAidType(AidType.HEALING_SMALL).setConsumable(true).setMaxStackSize(10).setStackSizeForQuest(5).setEffectiveness(3f);
		public static readonly Industry POT_SM_MANA =		new Industry("mana_potion",							12500000, 15000, 1, Scalar._2_SIMPLE, new IndustryInput(GLASS_PHIAL, 1), new IndustryInput(BLUE_BERRIES, 3)).addAidType(AidType.MANA_SMALL).setConsumable(true).setMaxStackSize(10).setStackSizeForQuest(5).setEffectiveness(3f);
		public static readonly Industry POT_POISON =		new Industry("poison_potion",						12500000, 15000, 1, Scalar._1_REFINED, new IndustryInput(GLASS_PHIAL, 1), new IndustryInput(NIGHTSHADE, 2)).addReqType(RequirementType.POISON_DAMAGE).setConsumable(true).setMaxStackSize(5).setStackSizeForQuest(5).setEffectiveness(5f);
		public static readonly Industry WOOD_BUCKLER =		new Industry("wooden_buckler",					    25000000, 30000, 1, Scalar._1_REFINED, new IndustryInput(WOOD, 4)).addAidType(AidType.LIGHT_SHIELD).setEquipType(ItemEquipType.SHIELD).setMaxStackSize(1).setIsViableRelic(true).setStackSizeForQuest(1).setEffectiveness(0.75f);
		public static readonly Industry GLASS_BOTTLES =		new Industry("glass_bottles",					    50000000, 12000, 5, Scalar._1_REFINED, new IndustryInput(GLASS, 2), new IndustryInput(CHARCOAL, 1)).setDisallowedForQuests().setMaxStackSize(4);
		public static readonly Industry LIGHT_CLOAK =		new Industry("light_cloak",							75000000, 100000, 1, Scalar._1_REFINED, new IndustryInput(LEATHER, 2)).setMaxStackSize(5).setConsumable(true).addReqType(RequirementType.STEALTH).setStackSizeForQuest(1);
		public static readonly Industry MANDRAKE =			new Industry("mandrake_root",					   225000000, 40000, 5, Scalar._0_RAW).addReqType(RequirementType.HERB).setConsumable(true).setMaxStackSize(15).setVendorSizeMulti(2).setStackSizeForQuest(1);
		public static readonly Industry BLOOD_MOSS =		new Industry("blood_moss",						   225000000, 40000, 5, Scalar._0_RAW).addReqType(RequirementType.HERB).setConsumable(true).setMaxStackSize(15).setVendorSizeMulti(2).setStackSizeForQuest(1);
		public static readonly Industry BANROOT =			new Industry("banroot",							   225000000, 40000, 5, Scalar._0_RAW).addReqType(RequirementType.HERB).setConsumable(true).setMaxStackSize(15).setVendorSizeMulti(2).setStackSizeForQuest(1);
		public static readonly Industry MUSHROOMS =			new Industry("mushrooms",						   225000000, 40000, 5, Scalar._0_RAW).addReqType(RequirementType.HERB).setConsumable(true).setMaxStackSize(15).setVendorSizeMulti(2).setStackSizeForQuest(1);
		public static readonly Industry POT_MED_HEALTH =	new Industry("medium_health_potion",			   750000000, 400000, 1, Scalar._3_COMPLEX, new IndustryInput(POT_SM_HEALTH, 3)).addAidType(AidType.HEALING_MEDIUM).setConsumable(true).setMaxStackSize(10).setStackSizeForQuest(5).setEffectiveness(5f);
		public static readonly Industry POT_MED_MANA =		new Industry("medium_mana_potion",				   750000000, 400000, 1, Scalar._3_COMPLEX, new IndustryInput(POT_SM_MANA, 3)).addAidType(AidType.MANA_MEDIUM).setConsumable(true).setMaxStackSize(10).setStackSizeForQuest(5).setEffectiveness(5f);
		public static readonly Industry POT_STRENGTH =		new Industry("strength_potion",					   750000000, 400000, 1, Scalar._1_REFINED, new IndustryInput(GLASS_BOTTLES, 1), new IndustryInput(MANDRAKE, 3)).addReqType(RequirementType.STRENGTH).setConsumable(true).setMaxStackSize(5).setStackSizeForQuest(2).setEffectiveness(2.5f);
		public static readonly Industry POT_AGILITY =		new Industry("agility_potion",					   750000000, 400000, 1, Scalar._1_REFINED, new IndustryInput(GLASS_BOTTLES, 1), new IndustryInput(BLOOD_MOSS, 3)).addReqType(RequirementType.AGILITY).setConsumable(true).setMaxStackSize(5).setStackSizeForQuest(2).setEffectiveness(2.5f);
		public static readonly Industry POT_INTELLIGENCE =	new Industry("intelligence_potion",				   750000000, 400000, 1, Scalar._1_REFINED, new IndustryInput(GLASS_BOTTLES, 1), new IndustryInput(BANROOT, 3)).addReqType(RequirementType.INTELLIGENCE).setConsumable(true).setMaxStackSize(5).setStackSizeForQuest(2).setEffectiveness(2.5f);
		public static readonly Industry POT_CHARISMA =		new Industry("charisma_potion",					   750000000, 400000, 1, Scalar._1_REFINED, new IndustryInput(GLASS_BOTTLES, 1), new IndustryInput(MUSHROOMS, 3)).addReqType(RequirementType.CHARISMA).setConsumable(true).setMaxStackSize(5).setStackSizeForQuest(2).setEffectiveness(2.5f);
		public static readonly Industry POT_RESTORATION =	new Industry("restoration_potion",				   750000000, 400000, 2, Scalar._3_COMPLEX, new IndustryInput(POT_SM_HEALTH, 1), new IndustryInput(POT_SM_MANA, 1)).addAidType(AidType.HEALING_SMALL).addAidType(AidType.MANA_SMALL).setConsumable(true).setMaxStackSize(5).setStackSizeForQuest(1).setEffectiveness(6f);
		public static readonly Industry IRON_ORE =			new Industry("iron_ore",			 new BigInteger(2,10),    1200000, 1, Scalar._0_RAW).setDisallowedForQuests();
		public static readonly Industry IRON_INGOTS =		new Industry("iron_ingots",			 new BigInteger(1,11),    480000, 5, Scalar._1_REFINED, new IndustryInput(IRON_ORE, 1)).addReqType(RequirementType.IRON).setMaxStackSize(5).setConsumable(true).setStackSizeForQuest(2);
		public static readonly Industry IRON_SWORD =		new Industry("iron_sword",			 new BigInteger(15,10),   5000000, 1, Scalar._2_SIMPLE, new IndustryInput(IRON_INGOTS, 2)).addAidType(AidType.WEAPON).setEquipType(ItemEquipType.WEAPON).setIsViableRelic(true).setMaxStackSize(1).setStackSizeForQuest(2);
		public static readonly Industry LANTERN =			new Industry("lantern",				 new BigInteger(5,11),    5000000, 2, Scalar._2_SIMPLE, new IndustryInput(TORCHES, 2), new IndustryInput(GLASS, 1), new IndustryInput(IRON_INGOTS, 2)).addReqType(RequirementType.LIGHT).setIsViableRelic(true).setEquipType(ItemEquipType.MISC).setMaxStackSize(1).setStackSizeForQuest(1);
		public static readonly Industry IMPROVED_CLOAK =	new Industry("improved_cloak",		 new BigInteger(75,10),   10000000, 1, Scalar._2_SIMPLE, new IndustryInput(LIGHT_CLOAK, 2)).setIsViableRelic(true).addReqType(RequirementType.STEALTH).setEquipType(ItemEquipType.CLOAK).setStackSizeForQuest(1).setEffectiveness(0.5f);
		public static readonly Industry IRON_HELMET =		new Industry("iron_helm",			 new BigInteger(3, 12),   20000000, 1, Scalar._2_SIMPLE, new IndustryInput(IRON_INGOTS, 4)).addAidType(AidType.MEDIUM_ARMOR).setIsViableRelic(true).setEquipType(ItemEquipType.HELMET).setStackSizeForQuest(1).setEffectiveness(0.2f);
		public static readonly Industry METAL_TOOLS =		new Industry("metal_tools",			 new BigInteger(6, 12),   15000000, 2, Scalar._1_REFINED, new IndustryInput(IRON_INGOTS, 2)).addReqType(RequirementType.TOOLS).setEquipType(ItemEquipType.MISC).setMaxStackSize(10).setStackSizeForQuest(1).setEffectiveness(1.5f);// tools
		public static readonly Industry POT_WEAKNESS = 		new Industry("weakness_potion",		 new BigInteger(10, 12),  30000000, 1, Scalar._3_COMPLEX, new IndustryInput(POT_STRENGTH,1),new IndustryInput(POT_POISON,1)).addReqType(RequirementType.WEAKNESS).setConsumable(true).setMaxStackSize(5).setStackSizeForQuest(1).setEffectiveness(2.5f);
		public static readonly Industry POT_CLUMSINESS = 	new Industry("clumsiness_potion",	 new BigInteger(10, 12),  30000000, 1, Scalar._3_COMPLEX, new IndustryInput(POT_AGILITY, 1), new IndustryInput(POT_POISON, 1)).addReqType(RequirementType.CLUMSINESS).setConsumable(true).setMaxStackSize(5).setStackSizeForQuest(1).setEffectiveness(2.5f);
		public static readonly Industry POT_STUPIDITY= 		new Industry("stupidity_potion",	 new BigInteger(10, 12),  30000000, 1, Scalar._3_COMPLEX, new IndustryInput(POT_INTELLIGENCE, 1), new IndustryInput(POT_POISON, 1)).addReqType(RequirementType.STUPIDITY).setConsumable(true).setMaxStackSize(5).setStackSizeForQuest(1).setEffectiveness(2.5f);
		public static readonly Industry POT_UGLINESS = 		new Industry("ugliness_potion",		 new BigInteger(10, 12),  30000000, 1, Scalar._3_COMPLEX, new IndustryInput(POT_CHARISMA, 1), new IndustryInput(POT_POISON, 1)).addReqType(RequirementType.UGLINESS).setConsumable(true).setMaxStackSize(5).setStackSizeForQuest(1).setEffectiveness(2.5f);
		public static readonly Industry POT_MED_REST =		new Industry("medium_rest_potion",	 new BigInteger(10, 12),  30000000, 2, Scalar._3_COMPLEX, new IndustryInput(POT_MED_HEALTH, 1), new IndustryInput(POT_MED_MANA, 1)).addAidType(AidType.HEALING_MEDIUM).addAidType(AidType.MANA_MEDIUM).setConsumable(true).setMaxStackSize(5).setStackSizeForQuest(1).setEffectiveness(10f);
		public static readonly Industry IRON_RING = 		new Industry("iron_ring",			 new BigInteger(25, 12),  50000000, 2, Scalar._1_REFINED, new IndustryInput(IRON_INGOTS, 1)).setMaxStackSize(1).setEquipType(ItemEquipType.RING).setIsViableRelic(true).setStackSizeForQuest(1).setEffectiveness(0.75f);
		public static readonly Industry IRON_BOOTS =		new Industry("iron_boots",			 new BigInteger(75, 12),  100000000, 1, Scalar._2_SIMPLE, new IndustryInput(IRON_INGOTS, 4)).addAidType(AidType.MEDIUM_ARMOR).setIsViableRelic(true).setEquipType(ItemEquipType.BOOTS).setStackSizeForQuest(1).setEffectiveness(0.25f);
		public static readonly Industry HEAVY_CROSSBOW =	new Industry("heavy_crossbow",		 new BigInteger(1, 14),   200000000, 1, Scalar._3_COMPLEX, new IndustryInput(IRON_INGOTS, 3), new IndustryInput(Industries.LEATHER,2)).addAidType(AidType.RANGED_WEAPON).setIsViableRelic(true).setEquipType(ItemEquipType.RANGED).setStackSizeForQuest(1).setEffectiveness(2f);
		public static readonly Industry GOLD_ORE =			new Industry("gold_ore",			 new BigInteger(25,13),   400000000, 1, Scalar._0_RAW).setDisallowedForQuests();
		public static readonly Industry GOLD_DUST = 		new Industry("gold_dust",			 new BigInteger(5, 14),   400000000, 2, Scalar._1_REFINED, new IndustryInput(GOLD_ORE,1)).setDisallowedForQuests();
		public static readonly Industry GOLD_INGOTS =		new Industry("gold_ingots",			 new BigInteger(75, 13),  500000000, 2, Scalar._4_RARE, new IndustryInput(GOLD_DUST, 1)).setConsumable(true).setMaxStackSize(4).setEffectiveness(1).addReqType(RequirementType.GOLD).setStackSizeForQuest(4);
		public static readonly Industry HOLY_SYMBOL = 		new Industry("holy_symbol",			 new BigInteger(3, 15),   1000000000, 1, Scalar._1_REFINED, new IndustryInput(IRON_INGOTS,1),new IndustryInput(GOLD_INGOTS,1)).setConsumable(true).setMaxStackSize(3).addReqType(RequirementType.UNHOLY_IMMUNE).setStackSizeForQuest(5).setEffectiveness(0.75f);
		public static readonly Industry UNHOLY_SYMBOL = 	new Industry("unholy_symbol",		 new BigInteger(3, 15),   1000000000, 1, Scalar._1_REFINED, new IndustryInput(IRON_INGOTS,1),new IndustryInput(GOLD_INGOTS,1)).setConsumable(true).setMaxStackSize(3).addReqType(RequirementType.HOLY_IMMUNE).setStackSizeForQuest(5).setEffectiveness(0.75f);
		public static readonly Industry ARMOR_CHAIN =		new Industry("chainmail_armor",		 new BigInteger(75, 14),  2000000000, 1, Scalar._2_SIMPLE, new IndustryInput(IRON_RING, 16)).addAidType(AidType.MEDIUM_ARMOR).setMaxStackSize(1).setIsViableRelic(true).setEquipType(ItemEquipType.ARMOR).setStackSizeForQuest(1);
		public static readonly Industry IRON_SHIELD = 		new Industry("iron_shield",			 new BigInteger(225,14),  4000000000, 1, Scalar._2_SIMPLE, new IndustryInput(WOOD_BUCKLER, 1), new IndustryInput(IRON_INGOTS,3)).addAidType(AidType.LIGHT_SHIELD).setMaxStackSize(1).setIsViableRelic(true).setEquipType(ItemEquipType.SHIELD).setStackSizeForQuest(1).setEffectiveness(1.25f);
		public static readonly Industry FANCY_BOTTLES =		new Industry("fancy_bottles",		 new BigInteger(15,16),   1500000000, 5, Scalar._2_SIMPLE, new IndustryInput(GLASS, 4), new IndustryInput(CHARCOAL, 1), new IndustryInput(GOLD_INGOTS, 1)).setDisallowedForQuests().setMaxStackSize(4);
		public static readonly Industry HOLY_WATER =		new Industry("holy_water",			 new BigInteger(5,17),	  15000000000, 1, Scalar._3_COMPLEX, new IndustryInput(FANCY_BOTTLES, 1), new IndustryInput(HOLY_SYMBOL, 1)).setConsumable(true).setMaxStackSize(5).addReqType(RequirementType.HOLY_DAMAGE).setStackSizeForQuest(2);
		public static readonly Industry UNHOLY_WATER =		new Industry("unholy_water",		 new BigInteger(5,17),	  15000000000, 1, Scalar._3_COMPLEX, new IndustryInput(FANCY_BOTTLES, 1), new IndustryInput(UNHOLY_SYMBOL, 1)).setConsumable(true).setMaxStackSize(5).addReqType(RequirementType.UNHOLY_DAMAGE).setStackSizeForQuest(2);
		public static readonly Industry KELPWEED =			new Industry("kelpweed",			 new BigInteger(15,17),   6000000000, 5, Scalar._0_RAW).setDisallowedForQuests();
		public static readonly Industry STONEROOT =			new Industry("stoneroot",			 new BigInteger(15,17),   6000000000, 5, Scalar._0_RAW).setDisallowedForQuests();
		public static readonly Industry SAGE_GRASS =		new Industry("sage_grass",			 new BigInteger(15,17),   6000000000, 5, Scalar._0_RAW).setDisallowedForQuests();
		public static readonly Industry PHOENIX_FEATHERS =	new Industry("phoenix_feather",		 new BigInteger(15,17),   6000000000, 5, Scalar._0_RAW).setDisallowedForQuests();
		public static readonly Industry POT_WATER_BREATH =	new Industry("water_breath_potion",	 new BigInteger(5,18),	  120000000000, 1, Scalar._4_RARE, new IndustryInput(FANCY_BOTTLES, 1), new IndustryInput(KELPWEED, 1)).setConsumable(true).setMaxStackSize(5).addReqType(RequirementType.WATER_BREATH).setStackSizeForQuest(2).setEffectiveness(0.75f);
		public static readonly Industry POT_BARKSKIN =		new Industry("barkskin_potion",		 new BigInteger(5,18),	  120000000000, 1, Scalar._4_RARE, new IndustryInput(FANCY_BOTTLES, 1), new IndustryInput(STONEROOT, 1)).setConsumable(true).setMaxStackSize(5).addAidType(AidType.BARKSKIN).setStackSizeForQuest(2);
		public static readonly Industry POT_ALERTNESS =		new Industry("alertness_potion",	 new BigInteger(5,18),	  120000000000, 1, Scalar._4_RARE, new IndustryInput(FANCY_BOTTLES, 1), new IndustryInput(SAGE_GRASS, 1)).setConsumable(true).setMaxStackSize(5).addReqType(RequirementType.DETECTION).setStackSizeForQuest(2);
		public static readonly Industry POT_REVIVE =		new Industry("revive_potion",		 new BigInteger(5,18),	  120000000000, 1, Scalar._4_RARE, new IndustryInput(FANCY_BOTTLES, 1), new IndustryInput(PHOENIX_FEATHERS, 1), new IndustryInput(POT_RESTORATION, 1)).setConsumable(true).setMaxStackSize(1).addAidType(AidType.RESSURECTION).setStackSizeForQuest(1);
		public static readonly Industry POT_LG_HEALTH =		new Industry("large_health_potion",  new BigInteger(1,19),    250000000000, 1, Scalar._4_RARE, new IndustryInput(POT_MED_HEALTH, 3)).addAidType(AidType.HEALING_LARGE).setConsumable(true).setMaxStackSize(10).setStackSizeForQuest(5).setEffectiveness(8f);
		public static readonly Industry POT_LG_MANA =		new Industry("large_mana_potion",	 new BigInteger(1,19),    250000000000, 1, Scalar._4_RARE, new IndustryInput(POT_MED_MANA, 3)).addAidType(AidType.MANA_LARGE).setConsumable(true).setMaxStackSize(10).setStackSizeForQuest(5).setEffectiveness(8f);
		public static readonly Industry HEAVY_SHIELD = 		new Industry("heavy_shield",		 new BigInteger(5,19),    500000000000, 1, Scalar._2_SIMPLE, new IndustryInput(IRON_SHIELD, 2), new IndustryInput(GOLD_INGOTS,1)).addAidType(AidType.HEAVY_SHIELD).setMaxStackSize(1).setIsViableRelic(true).setEquipType(ItemEquipType.SHIELD).setStackSizeForQuest(1).setEffectiveness(3f);
		public static readonly Industry GOLD_RING = 		new Industry("gold_ring",			 new BigInteger(1,20),    500000000000, 2, Scalar._4_RARE, new IndustryInput(GOLD_INGOTS, 1)).setMaxStackSize(1).setEquipType(ItemEquipType.RING).addReqType(RequirementType.GOLD).setIsViableRelic(true).setStackSizeForQuest(1);
		public static readonly Industry FANCY_CLOAK =		new Industry("fancy_cloak",			 new BigInteger(5,20),    2000000000000, 1, Scalar._3_COMPLEX, new IndustryInput(IMPROVED_CLOAK, 1), new IndustryInput(GOLD_DUST, 4)).setIsViableRelic(true).addReqType(RequirementType.STEALTH).setEquipType(ItemEquipType.CLOAK).setStackSizeForQuest(1).setEffectiveness(0.8f);
		public static readonly Industry GOLD_CROWN = 		new Industry("gold_crown",			 new BigInteger(1,21),	  4000000000000, 1, Scalar._4_RARE, new IndustryInput(GOLD_INGOTS, 4), new IndustryInput(IRON_HELMET, 1)).setMaxStackSize(1).setEquipType(ItemEquipType.HELMET).addAidType(AidType.MEDIUM_ARMOR).addReqType(RequirementType.GOLD).setIsViableRelic(true).setStackSizeForQuest(1).setEffectiveness(0.75f);
		public static readonly Industry POT_LG_REST =		new Industry("large_rest_potion",	 new BigInteger(5,21),	  250000000000, 2, Scalar._4_RARE, new IndustryInput(POT_LG_HEALTH, 1), new IndustryInput(POT_LG_MANA, 1)).addAidType(AidType.HEALING_LARGE).addAidType(AidType.MANA_LARGE).setConsumable(true).setMaxStackSize(5).setStackSizeForQuest(1).setEffectiveness(16f);
		
		public static class IndustryTypes {
			public static readonly Industry[] TYPE_WOOD = { WOOD, CHARCOAL, TORCHES, SIMPLE_TOOLS, QUARTERSTAFF, LIGHT_CROSSBOW, WOOD_BUCKLER };//7
			public static readonly Industry[] TYPE_ANIMAL = { LEATHER, LEATHER_BOOTS, ARMOR_LEATHER, LIGHT_CROSSBOW, LIGHT_CLOAK, IMPROVED_CLOAK, PHOENIX_FEATHERS, FANCY_CLOAK };//8
			public static readonly Industry[] TYPE_PLANT = { RED_BERRIES, BLUE_BERRIES, NIGHTSHADE, MANDRAKE, BLOOD_MOSS, BANROOT, MUSHROOMS, KELPWEED, STONEROOT, SAGE_GRASS };//10
			public static readonly Industry[] TYPE_POTION1 = { POT_SM_HEALTH, POT_SM_MANA, POT_POISON, POT_STRENGTH, POT_AGILITY, POT_INTELLIGENCE, POT_CHARISMA, POT_RESTORATION };//8
			public static readonly Industry[] TYPE_POTION2 = { POT_WEAKNESS, POT_CLUMSINESS, POT_STUPIDITY, POT_UGLINESS, POT_WATER_BREATH, POT_BARKSKIN, POT_ALERTNESS, POT_REVIVE, POT_MED_HEALTH, POT_MED_MANA };//10
			public static readonly Industry[] TYPE_POTION3 = { POT_LG_HEALTH, POT_LG_MANA, POT_MED_REST, POT_LG_REST };//4
			public static readonly Industry[] TYPE_GLASS = { GLASS, GLASS_PHIAL, GLASS_BOTTLES, LANTERN, FANCY_BOTTLES, HOLY_WATER, UNHOLY_WATER };//7
			public static readonly Industry[] TYPE_IRON = { IRON_ORE, IRON_INGOTS, IRON_SWORD, LANTERN, IRON_HELMET, IRON_RING, IRON_BOOTS, ARMOR_CHAIN, IRON_SHIELD, METAL_TOOLS, HEAVY_CROSSBOW };//11
			public static readonly Industry[] TYPE_GOLD = { GOLD_ORE, GOLD_DUST, GOLD_INGOTS, HOLY_SYMBOL, UNHOLY_SYMBOL, FANCY_BOTTLES, GOLD_RING, GOLD_CROWN, HEAVY_SHIELD };//9

			internal static IndustryTypesEnum getTypeOf(Industry item) {
				if(Array.IndexOf(TYPE_WOOD, item) >= 0) return IndustryTypesEnum.WOOD;
				if(Array.IndexOf(TYPE_ANIMAL, item) >= 0) return IndustryTypesEnum.ANIMAL;
				if(Array.IndexOf(TYPE_PLANT, item) >= 0) return IndustryTypesEnum.PLANT;
				if(Array.IndexOf(TYPE_POTION1, item) >= 0) return IndustryTypesEnum.SIMPLE_POTIONS;
				if(Array.IndexOf(TYPE_POTION2, item) >= 0) return IndustryTypesEnum.COMPLEX_POTIONS;
				if(Array.IndexOf(TYPE_POTION3, item) >= 0) return IndustryTypesEnum.RARE_POTIONS;
				if(Array.IndexOf(TYPE_GLASS, item) >= 0) return IndustryTypesEnum.GLASS;
				if(Array.IndexOf(TYPE_IRON, item) >= 0) return IndustryTypesEnum.IRON;
				if(Array.IndexOf(TYPE_GOLD, item) >= 0) return IndustryTypesEnum.GOLD;
				Debug.Log(item.unlocalizedName + " does not have an industry type!");
				return IndustryTypesEnum.NONE;
			}
		}

		public enum IndustryTypesEnum {
			NONE,
			WOOD,
			ANIMAL,
			PLANT,
			SIMPLE_POTIONS,
			COMPLEX_POTIONS,
			GLASS,
			IRON,
			GOLD,
			RARE_POTIONS
		}
	}
}