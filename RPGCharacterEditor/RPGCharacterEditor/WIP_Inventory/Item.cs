using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinaleAssignment_CharacterEdit.WIP_Inventory
{
    public enum ItemType { consumable, miscellaneous, equipmentWeapon, equipmentHelm, equipmentChest }
    public enum ItemEffect {RestoreHp, RestoreMp,None,Damage, Defence}
    public class Item
    {
        public string mItemName { get; set; }
        public int mItemAmount { get; set; }
        public int mDam { get; set; }
        
        public bool mEquiped { get; set; }
        public ItemType mItemtype { get; set; }
        public ItemEffect mItemEff { get; set; }
        public int mAmountRestored { get; set; }
        public int mHealth { get; set; }
        public int mMP { get; set; }
        public int mDefense { get; set; }
        public int mStrength { get; set; }
        public int mIntelligence { get; set; }
        public int mDexterity { get; set; }

        public Item(string itemName, ItemType itemtype, ItemEffect itemEff, int itemAmount = 1, bool equiped = false,int AmountRestored = -1,int Damage = -1,
            int HP = -1,int MP = -1,int Defence = -1,int Str = -1,int Int =-1 ,int Dex= -1 )
        {
            this.mItemEff = itemEff;
            this.mItemName = itemName;
            this.mItemAmount = itemAmount;
            this.mEquiped = equiped;
            this.mAmountRestored = AmountRestored;
            this.mDefense = Defence;
            this.mDam = Damage;
            this.mItemtype = itemtype;
            this.mStrength = Str;
            this.mHealth = HP;
            this.mMP = MP;
            this.mDexterity = Dex;
            this.mIntelligence = Int;
            if(mItemtype == ItemType.equipmentWeapon || mItemtype == ItemType.equipmentHelm || mItemtype == ItemType.equipmentChest)
            {
                if(mStrength < 0)
                    mStrength = 0;
                if (mDexterity < 0)
                    mDexterity = 0;
                if (mIntelligence < 0)
                    mIntelligence = 0;
                if (mDefense < 0)
                    mDefense = 0;
                if (mDam < 0)
                    mDam = 0;
                if (mHealth < 0)
                    mHealth = 0;
                if (mMP < 0)
                    mMP = 0;
                
            }

        }
    }
}
