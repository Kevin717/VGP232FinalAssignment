using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinaleAssignment_CharacterEdit.WIP_Inventory
{
    class Inventory
    {

        
        List<Item> Listofitems;
        List<Item> inventory = new List<Item>();
        public Inventory(ItemList itemList)
        {
            Listofitems = itemList.GetItems();
            
            
        }

        

        //adding to player inventory through list id number
        public void Add(int itemID)
        {
            inventory.Add(Listofitems[itemID]); 
        }
    }
}
