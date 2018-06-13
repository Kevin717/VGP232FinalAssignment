using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinaleAssignment_CharacterEdit.WIP_Inventory
{
    public enum ItemType { consumable, miscellaneous, equipment }
    public enum ItemEffect {RestoreHp, RestoreMp,None,Damage, Defence}
    class Item
    {
        public string itemName;
        public int itemAmount;
        public int DamDef;
        bool equiped;
        public ItemType itemtype;
        public ItemEffect itemEff;
        public int amountRestored;
        //Consumable
        public Item(string itemName, ItemType itemtype,ItemEffect itemEff,int itemAmount,int amountRestored)
            {
                this.itemName = itemName;
                this.itemAmount = itemAmount;
                this.itemtype = itemtype;
                this.itemEff = itemEff;
                this.amountRestored = amountRestored;
            }

        //Equip
        public Item(string itemName, ItemType itemtype,ItemEffect itemEff,int itemAmount, int DamDef,bool equiped)
            {
                this.itemName = itemName;
                this.equiped = equiped;
                this.itemAmount = itemAmount;
                this.DamDef = DamDef;
                this.itemtype = itemtype;
                this.itemEff = itemEff;
                
            }
        //Misc
        public Item(string itemName, ItemType itemtype,ItemEffect itemEff,int itemAmount)
            {
                this.itemName = itemName;
                this.itemAmount = itemAmount;
                this.itemtype = itemtype;
                this.itemEff = itemEff;
                
            }
    }
}
