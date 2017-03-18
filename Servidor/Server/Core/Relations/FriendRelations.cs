using System;
using System.Reflection;

namespace FORJERUM
{
    class FriendRelations
    {
        //*********************************************************************************************
        // GetFriendOpenSlot
        //*********************************************************************************************
        public static int GetFriendOpenSlot(int index)
        {
            //EXTEND
            if (Extensions.ExtensionApp.ExtendMyApp
                (MethodBase.GetCurrentMethod().Name, index) != null)
            {
                return Convert.ToInt32(Extensions.ExtensionApp.ExtendMyApp
                (MethodBase.GetCurrentMethod().Name, index));
            }

            //CÓDIGO
            for (int i = 1; i < Globals.Max_Friends; i++)
            {
                if (String.IsNullOrEmpty(PStruct.player[index].friend[i].name))
                {
                    return i;
                }
            }
            return 0;
        }
        //*********************************************************************************************
        // FriendNameExist
        //*********************************************************************************************
        public static bool FriendNameExist(int index, string name)
        {
            //EXTEND
            if (Extensions.ExtensionApp.ExtendMyApp
                (MethodBase.GetCurrentMethod().Name, index, name) != null)
            {
                return Convert.ToBoolean(Extensions.ExtensionApp.ExtendMyApp
                (MethodBase.GetCurrentMethod().Name, index, name));
            }

            //CÓDIGO
            for (int i = 1; i < Globals.Max_Friends; i++)
            {
                if (PStruct.player[index].friend[i].name == name)
                {
                    return true;
                }
            }
            return false;
        }
        //*********************************************************************************************
        // FriendIsOnline
        //*********************************************************************************************
        public static bool FriendIsOnline(int index, int friendnum)
        {
            //EXTEND
            if (Extensions.ExtensionApp.ExtendMyApp
                (MethodBase.GetCurrentMethod().Name, index, friendnum) != null)
            {
                return Convert.ToBoolean(Extensions.ExtensionApp.ExtendMyApp
                (MethodBase.GetCurrentMethod().Name, index, friendnum));
            }

            //CÓDIGO
            for (int i = 1; i <= Globals.Player_Highindex; i++)
            {
                if (PStruct.player[index].friend[friendnum].name == PStruct.character[i, PStruct.player[i].SelectedChar].CharacterName)
                {
                    return true;
                }
            }
            return false;
        }
        //*********************************************************************************************
        // GetPlayerFriendsCount
        //*********************************************************************************************
        public static int GetPlayerFriendsCount(int index)
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
            for (int i = 1; i < Globals.Max_Friends; i++)
            {
                if (!String.IsNullOrEmpty(PStruct.player[index].friend[i].name))
                {
                    count += 1;
                }
                else
                {
                    break;
                }
            }
            return count;
        }
        //*********************************************************************************************
        // RefreshFriends
        // Atualiza a lista de amigos de determinado jogador
        //*********************************************************************************************
        public static void RefreshFriends(int index)
        {
            //EXTEND
            if (Extensions.ExtensionApp.ExtendMyApp
                (MethodBase.GetCurrentMethod().Name, index) != null)
            {
                return;
            }

            //CÓDIGO
            int friendscount = GetPlayerFriendsCount(index);
            for (int i = 1; i <= friendscount; i++)
            {
                //Analisar todos os jogadores online
                for (int y = 0; y <= Globals.Player_Highindex; y++)
                {
                    if (PStruct.player[index].friend[i].name == PStruct.character[y, PStruct.player[y].SelectedChar].CharacterName)
                    {
                        PStruct.player[index].friend[i].sprite = PStruct.character[y, PStruct.player[y].SelectedChar].Sprite;
                        PStruct.player[index].friend[i].sprite_index = PStruct.character[y, PStruct.player[y].SelectedChar].Spriteindex;
                        PStruct.player[index].friend[i].classid = PStruct.character[y, PStruct.player[y].SelectedChar].ClassId;
                        PStruct.player[index].friend[i].level = PStruct.character[y, PStruct.player[y].SelectedChar].Level;
                        PStruct.player[index].friend[i].guildname = GStruct.guild[PStruct.character[y, PStruct.player[y].SelectedChar].Guild].name;
                    }
                }
            }
            SendData.Send_PlayerFriends(index);
        }
        //*********************************************************************************************
        // AddFriend
        // Adiciona um jogador na lista de amigos de outro
        //*********************************************************************************************
        public static bool AddFriend(int index, int friendnum)
        {
            //EXTEND
            if (Extensions.ExtensionApp.ExtendMyApp
                (MethodBase.GetCurrentMethod().Name, index, friendnum) != null)
            {
                return Convert.ToBoolean(Extensions.ExtensionApp.ExtendMyApp
                (MethodBase.GetCurrentMethod().Name, index, friendnum));
            }

            //CÓDIGO
            //Valor principal
            int friendslot = GetFriendOpenSlot(index);
            if (friendslot <= 0) { return false; }

            //Verificar se já não está na lista
            if (FriendNameExist(index, PStruct.character[friendnum, PStruct.player[friendnum].SelectedChar].CharacterName))
            {
                return false;
            }

            //Tentar adicionar
            try
            {
                PStruct.player[index].friend[friendslot].name = PStruct.character[friendnum, PStruct.player[friendnum].SelectedChar].CharacterName;
                PStruct.player[index].friend[friendslot].sprite = PStruct.character[friendnum, PStruct.player[friendnum].SelectedChar].Sprite;
                PStruct.player[index].friend[friendslot].sprite_index = PStruct.character[friendnum, PStruct.player[friendnum].SelectedChar].Spriteindex;
                PStruct.player[index].friend[friendslot].classid = PStruct.character[friendnum, PStruct.player[friendnum].SelectedChar].ClassId;
                PStruct.player[index].friend[friendslot].level = PStruct.character[friendnum, PStruct.player[friendnum].SelectedChar].Level;
                PStruct.player[index].friend[friendslot].guildname = GStruct.guild[PStruct.character[friendnum, PStruct.player[friendnum].SelectedChar].Guild].name;
                if (String.IsNullOrEmpty(PStruct.player[index].friend[friendslot].guildname)) { PStruct.player[index].friend[friendslot].guildname = ""; }
                SendData.Send_PlayerFriends(index);
                return true;
            }
            catch
            {
                return false;
            }
        }
        //*********************************************************************************************
        // DeleteFriend
        // Retira determinado jogador da lista de amigos de outro
        //*********************************************************************************************
        public static bool DeleteFriend(int index, int friendnum)
        {
            //EXTEND
            if (Extensions.ExtensionApp.ExtendMyApp
                (MethodBase.GetCurrentMethod().Name, index, friendnum) != null)
            {
                return Convert.ToBoolean(Extensions.ExtensionApp.ExtendMyApp
                (MethodBase.GetCurrentMethod().Name, index, friendnum));
            }

            //CÓDIGO
            if (friendnum == 0) { return false; }
            try
            {
                int friendscount = GetPlayerFriendsCount(index) + 1;
                PStruct.player[index].friend[friendnum].name = "";
                PStruct.player[index].friend[friendnum].sprite = "";
                PStruct.player[index].friend[friendnum].sprite_index = 0;
                PStruct.player[index].friend[friendnum].classid = 0;
                PStruct.player[index].friend[friendnum].level = 0;
                PStruct.player[index].friend[friendnum].guildname = "";
                if (friendnum < friendscount)
                {
                    for (int i = friendnum + 1; i <= friendscount; i++)
                    {
                        PStruct.player[index].friend[i - 1].name = PStruct.player[index].friend[i].name;
                        PStruct.player[index].friend[i - 1].sprite = PStruct.player[index].friend[i].sprite;
                        PStruct.player[index].friend[i - 1].sprite_index = PStruct.player[index].friend[i].sprite_index;
                        PStruct.player[index].friend[i - 1].classid = PStruct.player[index].friend[i].classid;
                        PStruct.player[index].friend[i - 1].level = PStruct.player[index].friend[i].level;
                        PStruct.player[index].friend[i - 1].guildname = PStruct.player[index].friend[i].guildname;
                    }
                }
                SendData.Send_PlayerFriends(index);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
