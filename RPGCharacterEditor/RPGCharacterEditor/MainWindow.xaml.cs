using RPGCharacterEditor.WIP_CharacterStats;
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

namespace RPGCharacterEditor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class Editor : Window
    {
        private BaseStatsManager baseStatsManager;
        public Editor()
        {
            baseStatsManager = new BaseStatsManager();
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
                    baseStatsManager.mStats.mHealth = result;
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
            baseStatsManager.mStats.mName = NameBox.Text;
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
                    baseStatsManager.mStats.mLevel = result;
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
                    baseStatsManager.mStats.mMP = result;
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
                    baseStatsManager.mStats.mDefense = result;
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
                    baseStatsManager.mStats.mStrength = result;
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
                    baseStatsManager.mStats.mIntelligence = result;
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
                    baseStatsManager.mStats.mDexterity = result;
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
    }
}

//If bug in InitializeComponent

// Check the .xaml a x:Class=" {HERE [This is the namespapce]RPGCharacterEditor}.MainWindow"
//AND the local namespace for the xaml [xmlns:local="clr-namespace:RPGCharacterEditor"]
