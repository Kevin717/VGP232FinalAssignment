using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinaleAssignment_CharacterEdit.WIP_Inventory
{
    public enum ItemType { consumable, miscellaneous, equipment }
    public enum ItemEffect {RestoreHp, RestoreMp,None,Damage, Defence}
    public class Item
    {
        public string mItemName { get; set; }
        public int mItemAmount { get; set; }
        public int mDam { get; set; }
        
        bool mEquiped { get; set; }
        public ItemType mItemtype { get; set; }
        public ItemEffect mItemEff { get; set; }
        public int mAmountRestored { get; set; }
        public float mHealth { get; set; }
        public float mMP { get; set; }
        public float mDefense { get; set; }
        public float mStrength { get; set; }
        public float mIntelligence { get; set; }
        public float mDexterity { get; set; }

        public Item(string itemName, ItemType itemtype, ItemEffect itemEff, int itemAmount = 1, bool equiped = false,int AmountRestored = -1,int Damage = -1,
            float HP = -1,float MP = -1,float Defence = -1,float Str = -1,float Int =-1 ,float Dex= -1 )
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
            if(mItemtype == ItemType.equipment)
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
