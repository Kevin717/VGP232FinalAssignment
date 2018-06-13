using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinaleAssignment_CharacterEdit.WIP_Inventory
{
    public class ItemList
    {
        List<Item> itemList;
        
        public ItemList()
        {
            itemList.Add(new Item("Potion", ItemType.consumable, ItemEffect.RestoreHp, 1, 20));
            itemList.Add(new Item("Ether", ItemType.consumable, ItemEffect.RestoreMp, 1, 10));
            itemList.Add(new Item("Leather Hide", ItemType.miscellaneous, ItemEffect.None, 1));
            itemList.Add(new Item("Rubber Object", ItemType.miscellaneous, ItemEffect.None, 1));
            itemList.Add(new Item("IronSword", ItemType.equipment, ItemEffect.Damage, 1, 20, false));
            itemList.Add(new Item("Leather Hat", ItemType.equipment, ItemEffect.Defence, 1, 10, false));



        }

        public List<Item> GetItems()
        {
            return itemList;
        }
    }
}
