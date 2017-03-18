using System;
using System.Reflection;

namespace FORJERUM
{
    class EquipmentRelations
    {
        //*********************************************************************************************
        // GetPlayerHelmet
        // Retorna o equipamento superior do jogador
        //*********************************************************************************************
        public static int GetPlayerHelmet(int index)
        {
            //EXTEND
            if (Extensions.ExtensionApp.ExtendMyApp
                (MethodBase.GetCurrentMethod().Name, index) != null)
            {
                return Convert.ToInt32(Extensions.ExtensionApp.ExtendMyApp
                (MethodBase.GetCurrentMethod().Name, index));
            }

            //CÓDIGO
            string[] splited = PStruct.character[index, PStruct.player[index].SelectedChar].Equipment.Split(',');

            int Helmet = Convert.ToInt32(splited[0].Split(';')[0]);
            return Helmet;
        }
        //*********************************************************************************************
        // GetPlayerArmor
        // Retorna a armadura do jogador
        //*********************************************************************************************
        public static int GetPlayerArmor(int index)
        {
            //EXTEND
            if (Extensions.ExtensionApp.ExtendMyApp
                (MethodBase.GetCurrentMethod().Name, index) != null)
            {
                return Convert.ToInt32(Extensions.ExtensionApp.ExtendMyApp
                (MethodBase.GetCurrentMethod().Name, index));
            }

            //CÓDIGO
            string[] splited = PStruct.character[index, PStruct.player[index].SelectedChar].Equipment.Split(',');
            int Armor = Convert.ToInt32(splited[1].Split(';')[0]);
            return Armor;
        }
        //*********************************************************************************************
        // GetPlayerWeapon
        // Retorna a arma do jogador
        //*********************************************************************************************
        public static int GetPlayerWeapon(int index)
        {
            //EXTEND
            if (Extensions.ExtensionApp.ExtendMyApp
                (MethodBase.GetCurrentMethod().Name, index) != null)
            {
                return Convert.ToInt32(Extensions.ExtensionApp.ExtendMyApp
                (MethodBase.GetCurrentMethod().Name, index));
            }

            //CÓDIGO
            string[] splited = PStruct.character[index, PStruct.player[index].SelectedChar].Equipment.Split(',');

            int Weapon = Convert.ToInt32(splited[2].Split(';')[0]);
            return Weapon;
        }
        //*********************************************************************************************
        // GetPlayerShield
        // Retorna o escudo do jogador
        //*********************************************************************************************
        public static int GetPlayerShield(int index)
        {
            //EXTEND
            if (Extensions.ExtensionApp.ExtendMyApp
                (MethodBase.GetCurrentMethod().Name, index) != null)
            {
                return Convert.ToInt32(Extensions.ExtensionApp.ExtendMyApp
                (MethodBase.GetCurrentMethod().Name, index));
            }

            //CÓDIGO
            string[] splited = PStruct.character[index, PStruct.player[index].SelectedChar].Equipment.Split(',');

            int Shield = Convert.ToInt32(splited[3].Split(';')[0]);
            return Shield;
        }
        //*********************************************************************************************
        // GetPlayerHelmetRefin
        //*********************************************************************************************
        public static int GetPlayerHelmetRefin(int index)
        {
            //EXTEND
            if (Extensions.ExtensionApp.ExtendMyApp
                (MethodBase.GetCurrentMethod().Name, index) != null)
            {
                return Convert.ToInt32(Extensions.ExtensionApp.ExtendMyApp
                (MethodBase.GetCurrentMethod().Name, index));
            }

            //CÓDIGO
            string[] splited = PStruct.character[index, PStruct.player[index].SelectedChar].Equipment.Split(',');

            int Helmet = Convert.ToInt32(splited[0].Split(';')[1]);
            return Helmet;
        }
        //*********************************************************************************************
        // GetPlayerArmorRefin
        //*********************************************************************************************
        public static int GetPlayerArmorRefin(int index)
        {
            //EXTEND
            if (Extensions.ExtensionApp.ExtendMyApp
                (MethodBase.GetCurrentMethod().Name, index) != null)
            {
                return Convert.ToInt32(Extensions.ExtensionApp.ExtendMyApp
                (MethodBase.GetCurrentMethod().Name, index));
            }

            //CÓDIGO
            string[] splited = PStruct.character[index, PStruct.player[index].SelectedChar].Equipment.Split(',');
            int Armor = Convert.ToInt32(splited[1].Split(';')[1]);
            return Armor;
        }
        //*********************************************************************************************
        // GetPlayerWeaponRefin
        //*********************************************************************************************
        public static int GetPlayerWeaponRefin(int index)
        {
            //EXTEND
            if (Extensions.ExtensionApp.ExtendMyApp
                (MethodBase.GetCurrentMethod().Name, index) != null)
            {
                return Convert.ToInt32(Extensions.ExtensionApp.ExtendMyApp
                (MethodBase.GetCurrentMethod().Name, index));
            }

            //CÓDIGO
            string[] splited = PStruct.character[index, PStruct.player[index].SelectedChar].Equipment.Split(',');

            int Weapon = Convert.ToInt32(splited[2].Split(';')[1]);
            return Weapon;
        }
        //*********************************************************************************************
        // GetPlayerShieldRefin
        //*********************************************************************************************
        public static int GetPlayerShieldRefin(int index)
        {
            //EXTEND
            if (Extensions.ExtensionApp.ExtendMyApp
                (MethodBase.GetCurrentMethod().Name, index) != null)
            {
                return Convert.ToInt32(Extensions.ExtensionApp.ExtendMyApp
                (MethodBase.GetCurrentMethod().Name, index));
            }

            //CÓDIGO
            string[] splited = PStruct.character[index, PStruct.player[index].SelectedChar].Equipment.Split(',');

            int Shield = Convert.ToInt32(splited[3].Split(';')[1]);
            return Shield;
        }
    }
}
