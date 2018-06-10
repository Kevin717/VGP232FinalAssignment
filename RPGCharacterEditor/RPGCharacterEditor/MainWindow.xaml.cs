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
using System.IO;
using FinaleAssignment_CharacterEdit.WIP_SpriteEdit;

namespace RPGCharacterEditor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SpriteEditor sprite_editor = new SpriteEditor();
        public MainWindow()
        {
            InitializeComponent();

            //Kevin's Load
            sprite_editor.Load(image_body, image_hat, image_shirt, image_boots);
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
    }
}
