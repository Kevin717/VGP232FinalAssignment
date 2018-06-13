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
        public List<Item> inventory = new List<Item>();

        public Inventory()
        {
        }

        public void Load(List<Item> AllItems)
        {
            allitems = AllItems;
        }

        //adding to player inventory through list id number
        public void Add(int itemID)
        {
            inventory.Add(allitems[itemID]);
        }
    }
}
