using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RPGCharacterEditor.WIP_Character;
using System.IO;
using System.Xml;

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
            System.Xml.Serialization.XmlSerializer reader =
                 new System.Xml.Serialization.XmlSerializer(typeof(Character));

            string path = Directory.GetCurrentDirectory() + "\\" + "LoadFILe.xml";

            FileStream mFile = File.OpenRead(path);
            object loadedData = reader.Deserialize(mFile);

            newCharacter = (Character)loadedData;
            mFile.Close();

            return newCharacter;
        }

        public void Save(Character character, string path)
        {
            System.Xml.Serialization.XmlSerializer writer =
                 new System.Xml.Serialization.XmlSerializer(typeof(Character));

            string fullPath = Directory.GetCurrentDirectory() + "\\"+ path;

            FileStream file = File.Create(fullPath);
            writer.Serialize(file, character);

            file.Close();

        }
    }
}
