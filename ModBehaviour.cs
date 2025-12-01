using Duckov.UI;
using Duckov.Utilities;
using FastModdingLib;
using ItemStatsSystem;
using System;
using System.Reflection;
using TMPro;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;
using UnityEngine.UI;

namespace DuckovWeaponExample
{
    public class ModBehaviour : Duckov.Modding.ModBehaviour
    {

        string dllPath = Assembly.GetExecutingAssembly().Location;
        string modid = "DuckovWeaponExample";
        void Awake()
        {
            Debug.Log($"DuckovWeaponExample awaked. Presented by Zaia");

            I18n.InitI18n(dllPath);
        }
        protected override void OnBeforeDeactivate()
        {

        }

        protected override void OnAfterSetup()
        {
            //AssetUtil.Start();
            RegisterItems();
            RegisterQuests();

            I18n.loadFileJson(dllPath, $"/{I18n.localizedNames[SodaCraft.Localizations.LocalizationManager.CurrentLanguage]}");
            AddFormulas();
            AddShopItems();
        }

        private static void AddShopItems()
        {
            ShopGoodsData data = new ShopGoodsData
            {
                merchantProfileID = "Merchant_Weapon",
                typeID = 31001,
                maxStock = 1,
                forceUnlock = false,
                priceFactor = 1F,
                possibility = 1F
            };

            ShopUtils.AddGoods(data);
        }

        private static void RegisterQuests()
        {
            QuestUtils.RegisterQuest(Quests.EXAMPLE_QUEST_1);
            QuestUtils.RegisterQuest(Quests.EXAMPLE_QUEST_2);
            QuestUtils.AddQuestRelation(31001, before: 23, after: 31002);
            QuestUtils.AddQuestRelation(31002, before: 31001);
        }

        private void RegisterItems()
        {
            var Bundle = AssetUtil.LoadBundle(dllPath, "examplebundle");
            if (Bundle != null)
            {
                ItemUtils.RegisterGun(Bundle, "LMRItem", 654, modid);
            }
            ItemUtils.CreateCustomBluePrint(Quests.BLUEPRINT_EXAMPLE);
        }

        private void AddFormulas()
        {
            CraftingUtils.AddCraftingFormula("lmr_crafting_example", 0L, new (int, long)[]
            {
                (367, 5L)
            }, 31001, 1, new string[1] { "WorkBenchAdvanced" }, "", false, false, false, modid

            );
            CraftingUtils.AddDecomposeFormula(31001, 0L, new (int, long)[]
            {
                (367, 1L)
            });
        }

        void OnDestroy()
        {
        }
        void OnEnable()
        {
        }
        void OnDisable()
        {
        }
    }
}