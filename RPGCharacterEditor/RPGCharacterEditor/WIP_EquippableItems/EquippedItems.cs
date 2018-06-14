using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinaleAssignment_CharacterEdit.WIP_Inventory;

namespace RPGCharacterEditor.WIP_EquippableItems
{
    public enum EquipType
    {
        Weapon,
        Helmet,
        Chest
    }


    public class EquippedItems
    {
        public System.Windows.Controls.ComboBox box_weapon;
        public System.Windows.Controls.ComboBox box_helm;
        public System.Windows.Controls.ComboBox box_chest;
        public Inventory mInv;

        public List<Item> weaponlist = new List<Item>();
        public List<Item> helmlist = new List<Item>();
        public List<Item> chestlist = new List<Item>();

        public List<string> weaponlist_string = new List<string>();
        public List<string> helmlist_string = new List<string>();
        public List<string> chestlist_string = new List<string>();

        public Item equippedWeapon;
        public Item equippedHelm;
        public Item equippedChest;
        public Item item_null = new Item("<Empty>", ItemType.miscellaneous, ItemEffect.None, 0, false, 0, 0, 0, 0, 0, 0, 0, 0);

        public int weapon_index = 0;
        public int helm_index = 0;
        public int chest_index = 0;

        public int bonusHP = 0;
        public int bonusMP = 0;
        public int bonusDEF = 0;
        public int bonusSTR = 0;
        public int bonusINT = 0;
        public int bonusDEX = 0;


        public EquippedItems(ref Inventory inventory, System.Windows.Controls.ComboBox combo_weapon, System.Windows.Controls.ComboBox combo_helm, System.Windows.Controls.ComboBox combo_chest)
        {
            mInv = inventory;

            weaponlist.Add(item_null);
            helmlist.Add(item_null);
            chestlist.Add(item_null);

            equippedWeapon = weaponlist[0];
            equippedHelm = helmlist[0];
            equippedChest = chestlist[0];

            for (int i = 0; i < mInv.inventory.Count(); i++)
            {
                if(mInv.inventory[i].mItemtype == ItemType.equipmentWeapon)
                {
                    weaponlist.Add(mInv.inventory[i]);
                }
                if(mInv.inventory[i].mItemtype == ItemType.equipmentHelm)
                {
                    helmlist.Add(mInv.inventory[i]);
                }
                if(mInv.inventory[i].mItemtype == ItemType.equipmentChest)
                {
                    chestlist.Add(mInv.inventory[i]);
                }
            }
            box_weapon = combo_weapon;
            box_helm = combo_helm;
            box_chest = combo_chest;

            for (int i = 0; i < weaponlist.Count(); i++)
            {
                weaponlist_string.Add(weaponlist[i].mItemName);
            }
            for (int i = 0; i < helmlist.Count(); i++)
            {
                helmlist_string.Add(helmlist[i].mItemName);
            }
            for (int i = 0; i < chestlist.Count(); i++)
            {
                chestlist_string.Add(chestlist[i].mItemName);
            }

            box_weapon.ItemsSource = weaponlist_string;
            box_helm.ItemsSource = helmlist_string;
            box_chest.ItemsSource = chestlist_string;

        }

        public void Refresh()
        {
            weaponlist = new List<Item>();
            helmlist = new List<Item>();
            chestlist = new List<Item>();

            weaponlist.Add(item_null);
            helmlist.Add(item_null);
            chestlist.Add(item_null);

            for (int i = 0; i < mInv.inventory.Count(); i++)
            {
                if (mInv.inventory[i].mItemtype == ItemType.equipmentWeapon)
                {
                    weaponlist.Add(mInv.inventory[i]);
                }
                if (mInv.inventory[i].mItemtype == ItemType.equipmentHelm)
                {
                    helmlist.Add(mInv.inventory[i]);
                }
                if (mInv.inventory[i].mItemtype == ItemType.equipmentChest)
                {
                    chestlist.Add(mInv.inventory[i]);
                }
            }

            weaponlist_string = new List<string>();
            helmlist_string = new List<string>();
            chestlist_string = new List<string>();

            for (int i = 0; i < weaponlist.Count(); i++)
            {
                weaponlist_string.Add(weaponlist[i].mItemName);
            }
            for (int i = 0; i < helmlist.Count(); i++)
            {
                helmlist_string.Add(helmlist[i].mItemName);
            }
            for (int i = 0; i < chestlist.Count(); i++)
            {
                chestlist_string.Add(chestlist[i].mItemName);
            }

            box_weapon.ItemsSource = weaponlist_string;
            box_weapon.Items.Refresh();
            box_helm.ItemsSource = helmlist_string;
            box_helm.Items.Refresh();
            box_chest.ItemsSource = chestlist_string;
            box_chest.Items.Refresh();
        }

        public void CalculateStats()
        {
            bonusHP = equippedWeapon.mHealth + equippedHelm.mHealth + equippedChest.mHealth;
            bonusMP = equippedWeapon.mMP + equippedHelm.mMP + equippedChest.mMP;
            bonusDEF = equippedWeapon.mDefense + equippedHelm.mDefense + equippedChest.mDefense;
            bonusSTR = equippedWeapon.mStrength + equippedHelm.mStrength + equippedChest.mStrength;
            bonusINT = equippedWeapon.mIntelligence + equippedHelm.mIntelligence + equippedChest.mIntelligence;
            bonusDEX = equippedWeapon.mDexterity + equippedHelm.mDexterity + equippedChest.mDexterity;
        }
    }
}
