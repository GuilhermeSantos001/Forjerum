using System;
using System.Reflection;

namespace FORJERUM
{
    class PlayerRelations : Languages.LStruct
    {
        //*********************************************************************************************
        // GetPlayerCritical
        //*********************************************************************************************
        public static int GetPlayerCritical(int index)
        {
            //EXTEND
            if (Extensions.ExtensionApp.ExtendMyApp
                (MethodBase.GetCurrentMethod().Name, index) != null)
            {
                return Convert.ToInt32(Extensions.ExtensionApp.ExtendMyApp
                (MethodBase.GetCurrentMethod().Name, index));
            }

            //CÓDIGO
            double armorcrit = 0.0;
            double weaponcrit = 0.0;
            double shieldcrit = 0.0;
            double helmetcrit = 0.0;
            int level = 0;

            if (EquipmentRelations.GetPlayerArmor(index) != 0)
            {
                level = EquipmentRelations.GetPlayerArmorRefin(index);
                armorcrit = AStruct.armorparams[EquipmentRelations.GetPlayerArmor(index), 7].value + ((AStruct.armorparams[EquipmentRelations.GetPlayerArmor(index), 7].value / 100) * (level * 7));
            }
            if (EquipmentRelations.GetPlayerWeapon(index) != 0)
            {
                level = EquipmentRelations.GetPlayerWeaponRefin(index);
                weaponcrit = WStruct.weaponparams[EquipmentRelations.GetPlayerWeapon(index), 7].value + ((WStruct.weaponparams[EquipmentRelations.GetPlayerWeapon(index), 7].value / 100) * (level * 7));
            }
            if (EquipmentRelations.GetPlayerShield(index) != 0)
            {
                level = EquipmentRelations.GetPlayerShieldRefin(index);
                shieldcrit = AStruct.armorparams[EquipmentRelations.GetPlayerShield(index), 7].value + ((AStruct.armorparams[EquipmentRelations.GetPlayerShield(index), 7].value / 100) * (level * 7));
            }
            if (EquipmentRelations.GetPlayerHelmet(index) != 0)
            {
                level = EquipmentRelations.GetPlayerHelmetRefin(index);
                helmetcrit = AStruct.armorparams[EquipmentRelations.GetPlayerHelmet(index), 7].value + ((AStruct.armorparams[EquipmentRelations.GetPlayerHelmet(index), 7].value / 100) * (level * 7));
            }

            double totalitemcrit = armorcrit + weaponcrit + shieldcrit + helmetcrit;

            double watercrit = Convert.ToDouble(PStruct.character[index, PStruct.player[index].SelectedChar].Water) * 0.2;
            double dtotalcrit = totalitemcrit + watercrit;

            if (PStruct.character[index, PStruct.player[index].SelectedChar].ClassId == 4)
            {
                for (int i = 1; i < Globals.MaxPlayer_Skills; i++)
                {
                    if ((PStruct.skill[index, i].num == 48) && (PStruct.skill[index, i].level > 0))
                    {
                        dtotalcrit += (PStruct.skill[index, i].level * 1.5);
                        break;
                    }
                }
            }

            if (PStruct.tempplayer[index].SORE) { dtotalcrit = dtotalcrit / 2; }

            int totalcrit = Convert.ToInt32(dtotalcrit);

            return totalcrit;
        }
        //*********************************************************************************************
        // GetPlayerParry
        // Chance de bloqueio
        //*********************************************************************************************
        public static int GetPlayerParry(int index)
        {
            //EXTEND
            if (Extensions.ExtensionApp.ExtendMyApp
                (MethodBase.GetCurrentMethod().Name, index) != null)
            {
                return Convert.ToInt32(Extensions.ExtensionApp.ExtendMyApp
                (MethodBase.GetCurrentMethod().Name, index));
            }

            //CÓDIGO
            double armorparry = 0.0;
            double weaponparry = 0.0;
            double shieldparry = 0.0;
            double helmetparry = 0.0;
            int level = 0;

            if (EquipmentRelations.GetPlayerArmor(index) != 0)
            {
                level = EquipmentRelations.GetPlayerArmorRefin(index);
                armorparry = AStruct.armorparams[EquipmentRelations.GetPlayerArmor(index), 6].value + ((AStruct.armorparams[EquipmentRelations.GetPlayerArmor(index), 6].value / 100) * (level * 7));
            }
            if (EquipmentRelations.GetPlayerWeapon(index) != 0)
            {
                level = EquipmentRelations.GetPlayerWeaponRefin(index);
                weaponparry = WStruct.weaponparams[EquipmentRelations.GetPlayerWeapon(index), 6].value + ((WStruct.weaponparams[EquipmentRelations.GetPlayerWeapon(index), 6].value / 100) * (level * 7));
            }
            if (EquipmentRelations.GetPlayerShield(index) != 0)
            {
                level = EquipmentRelations.GetPlayerShieldRefin(index);
                shieldparry = AStruct.armorparams[EquipmentRelations.GetPlayerShield(index), 6].value + ((AStruct.armorparams[EquipmentRelations.GetPlayerShield(index), 6].value / 100) * (level * 7));
            }
            if (EquipmentRelations.GetPlayerHelmet(index) != 0)
            {
                level = EquipmentRelations.GetPlayerHelmetRefin(index);
                helmetparry = AStruct.armorparams[EquipmentRelations.GetPlayerHelmet(index), 6].value + ((AStruct.armorparams[EquipmentRelations.GetPlayerHelmet(index), 6].value / 100) * (level * 7));
            }

            double totalitemparry = armorparry + weaponparry + shieldparry + helmetparry;

            double windparry = Convert.ToDouble(PStruct.character[index, PStruct.player[index].SelectedChar].Wind) * 0.3;
            double dtotalparry = totalitemparry + windparry;
            if (PStruct.tempplayer[index].SORE) { dtotalparry = dtotalparry / 2; }
            int totalparry = Convert.ToInt32(dtotalparry);

            return totalparry;
        }
        //*********************************************************************************************
        // GetPlayerDefense
        //*********************************************************************************************
        public static int GetPlayerDefense(int index)
        {
            //EXTEND
            if (Extensions.ExtensionApp.ExtendMyApp
                (MethodBase.GetCurrentMethod().Name, index) != null)
            {
                return Convert.ToInt32(Extensions.ExtensionApp.ExtendMyApp
                (MethodBase.GetCurrentMethod().Name, index));
            }

            //CÓDIGO
            double armordef = 0.0;
            double weapondef = 0.0;
            double shielddef = 0.0;
            double helmetdef = 0.0;
            int level = 0;

            if (EquipmentRelations.GetPlayerArmor(index) != 0)
            {
                level = EquipmentRelations.GetPlayerArmorRefin(index);
                armordef = AStruct.armorparams[EquipmentRelations.GetPlayerArmor(index), 3].value + ((AStruct.armorparams[EquipmentRelations.GetPlayerArmor(index), 3].value / 100) * (level * 7));
            }
            if (EquipmentRelations.GetPlayerWeapon(index) != 0)
            {
                level = EquipmentRelations.GetPlayerWeaponRefin(index);
                weapondef = WStruct.weaponparams[EquipmentRelations.GetPlayerWeapon(index), 3].value + ((WStruct.weaponparams[EquipmentRelations.GetPlayerWeapon(index), 3].value / 100) * (level * 7));
            }
            if (EquipmentRelations.GetPlayerShield(index) != 0)
            {
                level = EquipmentRelations.GetPlayerShieldRefin(index);
                shielddef = AStruct.armorparams[EquipmentRelations.GetPlayerShield(index), 3].value + ((AStruct.armorparams[EquipmentRelations.GetPlayerShield(index), 3].value / 100) * (level * 7));
            }
            if (EquipmentRelations.GetPlayerHelmet(index) != 0)
            {
                level = EquipmentRelations.GetPlayerHelmetRefin(index);
                helmetdef = AStruct.armorparams[EquipmentRelations.GetPlayerHelmet(index), 3].value + ((AStruct.armorparams[EquipmentRelations.GetPlayerHelmet(index), 3].value / 100) * (level * 7));
            }

            double totalitemdef = armordef + weapondef + shielddef + helmetdef;

            double earthdefense = Convert.ToDouble(PStruct.character[index, PStruct.player[index].SelectedChar].Earth) * 0.05;
            double dtotaldefense = totalitemdef + earthdefense;
            if (PStruct.tempplayer[index].SORE) { dtotaldefense = dtotaldefense / 2; }
            int totaldefense = Convert.ToInt32(dtotaldefense);

            return totaldefense;
        }
        //*********************************************************************************************
        // GetPlayerMinAttack
        //*********************************************************************************************
        public static int GetPlayerMinAttack(int index)
        {
            //EXTEND
            if (Extensions.ExtensionApp.ExtendMyApp
                (MethodBase.GetCurrentMethod().Name, index) != null)
            {
                return Convert.ToInt32(Extensions.ExtensionApp.ExtendMyApp
                (MethodBase.GetCurrentMethod().Name, index));
            }

            //CÓDIGO
            double armoratk = 0.0;
            double weaponatk = 0.0;
            double shieldatk = 0.0;
            double helmetatk = 0.0;
            int level = 0;

            if (EquipmentRelations.GetPlayerArmor(index) != 0)
            {
                level = EquipmentRelations.GetPlayerArmorRefin(index);
                armoratk = AStruct.armorparams[EquipmentRelations.GetPlayerArmor(index), 0].value + ((AStruct.armorparams[EquipmentRelations.GetPlayerArmor(index), 0].value / 100) * (level * 7));
            }
            if (EquipmentRelations.GetPlayerWeapon(index) != 0)
            {
                level = EquipmentRelations.GetPlayerWeaponRefin(index);
                weaponatk = WStruct.weaponparams[EquipmentRelations.GetPlayerWeapon(index), 0].value + ((WStruct.weaponparams[EquipmentRelations.GetPlayerWeapon(index), 0].value / 100) * (level * 7));
            }
            if (EquipmentRelations.GetPlayerShield(index) != 0)
            {
                level = EquipmentRelations.GetPlayerShieldRefin(index);
                shieldatk = AStruct.armorparams[EquipmentRelations.GetPlayerShield(index), 0].value + ((AStruct.armorparams[EquipmentRelations.GetPlayerShield(index), 0].value / 100) * (level * 7));
            }
            if (EquipmentRelations.GetPlayerHelmet(index) != 0)
            {
                level = EquipmentRelations.GetPlayerHelmetRefin(index);
                helmetatk = AStruct.armorparams[EquipmentRelations.GetPlayerHelmet(index), 0].value + ((AStruct.armorparams[EquipmentRelations.GetPlayerHelmet(index), 0].value / 100) * (level * 7));
            }

            double totalitematk = armoratk + weaponatk + shieldatk + helmetatk;

            double earthatk = Convert.ToDouble(PStruct.character[index, PStruct.player[index].SelectedChar].Earth) * 0.7;

            if (PStruct.character[index, PStruct.player[index].SelectedChar].ClassId == 6)
            {
                for (int i = 1; i < Globals.MaxPlayer_Skills; i++)
                {
                    if ((PStruct.skill[index, i].num == 39) && (PStruct.skill[index, i].level > 0))
                    {
                        earthatk += Convert.ToDouble(PStruct.character[index, PStruct.player[index].SelectedChar].Wind) * 0.7;
                        break;
                    }
                }
            }

            if (PStruct.character[index, PStruct.player[index].SelectedChar].ClassId == 5)
            {
                for (int i = 1; i < Globals.MaxPlayer_Skills; i++)
                {
                    if ((PStruct.skill[index, i].num == 35) && (PStruct.skill[index, i].level > 0))
                    {
                        earthatk += Convert.ToDouble(PStruct.character[index, PStruct.player[index].SelectedChar].Earth) * 0.7;
                        break;
                    }
                }
            }

            double dtotalatk = totalitematk + earthatk;
            if (PStruct.tempplayer[index].SORE) { dtotalatk = dtotalatk / 2; }
            int totalatk = Convert.ToInt32(dtotalatk);

            return totalatk;
        }
        //*********************************************************************************************
        // GetPlayerMinMagic
        //*********************************************************************************************
        public static int GetPlayerMinMagic(int index)
        {
            //EXTEND
            if (Extensions.ExtensionApp.ExtendMyApp
                (MethodBase.GetCurrentMethod().Name, index) != null)
            {
                return Convert.ToInt32(Extensions.ExtensionApp.ExtendMyApp
                (MethodBase.GetCurrentMethod().Name, index));
            }

            //CÓDIGO
            double armoratk = 0.0;
            double weaponatk = 0.0;
            double shieldatk = 0.0;
            double helmetatk = 0.0;
            int level = 0;

            if (EquipmentRelations.GetPlayerArmor(index) != 0)
            {
                level = EquipmentRelations.GetPlayerArmorRefin(index);
                armoratk = AStruct.armorparams[EquipmentRelations.GetPlayerArmor(index), 1].value + ((AStruct.armorparams[EquipmentRelations.GetPlayerArmor(index), 1].value / 100) * (level * 7));
            }
            if (EquipmentRelations.GetPlayerWeapon(index) != 0)
            {
                level = EquipmentRelations.GetPlayerWeaponRefin(index);
                weaponatk = WStruct.weaponparams[EquipmentRelations.GetPlayerWeapon(index), 1].value + ((WStruct.weaponparams[EquipmentRelations.GetPlayerWeapon(index), 1].value / 100) * (level * 7));
            }
            if (EquipmentRelations.GetPlayerShield(index) != 0)
            {
                level = EquipmentRelations.GetPlayerShieldRefin(index);
                shieldatk = AStruct.armorparams[EquipmentRelations.GetPlayerShield(index), 1].value + ((AStruct.armorparams[EquipmentRelations.GetPlayerShield(index), 1].value / 100) * (level * 7));
            }
            if (EquipmentRelations.GetPlayerHelmet(index) != 0)
            {
                level = EquipmentRelations.GetPlayerHelmetRefin(index);
                helmetatk = AStruct.armorparams[EquipmentRelations.GetPlayerHelmet(index), 1].value + ((AStruct.armorparams[EquipmentRelations.GetPlayerHelmet(index), 1].value / 100) * (level * 7));
            }

            double totalitematk = armoratk + weaponatk + shieldatk + helmetatk;

            double earthatk = Convert.ToDouble(PStruct.character[index, PStruct.player[index].SelectedChar].Dark) * 0.6;

            if (PStruct.character[index, PStruct.player[index].SelectedChar].ClassId == 6)
            {
                for (int i = 1; i < Globals.MaxPlayer_Skills; i++)
                {
                    if ((PStruct.skill[index, i].num == 39) && (PStruct.skill[index, i].level > 0))
                    {
                        earthatk += Convert.ToDouble(PStruct.character[index, PStruct.player[index].SelectedChar].Wind) * 0.6;
                        break;
                    }
                }
            }

            if (PStruct.character[index, PStruct.player[index].SelectedChar].ClassId == 5)
            {
                for (int i = 1; i < Globals.MaxPlayer_Skills; i++)
                {
                    if ((PStruct.skill[index, i].num == 35) && (PStruct.skill[index, i].level > 0))
                    {
                        earthatk += Convert.ToDouble(PStruct.character[index, PStruct.player[index].SelectedChar].Earth) * 0.6;
                        break;
                    }
                }
            }

            double dtotalatk = totalitematk + earthatk;


            if (PStruct.character[index, PStruct.player[index].SelectedChar].ClassId == 1)
            {
                for (int i = 1; i < Globals.MaxPlayer_Skills; i++)
                {
                    if ((PStruct.skill[index, i].num == 46) && (PStruct.skill[index, i].level > 0))
                    {
                        dtotalatk += ((dtotalatk / 100) * (5 * PStruct.skill[index, i].level));
                        break;
                    }
                }
            }

            if (PStruct.tempplayer[index].SORE) { dtotalatk = dtotalatk / 2; }
            int totalatk = Convert.ToInt32(dtotalatk);

            return totalatk;
        }
        //*********************************************************************************************
        // GetPlayerMaxMagic
        //*********************************************************************************************
        public static int GetPlayerMaxMagic(int index)
        {
            //EXTEND
            if (Extensions.ExtensionApp.ExtendMyApp
                (MethodBase.GetCurrentMethod().Name, index) != null)
            {
                return Convert.ToInt32(Extensions.ExtensionApp.ExtendMyApp
                (MethodBase.GetCurrentMethod().Name, index));
            }

            //CÓDIGO
            double armoratk = 0.0;
            double weaponatk = 0.0;
            double shieldatk = 0.0;
            double helmetatk = 0.0;
            int level = 0;

            if (EquipmentRelations.GetPlayerArmor(index) != 0)
            {
                level = EquipmentRelations.GetPlayerArmorRefin(index);
                armoratk = AStruct.armorparams[EquipmentRelations.GetPlayerArmor(index), 4].value + ((AStruct.armorparams[EquipmentRelations.GetPlayerArmor(index), 4].value / 100) * (level * 7));
            }
            if (EquipmentRelations.GetPlayerWeapon(index) != 0)
            {
                level = EquipmentRelations.GetPlayerWeaponRefin(index);
                weaponatk = WStruct.weaponparams[EquipmentRelations.GetPlayerWeapon(index), 4].value + ((WStruct.weaponparams[EquipmentRelations.GetPlayerWeapon(index), 4].value / 100) * (level * 7));
            }
            if (EquipmentRelations.GetPlayerShield(index) != 0)
            {
                level = EquipmentRelations.GetPlayerShieldRefin(index);
                shieldatk = AStruct.armorparams[EquipmentRelations.GetPlayerShield(index), 4].value + ((AStruct.armorparams[EquipmentRelations.GetPlayerShield(index), 4].value / 100) * (level * 7));
            }
            if (EquipmentRelations.GetPlayerHelmet(index) != 0)
            {
                level = EquipmentRelations.GetPlayerHelmetRefin(index);
                helmetatk = AStruct.armorparams[EquipmentRelations.GetPlayerHelmet(index), 4].value + ((AStruct.armorparams[EquipmentRelations.GetPlayerHelmet(index), 4].value / 100) * (level * 7));
            }

            double totalitematk = armoratk + weaponatk + shieldatk + helmetatk;

            double earthatk = Convert.ToDouble(PStruct.character[index, PStruct.player[index].SelectedChar].Dark) * 1.5;

            if (PStruct.character[index, PStruct.player[index].SelectedChar].ClassId == 6)
            {
                for (int i = 1; i < Globals.MaxPlayer_Skills; i++)
                {
                    if ((PStruct.skill[index, i].num == 39) && (PStruct.skill[index, i].level > 0))
                    {
                        earthatk += Convert.ToDouble(PStruct.character[index, PStruct.player[index].SelectedChar].Wind) * 1.5;
                        break;
                    }
                }
            }

            if (PStruct.character[index, PStruct.player[index].SelectedChar].ClassId == 5)
            {
                for (int i = 1; i < Globals.MaxPlayer_Skills; i++)
                {
                    if ((PStruct.skill[index, i].num == 35) && (PStruct.skill[index, i].level > 0))
                    {
                        earthatk += Convert.ToDouble(PStruct.character[index, PStruct.player[index].SelectedChar].Earth) * 1.5;
                        break;
                    }
                }
            }

            double dtotalatk = totalitematk + earthatk;

            if (PStruct.character[index, PStruct.player[index].SelectedChar].ClassId == 1)
            {
                for (int i = 1; i < Globals.MaxPlayer_Skills; i++)
                {
                    if ((PStruct.skill[index, i].num == 46) && (PStruct.skill[index, i].level > 0))
                    {
                        dtotalatk += ((dtotalatk / 100) * (5 * PStruct.skill[index, i].level));
                        break;
                    }
                }
            }

            if (PStruct.tempplayer[index].SORE) { dtotalatk = dtotalatk / 2; }
            int totalatk = Convert.ToInt32(dtotalatk);
            return totalatk;
        }
        //*********************************************************************************************
        // GetPlayerMagicDef / Revisto pela última vez em 01/08/2016, criado por Allyson S. Bacon
        //*********************************************************************************************
        public static int GetPlayerMagicDef(int index)
        {
            //EXTEND
            if (Extensions.ExtensionApp.ExtendMyApp
                (MethodBase.GetCurrentMethod().Name, index) != null)
            {
                return Convert.ToInt32(Extensions.ExtensionApp.ExtendMyApp
                (MethodBase.GetCurrentMethod().Name, index));
            }

            //CÓDIGO
            double armoratk = 0.0;
            double weaponatk = 0.0;
            double shieldatk = 0.0;
            double helmetatk = 0.0;
            int level = 0;

            if (EquipmentRelations.GetPlayerArmor(index) != 0)
            {
                level = EquipmentRelations.GetPlayerArmorRefin(index);
                armoratk = AStruct.armorparams[EquipmentRelations.GetPlayerArmor(index), 5].value + ((AStruct.armorparams[EquipmentRelations.GetPlayerArmor(index), 5].value / 100) * (level * 7));
            }
            if (EquipmentRelations.GetPlayerWeapon(index) != 0)
            {
                level = EquipmentRelations.GetPlayerWeaponRefin(index);
                weaponatk = WStruct.weaponparams[EquipmentRelations.GetPlayerWeapon(index), 5].value + ((WStruct.weaponparams[EquipmentRelations.GetPlayerWeapon(index), 5].value / 100) * (level * 7));
            }
            if (EquipmentRelations.GetPlayerShield(index) != 0)
            {
                level = EquipmentRelations.GetPlayerShieldRefin(index);
                shieldatk = AStruct.armorparams[EquipmentRelations.GetPlayerShield(index), 5].value + ((AStruct.armorparams[EquipmentRelations.GetPlayerShield(index), 5].value / 100) * (level * 7));
            }
            if (EquipmentRelations.GetPlayerHelmet(index) != 0)
            {
                level = EquipmentRelations.GetPlayerHelmetRefin(index);
                helmetatk = AStruct.armorparams[EquipmentRelations.GetPlayerHelmet(index), 5].value + ((AStruct.armorparams[EquipmentRelations.GetPlayerHelmet(index), 5].value / 100) * (level * 7));
            }

            double totalitematk = armoratk + weaponatk + shieldatk + helmetatk;

            double earthatk = Convert.ToDouble(PStruct.character[index, PStruct.player[index].SelectedChar].Light) * 0.05;
            double dtotalatk = totalitematk + earthatk;
            if (PStruct.tempplayer[index].SORE) { dtotalatk = dtotalatk / 2; }
            int totalatk = Convert.ToInt32(dtotalatk);

            return totalatk;
        }
        //*********************************************************************************************
        // GetPlayerMaxAttack / Revisto pela última vez em 01/08/2016, criado por Allyson S. Bacon
        //*********************************************************************************************
        public static int GetPlayerMaxAttack(int index)
        {
            //EXTEND
            if (Extensions.ExtensionApp.ExtendMyApp
                (MethodBase.GetCurrentMethod().Name, index) != null)
            {
                return Convert.ToInt32(Extensions.ExtensionApp.ExtendMyApp
                (MethodBase.GetCurrentMethod().Name, index));
            }

            //CÓDIGO
            double armoratk = 0.0;
            double weaponatk = 0.0;
            double shieldatk = 0.0;
            double helmetatk = 0.0;
            int level = 0;

            if (EquipmentRelations.GetPlayerArmor(index) != 0)
            {
                level = EquipmentRelations.GetPlayerArmorRefin(index);
                armoratk = AStruct.armorparams[EquipmentRelations.GetPlayerArmor(index), 2].value + ((AStruct.armorparams[EquipmentRelations.GetPlayerArmor(index), 2].value / 100) * (level * 7));
            }
            if (EquipmentRelations.GetPlayerWeapon(index) != 0)
            {
                level = EquipmentRelations.GetPlayerWeaponRefin(index);
                weaponatk = WStruct.weaponparams[EquipmentRelations.GetPlayerWeapon(index), 2].value + ((WStruct.weaponparams[EquipmentRelations.GetPlayerWeapon(index), 2].value / 100) * (level * 7));
            }
            if (EquipmentRelations.GetPlayerShield(index) != 0)
            {
                level = EquipmentRelations.GetPlayerShieldRefin(index);
                shieldatk = AStruct.armorparams[EquipmentRelations.GetPlayerShield(index), 2].value + ((AStruct.armorparams[EquipmentRelations.GetPlayerShield(index), 2].value / 100) * (level * 7));
            }
            if (EquipmentRelations.GetPlayerHelmet(index) != 0)
            {
                level = EquipmentRelations.GetPlayerHelmetRefin(index);
                helmetatk = AStruct.armorparams[EquipmentRelations.GetPlayerHelmet(index), 2].value + ((AStruct.armorparams[EquipmentRelations.GetPlayerHelmet(index), 2].value / 100) * (level * 7));
            }

            double totalitematk = armoratk + weaponatk + shieldatk + helmetatk;

            double fireatk = Convert.ToDouble(PStruct.character[index, PStruct.player[index].SelectedChar].Fire) * 1.8;

            if (PStruct.character[index, PStruct.player[index].SelectedChar].ClassId == 6)
            {
                for (int i = 1; i < Globals.MaxPlayer_Skills; i++)
                {
                    if ((PStruct.skill[index, i].num == 39) && (PStruct.skill[index, i].level > 0))
                    {
                        fireatk += Convert.ToDouble(PStruct.character[index, PStruct.player[index].SelectedChar].Wind) * 1.8;
                        break;
                    }
                }
            }

            if (PStruct.character[index, PStruct.player[index].SelectedChar].ClassId == 5)
            {
                for (int i = 1; i < Globals.MaxPlayer_Skills; i++)
                {
                    if ((PStruct.skill[index, i].num == 35) && (PStruct.skill[index, i].level > 0))
                    {
                        fireatk += Convert.ToDouble(PStruct.character[index, PStruct.player[index].SelectedChar].Earth) * 1.8;
                        break;
                    }
                }
            }

            double dtotalatk = totalitematk + fireatk;
            if (PStruct.tempplayer[index].SORE) { dtotalatk = dtotalatk / 2; }
            int totalatk = Convert.ToInt32(dtotalatk);

            return totalatk;
        }
        //*********************************************************************************************
        // GivePlayerGold / Revisto pela última vez em 01/08/2016, criado por Allyson S. Bacon
        // Entrega determinada quantidade de ouro para determinado jogador
        //*********************************************************************************************
        public static void GivePlayerGold(int index, int gold)
        {
            //EXTEND
            if (Extensions.ExtensionApp.ExtendMyApp
                (MethodBase.GetCurrentMethod().Name, index, gold) != null)
            {
                return;
            }

            //CÓDIGO
            PStruct.character[index, PStruct.player[index].SelectedChar].Gold += gold;
            SendData.Send_PlayerG(index);
        }
        public static int GetPlayerOriunklatex(int index)
        {
            //EXTEND
            if (Extensions.ExtensionApp.ExtendMyApp
                (MethodBase.GetCurrentMethod().Name, index) != null)
            {
                return Convert.ToInt32(Extensions.ExtensionApp.ExtendMyApp
                (MethodBase.GetCurrentMethod().Name, index));
            }

            //CÓDIGO
            for (int i = 1; i < Globals.MaxInvSlot; i++)
            {
                string item = PStruct.invslot[index, i].item;
                string[] splititem = item.Split(',');

                int itemNum = Convert.ToInt32(splititem[1]);
                int itemValue = Convert.ToInt32(splititem[2]);
                if ((itemNum == 68) && (itemValue > 0)) { return i; }
            }

            return 0;
        }
        //*********************************************************************************************
        // GetPlayerExp / Revisto pela última vez em 01/08/2016, criado por Allyson S. Bacon
        // Entrega determinada quantidade de exp para determinado jogador
        //*********************************************************************************************
        public static void GivePlayerExp(int index, int exp)
        {
            //EXTEND
            if (Extensions.ExtensionApp.ExtendMyApp
                (MethodBase.GetCurrentMethod().Name, index, exp) != null)
            {
                return;
            }

            //CÓDIGO
            int PlayerX = PStruct.character[index, PStruct.player[index].SelectedChar].X;
            int PlayerY = PStruct.character[index, PStruct.player[index].SelectedChar].Y;
            int Map = PStruct.character[index, PStruct.player[index].SelectedChar].Map;
            PStruct.character[index, PStruct.player[index].SelectedChar].Exp += exp;

            string equipment = PStruct.character[index, PStruct.player[index].SelectedChar].Equipment;
            string[] equipdata = equipment.Split(',');
            string[] petdata = equipdata[4].Split(';');

            int petnum = Convert.ToInt32(petdata[0]);
            int petlvl = Convert.ToInt32(petdata[1]);
            int petexp = Convert.ToInt32(petdata[2]);

            if (petnum > 0)
            {
                petexp += exp;

                if (petexp >= LevelRelations.GetPetExpToNextLevel(index, petlvl))
                {
                    petexp -= LevelRelations.GetPetExpToNextLevel(index, petlvl);
                    petlvl += 1;
                    PStruct.character[index, PStruct.player[index].SelectedChar].Equipment = equipdata[0] + "," + equipdata[1] + "," + equipdata[2] + "," + equipdata[3] + "," + petnum + ";" + petlvl + ";" + petexp;
                    SendData.Send_ActionMsg(index, lang.pet_evolve, 3, PStruct.character[index, PStruct.player[index].SelectedChar].X, PStruct.character[index, PStruct.player[index].SelectedChar].Y, 1, 0, Map);
                    SendData.Send_PlayerEquipmentTo(index, index);
                }
                else
                {
                    //Enviar nova exp
                    PStruct.character[index, PStruct.player[index].SelectedChar].Equipment = equipdata[0] + "," + equipdata[1] + "," + equipdata[2] + "," + equipdata[3] + "," + petnum + ";" + petlvl + ";" + petexp;
                    SendData.Send_PlayerEquipmentTo(index, index);
                }
            }

            //Verificamos se ele subiu de nível
            if ((PStruct.character[index, PStruct.player[index].SelectedChar].Exp >= LevelRelations.GetExpToNextLevel(index)) && (PStruct.character[index, PStruct.player[index].SelectedChar].Level < 99))
            {
                PStruct.character[index, PStruct.player[index].SelectedChar].Exp -= LevelRelations.GetExpToNextLevel(index);
                PStruct.character[index, PStruct.player[index].SelectedChar].Level += 1;
                PStruct.character[index, PStruct.player[index].SelectedChar].Points += 5;
                PStruct.character[index, PStruct.player[index].SelectedChar].SkillPoints += 1;
                SendData.Send_ActionMsg(index, lang.level_up, 3, PStruct.character[index, PStruct.player[index].SelectedChar].X, PStruct.character[index, PStruct.player[index].SelectedChar].Y, 1, 0, Map);
                SendData.Send_Animation(Map, 1, index, 109);
                SendData.Send_PlayerExp(index);
                SendData.Send_PlayerLevel(index, index);
                SendData.Send_PlayerSkillPoints(index);
                SendData.Send_PlayerAtrTo(index);
            }
            else
            {
                //GetExpToNextLevel
                SendData.Send_PlayerExp(index);
                //Enviamos uma animação bonitinha de exp :D
                SendData.Send_ActionMsg(index, "+" + exp + lang.exp, 0, PlayerX, PlayerY, 1, 0, Map);
            }
        }
        //*********************************************************************************************
        // IsPlayerPremmy
        // Retorna se determinado jogador é assinante
        //*********************************************************************************************
        public static bool IsPlayerPremmy(int index)
        {
            //EXTEND
            if (Extensions.ExtensionApp.ExtendMyApp
                (MethodBase.GetCurrentMethod().Name, index) != null)
            {
                return Convert.ToBoolean(Extensions.ExtensionApp.ExtendMyApp
                (MethodBase.GetCurrentMethod().Name, index));
            }

            //CÓDIGO
            DateTime myDate = DateTime.Parse(PStruct.player[index].Premmy);
            int result = DateTime.Compare(myDate, DateTime.Now);

            if (result <= 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        //*********************************************************************************************
        // IsPlayerBanned
        // Retorna se o jogador está banido
        //*********************************************************************************************
        public static bool IsPlayerBanned(int index)
        {
            //EXTEND
            if (Extensions.ExtensionApp.ExtendMyApp
                (MethodBase.GetCurrentMethod().Name, index) != null)
            {
                return Convert.ToBoolean(Extensions.ExtensionApp.ExtendMyApp
                (MethodBase.GetCurrentMethod().Name, index));
            }

            //CÓDIGO
            DateTime myDate = DateTime.Parse(PStruct.player[index].Banned);
            int result = DateTime.Compare(myDate, DateTime.Now);

            if (result <= 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
