using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinaleAssignment_CharacterEdit.WIP_Inventory
{
    public class ItemList
    {
        List<Item> itemList = new List<Item>();
        
        public ItemList()
        {
            itemList.Add(new Item("Potion", ItemType.consumable, ItemEffect.RestoreHp, 1,false,20));
            itemList.Add(new Item("Ether", ItemType.consumable, ItemEffect.RestoreMp,1,false,10));
            itemList.Add(new Item("Leather Hide", ItemType.miscellaneous, ItemEffect.None ));
            itemList.Add(new Item("Rubber Object", ItemType.miscellaneous, ItemEffect.None));
            itemList.Add(new Item("Iron Sword", ItemType.equipmentWeapon, ItemEffect.None,1, false, -1, 30, 10, 0, 0, 15, 0, 5));
            itemList.Add(new Item("Leather Hat", ItemType.equipmentHelm, ItemEffect.None, 1, false, -1, 0, 50, 10, 30, 10, 5, 10));
            itemList.Add(new Item("Iron Platebody", ItemType.equipmentChest, ItemEffect.None, 1, false, -1, 0, 120, 10, 30, 10, 0, 0));
            itemList.Add(new Item("Steel Sword", ItemType.equipmentWeapon, ItemEffect.None, 1, false, -1, 0, 50, 10, 20, 60, 5, 10));


        }

        public List<Item> GetItems()
        {
            return itemList;
        }
    }
}
