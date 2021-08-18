using System;
using System.Collections.Generic;
using UnityModManagerNet;
using ModKit;
using static EmpressGarbReskin.Main;

namespace EmpressGarbReskin.Menus.Viewers
{
    public class SampleModMenu1 : IMenuSelectablePage
    {
        public string Name => "Empress Garb Skin Menu";

        public int Priority => 1;
		
		private static void DisplayEmpressSkinSettings()
        {
            var skins = new List<string> { "Normal", "Plain Shirt", "Studded Leather", "Elven Chain", "Wizard Clothes" };
            var skinChoice = Math.Max(skins.FindIndex(x => x == Main.Settings.Skin), 0);

            UI.Label("");
            UI.Label("Empress Garb Appearance Settings".yellow().bold());

            UI.HStack("", 10, () => {
                if (UI.SelectionGrid(ref skinChoice, skins.ToArray(), skins.Count, UI.AutoWidth()))
                {
                    Main.Settings.Skin = skins[skinChoice];
                }
            });            
        }

        public void OnGUI(UnityModManager.ModEntry modEntry)
        {
            if (Mod == null || !Mod.Enabled) return;

            DisplayEmpressSkinSettings();
        }
    }
}

