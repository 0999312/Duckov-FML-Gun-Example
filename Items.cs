using FastModdingLib;
using System.Collections.Generic;

namespace DuckovWeaponExample
{
    public static class Items
    {
        public static ItemData STOCK_TEST = new ItemData
        {
            itemId = 31010,
            localizationKey = "STOCK_TEST",
            localizationDesc = "STOCK_TEST_Desc",
            spritePath = "items/stock.png",
            order = 616,
            value = 5623,
            quality = 5,
            weight = 0.01F,
            tags = { "Accessory", "Stock", "GunType_AR" },
            modifiers = new List<ModifierData> {
                new ModifierData {
                    key = "MoveSpeedMultiplier",
                    display = true,
                    type = ItemStatsSystem.Stats.ModifierType.PercentageAdd,
                    target = ItemStatsSystem.ModifierTarget.Parent,
                    value = 0.15F,
                },
                new ModifierData {
                    key = "RecoilScaleV",
                    display = true,
                    type = ItemStatsSystem.Stats.ModifierType.PercentageAdd,
                    target = ItemStatsSystem.ModifierTarget.Parent,
                    value = -0.5F,
                },
                new ModifierData {
                    key = "RecoilScaleH",
                    display = true,
                    type = ItemStatsSystem.Stats.ModifierType.PercentageAdd,
                    target = ItemStatsSystem.ModifierTarget.Parent,
                    value = -0.5F,
                },
            }
        };

        public static ItemData GRIP_TEST = new ItemData
        {
            itemId = 31011,
            localizationKey = "GRIP_TEST",
            localizationDesc = "GRIP_TEST_Desc",
            spritePath = "items/grip.png",
            order = 616,
            value = 5623,
            quality = 5,
            weight = 0.01F,
            tags = { "Accessory", "Grip"},
            modifiers = new List<ModifierData> {
                new ModifierData {
                    key = "ScatterFactorADS",
                    display = true,
                    type = ItemStatsSystem.Stats.ModifierType.PercentageAdd,
                    target = ItemStatsSystem.ModifierTarget.Parent,
                    value = -0.25F,
                },
                new ModifierData {
                    key = "RecoilScaleV",
                    display = true,
                    type = ItemStatsSystem.Stats.ModifierType.PercentageAdd,
                    target = ItemStatsSystem.ModifierTarget.Parent,
                    value = -0.4F,
                },
                new ModifierData {
                    key = "RecoilScaleH",
                    display = true,
                    type = ItemStatsSystem.Stats.ModifierType.PercentageAdd,
                    target = ItemStatsSystem.ModifierTarget.Parent,
                    value = -0.4F,
                },
            }
        };

        public static ItemData SIGHT_TEST = new ItemData
        {
            itemId = 31012,
            localizationKey = "SIGHT_TEST",
            localizationDesc = "SIGHT_TEST_Desc",
            spritePath = "items/sight.png",
            order = 616,
            value = 5623,
            quality = 5,
            weight = 0.01F,
            tags = { "Accessory", "Scope" },
            modifiers = new List<ModifierData> {
                new ModifierData {
                    key = "ADSAimDistanceFactor",
                    display = true,
                    type = ItemStatsSystem.Stats.ModifierType.PercentageAdd,
                    target = ItemStatsSystem.ModifierTarget.Parent,
                    value = 0.15F,
                },
                new ModifierData {
                    key = "ADSTime",
                    display = true,
                    type = ItemStatsSystem.Stats.ModifierType.PercentageAdd,
                    target = ItemStatsSystem.ModifierTarget.Parent,
                    value = -0.2F,
                },
                new ModifierData {
                    key = "CritDamageFactor",
                    display = true,
                    type = ItemStatsSystem.Stats.ModifierType.Add,
                    target = ItemStatsSystem.ModifierTarget.Parent,
                    value = 0.15F,
                },
            }
        };

        public static ItemData MUZZLE_TEST = new ItemData
        {
            itemId = 31013,
            localizationKey = "MUZZLE_TEST",
            localizationDesc = "MUZZLE_TEST_Desc",
            spritePath = "items/muzzle.png",
            order = 616,
            value = 5623,
            quality = 5,
            weight = 0.01F,
            tags = { "Accessory", "Muzzle", "GunType_AR" },
            modifiers = new List<ModifierData> {
                new ModifierData {
                    key = "SoundRange",
                    display = true,
                    type = ItemStatsSystem.Stats.ModifierType.PercentageAdd,
                    target = ItemStatsSystem.ModifierTarget.Parent,
                    value = -0.85F,
                },
                new ModifierData {
                    key = "BulletDistance",
                    display = true,
                    type = ItemStatsSystem.Stats.ModifierType.PercentageAdd,
                    target = ItemStatsSystem.ModifierTarget.Parent,
                    value = 0.15F,
                }
            }
        };

    }
}
