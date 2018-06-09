using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinaleAssignment_CharacterEdit.WIP_CharacterStats
{
    public class BaseStats
    {
        public BaseStats()
        {
            mName = string.Empty;
            mLevel = 0;
            mHealth = 0.0f;
            mMP = 0.0f;
            mDefense = 0.0f;
            mStrength = 0.0f;
            mIntelligence = 0.0f;
            mDexterity = 0.0f;
        }
        
        public string mName         { get; set; }
        public int mLevel           {get;set;}
        public float mHealth { get; set; }
        public float mMP            {get;set;}
        public float mDefense { get;set;}
        public float mStrength      {get;set;}
        public float mIntelligence  { get; set; }
        public float mDexterity     { get; set; }

    }
}
//The stats editor is responsible for setting the base stats a character have, such as:
//Names
//Character Level
//Health
//MP
//Defense
//Strength
//Intelligence
//Dexterity
