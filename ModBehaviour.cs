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
            var Bundle = AssetUtil.LoadBundle(dllPath, "examplebundle");
            if (Bundle != null) { 
                ItemUtils.RegisterGun(Bundle, "LMRItem");
            }

            I18n.loadFileJson(dllPath, $"/{I18n.localizedNames[SodaCraft.Localizations.LocalizationManager.CurrentLanguage]}");
            CraftingUtils.AddCraftingFormula("crafting_example", 0L, new (int, long)[1]
            {
                (367, 5L)
            }, 31001, 1, new string[1] { "WorkBenchAdvanced" });
            CraftingUtils.AddDecomposeFormula(31001, 0L, new (int, long)[1]
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