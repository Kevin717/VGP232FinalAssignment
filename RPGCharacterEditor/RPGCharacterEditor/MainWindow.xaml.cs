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

namespace RPGCharacterEditor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class Editor : Window
    {
        //Properties
        private Character character;
        private Serializer serializer;

        public Editor()
        {
            character = new Character();
            serializer = new Serializer();
            InitializeComponent();
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
                serializer.Save(character, path);
            }
        }
    }
}

//If bug in InitializeComponent

// Check the .xaml a x:Class=" {HERE [This is the namespapce]RPGCharacterEditor}.MainWindow"
//AND the local namespace for the xaml [xmlns:local="clr-namespace:RPGCharacterEditor"]
