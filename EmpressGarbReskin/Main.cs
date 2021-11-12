using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Collections.Generic;
using UnityModManagerNet;
using SolastaModApi;
using ModKit;
using ModKit.Utility;
using SolastaModApi.Extensions;

namespace EmpressGarbReskin
{
    public static class Main
    {
        public static readonly string MOD_FOLDER = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

        [Conditional("DEBUG")]
        internal static void Log(string msg) => Logger.Log(msg);
        internal static void Error(Exception ex) => Logger?.Error(ex.ToString());
        internal static void Error(string msg) => Logger?.Error(msg);
        internal static void Warning(string msg) => Logger?.Warning(msg);
        internal static UnityModManager.ModEntry.ModLogger Logger { get; private set; }
        internal static ModManager<Core, Settings> Mod { get; private set; }
        internal static MenuManager Menu { get; private set; }
        internal static Settings Settings { get { return Mod.Settings; } }

        internal static bool Load(UnityModManager.ModEntry modEntry)
        {
            try
            {
                Logger = modEntry.Logger;

                Mod = new ModManager<Core, Settings>();
                Menu = new MenuManager();
                modEntry.OnToggle = OnToggle;

                Translations.Load(MOD_FOLDER);
            }
            catch (Exception ex)
            {
                Error(ex);
                throw;
            }

            return true;
        }

        static bool OnToggle(UnityModManager.ModEntry modEntry, bool enabled)
        {
            if (enabled)
            {
                Assembly assembly = Assembly.GetExecutingAssembly();
                Mod.Enable(modEntry, assembly);
                Menu.Enable(modEntry, assembly);
            }
            else
            {
                Menu.Disable(modEntry);
                Mod.Disable(modEntry, false);
                ReflectionCache.Clear();
            }
            return true;
        }

        internal static void OnGameReady()
        {
            if (Main.Settings.SylvanArmor == "Everyone")
            {
                ItemDefinition sylvanArmor = DatabaseHelper.ItemDefinitions.GreenmageArmor;
                sylvanArmor.RequiredAttunementClasses.Clear();
            }

            if (Main.Settings.Skin == "Plain Shirt")
            {
                ItemDefinition plain_empress = DatabaseHelper.ItemDefinitions.Enchanted_ChainShirt_Empress_war_garb;
                plain_empress.ItemPresentation.SetUseCustomArmorMaterial(false);
            }

            if (Main.Settings.Skin == "Studded Leather")
            {
                ItemDefinition studdedleather_empress = DatabaseHelper.ItemDefinitions.Enchanted_ChainShirt_Empress_war_garb;
                studdedleather_empress.SetItemPresentation(DatabaseHelper.ItemDefinitions.StuddedLeather.ItemPresentation);
            }

            if (Main.Settings.Skin == "Elven Chain")
            {
                ItemDefinition elvenchain_empress = DatabaseHelper.ItemDefinitions.Enchanted_ChainShirt_Empress_war_garb;
                elvenchain_empress.SetItemPresentation(DatabaseHelper.ItemDefinitions.ElvenChain.ItemPresentation);
            }

            if (Main.Settings.Skin == "Wizard Clothes")
            {
                ItemDefinition clotheswizard_empress = DatabaseHelper.ItemDefinitions.Enchanted_ChainShirt_Empress_war_garb;
                clotheswizard_empress.SetItemPresentation(DatabaseHelper.ItemDefinitions.WizardClothes_Alternate.ItemPresentation);
            }

            if (Main.Settings.Beard == "Always")
            {
                FeatureDefinitionCharacterPresentation beardedBelt = DatabaseHelper.FeatureDefinitionCharacterPresentations.CharacterPresentationBeltOfDwarvenKind;
                beardedBelt.SetOccurencePercentage(100);
                beardedBelt.GuiPresentation.SetDescription("EmpressGarbReskin/&AlwaysBeardDescription");
            }

            if (Main.Settings.Beard == "Never")
            {
                ItemDefinition beardlessBelt = DatabaseHelper.ItemDefinitions.BeltOfDwarvenKind;
                for (int i = 0; i < beardlessBelt.StaticProperties.Count; i++)
                {
                    if (beardlessBelt.StaticProperties[i].FeatureDefinition.GUID == DatabaseHelper.FeatureDefinitionCharacterPresentations.CharacterPresentationBeltOfDwarvenKind.GUID)
                    {
                        beardlessBelt.StaticProperties.RemoveAt(i);
                        break;
                    }
                }
            }

            if (Main.Settings.InvisbleCrown == true)
            {
                GraphicsCharacterDefinitions.BodyPartBehaviour[] invisible_crown = new GraphicsCharacterDefinitions.BodyPartBehaviour[]
                {
                GraphicsCharacterDefinitions.BodyPartBehaviour.Shape, GraphicsCharacterDefinitions.BodyPartBehaviour.Shape,
                GraphicsCharacterDefinitions.BodyPartBehaviour.Keep, GraphicsCharacterDefinitions.BodyPartBehaviour.Keep,
                GraphicsCharacterDefinitions.BodyPartBehaviour.Keep, GraphicsCharacterDefinitions.BodyPartBehaviour.Keep,
                GraphicsCharacterDefinitions.BodyPartBehaviour.Keep, GraphicsCharacterDefinitions.BodyPartBehaviour.Keep,
                GraphicsCharacterDefinitions.BodyPartBehaviour.Keep, GraphicsCharacterDefinitions.BodyPartBehaviour.Keep
                };

                ItemDefinition invisibleCrownOfTheMagister = DatabaseHelper.ItemDefinitions.CrownOfTheMagister;
                ItemDefinition invisibleCrownOfTheMagister01 = DatabaseHelper.ItemDefinitions.CrownOfTheMagister01;
                ItemDefinition invisibleCrownOfTheMagister02 = DatabaseHelper.ItemDefinitions.CrownOfTheMagister02;
                ItemDefinition invisibleCrownOfTheMagister03 = DatabaseHelper.ItemDefinitions.CrownOfTheMagister03;
                ItemDefinition invisibleCrownOfTheMagister04 = DatabaseHelper.ItemDefinitions.CrownOfTheMagister04;
                ItemDefinition invisibleCrownOfTheMagister05 = DatabaseHelper.ItemDefinitions.CrownOfTheMagister05;
                ItemDefinition invisibleCrownOfTheMagister06 = DatabaseHelper.ItemDefinitions.CrownOfTheMagister06;
                ItemDefinition invisibleCrownOfTheMagister07 = DatabaseHelper.ItemDefinitions.CrownOfTheMagister07;
                ItemDefinition invisibleCrownOfTheMagister08 = DatabaseHelper.ItemDefinitions.CrownOfTheMagister08;
                ItemDefinition invisibleCrownOfTheMagister09 = DatabaseHelper.ItemDefinitions.CrownOfTheMagister09;
                ItemDefinition invisibleCrownOfTheMagister10 = DatabaseHelper.ItemDefinitions.CrownOfTheMagister10;
                ItemDefinition invisibleCrownOfTheMagister11 = DatabaseHelper.ItemDefinitions.CrownOfTheMagister11;
                ItemDefinition invisibleCrownOfTheMagister12 = DatabaseHelper.ItemDefinitions.CrownOfTheMagister12;

                invisibleCrownOfTheMagister.ItemPresentation.SetMaleBodyPartBehaviours(invisible_crown);
                invisibleCrownOfTheMagister01.ItemPresentation.SetMaleBodyPartBehaviours(invisible_crown);
                invisibleCrownOfTheMagister02.ItemPresentation.SetMaleBodyPartBehaviours(invisible_crown);
                invisibleCrownOfTheMagister03.ItemPresentation.SetMaleBodyPartBehaviours(invisible_crown);
                invisibleCrownOfTheMagister04.ItemPresentation.SetMaleBodyPartBehaviours(invisible_crown);
                invisibleCrownOfTheMagister05.ItemPresentation.SetMaleBodyPartBehaviours(invisible_crown);
                invisibleCrownOfTheMagister06.ItemPresentation.SetMaleBodyPartBehaviours(invisible_crown);
                invisibleCrownOfTheMagister07.ItemPresentation.SetMaleBodyPartBehaviours(invisible_crown);
                invisibleCrownOfTheMagister08.ItemPresentation.SetMaleBodyPartBehaviours(invisible_crown);
                invisibleCrownOfTheMagister09.ItemPresentation.SetMaleBodyPartBehaviours(invisible_crown);
                invisibleCrownOfTheMagister10.ItemPresentation.SetMaleBodyPartBehaviours(invisible_crown);
                invisibleCrownOfTheMagister11.ItemPresentation.SetMaleBodyPartBehaviours(invisible_crown);
                invisibleCrownOfTheMagister12.ItemPresentation.SetMaleBodyPartBehaviours(invisible_crown);
            }

        }
    }
}
