using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RPGCharacterEditor.WIP_Character;
using System.IO;
using System.Xml;
using System.Windows.Forms;
using FinaleAssignment_CharacterEdit.WIP_Inventory;

namespace FinaleAssignment_CharacterEdit.WIP_SaveLoad
{
    public class Serializer
    {
        public Serializer()
        {

        }

        public Character Load()
        {
            Character newCharacter;
            newCharacter = new Character();

            System.Xml.Serialization.XmlSerializer reader =
                 new System.Xml.Serialization.XmlSerializer(typeof(Character));
            string path;

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "xml files (*.xml)|*.xml";

            do
            {
                var dialogResult = openFileDialog.ShowDialog();
                if (openFileDialog.CheckPathExists && openFileDialog.FileName != string.Empty)
                {
                    path = openFileDialog.FileName;
                    FileStream mFile = File.OpenRead(path);

                    if (mFile.Length != 0)
                    {
                        object loadedData = reader.Deserialize(mFile);

                        newCharacter = (Character)loadedData;
                        mFile.Close();

                        return newCharacter;
                    }
                    if (dialogResult == DialogResult.Cancel)
                    {
                        return newCharacter;
                    }
                }
            } while (!openFileDialog.CheckPathExists);

            return newCharacter = null;
        }

        public void Save(Character character, string path)
        {
            System.Xml.Serialization.XmlSerializer writer =
                 new System.Xml.Serialization.XmlSerializer(typeof(Character));

            string fullPath = Directory.GetCurrentDirectory() + "\\" + path;

            FileStream file = File.Create(fullPath);
                writer.Serialize(file, character);

            file.Close();
        }
    }
}
