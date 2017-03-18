using System;
using System.Reflection;

namespace FORJERUM
{
    class MovementRelations
    {
        //*********************************************************************************************
        // CanPlayerMove / Revisto pela última vez em 01/08/2016, criado por Allyson S. Bacon
        // Verifica se determinado jogador pode se mover no contexto em que está atualmente
        //*********************************************************************************************
        public static bool CanPlayerMove(int index, byte Dir, int x = 0, int y = 0)
        {
            //EXTEND
            if (Extensions.ExtensionApp.ExtendMyApp
                (MethodBase.GetCurrentMethod().Name, index, Dir, x, y) != null)
            {
                return Convert.ToBoolean(Extensions.ExtensionApp.ExtendMyApp
                (MethodBase.GetCurrentMethod().Name, index, Dir, x, y));
            }

            //CÓDIGO
            int map = Convert.ToInt32(PStruct.character[index, PStruct.player[index].SelectedChar].Map);
            if (x <= 0 || y <= 0)
            {
                x = Convert.ToInt32(PStruct.character[index, PStruct.player[index].SelectedChar].X);
                y = Convert.ToInt32(PStruct.character[index, PStruct.player[index].SelectedChar].Y);
            }

            //Tentamos nos mover
            switch (Dir)
            {
                case 8:
                    if (y - 1 < 0)
                    {
                        return false;
                    }
                    if (Convert.ToBoolean(MStruct.tile[map, x, y].UpBlock) == false) { return false; }
                    if (Convert.ToBoolean(MStruct.tile[map, x, y - 1].DownBlock) == false) { return false; }
                    if ((MStruct.tile[map, x, y - 1].Data1 == "3") || (MStruct.tile[map, x, y - 1].Data1 == "10")) { return false; }
                    if (MStruct.tile[map, x, y - 1].Data1 == "21")
                    {
                        if (!PlayerRelations.IsPlayerPremmy(index))
                        {
                            PlayerMove(index, Convert.ToByte(Convert.ToInt32(MStruct.tile[map, x, y - 1].Data2)));
                            return false;
                        }
                    }
                    break;
                case 2:
                    if (y + 1 > 14)
                    {
                        return false;
                    }
                    if (Convert.ToBoolean(MStruct.tile[map, x, y].DownBlock) == false) { return false; }
                    if (Convert.ToBoolean(MStruct.tile[map, x, y + 1].UpBlock) == false) { return false; }
                    if ((MStruct.tile[map, x, y + 1].Data1 == "3") || (MStruct.tile[map, x, y + 1].Data1 == "10")) { return false; }
                    if (MStruct.tile[map, x, y + 1].Data1 == "21")
                    {
                        if (!PlayerRelations.IsPlayerPremmy(index))
                        {
                            PlayerMove(index, Convert.ToByte(Convert.ToInt32(MStruct.tile[map, x, y + 1].Data2)));
                            return false;
                        }
                    }
                    break;
                case 4:
                    if (x - 1 < 0)
                    {
                        return false;
                    }
                    if (Convert.ToBoolean(MStruct.tile[map, x, y].LeftBlock) == false) { return false; }
                    if (Convert.ToBoolean(MStruct.tile[map, x - 1, y].RightBlock) == false) { return false; }
                    if ((MStruct.tile[map, x - 1, y].Data1 == "3") || (MStruct.tile[map, x - 1, y].Data1 == "10")) { return false; }
                    if (MStruct.tile[map, x - 1, y].Data1 == "21")
                    {
                        if (!PlayerRelations.IsPlayerPremmy(index))
                        {
                            PlayerMove(index, Convert.ToByte(Convert.ToInt32(MStruct.tile[map, x - 1, y].Data2)));
                            return false;
                        }
                    }
                    break;
                case 6:
                    if (x + 1 > 19)
                    {
                        return false;
                    }
                    if (Convert.ToBoolean(MStruct.tile[map, x, y].RightBlock) == false) { return false; }
                    if (Convert.ToBoolean(MStruct.tile[map, x + 1, y].LeftBlock) == false) { return false; }
                    if ((MStruct.tile[map, x + 1, y].Data1 == "3") || (MStruct.tile[map, x + 1, y].Data1 == "10")) { return false; }
                    if (MStruct.tile[map, x + 1, y].Data1 == "21")
                    {
                        if (!PlayerRelations.IsPlayerPremmy(index))
                        {
                            PlayerMove(index, Convert.ToByte(Convert.ToInt32(MStruct.tile[map, x + 1, y].Data2)));
                            return false;
                        }
                    }
                    break;
                default:
                    WinsockAsync.Log(String.Format("Direção nula"));
                    break;
            }

            return true;
        }
        //*********************************************************************************************
        // PlayerMove / Revisto pela última vez em 01/08/2016, criado por Allyson S. Bacon
        // Move determinado jogador para determinada posição
        //*********************************************************************************************
        public static void PlayerMove(int index, byte Dir)
        {
            //EXTEND
            if (Extensions.ExtensionApp.ExtendMyApp
                (MethodBase.GetCurrentMethod().Name, index, Dir) != null)
            {
                return;
            }

            //CÓDIGO
            if (PStruct.tempplayer[index].Warping) { return; }
            //Tentamos nos mover
            switch (Dir)
            {
                case 8:
                    PStruct.character[index, PStruct.player[index].SelectedChar].Y = Convert.ToByte(Convert.ToInt32(PStruct.character[index, PStruct.player[index].SelectedChar].Y) - 1);
                    PStruct.character[index, PStruct.player[index].SelectedChar].Dir = Globals.DirUp;
                    break;
                case 2:
                    PStruct.character[index, PStruct.player[index].SelectedChar].Y = Convert.ToByte(Convert.ToInt32(PStruct.character[index, PStruct.player[index].SelectedChar].Y) + 1);
                    PStruct.character[index, PStruct.player[index].SelectedChar].Dir = Globals.DirDown;
                    break;
                case 4:
                    PStruct.character[index, PStruct.player[index].SelectedChar].X = Convert.ToByte(Convert.ToInt32(PStruct.character[index, PStruct.player[index].SelectedChar].X) - 1);
                    PStruct.character[index, PStruct.player[index].SelectedChar].Dir = Globals.DirLeft;
                    break;
                case 6:
                    PStruct.character[index, PStruct.player[index].SelectedChar].X = Convert.ToByte(Convert.ToInt32(PStruct.character[index, PStruct.player[index].SelectedChar].X) + 1);
                    PStruct.character[index, PStruct.player[index].SelectedChar].Dir = Globals.DirRight;
                    break;
                default:
                    WinsockAsync.Log(String.Format("Direção nula"));
                    break;
            }

            int map = Convert.ToInt32(PStruct.character[index, PStruct.player[index].SelectedChar].Map);
            int x = Convert.ToInt32(PStruct.character[index, PStruct.player[index].SelectedChar].X);
            int y = Convert.ToInt32(PStruct.character[index, PStruct.player[index].SelectedChar].Y);
            //Verifica os tipos de tiles
            if (MStruct.tile[map, x, y].Data1 == "2")
            {
                PStruct.tempplayer[index].Warping = true;
                PlayerWarp(index, Convert.ToInt32(MStruct.tile[map, x, y].Data2), Convert.ToByte(MStruct.tile[map, x, y].Data3), Convert.ToByte(MStruct.tile[map, x, y].Data4));
                return;
            }

            //Se nenhum tile tem ação, enviar as novas coordenadas do jogador após o movimento 
            SendData.Send_PlayerXY(index);
            SendData.Send_PlayerDir(index, 1);
        }
        //*********************************************************************************************
        // PlayerWarp / Revisto pela última vez em 01/08/2016, criado por Allyson S. Bacon
        // Move o jogador para outro mapa, importante perceber que tudo deve ser atualizado para ele e
        // para quem está no outro mapa.
        //*********************************************************************************************
        public static void PlayerWarp(int index, int Map, byte X, byte Y)
        {
            //EXTEND
            if (Extensions.ExtensionApp.ExtendMyApp
                (MethodBase.GetCurrentMethod().Name, index, Map, X, Y) != null)
            {
                return;
            }

            //CÓDIGO
            //Salvamos o mapa antigo
            int oldmap = PStruct.character[index, PStruct.player[index].SelectedChar].Map;

            if (Map == oldmap)
            {
                PStruct.character[index, PStruct.player[index].SelectedChar].X = X;
                PStruct.character[index, PStruct.player[index].SelectedChar].Y = Y;
                SendData.Send_PlayerWarp(index);
                SendData.Send_PlayerXY(index);
                SendData.Send_PlayerDeathToMap(index);
                PStruct.tempplayer[index].Warping = false;
                return;
            }

            //Definimos as novas coordenadas do jogador
            PStruct.character[index, PStruct.player[index].SelectedChar].Map = Map;
            PStruct.character[index, PStruct.player[index].SelectedChar].X = X;
            PStruct.character[index, PStruct.player[index].SelectedChar].Y = Y;

            //Valores sobre magias
            if (PStruct.tempplayer[index].preparingskill > 0)
            {
                PStruct.tempplayer[index].preparingskill = 0;
                PStruct.tempplayer[index].skilltimer = 0;
                PStruct.tempplayer[index].preparingskillslot = 0;
                PStruct.tempplayer[index].movespeed = Globals.NormalMoveSpeed;
                SendData.Send_BrokeSkill(index);
                SendData.Send_MoveSpeed(1, index);
            }

            //Enviamos o jogador ao novo mapa
            SendData.Send_PlayerWarp(index);
            SendData.Send_PlayerDataToMapBut(index, PStruct.player[index].Username, PStruct.player[index].SelectedChar);
            for (int i = 0; i <= Globals.Player_Highindex; i++)
            {
                if (PStruct.character[i, PStruct.player[i].SelectedChar].Map == PStruct.character[index, PStruct.player[index].SelectedChar].Map)
                    if (i != index)
                    {
                        {
                            SendData.Send_PlayerDataTo(index, i, PStruct.player[i].Username, PStruct.player[i].SelectedChar);
                            SendData.Send_GuildTo(index, i);
                            SendData.Send_PlayerSoreTo(index, i);
                            SendData.Send_PlayerPvpTo(index, i);
                            SendData.Send_PlayerShoppingTo(index, i);
                            if (PStruct.tempplayer[i].Stunned) { SendData.Send_Stun(PStruct.character[index, PStruct.player[index].SelectedChar].Map, 1, i, 1); }
                            if (PStruct.tempplayer[i].Sleeping) { SendData.Send_Sleep(PStruct.character[index, PStruct.player[index].SelectedChar].Map, 1, i, 1); }
                            if (PStruct.tempplayer[i].isDead) { SendData.Send_PlayerDeathTo(index, i); }
                            //SendData.Send_PlayerMoveSpeedTo(index, i);
                        }
                    }
            }

            for (int i = 0; i <= Globals.Max_WorkPoints - 1; i++)
            {
                if (MStruct.workpoint[i].map == Map)
                {
                    if ((MStruct.tempworkpoint[i].vitality <= 0))
                    {
                        SendData.Send_EventGraphicToMap(MStruct.workpoint[i].map, MStruct.tile[MStruct.workpoint[i].map, MStruct.workpoint[i].x, MStruct.workpoint[i].y].Event_Id, "", 0, Convert.ToByte(MStruct.workpoint[i].inactive_sprite));
                    }
                }
            }

            for (int i = 0; i <= Globals.Max_Chests - 1; i++)
            {
                if (MStruct.chestpoint[i].map == Map)
                {
                    if (PStruct.character[index, PStruct.player[index].SelectedChar].Chest[i])
                    {
                        SendData.Send_EventGraphic(index, MStruct.tile[MStruct.chestpoint[i].map, MStruct.chestpoint[i].x, MStruct.chestpoint[i].y].Event_Id, MStruct.chestpoint[i].inactive_sprite, MStruct.chestpoint[i].inactive_sprite_index, 0, 8);
                    }
                }
            }

            //????
            SendData.Send_MapGuildTo(index);
            SendData.Send_PlayerSkills(index);
            SendData.Send_InvSlots(index, PStruct.player[index].SelectedChar);
            SendData.Send_PlayerVitalityToMap(PStruct.character[index, PStruct.player[index].SelectedChar].Map, index, PStruct.tempplayer[index].Vitality);
            SendData.Send_GuildToMapBut(PStruct.character[index, PStruct.player[index].SelectedChar].Map, index);
            SendData.Send_CompleteGuild(index);
            SendData.Send_PlayerPvpToMap(index);
            SendData.Send_PlayerSoreToMap(index);
            SendData.Send_PlayerExtraVitalityToMap(index);
            SendData.Send_PlayerExtraSpiritToMap(index);
            //SendData.Send_PlayerMoveSpeedToMapBut(index, PStruct.character[index, PStruct.player[index].SelectedChar].Map, index);

            //Enviamos os npcs do novo mapa
            SendData.Send_MapNpcsTo(index);
            SendData.Send_MapItems(index);

            //Avisamos aos jogadores do antigo mapa que ele saiu
            SendData.Send_PlayerLeft(oldmap, index);

            PStruct.tempplayer[index].Warping = false;
        }
    }
}
