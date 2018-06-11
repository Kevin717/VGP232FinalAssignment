using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Media;
using System.Windows.Media.Imaging;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
//using FinaleAssignment_CharacterEdit.WIP_CharacterStats;

namespace FinaleAssignment_CharacterEdit.WIP_SpriteEdit
{
    class SpriteEditor
    {
        public List<String> hatlist = new List<String>();
        public List<String> shirtlist = new List<String>();
        public List<String> bootslist = new List<String>();

        public int hat_index;
        public int shirt_index;
        public int boots_index;

        public string path_images;
        public string path_body;

        public string path_hat;
        public string path_shirt;
        public string path_boots;

        private System.Windows.Controls.Image img_body;

        private System.Windows.Controls.Image img_hat;
        private System.Windows.Controls.Image img_shirt;
        private System.Windows.Controls.Image img_boots;

        public SpriteEditor(int Hat = 0, int Shirt = 0, int Boots = 0)
        {
            hat_index = Hat;
            shirt_index = Shirt;
            boots_index = Boots;
        }


        public void Load(System.Windows.Controls.Image image_body, System.Windows.Controls.Image image_hat, System.Windows.Controls.Image image_shirt, System.Windows.Controls.Image image_boots)
        {
            img_body = image_body;

            img_hat = image_hat;
            img_shirt = image_shirt;
            img_boots = image_boots;

            path_images = Directory.GetCurrentDirectory() + @"\Assets\Images\";

            path_body = path_images + "SpritePreview_Body.png";
            try
            {
                image_body.Source = new BitmapImage(new Uri(path_body));
            }
            catch
            {
                string mpath;
                System.Windows.Forms.MessageBox.Show("Cannot locate SpritePreivewBody.png directory, please select body image.");
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "png files (*.png)|*.png";
                openFileDialog.ShowDialog();
                mpath = openFileDialog.FileName;
                if(!Directory.Exists(path_images))
                {
                    Directory.CreateDirectory(path_images);
                }
                File.Copy(mpath, path_body);
                image_body.Source = new BitmapImage(new Uri(path_body));
            }


            path_hat = path_images + "SpritePreview_Hat_";
            path_shirt = path_images + "SpritePreview_Shirt_";
            path_boots = path_images + "Sprite_Preview_Boots_";

            for (int i = 0; File.Exists(path_hat + i.ToString() + ".png"); i++) //Initialize hat list
            {
                hatlist.Add(path_hat + i.ToString() + ".png");
            }
            try
            {
                if (File.Exists(hatlist[hat_index]))
                {image_hat.Source = new BitmapImage(new Uri(hatlist[hat_index]));};
            }
            catch
            {

            }
            for (int i = 0; File.Exists(path_shirt + i.ToString() + ".png"); i++) //Initialize shirt list
            {
                shirtlist.Add(path_shirt + i.ToString() + ".png");
            }
            try
            {
                if (File.Exists(shirtlist[shirt_index])) { image_shirt.Source = new BitmapImage(new Uri(shirtlist[shirt_index])); }
            }
            catch
            {

            }
            for (int i = 0; File.Exists(path_boots + i.ToString() + ".png"); i++) //Initialize boots list
            {
                bootslist.Add(path_boots + i.ToString() + ".png");
            }
            try
            {
                if (File.Exists(bootslist[boots_index])) { image_boots.Source = new BitmapImage(new Uri(bootslist[boots_index])); }
            }
            catch
            {

            }
        }

        public void Refresh(RPGCharacterEditor.WIP_Character.Character mCharacter)
        {
            try
            {
                if (File.Exists(hatlist[mCharacter.hat_index]))
                {
                    img_hat.Source = new BitmapImage(new Uri(hatlist[mCharacter.hat_index]));
                }
            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show(e + "\nThere is no elements initalized in hatlist[" + mCharacter.hat_index + "]");
            }
            try
            {
                if (File.Exists(shirtlist[mCharacter.shirt_index]))
                {
                    img_shirt.Source = new BitmapImage(new Uri(shirtlist[mCharacter.shirt_index]));
                }
            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show(e + "\nThere is no elements initalized in shirtlist[" + mCharacter.shirt_index + "]");
            }
            try
            {
                if (File.Exists(bootslist[mCharacter.boots_index]))
                {
                    img_boots.Source = new BitmapImage(new Uri(bootslist[mCharacter.boots_index]));
                }
            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show(e + "\nThere is no elements initalized in bootslist[" + mCharacter.boots_index + "]");
            }
        }

        //Hats functions
        public void Hat_Next()
        {
            ++hat_index;
            try
            {
                if (hat_index < hatlist.Count() && File.Exists(hatlist[hat_index]))
                {
                    img_hat.Source = new BitmapImage(new Uri(hatlist[hat_index]));
                }
                else
                {
                    hat_index = 0;
                    if (File.Exists(hatlist[hat_index]))
                    {
                        img_hat.Source = new BitmapImage(new Uri(hatlist[hat_index]));
                    }
                }
            }
            catch
            {

            }
        }

        public void Hat_Prev()
        {
            --hat_index;
            try
            {
                if (hat_index >= 0 && File.Exists(hatlist[hat_index]))
                {
                    img_hat.Source = new BitmapImage(new Uri(hatlist[hat_index]));
                }
                else
                {
                    hat_index = hatlist.Count - 1;
                    if (File.Exists(hatlist[hat_index]))
                    {
                        img_hat.Source = new BitmapImage(new Uri(hatlist[hat_index]));
                    }
                }
            }
            catch
            {

            }
        }

        public void Hat_Add()
        {
            string mpath;
            OpenFileDialog mfiledialog = new OpenFileDialog();
            mfiledialog.Filter = "png files (*.png)|*.png";
            mfiledialog.ShowDialog();
            mpath = mfiledialog.FileName;
            if (File.Exists(mpath))
            {
                File.Copy(mpath, path_hat + hatlist.Count + ".png", true);
                hatlist.Add(path_hat + hatlist.Count + ".png");
            }
        }

        //Shirts functions
        public void Shirt_Next()
        {
            ++shirt_index;
            try
            {
                if (shirt_index < shirtlist.Count() && File.Exists(shirtlist[shirt_index]))
                {
                    img_shirt.Source = new BitmapImage(new Uri(shirtlist[shirt_index]));
                }
                else
                {
                    shirt_index = 0;
                    if (File.Exists(shirtlist[shirt_index]))
                    {
                        img_shirt.Source = new BitmapImage(new Uri(shirtlist[shirt_index]));
                    }
                }
            }
            catch
            {

            }
        }

        public void Shirt_Prev()
        {
            --shirt_index;
            try
            {
                if (shirt_index >= 0 && File.Exists(shirtlist[shirt_index]))
                {
                    img_shirt.Source = new BitmapImage(new Uri(shirtlist[shirt_index]));
                }
                else
                {
                    shirt_index = shirtlist.Count - 1;
                    if (File.Exists(shirtlist[shirt_index]))
                    {
                        img_shirt.Source = new BitmapImage(new Uri(shirtlist[shirt_index]));
                    }
                }
            }
            catch
            {

            }
        }

        public void Shirt_Add()
        {
            string mpath;
            OpenFileDialog mfiledialog = new OpenFileDialog();
            mfiledialog.Filter = "png files (*.png)|*.png";
            mfiledialog.ShowDialog();
            mpath = mfiledialog.FileName;
            if (File.Exists(mpath))
            {
                File.Copy(mpath, path_shirt + shirtlist.Count + ".png", true);
                shirtlist.Add(path_shirt + shirtlist.Count + ".png");
            }
        }

        //Boots functions
        public void Boots_Next()
        {
            ++boots_index;
            try
            {
                if (boots_index < bootslist.Count() && File.Exists(bootslist[boots_index]))
                {
                    img_boots.Source = new BitmapImage(new Uri(bootslist[boots_index]));
                }
                else
                {
                    boots_index = 0;
                    if (File.Exists(bootslist[boots_index]))
                    {
                        img_boots.Source = new BitmapImage(new Uri(bootslist[boots_index]));
                    }
                }
            }
            catch
            {

            }
        }

        public void Boots_Prev()
        {
            --boots_index;
            try
            {
                if (boots_index >= 0 && File.Exists(bootslist[boots_index]))
                {
                    img_boots.Source = new BitmapImage(new Uri(bootslist[boots_index]));
                }
                else
                {
                    boots_index = bootslist.Count - 1;
                    if (File.Exists(bootslist[boots_index]))
                    {
                        img_boots.Source = new BitmapImage(new Uri(bootslist[boots_index]));
                    }
                }
            }
            catch
            {

            }
        }

        public void Boots_Add()
        {
            string mpath;
            OpenFileDialog mfiledialog = new OpenFileDialog();
            mfiledialog.Filter = "png files (*.png)|*.png";
            mfiledialog.ShowDialog();
            mpath = mfiledialog.FileName;
            if (File.Exists(mpath))
            {
                File.Copy(mpath, path_boots + bootslist.Count + ".png", true);
                bootslist.Add(path_boots + bootslist.Count + ".png");
            }
        }
    }
}
