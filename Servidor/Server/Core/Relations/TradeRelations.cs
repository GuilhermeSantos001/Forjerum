using System;
using System.Reflection;

namespace FORJERUM
{
    class TradeRelations
    {
        //*********************************************************************************************
        // GetPlayerTradeOffersCount
        // Retorna o número de ofertas na troca
        //*********************************************************************************************
        public static int GetPlayerTradeOffersCount(int index)
        {
            //EXTEND
            if (Extensions.ExtensionApp.ExtendMyApp
                (MethodBase.GetCurrentMethod().Name, index) != null)
            {
                return Convert.ToInt32(Extensions.ExtensionApp.ExtendMyApp
                (MethodBase.GetCurrentMethod().Name, index));
            }

            //CÓDIGO
            int finalindex = 0;

            //Checa o slot que não possúi item
            for (int i = 1; i < Globals.MaxTradeOffers; i++)
            {
                if ((PStruct.tradeslot[index, i].item == Globals.NullItem) || (String.IsNullOrEmpty(PStruct.tradeslot[index, i].item)))
                {
                    finalindex = i;
                    break;
                }
            }

            if (finalindex == 0) { finalindex = 9; }

            int totalcount = finalindex - 1;

            return totalcount;
        }
        //*********************************************************************************************
        // GetFreeTradeOffer
        // Retorna um slot na oferta que esteja livre
        //*********************************************************************************************
        public static int GetFreeTradeOffer(int index)
        {
            //EXTEND
            if (Extensions.ExtensionApp.ExtendMyApp
                (MethodBase.GetCurrentMethod().Name, index) != null)
            {
                return Convert.ToInt32(Extensions.ExtensionApp.ExtendMyApp
                (MethodBase.GetCurrentMethod().Name, index));
            }

            //CÓDIGO
            int finalindex = 0;

            //Checa o slot que possúi o jogador
            for (int i = 1; i < Globals.MaxTradeOffers; i++)
            {
                if ((PStruct.tradeslot[index, i].item == Globals.NullItem) || (String.IsNullOrEmpty(PStruct.tradeslot[index, i].item)))
                {
                    finalindex = i;
                    break;
                }
            }

            return finalindex;
        }
        //*********************************************************************************************
        // GiveTradeTo
        // Entrega itens da troca para determinado jogador
        //*********************************************************************************************
        public static void GiveTradeTo(int index, int intrade)
        {
            //EXTEND
            if (Extensions.ExtensionApp.ExtendMyApp
                (MethodBase.GetCurrentMethod().Name, index, intrade) != null)
            {
                return;
            }

            //CÓDIGO
            if (PStruct.tempplayer[index].TradeG > 0)
            {
                PlayerRelations.GivePlayerGold(intrade, PStruct.tempplayer[index].TradeG);
            }

            for (int i = 1; i < Globals.MaxTradeOffers; i++)
            {
                if ((PStruct.tradeslot[index, i].item != Globals.NullItem) && (!String.IsNullOrEmpty(PStruct.tradeslot[index, i].item)))
                {
                    string[] splititem = PStruct.tradeslot[index, i].item.Split(',');

                    int itemNum = Convert.ToInt32(splititem[1]);
                    int itemType = Convert.ToInt32(splititem[0]);
                    int itemValue = Convert.ToInt32(splititem[2]);
                    int itemRefin = Convert.ToInt32(splititem[3]);
                    int itemExp = Convert.ToInt32(splititem[4]);

                    InventoryRelations.GiveItem(intrade, itemType, itemNum, itemValue, itemRefin, itemExp);

                    PStruct.tradeslot[index, i].item = Globals.NullItem;
                }
            }
        }
        //*********************************************************************************************
        // GiveTrade
        // Entrega itens da troca
        //*********************************************************************************************
        public static void GiveTrade(int index)
        {
            //EXTEND
            if (Extensions.ExtensionApp.ExtendMyApp
                (MethodBase.GetCurrentMethod().Name, index) != null)
            {
                return;
            }

            //CÓDIGO
            if (PStruct.tempplayer[index].TradeG > 0)
            {
                PlayerRelations.GivePlayerGold(index, PStruct.tempplayer[index].TradeG);
            }
            for (int i = 1; i < Globals.MaxTradeOffers; i++)
            {
                if ((PStruct.tradeslot[index, i].item != Globals.NullItem) && (!String.IsNullOrEmpty(PStruct.tradeslot[index, i].item)))
                {
                    string[] splititem = PStruct.tradeslot[index, i].item.Split(',');

                    int itemNum = Convert.ToInt32(splititem[1]);
                    int itemType = Convert.ToInt32(splititem[0]);
                    int itemValue = Convert.ToInt32(splititem[2]);
                    int itemRefin = Convert.ToInt32(splititem[3]);
                    int itemExp = Convert.ToInt32(splititem[4]);

                    InventoryRelations.GiveItem(index, itemType, itemNum, itemValue, itemRefin, itemExp);

                    PStruct.tradeslot[index, i].item = Globals.NullItem;
                }
            }
            SendData.Send_InvSlots(index, PStruct.player[index].SelectedChar);
        }
        //*********************************************************************************************
        // ClearTempTrade
        // Limpa dados da troca de determinado jogador
        //*********************************************************************************************
        public static void ClearTempTrade(int index)
        {
            //EXTEND
            if (Extensions.ExtensionApp.ExtendMyApp
                (MethodBase.GetCurrentMethod().Name, index) != null)
            {
                return;
            }

            //CÓDIGO
            PStruct.tempplayer[index].InTrade = 0;
            PStruct.tempplayer[index].TradeG = 0;
            PStruct.tempplayer[index].TradeStatus = 0;

            //Limpa slot de troca
            for (int i = 1; i < Globals.MaxTradeOffers; i++)
            {
                PStruct.tradeslot[index, i].item = Globals.NullItem;
            }
        }
    }
}
