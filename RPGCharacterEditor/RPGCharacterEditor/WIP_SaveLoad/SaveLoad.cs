using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RPGCharacterEditor.WIP_Character;
using System.IO;

namespace FinaleAssignment_CharacterEdit.WIP_SaveLoad
{
    public class Serializer
    {
        public Serializer()
        {

        }

        public void Load()
        {
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
