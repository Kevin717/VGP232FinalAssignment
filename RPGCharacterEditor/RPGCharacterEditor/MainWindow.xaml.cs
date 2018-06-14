using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Forms;
using RPGCharacterEditor.WIP_Character;
using FinaleAssignment_CharacterEdit.WIP_SaveLoad;
using FinaleAssignment_CharacterEdit.WIP_SpriteEdit;
using FinaleAssignment_CharacterEdit.WIP_Inventory;
using System.IO;
using RPGCharacterEditor.WIP_Inventory;
using RPGCharacterEditor.WIP_EquippableItems;

namespace RPGCharacterEditor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class Editor : Window
    {
        //Properties
        public Character character;
        public Inventory pItems = new Inventory();
        public ItemList myItemList = new ItemList();

        private Serializer serializer;
        private SpriteEditor sprite_editor = new SpriteEditor();
        private EquippedItems equipped_items;
        WindowAddItem window_additem = new WindowAddItem();

        public Editor()
        {
            character = new Character();
            serializer = new Serializer();

            InitializeComponent();

            sprite_editor.Load(image_body, image_hat, image_shirt, image_boots);
            pItems.Load(myItemList.GetItems());

            //pItems.Add(0);
            //pItems.Add(4);
            //pItems.Add(5);
            //pItems.Add(3);
            //pItems.Add(2);

            window_additem.Load(ref window_main);
            InventoryList.ItemsSource = pItems.inventory;
            equipped_items = new EquippedItems(ref pItems, dropdown_equip_weapon, dropdown_equip_helm, dropdown_equip_chest);
            
            dropdown_equip_chest.SelectedIndex = 0;
            dropdown_equip_helm.SelectedIndex = 0;
            dropdown_equip_weapon.SelectedIndex = 0;
        }
        private void HPBox_TextChanged(object sender, TextChangedEventArgs e)
        {

            if (float.TryParse(HPBox.Text, out float result))
            {
                if (result <= 0)
                {
                    System.Windows.MessageBox.Show("Invalid Health");
                }
                else
                {
                    character.baseStatsManager.mStats.mHealth = result;
                }
            }
            else
            {
                if (HPBox.Text == string.Empty)
                {
                    return;
                }
                else
                {
                    System.Windows.MessageBox.Show("Invalid Health");
                }
            }
            UpdateText();
        }

        private void NameBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            character.baseStatsManager.mStats.mName = NameBox.Text;
        }

        private void LevelBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (int.TryParse(LevelBox.Text, out int result))
            {
                if (result < 0)
                {
                    System.Windows.MessageBox.Show("Invalid Level");
                }
                else
                {
                    character.baseStatsManager.mStats.mLevel = result;
                }
            }
            else
            {
                if (LevelBox.Text == string.Empty)
                {
                    return;
                }
                else
                {
                    System.Windows.MessageBox.Show("Invalid Level");
                }
            }
        }

        private void MPBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (float.TryParse(MPBox.Text, out float result))
            {
                if (result < 0)
                {
                    System.Windows.MessageBox.Show("Invalid MP");
                }
                else
                {
                    character.baseStatsManager.mStats.mMP = result;
                }
            }
            else
            {
                if (MPBox.Text == string.Empty)
                {
                    return;
                }
                else
                {
                    System.Windows.MessageBox.Show("Invalid MP");
                }
            }
            UpdateText();
        }

        private void DEFBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (float.TryParse(DEFBox.Text, out float result))
            {
                if (result <= 0)
                {
                    System.Windows.MessageBox.Show("Invalid Defense");
                }
                else
                {
                    character.baseStatsManager.mStats.mDefense = result;
                }
            }
            else
            {
                if (DEFBox.Text == string.Empty)
                {
                    return;
                }
                else
                {
                    System.Windows.MessageBox.Show("Invalid Defense");
                }
            }
            UpdateText();
        }

        private void STRGBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (float.TryParse(STRBox.Text, out float result))
            {
                if (result <= 0)
                {
                    System.Windows.MessageBox.Show("Invalid Strength");
                }
                else
                {
                    character.baseStatsManager.mStats.mStrength = result;
                }

            }
            else
            {
                if (STRBox.Text == string.Empty)
                {
                    return;
                }
                else
                {
                    System.Windows.MessageBox.Show("Invalid Strength");
                }
            }
            UpdateText();
        }

        private void INTELBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (float.TryParse(INTELBox.Text, out float result))
            {
                if (result <= 0)
                {
                    System.Windows.MessageBox.Show("Invalid Intelligence");
                }
                else
                {
                    character.baseStatsManager.mStats.mIntelligence = result;
                }
            }
            else
            {
                if (INTELBox.Text == string.Empty)
                {
                    return;
                }
                else
                {
                    System.Windows.MessageBox.Show("Invalid Intelligence");
                }
            }
            UpdateText();
        }

        private void DEXBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (float.TryParse(DEXBox.Text, out float result))
            {
                if (result <= 0)
                {
                    System.Windows.MessageBox.Show("Invalid Dexterity");
                }
                else
                {
                    character.baseStatsManager.mStats.mDexterity = result;
                }
            }
            else
            {
                if (DEXBox.Text == string.Empty)
                {
                    return;
                }
                else
                {
                    System.Windows.MessageBox.Show("Invalid Dexterity");
                }
            }
            UpdateText();
        }

        private void SaveButtom_Click(object sender, RoutedEventArgs e)
        {
            //Updating the inventory of the player
            character.inventory = pItems.inventory;

            if (FileNameBox.Text != string.Empty)
            {
                string path = FileNameBox.Text + ".xml";
                //Updating character 
                character.boots_index = sprite_editor.boots_index;
                character.hat_index   = sprite_editor.hat_index;
                character.shirt_index = sprite_editor.shirt_index; 

                serializer.Save(character, path);
            }
        }

        private void LoadButtom_Click(object sender, RoutedEventArgs e)
        {
                character = serializer.Load();
            if (character != null)
            {
                NameBox.Text = character.baseStatsManager.mStats.mName;
                LevelBox.Text = character.baseStatsManager.mStats.mLevel.ToString();
                HPBox.Text = character.baseStatsManager.mStats.mHealth.ToString();
                MPBox.Text = character.baseStatsManager.mStats.mMP.ToString();
                DEFBox.Text = character.baseStatsManager.mStats.mDefense.ToString();
                STRBox.Text = character.baseStatsManager.mStats.mStrength.ToString();
                INTELBox.Text = character.baseStatsManager.mStats.mIntelligence.ToString();
                DEXBox.Text = character.baseStatsManager.mStats.mDexterity.ToString();
                sprite_editor.Refresh(character);
                //Updating equippeditems
                equipped_items.mInv.inventory = character.inventory;
                equipped_items.Refresh();
                equipped_items.CalculateStats();

                //Updating UI
                UpdateText();
                Refresh_Inventory(equipped_items.mInv);
            }
        }

        //hat buttons
        private void btn_addhat_click(object sender, RoutedEventArgs e)
        {
            sprite_editor.Hat_Add();
        }

        private void btn_next_hat_click(object sender, RoutedEventArgs e)
        {
            sprite_editor.Hat_Next();
        }

        private void btn_prev_hat_click(object sender, RoutedEventArgs e)
        {
            sprite_editor.Hat_Prev();
        }

        //shirt buttons
        private void btn_add_shirt_click(object sender, RoutedEventArgs e)
        {
            sprite_editor.Shirt_Add();
        }

        private void btn_prev_shirt_click(object sender, RoutedEventArgs e)
        {
            sprite_editor.Shirt_Prev();
        }

        private void btn_next_shirt_click(object sender, RoutedEventArgs e)
        {
            sprite_editor.Shirt_Next();
        }

        //boots buttons
        private void btn_add_boots_click(object sender, RoutedEventArgs e)
        {
            sprite_editor.Boots_Add();
        }

        private void btn_prev_boots_click(object sender, RoutedEventArgs e)
        {
            sprite_editor.Boots_Prev();
        }

        private void btn_next_boots_click(object sender, RoutedEventArgs e)
        {
            sprite_editor.Boots_Next();
        }

        private void btn_additem_click(object sender, RoutedEventArgs e)
        {
            window_additem.listview_allitems.ItemsSource = myItemList.GetItems();
            
            window_additem.Show();
        }

        public void Refresh_Inventory(Inventory mitems)
        {
            InventoryList.ItemsSource = mitems.inventory;
            InventoryList.Items.Refresh();
            equipped_items.Refresh();
        }

        private void UpdateText()
        {
            text_bonusHP.Text = equipped_items.bonusHP.ToString();
            text_bonusMP.Text = equipped_items.bonusMP.ToString();
            text_bonusDEF.Text = equipped_items.bonusDEF.ToString();
            text_bonusSTR.Text = equipped_items.bonusSTR.ToString();
            text_bonusINT.Text = equipped_items.bonusINT.ToString();
            text_bonusDEX.Text = equipped_items.bonusDEX.ToString();

            try { text_totalHP.Text = (Int32.Parse(text_bonusHP.Text) + Int32.Parse(HPBox.Text)).ToString(); } catch{text_totalHP.Text = "Invalid";}
            try { text_totalMP.Text = (Int32.Parse(text_bonusMP.Text) + Int32.Parse(MPBox.Text)).ToString(); } catch { text_totalMP.Text = "Invalid"; }
            try { text_totalDEF.Text = (Int32.Parse(text_bonusDEF.Text) + Int32.Parse(DEFBox.Text)).ToString(); } catch { text_totalDEF.Text = "Invalid"; }
            try { text_totalSTR.Text = (Int32.Parse(text_bonusSTR.Text) + Int32.Parse(STRBox.Text)).ToString(); } catch { text_totalSTR.Text = "Invalid"; }
            try { text_totalINT.Text = (Int32.Parse(text_bonusINT.Text) + Int32.Parse(INTELBox.Text)).ToString(); } catch { text_totalINT.Text = "Invalid"; }
            try { text_totalDEX.Text = (Int32.Parse(text_bonusDEX.Text) + Int32.Parse(DEXBox.Text)).ToString(); } catch { text_totalDEX.Text = "Invalid"; }
        }

        private void dropdown_equip_helm_changed(object sender, SelectionChangedEventArgs e) //update bonus stats here
        {
            if (equipped_items.helmlist[dropdown_equip_helm.SelectedIndex] != null)
            {
                equipped_items.equippedHelm.mEquiped = false;
                equipped_items.equippedHelm = equipped_items.helmlist[dropdown_equip_helm.SelectedIndex];
                equipped_items.equippedHelm.mEquiped = true;
                equipped_items.CalculateStats();
                InventoryList.Items.Refresh();
                UpdateText();
                equipped_items.helm_index = dropdown_equip_helm.SelectedIndex;
            }
        }

        private void dropdown_equip_chest_changed(object sender, SelectionChangedEventArgs e) //Chest
        {
            if (equipped_items.chestlist[dropdown_equip_chest.SelectedIndex] != null)
            {
                equipped_items.equippedChest.mEquiped = false;
                equipped_items.equippedChest = equipped_items.chestlist[dropdown_equip_chest.SelectedIndex];
                equipped_items.equippedChest.mEquiped = true;
                equipped_items.CalculateStats();
                InventoryList.Items.Refresh();
                UpdateText();
                equipped_items.chest_index = dropdown_equip_chest.SelectedIndex;
            }
        }

        private void dropdown_equip_weapon_changed(object sender, SelectionChangedEventArgs e)
        {
            if (equipped_items.weaponlist[dropdown_equip_weapon.SelectedIndex] != null)
            {
                equipped_items.equippedWeapon.mEquiped = false;
                equipped_items.equippedWeapon = equipped_items.weaponlist[dropdown_equip_weapon.SelectedIndex];
                equipped_items.equippedWeapon.mEquiped = true;
                equipped_items.CalculateStats();
                InventoryList.Items.Refresh();
                UpdateText();
                equipped_items.weapon_index = dropdown_equip_weapon.SelectedIndex;
            }
        }

        private void window_main_closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            window_additem.Close();
        }
    }
}

//If bug in InitializeComponent

// Check the .xaml a x:Class=" {HERE [This is the namespapce]RPGCharacterEditor}.MainWindow"
//AND the local namespace for the xaml [xmlns:local="clr-namespace:RPGCharacterEditor"]
