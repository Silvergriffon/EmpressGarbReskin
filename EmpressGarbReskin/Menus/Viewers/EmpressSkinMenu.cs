using System;
using System.Collections.Generic;
using UnityModManagerNet;
using ModKit;
using static EmpressGarbReskin.Main;

namespace EmpressGarbReskin.Menus.Viewers
{
    public class EmpressGarbReskinMenu1 : IMenuSelectablePage
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

            var gloriousBeard = new List<string> { "Standard", "Always", "Never" };
            var beardChance = Math.Max(gloriousBeard.FindIndex(x => x == Main.Settings.Beard), 0);

            UI.Label("");
            UI.Label("Belt of Dwarvenkind Beard".yellow().bold());

            UI.HStack("", 10, () => {
                if (UI.SelectionGrid(ref beardChance, gloriousBeard.ToArray(), gloriousBeard.Count, UI.AutoWidth()))
                {
                    Main.Settings.Beard = gloriousBeard[beardChance];
                }
            });

            var sylvanClothing = new List<string> { "Wizard Only", "Everyone" };
            var sylvanChoice = Math.Max(sylvanClothing.FindIndex(x => x == Main.Settings.SylvanArmor), 0);

            UI.Label("");
            UI.Label("Sylvan Armor Equippable By:".yellow().bold());
            UI.HStack("", 10, () => {
                if (UI.SelectionGrid(ref sylvanChoice, sylvanClothing.ToArray(), sylvanClothing.Count, UI.AutoWidth()))
                {
                    Main.Settings.SylvanArmor = sylvanClothing[sylvanChoice];
                }
            });

            UI.Label("");
            UI.Toggle("Invisible Crown of the Magister".yellow().bold(), ref Main.Settings.InvisbleCrown, 0, UI.AutoWidth());

        }

        public void OnGUI(UnityModManager.ModEntry modEntry)
        {
            if (Mod == null || !Mod.Enabled) return;

            DisplayEmpressSkinSettings();
        }
    }
}

