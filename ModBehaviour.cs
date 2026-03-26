using Duckov.UI;
using Duckov.Utilities;
using FastModdingLib;
using ItemStatsSystem;
using System;
using System.Reflection;
using TMPro;
using Unity.VisualScripting;
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

            ShopGoodsData data1 = new ShopGoodsData
            {
                merchantProfileID = "Merchant_Weapon",
                typeID = 31010,
                maxStock = 1,
                forceUnlock = true,
                priceFactor = 1F,
                possibility = 1F
            };

            ShopUtils.AddGoods(data1);

            ShopGoodsData data2 = new ShopGoodsData
            {
                merchantProfileID = "Merchant_Weapon",
                typeID = 31011,
                maxStock = 1,
                forceUnlock = true,
                priceFactor = 1F,
                possibility = 1F
            };

            ShopUtils.AddGoods(data2);

            ShopGoodsData data3 = new ShopGoodsData
            {
                merchantProfileID = "Merchant_Weapon",
                typeID = 31012,
                maxStock = 1,
                forceUnlock = true,
                priceFactor = 1F,
                possibility = 1F
            };

            ShopUtils.AddGoods(data3);

            ShopGoodsData data4 = new ShopGoodsData
            {
                merchantProfileID = "Merchant_Weapon",
                typeID = 31013,
                maxStock = 1,
                forceUnlock = true,
                priceFactor = 1F,
                possibility = 1F
            };

            ShopUtils.AddGoods(data4);
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

                Item stock = ItemUtils.GetCustomItem(dllPath, Items.STOCK_TEST, modid);
                ItemUtils.SetItemGraphic(stock, Bundle, "IG_STOCK_TEST");
                ItemUtils.RegisterItem(stock, modid);

                Item sight = ItemUtils.GetCustomItem(dllPath, Items.SIGHT_TEST, modid);
                ItemUtils.SetItemGraphic(sight, Bundle, "IG_SIGHT_TEST");

                ItemSetting_Accessory itemSetting_Accessory = sight.AddComponent<ItemSetting_Accessory>();
                itemSetting_Accessory.overrideAdsAimMarker = ItemAssetsCollection.GetPrefab(571).GetComponent<ItemSetting_Accessory>().overrideAdsAimMarker;
                ItemUtils.RegisterItem(sight, modid);

                Item muzzle = ItemUtils.GetCustomItem(dllPath, Items.MUZZLE_TEST, modid);
                ItemUtils.SetItemGraphic(muzzle, Bundle, "IG_MUZZLE_TEST");
                ItemUtils.RegisterItem(muzzle, modid);

                Item grip = ItemUtils.GetCustomItem(dllPath, Items.GRIP_TEST, modid);
                ItemUtils.SetItemGraphic(grip, Bundle, "IG_GRIP_TEST");
                ItemUtils.RegisterItem(grip, modid);
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