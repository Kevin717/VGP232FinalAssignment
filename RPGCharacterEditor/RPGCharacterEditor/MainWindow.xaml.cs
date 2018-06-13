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
using FinaleAssignment_CharacterEdit.WIP_EquippableItems;
using System.IO;

namespace RPGCharacterEditor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class Editor : Window
    {
        //Properties
        private Character character;
        public ItemList myItemList = new ItemList();
        public Inventory pItems = new Inventory();


        private Serializer serializer;
        private SpriteEditor sprite_editor = new SpriteEditor();
        
        public Editor()
        {
            
            
            character = new Character();
            serializer = new Serializer();
            InitializeComponent();
            sprite_editor.Load(image_body, image_hat, image_shirt, image_boots);
            pItems.Load(myItemList.GetItems());
            pItems.Add(0);
            pItems.Add(4);
            pItems.Add(3);
            pItems.Add(2);
            InventoryList.ItemsSource = pItems.inventory;
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
        }

        private void SaveButtom_Click(object sender, RoutedEventArgs e)
        {
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
            
            NameBox.Text    = character.baseStatsManager.mStats.mName;
            LevelBox.Text   = character.baseStatsManager.mStats.mLevel.ToString();
            HPBox.Text      = character.baseStatsManager.mStats.mHealth.ToString();
            MPBox.Text      = character.baseStatsManager.mStats.mMP.ToString();
            DEFBox.Text     = character.baseStatsManager.mStats.mDefense.ToString();
            STRBox.Text     = character.baseStatsManager.mStats.mStrength.ToString();
            INTELBox.Text   = character.baseStatsManager.mStats.mIntelligence.ToString();
            DEXBox.Text     = character.baseStatsManager.mStats.mDexterity.ToString();
            sprite_editor.Refresh(character);
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

        private void Bttn_AddItem(object sender, RoutedEventArgs e)
        {
            
        }
    }
}

//If bug in InitializeComponent

// Check the .xaml a x:Class=" {HERE [This is the namespapce]RPGCharacterEditor}.MainWindow"
//AND the local namespace for the xaml [xmlns:local="clr-namespace:RPGCharacterEditor"]
