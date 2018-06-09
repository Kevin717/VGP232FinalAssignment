using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RPGCharacterEditor.WIP_CharacterStats;

namespace RPGCharacterEditor.WIP_Character
{
    public class Character
    {
        public BaseStatsManager baseStatsManager;

        public Character()
        {
            baseStatsManager = new BaseStatsManager();
        }
    }
}
