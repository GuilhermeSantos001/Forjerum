using System;
using System.Reflection;

namespace FORJERUM
{
    class InventoryRelations : Languages.LStruct
    {
        //*********************************************************************************************
        // GiveItem
        // Entrega determinado item para determinado jogador
        //*********************************************************************************************
        public static bool GiveItem(int index, int itemt, int itemn, int itemv, int itemr, int itemex)
        {
            //EXTEND
            if (Extensions.ExtensionApp.ExtendMyApp
                (MethodBase.GetCurrentMethod().Name, index, itemt, itemn, itemv, itemr, itemex) != null)
            {
                return Convert.ToBoolean(Extensions.ExtensionApp.ExtendMyApp
                (MethodBase.GetCurrentMethod().Name, index, itemt, itemn, itemv, itemr, itemex));
            }

            //CÓDIGO
            //Não entregar itens inválidos.
            if (itemn <= 0) { return false; }

            //Já temos os item? Se sim, adicionar.
            for (int i = 1; i < Globals.MaxInvSlot; i++)
            {
                string item = PStruct.invslot[index, i].item;
                string[] splititem = item.Split(',');

                int itemNum = Convert.ToInt32(splititem[1]);
                int itemType = Convert.ToInt32(splititem[0]);
                int itemValue = Convert.ToInt32(splititem[2]);
                int itemRefin = Convert.ToInt32(splititem[3]);
                int itemExp = Convert.ToInt32(splititem[4]);

                if ((itemn == itemNum) && (itemt == itemType) && (itemr == itemRefin) && (itemex == itemExp))
                {
                    PStruct.invslot[index, i].item = itemType + "," + itemNum + "," + (itemValue + itemv) + "," + itemRefin + "," + itemex;
                    return true;
                }
            }
            if (GetInvOpenSlot(index) > 0)
            {
                PStruct.invslot[index, GetInvOpenSlot(index)].item = itemt + "," + itemn + "," + itemv + "," + itemr + "," + itemex;
                return true;
            }
            else
            {
                SendData.Send_MsgToPlayer(index, lang.you_dont_have_inventory_slot, Globals.ColorRed, Globals.Msg_Type_Server);
                return false;
            }
        }
        //*********************************************************************************************
        // GetNumOfInvFreeSlots
        //*********************************************************************************************
        public static int GetNumOfInvFreeSlots(int index)
        {
            //EXTEND
            if (Extensions.ExtensionApp.ExtendMyApp
                (MethodBase.GetCurrentMethod().Name, index) != null)
            {
                return Convert.ToInt32(Extensions.ExtensionApp.ExtendMyApp
                (MethodBase.GetCurrentMethod().Name, index));
            }

            //CÓDIGO
            int count = 0;

            for (int i = 1; i < Globals.MaxInvSlot; i++)
            {
                if (PStruct.invslot[index, i].item == Globals.NullItem) { count += 1; }
            }
            return count;
        }
        //*********************************************************************************************
        // GetInvItemSlot
        // Retorna determinado item baseado no slot do inventário
        //*********************************************************************************************
        public static int GetInvItemSlot(int index, string item)
        {
            //EXTEND
            if (Extensions.ExtensionApp.ExtendMyApp
                (MethodBase.GetCurrentMethod().Name, index, item) != null)
            {
                return Convert.ToInt32(Extensions.ExtensionApp.ExtendMyApp
                (MethodBase.GetCurrentMethod().Name, index));
            }

            //CÓDIGO
            for (int i = 1; i < Globals.MaxInvSlot; i++)
            {
                if (PStruct.invslot[index, i].item == item) { return i; }
            }

            return 0;
        }
        //*********************************************************************************************
        // GetInvOpenSlot
        // Retorna slot livre no inventário de determinado jogador
        //*********************************************************************************************
        public static int GetInvOpenSlot(int index)
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
                if (PStruct.invslot[index, i].item == Globals.NullItem) { return i; }
            }

            return 0;
        }
        //*********************************************************************************************
        // PickItem
        //*********************************************************************************************
        public static bool PickItem(int index, int itemt, int itemn, int itemv, int itemr, int itemex = 0)
        {
            //EXTEND
            if (Extensions.ExtensionApp.ExtendMyApp
                (MethodBase.GetCurrentMethod().Name, index, itemt, itemn, itemv, itemr, itemex) != null)
            {
                return Convert.ToBoolean(Extensions.ExtensionApp.ExtendMyApp
                (MethodBase.GetCurrentMethod().Name, index, itemt, itemn, itemv, itemr, itemex));
            }

            //CÓDIGO
            for (int i = 1; i < Globals.MaxInvSlot; i++)
            {
                string item = PStruct.invslot[index, i].item;
                string[] splititem = item.Split(',');

                int itemNum = Convert.ToInt32(splititem[1]);
                int itemType = Convert.ToInt32(splititem[0]);
                int itemValue = Convert.ToInt32(splititem[2]);
                int itemRefin = Convert.ToInt32(splititem[3]);
                int itemExp = Convert.ToInt32(splititem[4]);

                if ((itemn == itemNum) && (itemt == itemType) && (itemr == itemRefin) && (itemv == itemValue))
                {
                    PStruct.invslot[index, i].item = Globals.NullItem;
                    return true;
                }

                if ((itemn == itemNum) && (itemt == itemType) && (itemr == itemRefin) && (itemv <= itemValue) && (itemex <= itemExp))
                {
                    PStruct.invslot[index, i].item = itemType + "," + itemNum + "," + (itemValue - itemv) + "," + itemRefin + "," + itemExp;
                    return true;
                }
            }
            return false;
        }
    }
}
