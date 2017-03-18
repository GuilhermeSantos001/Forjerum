using System;
using System.Reflection;

namespace FORJERUM
{
    class BankRelations
    {
        //*********************************************************************************************
        // GiveBankItem
        // Entrega determinado item do banco para determinado jogador
        //*********************************************************************************************
        public static bool GiveBankItem(int index, int itemt, int itemn, int itemv, int itemr, int itemex)
        {
            //EXTEND
            if (Extensions.ExtensionApp.ExtendMyApp
                (MethodBase.GetCurrentMethod().Name, index, itemt, itemn, itemv, itemr, itemex) != null)
            {
                return Convert.ToBoolean(Extensions.ExtensionApp.ExtendMyApp
                (MethodBase.GetCurrentMethod().Name, index, itemt, itemn, itemv, itemr, itemex));
            }

            //CÓDIGO
            //Já temos os item? Se sim, adicionar.
            for (int i = 1; i < Globals.Max_BankSlots; i++)
            {

                int itemNum = PStruct.player[index].bankslot[i].num;
                int itemType = PStruct.player[index].bankslot[i].type;
                int itemValue = PStruct.player[index].bankslot[i].value;
                int itemRefin = PStruct.player[index].bankslot[i].refin;
                int itemExp = PStruct.player[index].bankslot[i].exp;

                if ((itemn == itemNum) && (itemt == itemType) && (itemr == itemRefin) && (itemex == itemExp))
                {
                    PStruct.player[index].bankslot[i].value += itemv;
                    return true;
                }
            }
            if (GetBankOpenSlot(index) > 0)
            {
                int openslot = GetBankOpenSlot(index);
                PStruct.player[index].bankslot[openslot].type = itemt;
                PStruct.player[index].bankslot[openslot].num = itemn;
                PStruct.player[index].bankslot[openslot].value = itemv;
                PStruct.player[index].bankslot[openslot].refin = itemr;
                PStruct.player[index].bankslot[openslot].exp = itemex;
                return true;
            }
            else
            {
                return false;
            }
        }
        //*********************************************************************************************
        // GetBankOpenSlot
        // Retorna slot livre no banco de determinado jogador
        //*********************************************************************************************
        public static int GetBankOpenSlot(int index)
        {
            //EXTEND
            if (Extensions.ExtensionApp.ExtendMyApp
                (MethodBase.GetCurrentMethod().Name, index) != null)
            {
                return Convert.ToInt32(Extensions.ExtensionApp.ExtendMyApp
                (MethodBase.GetCurrentMethod().Name, index));
            }

            //CÓDIGO
            for (int i = 1; i < Globals.Max_BankSlots; i++)
            {
                if (PStruct.player[index].bankslot[i].num == 0) { return i; }
            }

            return 0;
        }
        //*********************************************************************************************
        // PickBankItem
        // Pegar determinado item do banco
        //*********************************************************************************************
        public static bool PickBankItem(int index, int itemt, int itemn, int itemv, int itemr)
        {
            //EXTEND
            if (Extensions.ExtensionApp.ExtendMyApp
                (MethodBase.GetCurrentMethod().Name, index, itemt, itemn, itemv, itemr) != null)
            {
                return Convert.ToBoolean(Extensions.ExtensionApp.ExtendMyApp
                (MethodBase.GetCurrentMethod().Name, index, itemt, itemn, itemv, itemr));
            }

            //CÓDIGO
            for (int i = 1; i < Globals.Max_BankSlots; i++)
            {
                int itemNum = PStruct.player[index].bankslot[i].num;
                int itemType = PStruct.player[index].bankslot[i].type;
                int itemValue = PStruct.player[index].bankslot[i].value;
                int itemRefin = PStruct.player[index].bankslot[i].refin;

                if ((itemn == itemNum) && (itemt == itemType) && (itemr == itemRefin) && (itemv == itemValue))
                {
                    PStruct.player[index].bankslot[i].type = 0;
                    PStruct.player[index].bankslot[i].num = 0;
                    PStruct.player[index].bankslot[i].value = 0;
                    PStruct.player[index].bankslot[i].refin = 0;
                    PStruct.player[index].bankslot[i].exp = 0;

                    return true;
                }

                if ((itemn == itemNum) && (itemt == itemType) && (itemr == itemRefin) && (itemv <= itemValue))
                {
                    PStruct.player[index].bankslot[i].type = 0;
                    PStruct.player[index].bankslot[i].num = 0;
                    PStruct.player[index].bankslot[i].value -= itemv;
                    PStruct.player[index].bankslot[i].refin = 0;
                    PStruct.player[index].bankslot[i].exp = 0;
                    return true;
                }
            }
            return false;
        }
    }
}
