using Duckov.Quests;
using FastModdingLib;
using FastModdingLib.Utils;

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

        public static readonly Identifier Quest1Id = new Identifier("DuckovWeaponExample", "example_quest_1");
        public static readonly Identifier Quest2Id = new Identifier("DuckovWeaponExample", "example_quest_2");
        public static readonly Identifier AgentUnlockQuestId = new Identifier("DuckovWeaponExample", "agent_unlock_quest");

        public static QuestData EXAMPLE_QUEST_1 = new QuestData
            {
                Id = Quest1Id,
                displayName = "WPNExampleQuest1",
                description = "WPNExampleQuest1_desc",
                questGiver = QuestGiverID.Xavier,
                requireLevel = 1,
                tasks = {
                    new TaskRequireMoney
                    {
                        money = 2500
                    }
                },
                rewards = {
                    new RewardGiveItem
                    {
                        itemIdentifier = new Identifier("DuckovWeaponExample", "lmr_item"),
                        amount = 1
                    },
                    new RewardUnlockItem {
                        itemIdentifier = new Identifier("DuckovWeaponExample", "lmr_item")
                    }
                }
            };

        public static QuestData EXAMPLE_QUEST_2 = new QuestData
        {
            Id = Quest2Id,
            displayName = "WPNExampleQuest2",
            description = "WPNExampleQuest2_desc",
            questGiver = QuestGiverID.Jeff,
            requireLevel = 1,
            tasks = {
                    new TaskRequireItem
                    {
                        itemIdentifier = new Identifier("DuckovWeaponExample", "lmr_item"),
                        requiredAmount = 1
                    }
                },
            rewards = {
                    new RewardEXP
                    {
                        amount = 500
                    },
                    new RewardGiveItem
                    {
                        itemIdentifier = new Identifier("DuckovWeaponExample", "lmr_blueprint"),
                        amount = 1
                    }
            }
        };

        // TODO: 以下文本为占位符，请在 locale 文件中编辑实际文本
        // - displayName key: "AgentEndowmentUnlock"
        // - description key: "AgentEndowmentUnlock_desc"
        public static QuestData AGENT_UNLOCK_QUEST = new QuestData
        {
            Id = AgentUnlockQuestId,
            displayName = "AgentEndowmentUnlock",
            description = "AgentEndowmentUnlock_desc",
            questGiver = QuestGiverID.Xavier,
            requireLevel = 5,
            tasks = {
                    new TaskKillCount
                    {
                        weaponIdentifier = new Identifier("DuckovWeaponExample", "mk23_item"),
                        requireAmount = 10       // 击杀 10 名任意敌人
                    }
                },
            rewards = {
                    new RewardEXP
                    {
                        amount = 1000
                    },
                    // 任务完成时自动解锁 Agent 天赋（AutoClaim）
                    new RewardUnlockEndowmentData
                    {
                        endowmentId = new Identifier("DuckovWeaponExample", "Agent")
                    }
                }
        };
    }
}
