
using Cysharp.Threading.Tasks;
using FastModdingLib;
using FastModdingLib.Audio;
using FastModdingLib.Items;
using FastModdingLib.Utils;
using ItemStatsSystem;
using System.Reflection;
using Unity.VisualScripting;

namespace DuckovWeaponExample
{
    public class ModBehaviour : Duckov.Modding.ModBehaviour, IHasModid
    {
        private readonly string dllPath = Assembly.GetExecutingAssembly().Location;
        private readonly string modid = "DuckovWeaponExample";
        public string GetModid() => modid;
        protected override async void OnAfterSetup()
        {
            ModPathResolver.Register(modid, dllPath);

            I18n.InitI18n(modid);
            RegisterAudios();
            await RegisterItems();
            RegisterNPCWeapons();
            RegisterLotteryBoxItems();
            RegisterEndowments();
            RegisterQuests();
            AddFormulas();
            AddShopItems();
        }
        private void RegisterAudios()
        {
            AudioUtil.Instance.RegisterAudio(new Identifier(modid, "mk23_shoot"), AudioDatas.mk23_shoot);
            AudioUtil.Instance.RegisterAudio(new Identifier(modid, "mk23_shoot_mute"), AudioDatas.mk23_shoot_mute);
            AudioUtil.Instance.RegisterAudio(new Identifier(modid, "mk23_reload"), AudioDatas.mk23_reload);
            AudioUtil.Instance.RegisterAudio(new Identifier(modid, "mk23_reload_end"), AudioDatas.mk23_reload_end);
        }
        private void RegisterEndowments()
        {
            var agentConfig = Endowments.BuildAgentConfig();
            EndowmentUtils.RegisterEndowment(
                new Identifier(modid, "Agent"),
                agentConfig);
        }

        private void AddShopItems()
        {
            ShopGoodsData data = new ShopGoodsData
            {
                merchantProfileID = "Merchant_Weapon",
                itemIdentifier = new Identifier(modid, "lmr_item"),
                maxStock = 1,
                forceUnlock = false,
                priceFactor = 1F,
                possibility = 1F
            };

            ShopUtils.AddGoods(data, modid);

            ShopGoodsData data1 = new ShopGoodsData
            {
                merchantProfileID = "Merchant_Weapon",
                itemIdentifier = new Identifier(modid, "stock_test"),
                maxStock = 1,
                forceUnlock = true,
                priceFactor = 1F,
                possibility = 1F
            };

            ShopUtils.AddGoods(data1, modid);

            ShopGoodsData data2 = new ShopGoodsData
            {
                merchantProfileID = "Merchant_Weapon",
                itemIdentifier = new Identifier(modid, "grip_test"),
                maxStock = 1,
                forceUnlock = true,
                priceFactor = 1F,
                possibility = 1F
            };

            ShopUtils.AddGoods(data2, modid);

            ShopGoodsData data3 = new ShopGoodsData
            {
                merchantProfileID = "Merchant_Weapon",
                itemIdentifier = new Identifier(modid, "sight_test"),
                maxStock = 1,
                forceUnlock = true,
                priceFactor = 1F,
                possibility = 1F
            };

            ShopUtils.AddGoods(data3, modid);

            ShopGoodsData data4 = new ShopGoodsData
            {
                merchantProfileID = "Merchant_Weapon",
                itemIdentifier = new Identifier(modid, "muzzle_test"),
                maxStock = 1,
                forceUnlock = true,
                priceFactor = 1F,
                possibility = 1F
            };

            ShopUtils.AddGoods(data4, modid);

            ShopGoodsData data5 = new ShopGoodsData
            {
                merchantProfileID = "Merchant_Weapon",
                itemIdentifier = new Identifier(modid, "mk23_item"),
                maxStock = 1,
                forceUnlock = true,
                priceFactor = 1F,
                possibility = 1F
            };

            ShopUtils.AddGoods(data5, modid);

            ShopGoodsData data6 = new ShopGoodsData
            {
                merchantProfileID = "Merchant_MystIsland",
                itemIdentifier = new Identifier(modid, "mk23_item"),
                maxStock = 1,
                forceUnlock = true,
                priceFactor = 1F,
                possibility = 1F
            };

            ShopUtils.AddGoods(data6, modid);
        }

        private void RegisterQuests()
        {
            QuestUtils.RegisterQuest(Quests.Quest1Id, Quests.EXAMPLE_QUEST_1);
            QuestUtils.RegisterQuest(Quests.Quest2Id, Quests.EXAMPLE_QUEST_2);
            QuestUtils.RegisterQuest(Quests.AgentUnlockQuestId, Quests.AGENT_UNLOCK_QUEST);

            QuestUtils.AddQuestRelation(Quests.Quest1Id, before: new Identifier("duckov", "23"), after: Quests.Quest2Id);
            QuestUtils.AddQuestRelation(Quests.Quest2Id, before: Quests.Quest1Id);
            QuestUtils.AddQuestRelation(Quests.AgentUnlockQuestId, before: Quests.Quest1Id);
        }

        private async UniTask RegisterItems()
        {
            var Bundle = AssetUtil.LoadBundle(new Identifier(modid, "examplebundle"));
            if (Bundle != null)
            {
                ItemUtils.RegisterGun(new Identifier(modid, "lmr_item"), Bundle, "LMRItem", 654);
                ItemUtils.RegisterGun(new Identifier(modid, "mk23_item"), Bundle, "MK23Item", 783);

                var stock = await ItemUtils.GetCustomItemAsync(new Identifier(modid, "stock_test"), Items.STOCK_TEST);
                var sight = await ItemUtils.GetCustomItemAsync(new Identifier(modid, "sight_test"), Items.SIGHT_TEST);
                var muzzle = await ItemUtils.GetCustomItemAsync(new Identifier(modid, "muzzle_test"), Items.MUZZLE_TEST);
                var grip = await ItemUtils.GetCustomItemAsync(new Identifier(modid, "grip_test"), Items.GRIP_TEST);

                ItemUtils.SetItemGraphic(stock, Bundle, "IG_STOCK_TEST");
                ItemUtils.RegisterItem(new Identifier(modid, "stock_test"), stock);

                ItemUtils.SetItemGraphic(sight, Bundle, "IG_SIGHT_TEST");

                ItemSetting_Accessory itemSetting_Accessory = sight.AddComponent<ItemSetting_Accessory>();
                itemSetting_Accessory.overrideAdsAimMarker = ItemAssetsCollection.GetPrefab(571).GetComponent<ItemSetting_Accessory>().overrideAdsAimMarker;
                ItemUtils.RegisterItem(new Identifier(modid, "sight_test"), sight);

                ItemUtils.SetItemGraphic(muzzle, Bundle, "IG_MUZZLE_TEST");
                ItemUtils.RegisterItem(new Identifier(modid, "muzzle_test"), muzzle);

                ItemUtils.SetItemGraphic(grip, Bundle, "IG_GRIP_TEST");
                ItemUtils.RegisterItem(new Identifier(modid, "grip_test"), grip);
            }

            ItemUtils.CreateCustomBluePrint(new Identifier(modid, "lmr_blueprint"), Quests.BLUEPRINT_EXAMPLE);
        }

        private void RegisterNPCWeapons()
        {
            var lmrEntry = ItemEntry.Of(new Identifier(modid, "lmr_item"), 1);
            var mk23Entry = ItemEntry.Of(new Identifier(modid, "mk23_item"), 1);

            // Scav + USEC → LMR rifle (prefix wildcard covers all variants)
            WeaponInjectionUtils.AddWeaponToPreset("Cname_Scav*", lmrEntry, 0.3f);

            WeaponInjectionUtils.AddWeaponToPreset("Cname_Usec*", lmrEntry, 0.2f);
            WeaponInjectionUtils.AddWeaponToPreset("Cname_Usec*", mk23Entry, 0.1f);
            // Raider → MK23 pistol
            WeaponInjectionUtils.AddWeaponToPreset("Cname_Raider*", mk23Entry, 0.3f);
        }

        private void RegisterLotteryBoxItems()
        {
            var lmrEntry = ItemEntry.Of(new Identifier(modid, "lmr_item"), 1);
            var mk23Entry = ItemEntry.Of(new Identifier(modid, "mk23_item"), 1);

            // Inject into all gun lottery boxes
            LotteryBoxUtils.AddItemToLotteryBox("LotteryBox_Guns", lmrEntry);
            LotteryBoxUtils.AddItemToLotteryBox("LotteryBox_Guns", mk23Entry);
        }

        private void AddFormulas()
        {
            GameItemLookup.TryGetIdentifier(367, out Identifier id_367);
            CraftingUtils.AddCraftingFormula(new CraftingFormulaData
            {
                Id = new Identifier(modid, "lmr_crafting_example"),
                Money = 0L,
                CostItems = new[]
                {
                ItemEntry.Of(id_367, 5)
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
                    ItemEntry.Of(id_367, 1)
                }
            }
            );

            CraftingUtils.AddDecomposeFormula(new DecomposeFormulaData
            {
                Id = new Identifier(modid, "scrap_mk23"),
                SourceItemId = new Identifier(modid, "mk23_item"),  // 被分解物品
                Money = 50,
                ResultItems = new[] {
                    ItemEntry.Of(id_367, 3)
                }
            }
);
        }
    }
}
