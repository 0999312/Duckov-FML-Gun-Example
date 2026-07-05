using FastModdingLib;
using ItemStatsSystem.Stats;

namespace DuckovWeaponExample
{
    /// <summary>
    /// Custom endowment definitions for this mod.
    /// Endowments are character traits that apply permanent stat modifiers.
    /// Uses FML's EndowmentConfig DTO — no reflection, no direct EndowmentEntry manipulation.
    /// </summary>
    public static class Endowments
    {

        /// <summary>
        /// Build the Agent (特工) endowment config.
        /// Grants bonuses to move speed, melee/gun damage, recoil control, and reload speed.
        /// Unlock requirement: kill 10 enemies with MK23 (see AGENT_UNLOCK_QUEST).
        /// </summary>
        public static EndowmentConfig BuildAgentConfig()
        {
            // 加载图标（从 assets/textures/Endowment_Agent.png）
            var icon = ItemUtils.LoadSprite("Endowment_Agent.png");

            return new EndowmentConfig
            {
                Modifiers = new[]
                {

                    new EndowmentModifier
                    {
                        StatKey = "MoveSpeedMultiplier",
                        Type = ModifierType.PercentageAdd,
                        Value = 0.10f
                    },

                    new EndowmentModifier
                    {
                        StatKey = "MeleeDamageMultiplier",
                        Type = ModifierType.PercentageAdd,
                        Value = 0.15f
                    },

                    new EndowmentModifier
                    {
                        StatKey = "GunDamageMultiplier",
                        Type = ModifierType.PercentageAdd,
                        Value = 0.15f
                    },

                    new EndowmentModifier
                    {
                        StatKey = "GunDistanceMultiplier",
                        Type = ModifierType.PercentageAdd,
                        Value = 0.15f
                    },

                    new EndowmentModifier
                    {
                        StatKey = "RecoilControl",
                        Type = ModifierType.PercentageAdd,
                        Value = 0.2f
                    },

                    new EndowmentModifier
                    {
                        StatKey = "ReloadSpeedGain",
                        Type = ModifierType.PercentageAdd,
                        Value = 0.15f
                    },
                },
                UnlockedByDefault = false,
                Icon = icon,
            };
        }
    }
}
