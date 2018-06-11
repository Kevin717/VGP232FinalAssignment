using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RPGCharacterEditor.WIP_CharacterStats;
using FinaleAssignment_CharacterEdit.WIP_Inventory;
namespace RPGCharacterEditor.WIP_Character
{
    public class Character
    {
        public BaseStatsManager baseStatsManager;

        public ItemList itemList;
        
        public int hat_index   { get; set; }
        public int shirt_index { get;set;  }
        public int boots_index { get;set;  }

        public Character()
        {
            baseStatsManager = new BaseStatsManager();
            itemList = new ItemList();
        }
    }
}
