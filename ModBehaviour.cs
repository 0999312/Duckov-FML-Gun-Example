
using FastModdingLib;
using FastModdingLib.Audio;
using FastModdingLib.Utils;
using ItemStatsSystem;
using System;
using System.Reflection;
using Unity.VisualScripting;

namespace DuckovWeaponExample
{
    public class ModBehaviour : Duckov.Modding.ModBehaviour, IHasModid
    {
        readonly string dllPath = Assembly.GetExecutingAssembly().Location;
        readonly string modid = "DuckovWeaponExample";
        public string GetModid() => modid;
        protected override void OnAfterSetup()
        {
            ModPathResolver.Register(modid, dllPath);
            
            I18n.InitI18n(modid);
            RegisterAudios();
            RegisterItems();
            RegisterQuests();
            AddFormulas();
            AddShopItems();
        }
        private void RegisterAudios()
        {
            AudioUtil.Instance.RegisterAudio(new Identifier(modid,"mk23_shoot"), AudioDatas.mk23_shoot);
            AudioUtil.Instance.RegisterAudio(new Identifier(modid, "mk23_shoot_mute"), AudioDatas.mk23_shoot_mute);
            AudioUtil.Instance.RegisterAudio(new Identifier(modid, "mk23_reload"), AudioDatas.mk23_reload);
            AudioUtil.Instance.RegisterAudio(new Identifier(modid, "mk23_reload_end"), AudioDatas.mk23_reload_end);
        }
        private void AddShopItems()
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

            ShopUtils.AddGoods(data, modid);

            ShopGoodsData data1 = new ShopGoodsData
            {
                merchantProfileID = "Merchant_Weapon",
                typeID = 31010,
                maxStock = 1,
                forceUnlock = true,
                priceFactor = 1F,
                possibility = 1F
            };

            ShopUtils.AddGoods(data1, modid);

            ShopGoodsData data2 = new ShopGoodsData
            {
                merchantProfileID = "Merchant_Weapon",
                typeID = 31011,
                maxStock = 1,
                forceUnlock = true,
                priceFactor = 1F,
                possibility = 1F
            };

            ShopUtils.AddGoods(data2, modid);

            ShopGoodsData data3 = new ShopGoodsData
            {
                merchantProfileID = "Merchant_Weapon",
                typeID = 31012,
                maxStock = 1,
                forceUnlock = true,
                priceFactor = 1F,
                possibility = 1F
            };

            ShopUtils.AddGoods(data3, modid);

            ShopGoodsData data4 = new ShopGoodsData
            {
                merchantProfileID = "Merchant_Weapon",
                typeID = 31013,
                maxStock = 1,
                forceUnlock = true,
                priceFactor = 1F,
                possibility = 1F
            };

            ShopUtils.AddGoods(data4, modid);

            ShopGoodsData data5 = new ShopGoodsData
            {
                merchantProfileID = "Merchant_Weapon",
                typeID = 31003,
                maxStock = 1,
                forceUnlock = true,
                priceFactor = 1F,
                possibility = 1F
            };

            ShopUtils.AddGoods(data5, modid);
        }

        private void RegisterQuests()
        {
            QuestUtils.RegisterQuest(Quests.EXAMPLE_QUEST_1, modid);
            QuestUtils.RegisterQuest(Quests.EXAMPLE_QUEST_2, modid);
            QuestUtils.AddQuestRelation(31001, before: 23, after: 31002);
            QuestUtils.AddQuestRelation(31002, before: 31001);
        }

        private void RegisterItems()
        {
            var Bundle = AssetUtil.LoadBundle(new Identifier(modid, "examplebundle"));
            if (Bundle != null)
            {
                ItemUtils.RegisterGun(new Identifier(modid, "lmr_item"), Bundle, "LMRItem", 654);
                ItemUtils.RegisterGun(new Identifier(modid, "mk23_item"), Bundle, "MK23Item", 783);

                Item stock = ItemUtils.GetCustomItem(new Identifier(modid, "stock_test"), Items.STOCK_TEST);
                ItemUtils.SetItemGraphic(stock, Bundle, "IG_STOCK_TEST");
                ItemUtils.RegisterItem(new Identifier(modid, "stock_test"), stock);

                Item sight = ItemUtils.GetCustomItem(new Identifier(modid, "sight_test"), Items.SIGHT_TEST);
                ItemUtils.SetItemGraphic(sight, Bundle, "IG_SIGHT_TEST");

                ItemSetting_Accessory itemSetting_Accessory = sight.AddComponent<ItemSetting_Accessory>();
                itemSetting_Accessory.overrideAdsAimMarker = ItemAssetsCollection.GetPrefab(571).GetComponent<ItemSetting_Accessory>().overrideAdsAimMarker;
                ItemUtils.RegisterItem(new Identifier(modid, "sight_test"), sight);

                Item muzzle = ItemUtils.GetCustomItem(new Identifier(modid, "muzzle_test"), Items.MUZZLE_TEST);
                ItemUtils.SetItemGraphic(muzzle, Bundle, "IG_MUZZLE_TEST");
                ItemUtils.RegisterItem(new Identifier(modid, "muzzle_test"), muzzle);

                Item grip = ItemUtils.GetCustomItem(new Identifier(modid, "grip_test"), Items.GRIP_TEST);
                ItemUtils.SetItemGraphic(grip, Bundle, "IG_GRIP_TEST");
                ItemUtils.RegisterItem(new Identifier(modid, "grip_test"), grip);
            }

            ItemUtils.CreateCustomBluePrint(new Identifier(modid, "lmr_blueprint"), Quests.BLUEPRINT_EXAMPLE);
        }

        private void AddFormulas()
        {
            CraftingUtils.AddCraftingFormula(new CraftingFormulaData {
                Id = new Identifier(modid, "lmr_crafting_example"), 
                Money = 0L,
                CostItems = new[]
                {
                ItemEntry.Of(367, 5)
                },
                Result = ItemEntry.Of(new Identifier(modid, "lmr_item"), 1),
                Tags = new string[] { "WorkBenchAdvanced" },
                RequirePerk = "",
                UnlockByDefault = false,
                HideInIndex = false,
                LockInDemo = false
            }
                
            );

            CraftingUtils.AddDecomposeFormula(new DecomposeFormulaData 
            {
                Id = new Identifier(modid, "scrap_old_gun"),
                SourceItemId = new Identifier(modid, "lmr_item"),  // 被分解物品
                Money = 50,
                ResultItems = new[] {
                    ItemEntry.Of(367, 1)
                }
            }
            );
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
