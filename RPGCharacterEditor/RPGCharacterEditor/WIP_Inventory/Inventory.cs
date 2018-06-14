using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinaleAssignment_CharacterEdit.WIP_Inventory
{
    public class Inventory
    {
        private List<Item> allitems;
        public List<Item> inventory { get; set; }

        public Inventory()
        {
            inventory = new List<Item>();
        }

        public void Load(List<Item> AllItems)
        {
            allitems = AllItems;
        }

        //adding to player inventory through list id number 
        public void Add(int itemID, int amount = 1)
        {
            bool itemexist = false;
            for (int i = 0; i < inventory.Count(); i++)
            {
                if(inventory[i].mItemName == allitems[itemID].mItemName) // Checking if the Item exist, if does increase amount
                {
                    inventory[i].mItemAmount += amount;
                    itemexist = true;
                    break;
                }
            }
            if(!itemexist)
            {
                inventory.Add(allitems[itemID]);
                inventory[inventory.Count - 1].mItemAmount = amount;
            }
        }
        
    }
}
