using System;
using System.Reflection;
using System.Linq;

namespace FORJERUM
{
    class PartyRelations : Languages.LStruct
    {
        //*********************************************************************************************
        // PartyShareExp / Revisto pela última vez em 01/08/2016, criado por Allyson S. Bacon
        // Divide a Exp para determinado grupo baseado no atacante
        //*********************************************************************************************
        public static void PartyShareExp(int Attacker, int Victim, int Map)
        {
            //EXTEND
            if (Extensions.ExtensionApp.ExtendMyApp
                (MethodBase.GetCurrentMethod().Name, Attacker, Victim, Map) != null)
            {
                return;
            }

            //CÓDIGO
            int NpcX = NStruct.tempnpc[Map, Victim].X;
            int NpcY = NStruct.tempnpc[Map, Victim].Y;
            int PlayerX = Convert.ToInt32(PStruct.character[Attacker, PStruct.player[Attacker].SelectedChar].X);
            int PlayerY = Convert.ToInt32(PStruct.character[Attacker, PStruct.player[Attacker].SelectedChar].Y);

            //PARTY EXP
            int partynum = PStruct.tempplayer[Attacker].Party;

            //Damos xp ao jogador e mostramos a xp ganha
            if (partynum > 0)
            {
                int memberscount = PartyRelations.GetPartyMembersCount(partynum);
                for (int i = 1; i <= memberscount; i++)
                {
                    int memberindex = PStruct.partymembers[partynum, i].index;
                    if (PStruct.character[memberindex, PStruct.player[memberindex].SelectedChar].Map == PStruct.character[Attacker, PStruct.player[Attacker].SelectedChar].Map)
                    {
                        //Tem grupo para dividir a exp
                        //Adiciona uma kill se houver uma quest para esse npc
                        for (int g = 1; g < Globals.MaxQuestGivers; g++)
                        {
                            for (int q = 1; q < Globals.MaxQuestPerGiver; q++)
                            {
                                //Prevent
                                if ((String.IsNullOrEmpty(MStruct.quest[g, q].type)) && (PStruct.queststatus[memberindex, g, q].status > 0)) { PStruct.queststatus[memberindex, g, q].status = 0; return; }

                                //Execute
                                if ((PStruct.queststatus[memberindex, g, q].status == 1) && (Convert.ToInt32(MStruct.quest[g, q].type.Split('|')[0]) > 0))
                                {
                                    for (int k = 1; k < Globals.MaxQuestKills; k++)
                                    {
                                        if (MStruct.questkills[g, q, k].monstername == NStruct.npc[Map, Victim].Name)
                                        {
                                            if (PStruct.questkills[memberindex, g, q, k].kills < MStruct.questkills[g, q, k].value)
                                            {
                                                PStruct.questkills[memberindex, g, q, k].kills += 1;
                                                SendData.Send_ActionMsg(memberindex, lang.quest_defeat + " " + MStruct.questkills[g, q, k].monstername + " " + PStruct.questkills[memberindex, g, q, k].kills + "/" + MStruct.questkills[g, q, k].value, Globals.ColorGreen, NpcX, NpcY, 0, PStruct.character[Attacker, PStruct.player[Attacker].SelectedChar].Dir);
                                                SendData.Send_QuestKill(memberindex, g, q, k);
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        int exp = NStruct.npc[Map, Victim].Exp;
                        if (PlayerRelations.IsPlayerPremmy(memberindex)) { exp = Convert.ToInt32(exp * 1.5); }
                        PlayerRelations.GivePlayerExp(memberindex, exp);
                    }
                }
            }
            //Não tem grupo para dividir a exp
            else
            {
                //Adiciona uma kill se houver uma quest para esse npc
                for (int g = 1; g < Globals.MaxQuestGivers; g++)
                {
                    for (int q = 1; q < Globals.MaxQuestPerGiver; q++)
                    {
                        //Prevent
                        if ((String.IsNullOrEmpty(MStruct.quest[g, q].type)) && (PStruct.queststatus[Attacker, g, q].status > 0)) { PStruct.queststatus[Attacker, g, q].status = 0; return; }

                        //Execute
                        if ((PStruct.queststatus[Attacker, g, q].status == 1) && (Convert.ToInt32(MStruct.quest[g, q].type.Split('|')[0]) > 0))
                        {
                            for (int k = 1; k < Globals.MaxQuestKills; k++)
                            {
                                if (MStruct.questkills[g, q, k].monstername == NStruct.npc[Map, Victim].Name)
                                {
                                    if (PStruct.questkills[Attacker, g, q, k].kills < MStruct.questkills[g, q, k].value)
                                    {
                                        PStruct.questkills[Attacker, g, q, k].kills += 1;
                                        SendData.Send_ActionMsg(Attacker, lang.quest_defeat + " " + MStruct.questkills[g, q, k].monstername + " " + PStruct.questkills[Attacker, g, q, k].kills + "/" + MStruct.questkills[g, q, k].value, Globals.ColorGreen, NpcX, NpcY, 0, PStruct.character[Attacker, PStruct.player[Attacker].SelectedChar].Dir);
                                        SendData.Send_QuestKill(Attacker, g, q, k);
                                    }
                                }
                            }
                        }
                    }
                }
                int exp = NStruct.npc[Map, Victim].Exp;
                if (PlayerRelations.IsPlayerPremmy(Attacker)) { exp = Convert.ToInt32(exp * 1.5); }
                PlayerRelations.GivePlayerExp(Attacker, exp);
            }
        }
        //*********************************************************************************************
        // KickParty / Revisto pela última vez em 01/08/2016, criado por Allyson S. Bacon
        // Retira determinado jogador do grupo
        //*********************************************************************************************
        public static void KickParty(int index, int kicktarget, bool order = false)
        {
            //EXTEND
            if (Extensions.ExtensionApp.ExtendMyApp
                (MethodBase.GetCurrentMethod().Name, index, kicktarget, order) != null)
            {
                return;
            }

            //CÓDIGO
            //Tentativas possíveis de hacker
            if ((PStruct.tempplayer[kicktarget].Party == 0) || (PStruct.tempplayer[kicktarget].Party != PStruct.tempplayer[index].Party)) { return; }

            if ((UserConnection.Getindex(kicktarget) < 0) || (UserConnection.Getindex(kicktarget) >= WinsockAsync.Clients.Count()))
            {
                SendData.Send_MsgToPlayer(index, lang.player_kick_offline, Globals.ColorRed, Globals.Msg_Type_Server);
                return;
            }

            //Verifica se ele não saiu no processo
            if (!WinsockAsync.Clients[(UserConnection.Getindex(kicktarget))].IsConnected && (!order))
            {
                SendData.Send_MsgToPlayer(index, lang.player_kick_offline, Globals.ColorRed, Globals.Msg_Type_Server);
                return;
            }

            //Verificar se ele é lider para tirar outro jogador
            if ((PStruct.party[PStruct.tempplayer[index].Party].leader != index) && (kicktarget != index))
            {
                SendData.Send_MsgToPlayer(index, lang.you_is_not_the_party_leader, Globals.ColorRed, Globals.Msg_Type_Server);
                return;
            }

            //Vamos trabalhar com isso
            int partynum = PStruct.tempplayer[index].Party;
            int memberindex = 0;

            if (kicktarget == index)
            {
                //O id do jogador no grupo
                memberindex = GetPartyPlayerindex(partynum, index);

                //Reposicionar todos os membros no grupo se quem saiu for maior que 3
                if (memberindex <= 3)
                {
                    for (int i = (memberindex + 1); i < Globals.MaxPartyMembers; i++)
                    {
                        PStruct.partymembers[partynum, i - 1].index = PStruct.partymembers[partynum, i].index;
                        PStruct.partymembers[partynum, i].index = 0;
                    }
                }
                else
                {
                    PStruct.partymembers[partynum, 4].index = 0;
                }

                if (kicktarget == PStruct.party[partynum].leader)
                {
                    PStruct.party[partynum].leader = PStruct.partymembers[partynum, 1].index;
                }

                //Tiramos o grupo do jogador
                PStruct.tempplayer[index].Party = 0;
            }
            else
            {
                //O id do jogador no grupo
                memberindex = GetPartyPlayerindex(partynum, kicktarget);

                //Reposicionar todos os membros no grupo se quem saiu for maior que 3
                if (memberindex <= 3)
                {
                    for (int i = (memberindex + 1); i < Globals.MaxPartyMembers; i++)
                    {
                        PStruct.partymembers[partynum, i - 1].index = PStruct.partymembers[partynum, i].index;
                        PStruct.partymembers[partynum, i].index = 0;
                    }
                }
                else
                {
                    PStruct.partymembers[partynum, 4].index = 0;
                }

                //Tiramos o grupo do jogador
                PStruct.tempplayer[kicktarget].Party = 0;
            }


            //Algum jogador ficou sozinho?
            if (GetPartyMembersCount(partynum) == 1)
            {
                //Jogador que ficou sozinho será sempre o 1
                int alone = PStruct.partymembers[partynum, 1].index;

                //Limpamos o grupo do jogador que ficou sozinho
                PStruct.tempplayer[alone].Party = 0;

                //Limpamos o grupo
                PStruct.party[partynum].leader = 0;
                PStruct.party[partynum].active = false;

                //Avisa ao jogador que ele não tem mais um grupo
                SendData.Send_PartyKick(alone);

                //Verifica se não é um kick por ordem do servidor
                if (!order)
                {
                    SendData.Send_PartyKick(kicktarget);
                }

                //Limpamos todos os membros do grupo
                for (int i = (memberindex + 1); i < Globals.MaxPartyMembers; i++)
                {
                    PStruct.partymembers[partynum, i].index = 0;
                }
                return;
            }

            //Verifica se não é um kick por ordem do servidor
            if (!order)
            {
                SendData.Send_PartyKick(kicktarget);
            }

            //Envia o grupo atualizado
            SendData.Send_PartyDataToParty(partynum);
        }
        //*********************************************************************************************
        // GetPartyMembersCount
        // Retorna o número de membros em um grupo
        //*********************************************************************************************
        public static int GetPartyMembersCount(int partynum)
        {
            //EXTEND
            if (Extensions.ExtensionApp.ExtendMyApp
                (MethodBase.GetCurrentMethod().Name, partynum) != null)
            {
                return Convert.ToInt32(Extensions.ExtensionApp.ExtendMyApp
                (MethodBase.GetCurrentMethod().Name, partynum));
            }

            //CÓDIGO
            int count = 0;

            for (int i = 1; i < Globals.MaxPartyMembers; i++)
            {
                if (PStruct.partymembers[partynum, i].index > 0) { count += 1; }
            }

            return count;
        }
        //*********************************************************************************************
        // GetPartyPlayerIndex
        // Retorna o index do jogador com base no index do grupo
        //*********************************************************************************************
        public static int GetPartyPlayerindex(int partynum, int index)
        {
            //EXTEND
            if (Extensions.ExtensionApp.ExtendMyApp
                (MethodBase.GetCurrentMethod().Name, partynum, index) != null)
            {
                return Convert.ToInt32(Extensions.ExtensionApp.ExtendMyApp
                (MethodBase.GetCurrentMethod().Name, partynum, index));
            }

            //CÓDIGO
            int finalindex = 0;

            //Checa o slot que possúi o jogador
            for (int i = 1; i < Globals.MaxPartyMembers; i++)
            {
                if (PStruct.partymembers[partynum, i].index == index)
                {
                    finalindex = i;
                    break;
                }
            }

            return finalindex;
        }
        //*********************************************************************************************
        // GetPartyFree
        // Retorna um slot de grupo livre
        //*********************************************************************************************
        public static int GetPartyFree()
        {
            //EXTEND
            if (Extensions.ExtensionApp.ExtendMyApp
                (MethodBase.GetCurrentMethod().Name) != null)
            {
                return Convert.ToInt32(Extensions.ExtensionApp.ExtendMyApp
                (MethodBase.GetCurrentMethod().Name));
            }

            //CÓDIGO
            int partynum = 0;

            //Checa um grupo livre
            for (int i = 1; i < Globals.MaxParty; i++)
            {
                if (PStruct.party[i].active == false)
                {
                    partynum = i;
                    break;
                }
            }

            return partynum;
        }
    }
}
