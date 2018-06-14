using FinaleAssignment_CharacterEdit.WIP_Inventory;
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
using System.Windows.Shapes;
using System.Windows.Forms;

namespace RPGCharacterEditor.WIP_Inventory
{
    /// <summary>
    /// Interaction logic for WindowAddItem.xaml
    /// </summary>
    public partial class WindowAddItem : Window
    {
        Editor main_window;
//        public Inventory pitems;

        public WindowAddItem()
        {
            InitializeComponent();
        }

        public void Load(ref Editor MainWindow)
        {
            main_window = MainWindow;
        }

        private void btn_additem_confirm_click(object sender, RoutedEventArgs e)
        {
            int amount;
        
            if (text_additem_amount.Text != "")
            {
                if (Int32.TryParse(text_additem_amount.Text, out amount))
                {
                    main_window.pItems.Add(listview_allitems.SelectedIndex, amount);
                    main_window.Refresh_Inventory(main_window.pItems);
                    this.Hide();
                }
                else
                {
                    System.Windows.Forms.MessageBox.Show("Invalid value, PLEASE ONLY ENTER INTEGERS!");
                }
            }
            else
            {
                main_window.pItems.Add(listview_allitems.SelectedIndex);
                main_window.Refresh_Inventory(main_window.pItems);
                this.Hide();
            }        
        }

    }
}
