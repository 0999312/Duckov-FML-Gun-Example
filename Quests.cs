using Duckov.Quests;
using FastModdingLib;
using System;
using System.Collections.Generic;
using System.Text;

namespace DuckovWeaponExample
{
    public static class Quests
    {
        public static BlueprintData BLUEPRINT_EXAMPLE = new BlueprintData
        {
            itemId = 31002,
            order = 35,
            localizationKey = "lmrBP",
            localizationDesc = "lmrBP_Desc",
            tags = { "Formula", "Formula_Blueprint" },
            formulaID = "lmr_crafting_example"
        };

        public static QuestData EXAMPLE_QUEST_1 = new QuestData
            {
                ID = 31001,
                displayName = "WPNExampleQuest1",
                description = "WPNExampleQuest1_desc",
                questGiver = QuestGiverID.Xavier,
                requireLevel = 1,
                tasks = {
                    new TaskRequireMoney
                    {
                        id = 1,
                        money = 2500
                    }
                },
                rewards = {
                    new RewardGiveItem
                    {
                        id = 1,
                        itemTypeID = 31001,
                        amount = 1
                    },
                    new RewardUnlockItem {
                        id = 2,
                        itemTypeID = 31001
                    }
                }
            };

        public static QuestData EXAMPLE_QUEST_2 = new QuestData
        {
            ID = 31002,
            displayName = "WPNExampleQuest2",
            description = "WPNExampleQuest2_desc",
            questGiver = QuestGiverID.Jeff,
            requireItemID = 31001,
            tasks = {
                    new TaskRequireItem
                    {
                        id = 1,
                        itemTypeID = 31001,
                        requiredAmount = 1
                    }
                },
            rewards = {
                    new RewardEXP
                    {
                        id = 1,
                        amount = 500
                    },
                    new RewardGiveItem
                    {
                        id = 1,
                        itemTypeID = 31002,
                        amount = 1
                    }
            }
        };
    }
}
