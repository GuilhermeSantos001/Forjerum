using System;
using System.Linq;
using System.Reflection;

namespace FORJERUM
{
    //*********************************************************************************************
    // Estruturas e métodos relacionados ao jogadores.
    // PStruct.cs
    //*********************************************************************************************
    class PStruct : Languages.LStruct
    {
        //*********************************************************************************************
        // ESTRUTURAS DO JOGADOR 
        // Se inclui também pontos de interação como hotkeys, craft, quest e outros.
        //*********************************************************************************************
        public static PStruct.Player[] player = new PStruct.Player[Globals.MaxPlayers];
        public static PStruct.ClassData[] classes = new PStruct.ClassData[Globals.MaxClasses + 1];
        public static PStruct.Character[,] character = new PStruct.Character[Globals.MaxPlayers, 3];
        public static PStruct.TempPlayer[] tempplayer = new PStruct.TempPlayer[Globals.MaxPlayers];
        public static PStruct.Skill[,] skill = new PStruct.Skill[Globals.MaxPlayers, 17];
        public static PStruct.InvSlot[,] invslot = new PStruct.InvSlot[Globals.MaxPlayers, Globals.MaxInvSlot];
        public static PStruct.Craft[,] craft = new PStruct.Craft[Globals.MaxPlayers, Globals.Max_Craft];
        public static PStruct.QuestStatus[,,] queststatus = new PStruct.QuestStatus[Globals.MaxPlayers, Globals.MaxQuestGivers, Globals.MaxQuestPerGiver];
        public static PStruct.QuestKills[,,,] questkills = new PStruct.QuestKills[Globals.MaxPlayers, Globals.MaxQuestGivers, Globals.MaxQuestPerGiver, Globals.MaxQuestKills];
        public static PStruct.QuestActions[,,,] questactions = new PStruct.QuestActions[Globals.MaxPlayers, Globals.MaxQuestGivers, Globals.MaxQuestPerGiver, Globals.MaxQuestActions];
        public static PStruct.TradeSlot[,] tradeslot = new PStruct.TradeSlot[Globals.MaxPlayers, 17];
        public static PStruct.Hotkey[,] hotkey = new PStruct.Hotkey[Globals.MaxPlayers, 11];
        public static PStruct.Party[] party = new PStruct.Party[100];
        public static PStruct.PartyMembers[,] partymembers = new PStruct.PartyMembers[100, 5];
        public static PStruct.PTempSpell[,] ptempspell = new PStruct.PTempSpell[Globals.MaxPlayers, Globals.MaxPTempSpells];
        public static PStruct.PPassiveEffect[,] ppassiveffect = new PStruct.PPassiveEffect[Globals.MaxPlayers, Globals.MaxPassiveEffects];
        public static PStruct.PSpellBuff[,] pspellbuff = new PStruct.PSpellBuff[Globals.MaxPlayers, Globals.MaxSpellBuffs];

        public struct Player
        {
            public string Email;
            public string Password;
            public string Username;
            public string Premmy;
            public bool Confirmed;
            public string Banned;
            public int SelectedChar;
            public int WPoints;
            public BankSlot[] bankslot;
            public int skin_count;
            public bool[] skin;
            public FriendList[] friend;
        }

        public struct ClassData
        {
            public string[] sprite_name;
            public int[] sprite_index;
            public int fire;
            public int earth;
            public int water;
            public int wind;
            public int dark;
            public int light;
        }

        public struct FriendList
        {
            public string name;
            public string sprite;
            public int sprite_index;
            public int classid;
            public int level;
            public string guildname;
        }

        public struct BankSlot
        {
            public int type;
            public int num;
            public int value;
            public int refin;
            public int exp;
        }

        public struct PShopSlot
        {
            public int type;
            public int num;
            public int value;
            public int refin;
            public int price;
            public int exp;
        }

        public struct Character
        {
            public string CharacterName;
            public int Spriteindex;
            public int ClassId;
            public string Sprite;
            public int Level;
            public int Exp;
            public int Fire;
            public int Earth;
            public int Water;
            public int Wind;
            public int Dark;
            public int Light;
            public int Points;
            public int Map;
            public byte X;
            public byte Y;
            public byte Dir;
            public string Equipment;
            public int Vitality;
            public int Spirit;
            public int Access;
            public int SkillPoints;
            public int Gold;
            public int Cash;
            public int Hue;
            public int Gender;
            public int Guild;
            public long PVPChangeTimer;
            public long PVPBanTimer;
            public long PVPPenalty;
            public bool PVP;
            public int BootMap;
            public byte BootX;
            public byte BootY;
            //Profissões
            public int[] Prof_Type;
            public int[] Prof_Level;
            public int[] Prof_Exp;
            public bool[] Chest;
            public PShopSlot[] pshopslot;
        }

        public struct Skill
        {
            public int num;
            public int level;
            public long cooldown;
        }

        public struct InvSlot
        {
            public string item;
        }

        public struct Craft
        {
            public int type;
            public int num;
            public int value;
            public int refin;
            public int exp;
        }

        public struct QuestStatus
        {
            public int status;
        }

        public struct QuestKills
        {
            public int kills;
        }

        public struct QuestActions
        {
            public bool actiondone;
        }

        public struct Hotkey
        {
            public byte type;
            public int num;
        }

        public struct TempPlayer
        {
            public bool ingame;
            public int MaxVitality;
            public int Vitality;
            public int MaxSpirit;
            public int Spirit;
            public bool Warping;
            public byte targettype;
            public int target;
            public long skilltimer;
            public int preparingskill;
            public int preparingskillslot;
            public double  movespeed;
            public long MoveTimer;
            public long InviteTimer;
            public int Inviting;
            public int Invited;
            public int Party;
            public int InTrade;
            public int TradeG;
            public int TradeStatus;
            public long RegenTimer;
            public bool Sleeping;
            public long SleepTimer;
            public bool Stunned;
            public long StunTimer;
            public bool Slowed;
            public long SlowTimer;
            public long AttackTimer;
            public int InShop;
            public bool InCraft;
            public bool InBank;
            public int CraftType;
            public int CraftItem;
            public bool Blind;
            public long BlindTimer;
            public bool Logged;
            public long DataTimer;
            public long ChatTimer;
            public int ChatExcept;
            public long AllChatTimer;
            public bool isDead;
            public int ActivationCode;
            public bool SORE;
            public bool Reflect;
            public long ReflectTimer;
            public bool Shopping;
            public int InPShop;
            public bool isFrozen;
            public byte Sheathe;
            public byte ReduceDamage;
            public long PetTimer;
            public int PetTarget;
            public int PetTargetType;
            public int LastTarget;
            public int LastTargetType;
        }

        public struct PTempSpell
        {
            public bool active;
            public int attacker;
            public int spellnum;
            public long timer;
            public int repeats;
            public int anim;
            public int area_range;
            public bool is_line;
            public bool is_heal;
            public bool fast_buff;
        }

        public struct PPassiveEffect
        {
            public bool active;
            public int type;
            public long timer;
            public int spellnum;
            public int targettype;
            public int target;
        }

        public struct PSpellBuff
        {
            public bool active;
            public int type;
            public long timer;
            public int value; //porcentagem
        }

        public struct Party
        {
            public int leader;
            public bool active;
        }
        public struct PartyMembers
        {
            public int index;
        }
        public struct TradeSlot
        {
            public string item;
        }
        //*********************************************************************************************
        // ResetPlayerStatus
        // Reinicia os status de determinado jogador (OBSOLETO)
        //*********************************************************************************************
        public static void ResetPlayerStatus(int index)
        {
            //EXTEND
            if (Extensions.ExtensionApp.ExtendMyApp
                (MethodBase.GetCurrentMethod().Name, index) != null)
            {
                return;
            }

            //CÓDIGO
            int totalpoints = 0;

            totalpoints += PStruct.character[index, PStruct.player[index].SelectedChar].Earth - 1;
            totalpoints += PStruct.character[index, PStruct.player[index].SelectedChar].Wind - 1;
            totalpoints += PStruct.character[index, PStruct.player[index].SelectedChar].Dark - 1;
            totalpoints += PStruct.character[index, PStruct.player[index].SelectedChar].Light - 1;
            totalpoints += PStruct.character[index, PStruct.player[index].SelectedChar].Water- 1;
            totalpoints += PStruct.character[index, PStruct.player[index].SelectedChar].Fire - 1;

            PStruct.character[index, PStruct.player[index].SelectedChar].Earth = 1;
            PStruct.character[index, PStruct.player[index].SelectedChar].Wind = 1;
            PStruct.character[index, PStruct.player[index].SelectedChar].Dark = 1;
            PStruct.character[index, PStruct.player[index].SelectedChar].Light = 1;
            PStruct.character[index, PStruct.player[index].SelectedChar].Water = 1;
            PStruct.character[index, PStruct.player[index].SelectedChar].Fire = 1;

            PStruct.character[index, PStruct.player[index].SelectedChar].Points += totalpoints;
            SendData.Send_PlayerAtrToMap(index);
            SendData.Send_MsgToPlayer(index, lang.success_atributte_reset, Globals.ColorGreen, Globals.Msg_Type_Server);
        }
        //*********************************************************************************************
        // PlayerAddPremmy
        // Adiciona tempo de assinatura
        //*********************************************************************************************
        public static void PlayerAddPremmy(int index)
        {
            //EXTEND
            if (Extensions.ExtensionApp.ExtendMyApp
                (MethodBase.GetCurrentMethod().Name, index) != null)
            {
                return;
            }

            //CÓDIGO
            //return;
            DateTime myDate = DateTime.Parse(player[index].Premmy);
            myDate = myDate.AddDays(30);
            player[index].Premmy = myDate.ToString();
            Console.WriteLine(player[index].Premmy);
            Database.SaveAccount(index);
        }
        //*********************************************************************************************
        // InitializePlayerArrays
        //*********************************************************************************************
        public static void InitializePlayerArrays()
        {
            //EXTEND
            if (Extensions.ExtensionApp.ExtendMyApp
                (MethodBase.GetCurrentMethod().Name) != null)
            {
                return;
            }

            //CÓDIGO
            for (int i = 1; i < Globals.MaxPlayers; i++)
            {
                PStruct.player[i].bankslot = new BankSlot[Globals.Max_BankSlots];
                PStruct.player[i].friend = new FriendList[Globals.Max_Friends];
                for (int c = 0; c < Globals.MaxChars; c++)
                {
                    PStruct.character[i, c].Prof_Type = new int[Globals.Max_Profs_Per_Char];
                    PStruct.character[i, c].Prof_Level = new int[Globals.Max_Profs_Per_Char];
                    PStruct.character[i, c].Prof_Exp = new int[Globals.Max_Profs_Per_Char];
                    PStruct.character[i, c].Chest = new bool[Globals.Max_Chests];
                    PStruct.character[i, c].pshopslot = new PShopSlot[Globals.Max_PShops];
                }
            }
        }
        //*********************************************************************************************
        // GetPlayerProf
        // Retorna profissão do jogador
        //*********************************************************************************************
        public static int GetPlayerProf(int index, int type)
        {
            //EXTEND
            if (Extensions.ExtensionApp.ExtendMyApp
                (MethodBase.GetCurrentMethod().Name, index, type) != null)
            {
                return Convert.ToInt32(Extensions.ExtensionApp.ExtendMyApp
                (MethodBase.GetCurrentMethod().Name, index, type));
            }

            //CÓDIGO
            int prof = 0;

            for (int i = 1; i < Globals.Max_Profs_Per_Char; i++)
            {
                if (PStruct.character[index, PStruct.player[index].SelectedChar].Prof_Type[i] == type)
                {
                    prof = i;
                    break;
                }
            }

            return prof;
        }

        //*********************************************************************************************
        // GetFreeCraft
        // Retorna um slot no craft que esteja livre
        //*********************************************************************************************
        public static int GetFreeCraft(int index)
        {
            //EXTEND
            if (Extensions.ExtensionApp.ExtendMyApp
                (MethodBase.GetCurrentMethod().Name, index) != null)
            {
                return Convert.ToInt32(Extensions.ExtensionApp.ExtendMyApp
                (MethodBase.GetCurrentMethod().Name, index));
            }

            //CÓDIGO
            int finalindex = -1;

            //Checa o slot que possúi o jogador
            for (int i = 1; i < Globals.Max_Craft; i++)
            {
                if ((PStruct.craft[index, i].num == 0))
                {
                    finalindex = i;
                    break;
                }
            }

            return finalindex;
        }
        //*********************************************************************************************
        // isBusy
        // Jogador ocupado
        //*********************************************************************************************
        public static bool IsBusy(int index)
        {
            //EXTEND
            if (Extensions.ExtensionApp.ExtendMyApp
                (MethodBase.GetCurrentMethod().Name, index) != null)
            {
                return Convert.ToBoolean(Extensions.ExtensionApp.ExtendMyApp
                (MethodBase.GetCurrentMethod().Name, index));
            }

            //CÓDIGO
            if ((tempplayer[index].Inviting <= 0) && (tempplayer[index].Invited <= 0)) { return false; }
            if (tempplayer[index].InPShop > 0) { return false; }
            if (tempplayer[index].Shopping) { return false; }
            if (tempplayer[index].InBank) { return false; }
            if (tempplayer[index].InCraft) { return false; }
            if (tempplayer[index].InShop > 0) { return false; }
            if (tempplayer[index].InTrade > 0) { return false; }
            if (tempplayer[index].isDead) { return false; }
            return true;
        }
        //*********************************************************************************************
        // GetProfExpToNextLevel
        // Cálculo da exp necessária para a profissão do jogador subir de nível
        //*********************************************************************************************
        public static int GetpProfExpToNextLevel(int index, int type)
        {
            //EXTEND
            if (Extensions.ExtensionApp.ExtendMyApp
                (MethodBase.GetCurrentMethod().Name, index, type) != null)
            {
                return Convert.ToInt32(Extensions.ExtensionApp.ExtendMyApp
                (MethodBase.GetCurrentMethod().Name, index, type));
            }

            //CÓDIGO
            int level = PStruct.character[index, PStruct.player[index].SelectedChar].Prof_Level[type];
            double exptonextlevel = (level * 10) * 1.2;
            int exp = Convert.ToInt32(exptonextlevel);
            return exp;
        }
        //*********************************************************************************************
        // GetOpenProf
        // Retorna slot de profissão livre
        //*********************************************************************************************
        public static int GetOpenProf(int index)
        {
            //EXTEND
            if (Extensions.ExtensionApp.ExtendMyApp
                (MethodBase.GetCurrentMethod().Name, index) != null)
            {
                return Convert.ToInt32(Extensions.ExtensionApp.ExtendMyApp
                (MethodBase.GetCurrentMethod().Name, index));
            }

            //CÓDIGO
            //Limpa slot de troca
            for (int i = 1; i < Globals.Max_Profs_Per_Char; i++)
            {
                if (PStruct.character[index, PStruct.player[index].SelectedChar].Prof_Type[i] == 0)
                {
                    return i;
                }
            }

            return 0;
        }
        //*********************************************************************************************
        // ClearTempPlayer
        // Limpa informações temporárias do jogador
        //*********************************************************************************************
        public static void ClearTempPlayer(int index)
        {
            //EXTEND
            if (Extensions.ExtensionApp.ExtendMyApp
                (MethodBase.GetCurrentMethod().Name, index) != null)
            {
                return;
            }

            //CÓDIGO
            PStruct.tempplayer[index].ingame = false;
            PStruct.tempplayer[index].preparingskill = 0;
            PStruct.tempplayer[index].movespeed = 0;
            PStruct.tempplayer[index].Inviting = 0;
            PStruct.tempplayer[index].Invited = 0;
            PStruct.tempplayer[index].MaxSpirit = 0;
            PStruct.tempplayer[index].MaxVitality = 0;
            PStruct.tempplayer[index].Party = 0;
            PStruct.tempplayer[index].skilltimer = 0;
            PStruct.tempplayer[index].Spirit = 0;
            PStruct.tempplayer[index].target = 0;
            PStruct.tempplayer[index].targettype = 0;
            PStruct.tempplayer[index].Warping = false;
            PStruct.tempplayer[index].Vitality = 0;
            PStruct.tempplayer[index].preparingskillslot = 0;
            PStruct.tempplayer[index].InTrade = 0;
            PStruct.tempplayer[index].InCraft = false;
            PStruct.tempplayer[index].InBank = false;
            PStruct.tempplayer[index].Stunned = false;
            PStruct.tempplayer[index].Sleeping = false;
            PStruct.tempplayer[index].StunTimer = 0;
            PStruct.tempplayer[index].SleepTimer = 0;
            PStruct.tempplayer[index].ActivationCode = 0;
            PStruct.tempplayer[index].AttackTimer = 0;
            PStruct.tempplayer[index].InShop = 0;
            PStruct.tempplayer[index].InCraft = false;
            PStruct.tempplayer[index].InBank = false;
            PStruct.tempplayer[index].CraftType = 0;
            PStruct.tempplayer[index].CraftItem = 0;
            PStruct.tempplayer[index].Blind = false;
            PStruct.tempplayer[index].BlindTimer = 0;
            PStruct.tempplayer[index].Logged = false;
            PStruct.tempplayer[index].DataTimer = 0;
            PStruct.tempplayer[index].ChatTimer = 0;
            PStruct.tempplayer[index].ChatExcept = 0;
            PStruct.tempplayer[index].AllChatTimer = 0;
            PStruct.tempplayer[index].isDead = false;
            PStruct.tempplayer[index].ActivationCode = 0;
            PStruct.tempplayer[index].SORE = false;
            PStruct.tempplayer[index].Reflect = false;
            PStruct.tempplayer[index].ReflectTimer = 0;
            PStruct.tempplayer[index].Shopping = false;
            PStruct.tempplayer[index].InPShop = 0;
            //Limpa slot de troca
            for (int i = 1; i < Globals.MaxTradeOffers; i++)
            {
                PStruct.tradeslot[index, i].item = Globals.NullItem;
            }
        }
        //*********************************************************************************************
        // HasItem
        // Retorna se o jogador tem determinado item
        //*********************************************************************************************
        public static bool HasItem(int index, string item)
        {
            //EXTEND
            if (Extensions.ExtensionApp.ExtendMyApp
                (MethodBase.GetCurrentMethod().Name, index, item) != null)
            {
                return Convert.ToBoolean(Extensions.ExtensionApp.ExtendMyApp
                (MethodBase.GetCurrentMethod().Name, index, item));
            }

            //CÓDIGO
            string[] data = item.Split(',');
            string itemtype = data[0];
            string itemnum = data[1];
            int itemvalue = Convert.ToInt32(data[2]);

            string[] datainv;
            for (int i = 1; i < Globals.MaxInvSlot; i++)
            {
                datainv = PStruct.invslot[index, i].item.Split(',');
                if ((itemtype == datainv[0]) && (itemnum == datainv[1]) && (itemvalue <= Convert.ToInt32(datainv[2]))) { return true; }
            }

            return false;
        }
        //*********************************************************************************************
        // CraftHasItem
        // Retorna se existe determinado item no craft
        //*********************************************************************************************
        public static int CraftHasItem(int index, int type, int num)
        {
            //EXTEND
            if (Extensions.ExtensionApp.ExtendMyApp
                (MethodBase.GetCurrentMethod().Name, index, type, num) != null)
            {
                return Convert.ToInt32(Extensions.ExtensionApp.ExtendMyApp
                (MethodBase.GetCurrentMethod().Name, index, type, num));
            }

            //CÓDIGO
            for (int i = 1; i < Globals.Max_Craft; i++)
            {
                if ((PStruct.craft[index, i].num == num) && (PStruct.craft[index, i].type == type))
                {
                    return i;
                }
            }

            return -1;
        }
        //*********************************************************************************************
        // ClearItem
        // Limpar o item (?)
        //*********************************************************************************************
        public static bool ClearItem(int index, string item)
        {
            //EXTEND
            if (Extensions.ExtensionApp.ExtendMyApp
                (MethodBase.GetCurrentMethod().Name, index, item) != null)
            {
                return Convert.ToBoolean(Extensions.ExtensionApp.ExtendMyApp
                (MethodBase.GetCurrentMethod().Name, index, item));
            }

            //CÓDIGO
            for (int i = 1; i < Globals.MaxInvSlot; i++)
            {
                if (PStruct.invslot[index, i].item == item) { PStruct.invslot[index, i].item = Globals.NullItem; return true; }
            }

            return false;
        }
        //*********************************************************************************************
        // GiveSpell
        // Entrega determinada magia para determinado jogador
        //*********************************************************************************************
        public static bool GiveSpell(int index, int spellnum)
        {
            //EXTEND
            if (Extensions.ExtensionApp.ExtendMyApp
                (MethodBase.GetCurrentMethod().Name, index, spellnum) != null)
            {
                return Convert.ToBoolean(Extensions.ExtensionApp.ExtendMyApp
                (MethodBase.GetCurrentMethod().Name, index, spellnum));
            }

            //CÓDIGO
            if (GetSkillOpenSlot(index) > 0)
            {
                int openslot = GetSkillOpenSlot(index);
                PStruct.skill[index, openslot].level = 0;
                PStruct.skill[index, openslot].cooldown = 0;
                PStruct.skill[index, openslot].num = spellnum;
                return true;
            }
            else
            {
                SendData.Send_MsgToPlayer(index, lang.you_cant_learn_more_skills, Globals.ColorRed, Globals.Msg_Type_Server);
                return false;
            }
        }
        //*********************************************************************************************
        // PetAttack
        //*********************************************************************************************
        public static void PetAttack(int index, int target, int targettype)
        {
            //EXTEND
            if (Extensions.ExtensionApp.ExtendMyApp
                (MethodBase.GetCurrentMethod().Name, index, target, targettype) != null)
            {
                return;
            }

            //CÓDIGO
            PStruct.tempplayer[index].PetTarget = target;
            PStruct.tempplayer[index].PetTargetType = targettype;
            if (targettype == Globals.Target_Npc)
            {
                PlayerAttackNpc(index, target, 0, 0, false, 0, true);
            }
            else if (targettype == Globals.Target_Player)
            {
                PlayerAttackPlayer(index, target, 0, 0, false, 0, 0, true);
            }
            SendData.Send_PetAttack(index, target, targettype);
            PStruct.tempplayer[index].PetTimer = Loops.TickCount.ElapsedMilliseconds + 2000;
        }
        //*********************************************************************************************
        // PetMove
        //*********************************************************************************************
        public static void PetMove(int index)
        {
            //EXTEND
            if (Extensions.ExtensionApp.ExtendMyApp
                (MethodBase.GetCurrentMethod().Name, index) != null)
            {
                return;
            }

            //CÓDIGO
            if (PStruct.tempplayer[index].PetTimer > Loops.TickCount.ElapsedMilliseconds) { return; }
            if (PStruct.tempplayer[index].isDead) { return; }

            string equipment = PStruct.character[index, PStruct.player[index].SelectedChar].Equipment;
            string[] equipdata = equipment.Split(',');
            string[] petdata = equipdata[4].Split(';');

            int petnum = Convert.ToInt32(petdata[0]);
            int petlvl = Convert.ToInt32(petdata[1]);
            int petexp = Convert.ToInt32(petdata[2]);
            int Map = PStruct.character[index, PStruct.player[index].SelectedChar].Map;
            int targetx = PStruct.character[index, PStruct.player[index].SelectedChar].X;
            int targety = PStruct.character[index, PStruct.player[index].SelectedChar].Y;
            int lasttarget = tempplayer[index].LastTarget;
            int lasttargettype = tempplayer[index].LastTargetType;
            int target = tempplayer[index].PetTarget;
            int targettype = tempplayer[index].PetTargetType;
            int DistanceX = 0;
            int DistanceY = 0;
            int n = 2;

            if (petnum <= 0) { return; }

          


            if ((targettype == Globals.Target_Npc))
            {
                if ((NStruct.tempnpc[Map, target].Dead) || (NStruct.tempnpc[Map, target].Vitality <= 0))
                {
                    tempplayer[index].PetTarget = 0;
                    tempplayer[index].PetTargetType = 0;
                    return;
                }
                DistanceX = NStruct.tempnpc[Map, target].X - targetx;
                DistanceY = NStruct.tempnpc[Map, target].Y - targety;

                if (DistanceX < 0) { DistanceX = DistanceX * -1; }
                if (DistanceY < 0) { DistanceY = DistanceY * -1; }

                //Verificar se está no alcance
                if ((DistanceX <= n) && (DistanceY <= n))
                {
                    PetAttack(index, target, Globals.Target_Npc);
                    return;
                }
            }

            if ((targettype == Globals.Target_Player))
            {
                //Verificar se o jogador não se desconectou no processo
                int clientindex = UserConnection.Getindex(target);
                if ((clientindex < 0) || (clientindex >= WinsockAsync.Clients.Count())) 
                {
                    tempplayer[index].PetTarget = 0;
                    tempplayer[index].PetTargetType = 0;
                    return; }
                if ((clientindex < 0) || (clientindex >= WinsockAsync.Clients.Count())) 
                {
                    tempplayer[index].PetTarget = 0;
                    tempplayer[index].PetTargetType = 0;
                    return;}
                if (!WinsockAsync.Clients[clientindex].IsConnected) 
                {                  
                    tempplayer[index].PetTarget = 0;
                    tempplayer[index].PetTargetType = 0;
                    return; }

                //Verificar se não está morto ou sem vida
                if ((tempplayer[target].isDead) || (tempplayer[target].Vitality <= 0))
                {
                    tempplayer[index].PetTarget = 0;
                    tempplayer[index].PetTargetType = 0;
                    return;
                }
                //Condições preventivas
                if ((PStruct.character[target, PStruct.player[target].SelectedChar].Map == Map) && (target != index))
                {
                    if ((PStruct.character[target, PStruct.player[target].SelectedChar].PVP) || (PStruct.character[index, PStruct.player[index].SelectedChar].PVP))
                    {
                        DistanceX = PStruct.character[target, PStruct.player[target].SelectedChar].X - targetx;
                        DistanceY = PStruct.character[target, PStruct.player[target].SelectedChar].Y - targety;

                        if (DistanceX < 0) { DistanceX = DistanceX * -1; }
                        if (DistanceY < 0) { DistanceY = DistanceY * -1; }

                        //Verificar se está no alcance
                        if ((DistanceX <= n) && (DistanceY <= n))
                        {
                            PetAttack(index, target, Globals.Target_Player);
                            return;
                        }
                    }
                }
            }

            if ((lasttargettype == Globals.Target_Npc) && (NStruct.tempnpc[Map, lasttarget].Vitality > 0))
            {
                DistanceX = NStruct.tempnpc[Map, lasttarget].X - targetx;
                DistanceY = NStruct.tempnpc[Map, lasttarget].Y - targety;

                if (DistanceX < 0) { DistanceX = DistanceX * -1; }
                if (DistanceY < 0) { DistanceY = DistanceY * -1; }

                //Verificar se está no alcance
                if ((DistanceX <= n) && (DistanceY <= n))
                {
                    PetAttack(index, lasttarget, Globals.Target_Npc);
                    return;
                }
            }

            if ((lasttargettype == Globals.Target_Player) && (tempplayer[lasttarget].Vitality > 0))
            {
                //Condições preventivas
                if ((PStruct.character[lasttarget, PStruct.player[lasttarget].SelectedChar].Map == Map) && (lasttarget != index))
                {
                    if ((PStruct.character[lasttarget, PStruct.player[lasttarget].SelectedChar].PVP) || (PStruct.character[index, PStruct.player[index].SelectedChar].PVP))
                    {
                        DistanceX = PStruct.character[lasttarget, PStruct.player[lasttarget].SelectedChar].X - targetx;
                        DistanceY = PStruct.character[lasttarget, PStruct.player[lasttarget].SelectedChar].Y - targety;

                        if (DistanceX < 0) { DistanceX = DistanceX * -1; }
                        if (DistanceY < 0) { DistanceY = DistanceY * -1; }

                        //Verificar se está no alcance
                        if ((DistanceX <= n) && (DistanceY <= n))
                        {
                            PetAttack(index, lasttarget, Globals.Target_Player);
                            return;
                        }
                    }

                }
            }

            //Analisa todos os npcs do mapa
            for (int i = 0; i <= MStruct.tempmap[Map].NpcCount; i++)
            {
                if (NStruct.tempnpc[Map, i].Vitality > 0)
                {
                    if (NStruct.tempnpc[Map, i].Target > 0)
                    {
                        DistanceX = NStruct.tempnpc[Map, i].X - targetx;
                        DistanceY = NStruct.tempnpc[Map, i].Y - targety;

                        if (DistanceX < 0) { DistanceX = DistanceX * -1; }
                        if (DistanceY < 0) { DistanceY = DistanceY * -1; }

                        //Verificar se está no alcance
                        if ((DistanceX <= n) && (DistanceY <= n))
                        {
                            PetAttack(index, i, Globals.Target_Npc);
                            return;
                        }
                    }
                }
            }

            //Analisar todos os jogadores online
            for (int i = 0; i <= Globals.Player_Highindex; i++)
            {
                if ((!tempplayer[i].isDead) && (tempplayer[i].Vitality > 0))
                {
                    //Condições preventivas
                    if ((PStruct.character[i, PStruct.player[i].SelectedChar].Map == Map) && (i != index))
                    {
                        if (PStruct.character[i, PStruct.player[i].SelectedChar].Guild != PStruct.character[index, PStruct.player[index].SelectedChar].Guild)
                        {
                            if (tempplayer[i].Party != tempplayer[index].Party)
                            {
                                if ((PStruct.character[i, PStruct.player[i].SelectedChar].PVP) || (PStruct.character[index, PStruct.player[index].SelectedChar].PVP))
                                {
                                    DistanceX = PStruct.character[i, PStruct.player[i].SelectedChar].X - targetx;
                                    DistanceY = PStruct.character[i, PStruct.player[i].SelectedChar].Y - targety;

                                    if (DistanceX < 0) { DistanceX = DistanceX * -1; }
                                    if (DistanceY < 0) { DistanceY = DistanceY * -1; }

                                    //Verificar se está no alcance
                                    if ((DistanceX <= n) && (DistanceY <= n))
                                    {
                                        PetAttack(index, i, Globals.Target_Player);
                                        return;
                                    }
                                }
                            }
                        }
                    }
                }
            }
        
        }
        //*********************************************************************************************
        // GivePShopItem
        // Entrega item da loja do jogador ao próprio jogador
        //*********************************************************************************************
        public static bool GivePShopItem(int index, int itemt, int itemn, int itemv, int itemr, int itemp, int itemex)
        {
            //EXTEND
            if (Extensions.ExtensionApp.ExtendMyApp
                (MethodBase.GetCurrentMethod().Name, index, itemt, itemn, itemv, itemr, itemp, itemex) != null)
            {
                return Convert.ToBoolean(Extensions.ExtensionApp.ExtendMyApp
                (MethodBase.GetCurrentMethod().Name, index, itemt, itemn, itemv, itemr, itemp, itemex));
            }

            //CÓDIGO
            //Já temos os item? Se sim, adicionar.
            for (int i = 1; i < Globals.Max_PShops; i++)
            {

                int itemNum = PStruct.character[index, PStruct.player[index].SelectedChar].pshopslot[i].num;
                int itemType = PStruct.character[index, PStruct.player[index].SelectedChar].pshopslot[i].type;
                int itemValue = PStruct.character[index, PStruct.player[index].SelectedChar].pshopslot[i].value;
                int itemRefin = PStruct.character[index, PStruct.player[index].SelectedChar].pshopslot[i].refin;
                int itemExp = PStruct.character[index, PStruct.player[index].SelectedChar].pshopslot[i].exp;
                int itemPrice = PStruct.character[index, PStruct.player[index].SelectedChar].pshopslot[i].price;

                if ((itemn == itemNum) && (itemt == itemType) && (itemr == itemRefin) && (itemp == itemPrice) && (itemex == itemExp))
                {
                    PStruct.character[index, PStruct.player[index].SelectedChar].pshopslot[i].value += itemv;
                    return true;
                }
            }
            if (GetPShopOpenSlot(index) > 0)
            {
                int openslot = GetPShopOpenSlot(index);
                PStruct.character[index, PStruct.player[index].SelectedChar].pshopslot[openslot].type = itemt;
                PStruct.character[index, PStruct.player[index].SelectedChar].pshopslot[openslot].num = itemn;
                PStruct.character[index, PStruct.player[index].SelectedChar].pshopslot[openslot].value = itemv;
                PStruct.character[index, PStruct.player[index].SelectedChar].pshopslot[openslot].refin = itemr;
                PStruct.character[index, PStruct.player[index].SelectedChar].pshopslot[openslot].exp = itemex;
                PStruct.character[index, PStruct.player[index].SelectedChar].pshopslot[openslot].price = itemp;
                return true;
            }
            else
            {
                return false;
            }
        }
        //*********************************************************************************************
        // GetSkillOpenSlot
        // Retorna slot de skill livre para determinado jogador
        //*********************************************************************************************
        public static int GetSkillOpenSlot(int index)
        {
            //EXTEND
            if (Extensions.ExtensionApp.ExtendMyApp
                (MethodBase.GetCurrentMethod().Name, index) != null)
            {
                return Convert.ToInt32(Extensions.ExtensionApp.ExtendMyApp
                (MethodBase.GetCurrentMethod().Name, index));
            }

            //CÓDIGO
            for (int i = 9; i < Globals.MaxPlayer_Skills; i++)
            {
                if (PStruct.skill[index, i].num == 0) { return i; }
            }

            return 0;
        }
        //*********************************************************************************************
        // GetPShopOpenSlot
        // Retorna slot livre na loja pessoal de determinado jogador
        //*********************************************************************************************
        public static int GetPShopOpenSlot(int index)
        {
            //EXTEND
            if (Extensions.ExtensionApp.ExtendMyApp
                (MethodBase.GetCurrentMethod().Name, index) != null)
            {
                return Convert.ToInt32(Extensions.ExtensionApp.ExtendMyApp
                (MethodBase.GetCurrentMethod().Name, index));
            }

            //CÓDIGO
            for (int i = 1; i < Globals.Max_PShops; i++)
            {
                if (PStruct.character[index, PStruct.player[index].SelectedChar].pshopslot[i].num == 0) { return i; }
            }

            return 0;
        }
        //*********************************************************************************************
        // GetPlayerMaxSpirit
        // Retorna enegia máxima de determinado jogador
        //*********************************************************************************************
        public static int GetPlayerMaxSpirit(int index)
        {
            //EXTEND
            if (Extensions.ExtensionApp.ExtendMyApp
                (MethodBase.GetCurrentMethod().Name, index) != null)
            {
                return Convert.ToInt32(Extensions.ExtensionApp.ExtendMyApp
                (MethodBase.GetCurrentMethod().Name, index));
            }

            //CÓDIGO
            int LevelVital = 0;
            if (PStruct.character[index, PStruct.player[index].SelectedChar].ClassId == 1) { LevelVital = PStruct.character[index, PStruct.player[index].SelectedChar].Level * 30; }
            else if (PStruct.character[index, PStruct.player[index].SelectedChar].ClassId == 2) { LevelVital = PStruct.character[index, PStruct.player[index].SelectedChar].Level * 22; }
            else if (PStruct.character[index, PStruct.player[index].SelectedChar].ClassId == 3) { LevelVital = PStruct.character[index, PStruct.player[index].SelectedChar].Level * 60; }
            else if (PStruct.character[index, PStruct.player[index].SelectedChar].ClassId == 4) { LevelVital = PStruct.character[index, PStruct.player[index].SelectedChar].Level * 18; }
            else if (PStruct.character[index, PStruct.player[index].SelectedChar].ClassId == 5) { LevelVital = PStruct.character[index, PStruct.player[index].SelectedChar].Level * 14; }
            else if (PStruct.character[index, PStruct.player[index].SelectedChar].ClassId == 6) { LevelVital = PStruct.character[index, PStruct.player[index].SelectedChar].Level * 40; }
            double FireVital = Convert.ToDouble(PStruct.character[index, PStruct.player[index].SelectedChar].Fire) * 0.5;
            double EarthVital = Convert.ToDouble(PStruct.character[index, PStruct.player[index].SelectedChar].Earth) * 0.8;
            double WaterVital = Convert.ToDouble(PStruct.character[index, PStruct.player[index].SelectedChar].Water) * 1.2;
            double WindVital = Convert.ToDouble(PStruct.character[index, PStruct.player[index].SelectedChar].Wind) * 1.3;
            double DarkVital = Convert.ToDouble(PStruct.character[index, PStruct.player[index].SelectedChar].Dark) * 2;
            double LightVital = Convert.ToDouble(PStruct.character[index, PStruct.player[index].SelectedChar].Light) * 1.5;
            double DVital = FireVital + EarthVital + WaterVital + WindVital + DarkVital + LightVital;
            int vital = Convert.ToInt32(DVital) + LevelVital;
            if (GetExtraSpirit(index) > 0) { vital += (vital / 100) * GetExtraSpirit(index); }
            if (PStruct.tempplayer[index].SORE) { vital = vital / 2; }
            return vital;
        }
        //*********************************************************************************************
        // GetPlayerMaxVitality
        // Retorna vida máxima de determinado jogador
        //*********************************************************************************************
        public static int GetPlayerMaxVitality(int index)
        {
            //EXTEND
            if (Extensions.ExtensionApp.ExtendMyApp
                (MethodBase.GetCurrentMethod().Name, index) != null)
            {
                return Convert.ToInt32(Extensions.ExtensionApp.ExtendMyApp
                (MethodBase.GetCurrentMethod().Name, index));
            }

            //CÓDIGO
            int LevelVital = 0;
            if (PStruct.character[index, PStruct.player[index].SelectedChar].ClassId == 1) { LevelVital = PStruct.character[index, PStruct.player[index].SelectedChar].Level * 52; }
            else if (PStruct.character[index, PStruct.player[index].SelectedChar].ClassId == 2) { LevelVital = PStruct.character[index, PStruct.player[index].SelectedChar].Level * 63; }
            else if (PStruct.character[index, PStruct.player[index].SelectedChar].ClassId == 3) { LevelVital = PStruct.character[index, PStruct.player[index].SelectedChar].Level * 34; }
            else if (PStruct.character[index, PStruct.player[index].SelectedChar].ClassId == 4) { LevelVital = PStruct.character[index, PStruct.player[index].SelectedChar].Level * 40; }
            else if (PStruct.character[index, PStruct.player[index].SelectedChar].ClassId == 5) { LevelVital = PStruct.character[index, PStruct.player[index].SelectedChar].Level * 76; }
            else if (PStruct.character[index, PStruct.player[index].SelectedChar].ClassId == 6) { LevelVital = PStruct.character[index, PStruct.player[index].SelectedChar].Level * 32; }
            //int LevelVital = PStruct.character[index, PStruct.player[index].SelectedChar].Level * 75;
            double FireVital = Convert.ToDouble(PStruct.character[index, PStruct.player[index].SelectedChar].Fire) * 2.5;
            double EarthVital = Convert.ToDouble(PStruct.character[index, PStruct.player[index].SelectedChar].Earth) * 4;
            double WaterVital = Convert.ToDouble(PStruct.character[index, PStruct.player[index].SelectedChar].Water) * 2.3;
            double WindVital = Convert.ToDouble(PStruct.character[index, PStruct.player[index].SelectedChar].Wind) * 2.2;
            double DarkVital = Convert.ToDouble(PStruct.character[index, PStruct.player[index].SelectedChar].Dark) * 1.8;
            double LightVital = Convert.ToDouble(PStruct.character[index, PStruct.player[index].SelectedChar].Light) * 1.5;
            double DVital = FireVital + EarthVital + WaterVital + WindVital + DarkVital + LightVital;
            int vital = Convert.ToInt32(DVital) + LevelVital;
            if (GetExtraVitality(index) > 0) { vital += (vital / 100) * GetExtraVitality(index); }
            if (PStruct.tempplayer[index].SORE) { vital = vital / 2; }
            return vital;
        }
        //*********************************************************************************************
        // GetExtraVitality
        // Vida que deve ser adicionada baseado em algum status, magia ou item especial
        //*********************************************************************************************
        public static int GetExtraVitality(int index)
        {
            //EXTEND
            if (Extensions.ExtensionApp.ExtendMyApp
                (MethodBase.GetCurrentMethod().Name, index) != null)
            {
                return Convert.ToInt32(Extensions.ExtensionApp.ExtendMyApp
                (MethodBase.GetCurrentMethod().Name, index));
            }

            //CÓDIGO
          int vital = 0;
          if (PStruct.character[index, PStruct.player[index].SelectedChar].ClassId == 5)
            {
                for (int i = 1; i < Globals.MaxPlayer_Skills; i++)
                {
                    if ((PStruct.skill[index, i].num == 35) && (PStruct.skill[index, i].level > 0))
                    {
                        vital = 40;
                        break;
                    }
                }
            }
          return vital;
        }
        //*********************************************************************************************
        // GetExtraSpirit
        // Energia que deve ser adicionada baseada em algum status, item ou magia especial
        //*********************************************************************************************
        public static int GetExtraSpirit(int index)
        {
            //EXTEND
            if (Extensions.ExtensionApp.ExtendMyApp
                (MethodBase.GetCurrentMethod().Name, index) != null)
            {
                return Convert.ToInt32(Extensions.ExtensionApp.ExtendMyApp
                (MethodBase.GetCurrentMethod().Name, index));
            }

            //CÓDIGO
            int vital = 0;
            if (PStruct.character[index, PStruct.player[index].SelectedChar].ClassId == 1)
            {
                for (int i = 1; i < Globals.MaxPlayer_Skills; i++)
                {
                    if ((PStruct.skill[index, i].num == 46) && (PStruct.skill[index, i].level > 0))
                    {
                        vital = 10;
                        break;
                    }
                }
            }
            return vital;
        }
        //*********************************************************************************************
        // GetPlayerVitalityRegen
        //*********************************************************************************************
        public static int GetPlayerVitalityRegen(int index)
        {
            //EXTEND
            if (Extensions.ExtensionApp.ExtendMyApp
                (MethodBase.GetCurrentMethod().Name, index) != null)
            {
                return Convert.ToInt32(Extensions.ExtensionApp.ExtendMyApp
                (MethodBase.GetCurrentMethod().Name, index));
            }

            //CÓDIGO
            double LightRegen = Convert.ToDouble(PStruct.character[index, PStruct.player[index].SelectedChar].Light) * 0.6;
            int vital = 1 + Convert.ToInt32(LightRegen); //per second
            if (PStruct.character[index, PStruct.player[index].SelectedChar].ClassId == 2)
            {
                for (int i = 1; i < Globals.MaxPlayer_Skills; i++)
                {
                    if ((PStruct.skill[index, i].num == 52) && (PStruct.skill[index, i].level > 0))
                    {
                        vital += ((GetPlayerMaxVitality(index) / 100) * PStruct.skill[index, i].level);
                        break;
                    }
                }
            }
            return vital;
        }
        //*********************************************************************************************
        // GetPlayerSpiritRegen
        //*********************************************************************************************
        public static int GetPlayerSpiritRegen(int index)
        {
            //EXTEND
            if (Extensions.ExtensionApp.ExtendMyApp
                (MethodBase.GetCurrentMethod().Name, index) != null)
            {
                return Convert.ToInt32(Extensions.ExtensionApp.ExtendMyApp
                (MethodBase.GetCurrentMethod().Name, index));
            }

            //CÓDIGO
            double DarkRegen = Convert.ToDouble(PStruct.character[index, PStruct.player[index].SelectedChar].Dark) * 0.3;
            int vital = 1 + Convert.ToInt32(DarkRegen); //per second
            return vital;
        }
        //*********************************************************************************************
        // CanPlayerAttackNpc / Revisto pela última vez em 01/08/2016, criado por Allyson S. Bacon
        // Verifica se determinado jogador pode atacar determinado npc no contexto em que está
        //*********************************************************************************************
        public static bool CanPlayerAttackNpc(int Attacker, int Victim)
        {
            //EXTEND
            if (Extensions.ExtensionApp.ExtendMyApp
                (MethodBase.GetCurrentMethod().Name, Attacker, Victim) != null)
            {
                return Convert.ToBoolean(Extensions.ExtensionApp.ExtendMyApp
                (MethodBase.GetCurrentMethod().Name, Attacker, Victim));
            }

            //CÓDIGO
            int Map = PStruct.character[Attacker, PStruct.player[Attacker].SelectedChar].Map;
            int Dir = PStruct.character[Attacker, PStruct.player[Attacker].SelectedChar].Dir;
            int NpcX = 0;
            int NpcY = 0;
            int PlayerX = PStruct.character[Attacker, PStruct.player[Attacker].SelectedChar].X;
            int PlayerY = PStruct.character[Attacker, PStruct.player[Attacker].SelectedChar].Y;

            if (NStruct.tempnpc[Map, Victim].Dead == true) { return false; }
            //if (NStruct.tempnpc[Map, Victim].guildnum == PStruct.character[Attacker, PStruct.player[Attacker].SelectedChar].Guild) { return false; }

            switch (Dir)
            {
                case 8:
                    NpcX = NStruct.tempnpc[Map, Victim].X;
                    NpcY = NStruct.tempnpc[Map, Victim].Y + 1;
                    break;
                case 2:
                    NpcX = NStruct.tempnpc[Map, Victim].X;
                    NpcY = NStruct.tempnpc[Map, Victim].Y - 1;
                    break;
                case 4:
                    NpcX = NStruct.tempnpc[Map, Victim].X + 1;
                    NpcY = NStruct.tempnpc[Map, Victim].Y;
                    break;
                case 6:
                    NpcX = NStruct.tempnpc[Map, Victim].X - 1;
                    NpcY = NStruct.tempnpc[Map, Victim].Y;
                    break;
                default:
                    WinsockAsync.Log(String.Format("Direção nula"));
                    return false;
            }
            
            if ((NpcX == PlayerX) && (NpcY == PlayerY))
            {
                return true;
            }

            return false;
        }
        //*********************************************************************************************
        // CanPlayerAttackPlayer / Revisto pela última vez em 01/08/2016, criado por Allyson S. Bacon
        // Verifica se determinado jogador pode atacar outro jogador determinado no contexto em que
        // ambos estão.
        //*********************************************************************************************
        public static bool CanPlayerAttackPlayer(int Attacker, int Victim)
        {
            //EXTEND
            if (Extensions.ExtensionApp.ExtendMyApp
                (MethodBase.GetCurrentMethod().Name, Attacker, Victim) != null)
            {
                return Convert.ToBoolean(Extensions.ExtensionApp.ExtendMyApp
                (MethodBase.GetCurrentMethod().Name, Attacker, Victim));
            }

            //CÓDIGO
            int Map = Convert.ToInt32(PStruct.character[Attacker, PStruct.player[Attacker].SelectedChar].Map);
            int Dir = PStruct.character[Attacker, PStruct.player[Attacker].SelectedChar].Dir;
            int VictimX = PStruct.character[Victim, PStruct.player[Victim].SelectedChar].X;
            int VictimY = PStruct.character[Victim, PStruct.player[Victim].SelectedChar].Y;
            int PlayerX = PStruct.character[Attacker, PStruct.player[Attacker].SelectedChar].X;
            int PlayerY = PStruct.character[Attacker, PStruct.player[Attacker].SelectedChar].Y;

            if (PStruct.tempplayer[Victim].isDead == true) { return false; }

            if (!MStruct.tempmap[Map].WarActive)
            {
                if (PStruct.character[Victim, PStruct.player[Victim].SelectedChar].Level < 10) { SendData.Send_MsgToPlayer(Attacker, lang.pvp_level_restriction, Globals.ColorRed, Globals.Msg_Type_Server); return false; }
                if (!MStruct.MapIsPVP(Map)) { SendData.Send_MsgToPlayer(Attacker, lang.pvp_safe_zone, Globals.ColorRed, Globals.Msg_Type_Server); return false; }
            }

            switch (Dir)
            {
                case 8:
                    VictimY += 1;
                    break;
                case 2:
                    VictimY -= 1;
                    break;
                case 4:
                    VictimX += 1;
                    break;
                case 6:
                    VictimX -= 1;
                    break;
                default:
                    WinsockAsync.Log(String.Format("Direção nula"));
                    return false;
            }

            if ((VictimX == PlayerX) && (VictimY == PlayerY))
            {
                return true;
            }

            return false;
        }
        //*********************************************************************************************
        // GetPlayerElement / Revisto pela última vez em 01/08/2016, criado por Allyson S. Bacon
        //*********************************************************************************************
        public static int GetPlayerElement(int index, int element)
        {
            //EXTEND
            if (Extensions.ExtensionApp.ExtendMyApp
                (MethodBase.GetCurrentMethod().Name, index, element) != null)
            {
                return Convert.ToInt32(Extensions.ExtensionApp.ExtendMyApp
                (MethodBase.GetCurrentMethod().Name, index, element));
            }

            //CÓDIGO
            int quantity = 0;

            if (element == 1)
            {
                return Convert.ToInt32(PStruct.character[index, PStruct.player[index].SelectedChar].Fire);
            }

            if (element == 2)
            {
                return Convert.ToInt32(PStruct.character[index, PStruct.player[index].SelectedChar].Earth);
            }
            if (element == 3)
            {
                return Convert.ToInt32(PStruct.character[index, PStruct.player[index].SelectedChar].Water);
            }
            if (element == 4)
            {
                return Convert.ToInt32(PStruct.character[index, PStruct.player[index].SelectedChar].Wind);
            }
            if (element == 5)
            {
                return Convert.ToInt32(PStruct.character[index, PStruct.player[index].SelectedChar].Dark);
            }
            if (element == 6)
            {
                return Convert.ToInt32(PStruct.character[index, PStruct.player[index].SelectedChar].Light);
            }

            return quantity;
        }
        //*********************************************************************************************
        // GetRefinCraft / Revisto pela última vez em 01/08/2016, criado por Allyson S. Bacon
        //*********************************************************************************************
        public static int GetRefinCraft(int index, int type)
        {
            //EXTEND
            if (Extensions.ExtensionApp.ExtendMyApp
                (MethodBase.GetCurrentMethod().Name, index, type) != null)
            {
                return Convert.ToInt32(Extensions.ExtensionApp.ExtendMyApp
                (MethodBase.GetCurrentMethod().Name, index, type));
            }

            //CÓDIGO
            //Váriaveis
            int RefinChance = GetRefinDrop();
            int Refin = RefinChance;

            //Retorna o valor de Refin
            return Refin;
        }
        //*********************************************************************************************
        // GetRefinDrop / Revisto pela última vez em 01/08/2016, criado por Allyson S. Bacon
        //*********************************************************************************************
        public static int GetRefinDrop()
        {
            //EXTEND
            if (Extensions.ExtensionApp.ExtendMyApp
                (MethodBase.GetCurrentMethod().Name) != null)
            {
                return Convert.ToInt32(Extensions.ExtensionApp.ExtendMyApp
                (MethodBase.GetCurrentMethod().Name));
            }

            //CÓDIGO
            //Váriaveis
            int RefinChance = Globals.Rand(1, 100);
            int Refin = 0;


            //Verificação e definição do nível de Refin
            if ((RefinChance <= 30)  && (RefinChance >= 16))// 30% Refin 1
            {
                Refin = 1;
            }
            else if ((RefinChance <= 51) && (RefinChance >= 31)) // 20% Refin 2
            {
                Refin = 2;
            }
            else if ((RefinChance <= 67) && (RefinChance >= 52)) // 15% Refin 3
            {
                Refin = 3;
            }
            else if ((RefinChance <= 78) && (RefinChance >= 68)) // 10% Refin 4
            {
                Refin = 4;
            }
            else if ((RefinChance <= 87) && (RefinChance >= 79)) // 8% Refin 5
            {
                Refin = 5;
            }
            else if ((RefinChance <= 87) && (RefinChance >= 85)) // 5% Refin 6
            {
                Refin = 6;
            }
            else if ((RefinChance <= 90) && (RefinChance >= 88)) // 3% Refin 7
            {
                Refin = 7;
            }
            else if ((RefinChance <= 92) && (RefinChance >= 91)) // 1.x% Refin 8
            {
                Refin = 8;
            }
            else if ((RefinChance <= 94) && (RefinChance >= 93)) // 1.x% Refin 9
            {
                Refin = 9;
            }
            else if ((RefinChance <= 96) && (RefinChance >= 95)) // 1.x% Refin 10
            {
                Refin = 10;
            }
            else if ((RefinChance <= 98) && (RefinChance >= 97)) // 1.x% Refin 11
            {
                Refin = 11;
            }
            else if (RefinChance == 99) // 0.5% Refin 12
            {
                Refin = 12;
            }
            else if (RefinChance == 100) // 0.5% Refin 13
            {
                Refin = 13;
            }

            //Retorna o valor de Refin
            return Refin;
        }
        //*********************************************************************************************
        // DropItem / Revisto pela última vez em 01/08/2016, criado por Allyson S. Bacon
        // Faz com que determinado item apareça em determinado mapa
        //*********************************************************************************************
        public static void DropItem(int Map, int MapItem, int x, int y, int Value, int ItemNum, int ItemType, int ItemRefin)
        {
            //EXTEND
            if (Extensions.ExtensionApp.ExtendMyApp
                (MethodBase.GetCurrentMethod().Name, Map, MapItem, x, y, Value, ItemNum, ItemType, ItemRefin) != null)
            {
                return;
            }

            //CÓDIGO
            MStruct.mapitem[Map, MapItem].Value = Value;
            MStruct.mapitem[Map, MapItem].X = x;
            MStruct.mapitem[Map, MapItem].Y = y;
            MStruct.mapitem[Map, MapItem].ItemNum = ItemNum;
            MStruct.mapitem[Map, MapItem].ItemType = ItemType;
            MStruct.mapitem[Map, MapItem].Refin = ItemRefin;
            MStruct.mapitem[Map, MapItem].Timer = Loops.TickCount.ElapsedMilliseconds + 600000;
        }
        //*********************************************************************************************
        // GetPlayerSkillSlot / Revisto pela última vez em 01/08/2016, criado por Allyson S. Bacon
        // Retorna determinada magia baseado no slot em que está.
        //*********************************************************************************************
        public static int GetPlayerSkillSlot(int index, int SkillNum, bool by_skill_slot = false)
        {
            //EXTEND
            if (Extensions.ExtensionApp.ExtendMyApp
                (MethodBase.GetCurrentMethod().Name, index, SkillNum, by_skill_slot) != null)
            {
                return Convert.ToInt32(Extensions.ExtensionApp.ExtendMyApp
                (MethodBase.GetCurrentMethod().Name, index, SkillNum, by_skill_slot));
            }

            //CÓDIGO
            if (!by_skill_slot)
            {
                for (int i = 1; i < Globals.MaxHotkeys; i++)
                {
                    if (PStruct.skill[index, PStruct.hotkey[index, i].num].num == SkillNum)
                    {
                        return i;
                    }
                }
            }

            for (int i = 1; i < Globals.MaxPlayer_Skills; i++)
            {
                if (PStruct.skill[index, i].num == SkillNum)
                {
                    return i;
                }
            }

            return 0;
        }
        //*********************************************************************************************
        // GetOpenPassiveEffect / Revisto pela última vez em 01/08/2016, criado por Allyson S. Bacon
        //*********************************************************************************************
        public static int GetOpenPassiveEffect(int index)
        {
            //EXTEND
            if (Extensions.ExtensionApp.ExtendMyApp
                (MethodBase.GetCurrentMethod().Name, index) != null)
            {
                return Convert.ToInt32(Extensions.ExtensionApp.ExtendMyApp
                (MethodBase.GetCurrentMethod().Name, index));
            }

            //CÓDIGO
            for (int i = 1; i < Globals.MaxPassiveEffects; i++)
            {
                if (!PStruct.ppassiveffect[index, i].active)
                {
                    return i;
                }
            }

            return 0;
        }
        //*********************************************************************************************
        // GetOpenSpellBuff / Revisto pela última vez em 01/08/2016, criado por Allyson S. Bacon
        //*********************************************************************************************
        public static int GetOpenSpellBuff(int index)
        {
            //EXTEND
            if (Extensions.ExtensionApp.ExtendMyApp
                (MethodBase.GetCurrentMethod().Name, index) != null)
            {
                return Convert.ToInt32(Extensions.ExtensionApp.ExtendMyApp
                (MethodBase.GetCurrentMethod().Name, index));
            }

            //CÓDIGO
            for (int i = 1; i < Globals.MaxSpellBuffs; i++)
            {
                if (!PStruct.pspellbuff[index, i].active)
                {
                    return i;
                }
            }

            return 0;
        }
        //*********************************************************************************************
        // IsActiveSpellBuff / Revisto pela última vez em 01/08/2016, criado por Allyson S. Bacon
        //*********************************************************************************************
        public static int IsActiveSpellBuff(int index)
        {
            //EXTEND
            if (Extensions.ExtensionApp.ExtendMyApp
                (MethodBase.GetCurrentMethod().Name, index) != null)
            {
                return Convert.ToInt32(Extensions.ExtensionApp.ExtendMyApp
                (MethodBase.GetCurrentMethod().Name, index));
            }

            //CÓDIGO
            for (int i = 1; i < Globals.MaxSpellBuffs; i++)
            {
                if (!PStruct.pspellbuff[index, i].active)
                {
                    return i;
                }
            }

            return 0;
        }
        //*********************************************************************************************
        // ExecutePassiveEffect / Revisto pela última vez em 01/08/2016, criado por Allyson S. Bacon
        //*********************************************************************************************
        public static void ExecutePassiveEffect(int index, int passive)
        {
            //EXTEND
            if (Extensions.ExtensionApp.ExtendMyApp
                (MethodBase.GetCurrentMethod().Name, index, passive) != null)
            {
                return;
            }

            //CÓDIGO
            if (PStruct.ppassiveffect[index, passive].targettype == 1)
            {
                //Jogador
                if (PStruct.ppassiveffect[index, passive].type == 1) //DANO
                {
                    SendData.Send_Animation(PStruct.character[index, PStruct.player[index].SelectedChar].Map, PStruct.ppassiveffect[index, passive].targettype, PStruct.ppassiveffect[index, passive].target, SStruct.skill[PStruct.ppassiveffect[index, passive].spellnum].animation_id);
                    PlayerAttackPlayer(index, PStruct.ppassiveffect[index, passive].target, PStruct.ppassiveffect[index, passive].spellnum, PStruct.character[index, PStruct.player[index].SelectedChar].Map, true);
                    PStruct.ppassiveffect[index, passive].active = false;
                    PStruct.ppassiveffect[index, passive].type = 0;
                    PStruct.ppassiveffect[index, passive].timer = 0;
                    PStruct.ppassiveffect[index, passive].target = 0;
                    PStruct.ppassiveffect[index, passive].targettype = 0;
                    PStruct.ppassiveffect[index, passive].spellnum = 0;
                    return;
                }
            }
            if (PStruct.ppassiveffect[index, passive].targettype == 2)
            {
                //NPC
                if (PStruct.ppassiveffect[index, passive].type == 1) //DANO
                {
                    SendData.Send_Animation(PStruct.character[index, PStruct.player[index].SelectedChar].Map, PStruct.ppassiveffect[index, passive].targettype, PStruct.ppassiveffect[index, passive].target, SStruct.skill[PStruct.ppassiveffect[index, passive].spellnum].animation_id);
                    PlayerAttackNpc(index, PStruct.ppassiveffect[index, passive].target, PStruct.ppassiveffect[index, passive].spellnum, PStruct.character[index, PStruct.player[index].SelectedChar].Map, true);
                    PStruct.ppassiveffect[index, passive].active = false;
                    PStruct.ppassiveffect[index, passive].type = 0;
                    PStruct.ppassiveffect[index, passive].timer = 0;
                    PStruct.ppassiveffect[index, passive].target = 0;
                    PStruct.ppassiveffect[index, passive].targettype = 0;
                    PStruct.ppassiveffect[index, passive].spellnum = 0;
                    return;
                }
            }
            PStruct.ppassiveffect[index, passive].active = false;
            PStruct.ppassiveffect[index, passive].type = 0;
            PStruct.ppassiveffect[index, passive].timer = 0;
            PStruct.ppassiveffect[index, passive].target = 0;
            PStruct.ppassiveffect[index, passive].targettype = 0;
            PStruct.ppassiveffect[index, passive].spellnum = 0;
        }
        //*********************************************************************************************
        // SkillPassive / Revisto pela última vez em 01/08/2016, criado por Allyson S. Bacon
        //*********************************************************************************************
        public static void SkillPassive(int index, int targettype, int target)
        {
            //EXTEND
            if (Extensions.ExtensionApp.ExtendMyApp
                (MethodBase.GetCurrentMethod().Name, index, targettype, target) != null)
            {
                return;
            }

            //CÓDIGO
            int open_passive = GetOpenPassiveEffect(index);

            if (open_passive == 0) { return; }

            for (int i = 1; i < Globals.MaxPlayer_Skills; i++)
            {
                if (SStruct.skill[PStruct.skill[index, i].num].type == 10)
                {
                    int levelmultiplier = (SStruct.skill[PStruct.skill[index, i].num].passive_multiplier) * PStruct.skill[index, i].level;
                    int chance = SStruct.skill[PStruct.skill[index, i].num].passive_chance + levelmultiplier;


                    //Motivação Aiprah
                    if (SStruct.skill[PStruct.skill[index, i].num].passive_type == 1)
                    {
                        int passive_test = Globals.Rand(1, 100);
                        if (passive_test <= chance)
                        {
                            if (targettype == 2)
                            {
                                PStruct.ppassiveffect[index, open_passive].spellnum = PStruct.skill[index, i].num;
                                PStruct.ppassiveffect[index, open_passive].timer = Loops.TickCount.ElapsedMilliseconds + SStruct.skill[PStruct.skill[index, i].num].passive_interval;
                                PStruct.ppassiveffect[index, open_passive].target = target;
                                PStruct.ppassiveffect[index, open_passive].targettype = targettype;
                                PStruct.ppassiveffect[index, open_passive].type = 1;
                                PStruct.ppassiveffect[index, open_passive].active = true;
                            }
                            if (targettype == 1)
                            {
                                PStruct.ppassiveffect[index, open_passive].spellnum = PStruct.skill[index, i].num;
                                PStruct.ppassiveffect[index, open_passive].timer = Loops.TickCount.ElapsedMilliseconds + SStruct.skill[PStruct.skill[index, i].num].passive_interval;
                                PStruct.ppassiveffect[index, open_passive].target = target;
                                PStruct.ppassiveffect[index, open_passive].targettype = targettype;
                                PStruct.ppassiveffect[index, open_passive].type = 1;
                                PStruct.ppassiveffect[index, open_passive].active = true;
                            }
                        }
                    }

                }
            }
        }
        //*********************************************************************************************
        // PlayerAttackNpc / Revisto pela última vez em 01/08/2016, criado por Allyson S. Bacon
        // Determinado jogador efetua um ataque em determinado NPC
        //*********************************************************************************************
        public static void PlayerAttackNpc(int Attacker, int Victim, int isSpell = 0, int Map = 0, bool isPassive = false, int skill_level = 0, bool is_pet = false)
        {
            //EXTEND
            if (Extensions.ExtensionApp.ExtendMyApp
                (MethodBase.GetCurrentMethod().Name, Attacker, Victim, isSpell, Map, isPassive, skill_level, is_pet) != null)
            {
                return;
            }

            //CÓDIGO
            if (Map == 0) { Map = Convert.ToInt32(PStruct.character[Attacker, PStruct.player[Attacker].SelectedChar].Map); }
            int Dir = PStruct.character[Attacker, PStruct.player[Attacker].SelectedChar].Dir;
            int NpcX = NStruct.tempnpc[Map, Victim].X;
            int NpcY = NStruct.tempnpc[Map, Victim].Y;
            int PlayerX = Convert.ToInt32(PStruct.character[Attacker, PStruct.player[Attacker].SelectedChar].X);
            int PlayerY = Convert.ToInt32(PStruct.character[Attacker, PStruct.player[Attacker].SelectedChar].Y);
            int Damage = 0;
            int chance = 0;
            bool is_critical = false;

            if ((!isPassive) && (isSpell == 0)) { SkillPassive(Attacker, Globals.Target_Npc, Victim); }
            if ((NStruct.tempnpc[Map, Victim].Vitality <= 0) || (NStruct.tempnpc[Map, Victim].Dead)) { return; }

            //Cálculo do dano

            //Magias
            if (isSpell > 0)
            {
                int skill_slot = 0;

                if (!isPassive) { skill_slot = GetPlayerSkillSlot(Attacker, isSpell); }
                else { skill_slot = GetPlayerSkillSlot(Attacker, isSpell, true); }

                if (skill_slot == 0) { return; }

                int extra_spellbuff = 0;

                for (int i = 1; i < Globals.MaxSpellBuffs; i++)
                {
                    if (PStruct.pspellbuff[Attacker, i].active)
                    {
                        if (PStruct.pspellbuff[Attacker, i].timer > Loops.TickCount.ElapsedMilliseconds) { extra_spellbuff += PStruct.pspellbuff[Attacker, i].value; }
                        else
                        {
                            PStruct.pspellbuff[Attacker, i].value = 0;
                            PStruct.pspellbuff[Attacker, i].type = 0;
                            PStruct.pspellbuff[Attacker, i].timer = 0;
                            PStruct.pspellbuff[Attacker, i].active = false;
                        }
                    }
                }

                //Multiplicador de dano
                double multiplier = Convert.ToDouble(SStruct.skill[isSpell].scope) / 7.2;

                //Elemento mágico multiplicado
                double min_damage = PlayerRelations.GetPlayerMinMagic(Attacker);
                double max_damage = PlayerRelations.GetPlayerMaxMagic(Attacker);

                if (PStruct.hotkey[Attacker, skill_slot].num > Globals.MaxPlayer_Skills)
                {
                    PStruct.hotkey[Attacker, skill_slot].num = 0;
                    return;
                }

                //Multiplicador de nível
                double levelmultiplier = (1.0 + multiplier) * PStruct.skill[Attacker, PStruct.hotkey[Attacker, skill_slot].num].level; //Except

                //Verificando se a skill teve algum problema e corrigindo
                if (levelmultiplier < 1.0) { levelmultiplier = 1.0; }

                //Dano total que pode ser causado
                double totaldamage = max_damage + (Convert.ToDouble(SStruct.skill[isSpell].damage_formula) * levelmultiplier);
                double totalmindamage = min_damage + (Convert.ToDouble(SStruct.skill[isSpell].damage_formula) * levelmultiplier);

                //Passamos para int para tornar o dano exato
                int MinDamage = Convert.ToInt32(totalmindamage);
                int MaxDamage = Convert.ToInt32(totaldamage) + 1;

                if (MinDamage >= MaxDamage) { MaxDamage = MinDamage; }

                //Definição geral do dano
                Damage = Globals.Rand(MinDamage, MaxDamage);
                Damage -= (Damage / 100) * PStruct.tempplayer[Attacker].ReduceDamage;
                Damage = Damage - ((Damage / 100) * NStruct.npc[Map, Victim].MagicDefense);

                if (PStruct.tempplayer[Attacker].ReduceDamage > 0)
                {
                    SendData.Send_ActionMsg(Victim, lang.damage_reduced, Globals.ColorWhite, NpcX, NpcY, 1, 0, Map);
                    PStruct.tempplayer[Attacker].ReduceDamage = 0;
                }

                if (isSpell == 36)
                {
                    Damage += ((Damage / 100) * PlayerRelations.GetPlayerDefense(Attacker));
                }

                if (PStruct.character[Attacker, PStruct.player[Attacker].SelectedChar].ClassId == 6)
                {
                    for (int i = 1; i < Globals.MaxPlayer_Skills; i++)
                    {
                        if ((PStruct.skill[Attacker, i].num == 42) && (PStruct.skill[Attacker, i].level > 0))
                        {
                            //Dano crítico?
                            int critical_t = Globals.Rand(0, 100);

                            if (critical_t <= PlayerRelations.GetPlayerCritical(Attacker))
                            {
                                Damage = Convert.ToInt32((Convert.ToDouble(Damage) * 1.5));
                                SendData.Send_Animation(Map, Globals.Target_Npc, Victim, 152);
                            }
                            //break;
                        }
                        if ((PStruct.skill[Attacker, i].num == 41) && (PStruct.skill[Attacker, i].level > 0))
                        {
                            if (isSpell == 40)
                            {
                                int open_passive = GetOpenPassiveEffect(Attacker);

                                if (open_passive == 0) { return; }

                                PStruct.ppassiveffect[Attacker, open_passive].spellnum = PStruct.skill[Attacker, i].num;
                                PStruct.ppassiveffect[Attacker, open_passive].timer = Loops.TickCount.ElapsedMilliseconds + SStruct.skill[PStruct.skill[Attacker, i].num].passive_interval;
                                PStruct.ppassiveffect[Attacker, open_passive].target = Victim;
                                PStruct.ppassiveffect[Attacker, open_passive].targettype = Globals.Target_Npc;
                                PStruct.ppassiveffect[Attacker, open_passive].type = 1;
                                PStruct.ppassiveffect[Attacker, open_passive].active = true;
                            }
                            //break;
                        }
                    }
                }

                if (Damage < 1)
                {
                    SendData.Send_ActionMsg(Attacker, lang.resisted, Globals.ColorPink, NpcX, NpcY, Globals.Action_Msg_Scroll, 0, Map);
                    return;
                }

                if (extra_spellbuff > 0)
                {
                    //BUFFF :DDDD
                    Damage += (Damage / 100) * extra_spellbuff;
                }

                int drain = SStruct.skill[isSpell].drain;

                //Drenagem de vida?
                if (drain > 0)
                {
                    double real_drain = (Convert.ToDouble(Damage) / 100) * drain;
                    PlayerLogic.HealPlayer(Attacker, Convert.ToInt32(real_drain));
                    //SendData.Send_ActionMsg(Attacker, Convert.ToInt32(real_drain).ToString(), Globals.ColorGreen, PlayerX, PlayerY, 1, 1);
                    //SendData.Send_PlayerVitalityToMap(Map, Attacker, PStruct.tempplayer[Attacker].Vitality);
                }

                NStruct.tempnpc[Map, Victim].Target = Attacker;
            }
            //Ataques básicos
            else
            {
                if (tempplayer[Attacker].Blind)
                {
                    SendData.Send_ActionMsg(Attacker, lang.attack_missed, Globals.ColorWhite, NpcX, NpcY, 1, 0, Map);
                    return;
                }

                //Desviar do golpe?
                int parry_test = Globals.Rand(0, 100);

                if (parry_test <= (NStruct.GetNpcParry(Map, Victim) - PlayerRelations.GetPlayerCritical(Attacker)))
                {
                    SendData.Send_ActionMsg(Attacker, lang.attack_missed, Globals.ColorWhite, NpcX, NpcY, 1, 0, Map);
                    return;
                }

                //Dano comum
                int MinDamage = PlayerRelations.GetPlayerMinAttack(Attacker);
                int MaxDamage = PlayerRelations.GetPlayerMaxAttack(Attacker);

                if (is_pet)
                {
                    string equipment = PStruct.character[Attacker, PStruct.player[Attacker].SelectedChar].Equipment;
                    string[] equipdata = equipment.Split(',');
                    string[] petdata = equipdata[4].Split(';');

                    int petnum = Convert.ToInt32(petdata[0]);
                    int petlvl = Convert.ToInt32(petdata[1]);

                    MinDamage = (Convert.ToInt32(IStruct.item[petnum].damage_variance)) + ((petlvl / 2) * Convert.ToInt32(IStruct.item[petnum].damage_formula));
                    MaxDamage = (Convert.ToInt32(IStruct.item[petnum].damage_variance)) + ((petlvl) * Convert.ToInt32(IStruct.item[petnum].damage_formula));

                    if (MinDamage >= MaxDamage)
                    {
                        Damage = MinDamage;
                        Damage -= (Damage / 100) * PStruct.tempplayer[Attacker].ReduceDamage;
                        Damage = Damage - ((Damage / 100) * NStruct.npc[Map, Victim].Defense);
                    }
                    else
                    {
                        Damage = Globals.Rand(MinDamage, MaxDamage);
                        Damage -= (Damage / 100) * PStruct.tempplayer[Attacker].ReduceDamage;
                        Damage = Damage - ((Damage / 100) * NStruct.npc[Map, Victim].Defense);
                    }

                    SendData.Send_Animation(Map, Globals.Target_Npc, Victim, IStruct.item[petnum].animation_id);
                    SendData.Send_ActionMsg(Attacker, "-" + Damage.ToString(), Globals.ColorPurple, NpcX, NpcY, 1, PStruct.character[Attacker, PStruct.player[Attacker].SelectedChar].Dir, Map);
                    goto important;
                }

                if (MinDamage >= MaxDamage)
                {
                    Damage = MinDamage;
                    Damage -= (Damage / 100) * PStruct.tempplayer[Attacker].ReduceDamage;
                    Damage = Damage - ((Damage / 100) * NStruct.npc[Map, Victim].Defense);
                }
                else
                {
                    Damage = Globals.Rand(MinDamage, MaxDamage);
                    Damage -= (Damage / 100) * PStruct.tempplayer[Attacker].ReduceDamage;
                    Damage = Damage - ((Damage / 100) * NStruct.npc[Map, Victim].Defense);
                }

                if (PStruct.character[Attacker, PStruct.player[Attacker].SelectedChar].ClassId == 2)
                {
                    for (int i = 1; i < Globals.MaxPlayer_Skills; i++)
                    {
                        if ((PStruct.skill[Attacker, i].num == 52) && (PStruct.skill[Attacker, i].level > 0))
                        {
                            Damage += ((NStruct.npc[Map, Victim].Vitality / 100) * (2 + PStruct.skill[Attacker, i].level));
                        }
                    }
                }

                if (PStruct.tempplayer[Attacker].ReduceDamage > 0)
                {
                    SendData.Send_ActionMsg(Victim, lang.damage_reduced, Globals.ColorWhite, NpcX, NpcY, 1, 0, Map);
                    PStruct.tempplayer[Attacker].ReduceDamage = 0;
                }

                if (Damage <= 0)
                {
                    Damage = 1;
                }

                //Dano crítico?
                int critical_test = Globals.Rand(0, 100);

                if (critical_test <= PlayerRelations.GetPlayerCritical(Attacker))
                {
                    Damage = Convert.ToInt32((Convert.ToDouble(Damage) * 1.5));
                    is_critical = true;
                    NStruct.tempnpc[Map, Victim].Target = Attacker;
                }

                //Dano e animação
                SendData.Send_Animation(Map, 2, Victim, 7);
            }

            if (is_critical)
            {
                SendData.Send_ActionMsg(Attacker, "-" + Damage.ToString(), 1, NpcX, NpcY, 1, PStruct.character[Attacker, PStruct.player[Attacker].SelectedChar].Dir, Map);
                int true_range = 0;
                for (int i = 1; i <= 2; i++)
                {
                    if (PStruct.CanThrowNpc(Map, Victim, PStruct.character[Attacker, PStruct.player[Attacker].SelectedChar].Dir, i))
                    {
                        true_range += 1;
                    }
                    else
                    {
                        break;
                    }
                }

                if (true_range < 2)
                {
                    Damage += 2 - true_range;
                }

                if (true_range > 0)
                {
                    PStruct.ThrowNpc(Map, Victim, PStruct.character[Attacker, PStruct.player[Attacker].SelectedChar].Dir, true_range);
                }
            }
            else
            {
                if (isSpell > 0) { SendData.Send_ActionMsg(Attacker, "-" + Damage.ToString(), Globals.ColorPink, NpcX, NpcY, Globals.Action_Msg_Scroll, PStruct.character[Attacker, PStruct.player[Attacker].SelectedChar].Dir, Map); }
                else { SendData.Send_ActionMsg(Attacker, "-" + Damage.ToString(), 4, NpcX, NpcY, Globals.Action_Msg_Scroll, PStruct.character[Attacker, PStruct.player[Attacker].SelectedChar].Dir, Map); }
            }

        important:
            //Nova vida do npc
            NStruct.tempnpc[Map, Victim].Vitality -= Damage;

            //O NPC é um coletor?
            if (NStruct.tempnpc[Map, Victim].guildnum > 0)
            {
                if (!MStruct.tempmap[Map].WarActive)
                {
                    MStruct.tempmap[Map].WarActive = true;
                    SendData.Send_MsgToGuild(NStruct.tempnpc[Map, Victim].guildnum, lang.the_colector_of + " " + MStruct.map[Map].name + " " + lang.is_being_attacked, Globals.ColorYellow, Globals.Msg_Type_Server);
                }
                MStruct.tempmap[Map].WarTimer = Loops.TickCount.ElapsedMilliseconds + 20000;
                //Avisar a guilda sobre seu ataque
            }

            //Sleep?
            if (NStruct.tempnpc[Map, Victim].Sleeping)
            {
                NStruct.tempnpc[Map, Victim].Sleeping = false;
                NStruct.tempnpc[Map, Victim].SleepTimer = 0;
                SendData.Send_Sleep(Map, 2, Victim, 0);
            }

            //Enviamos a nova vida do npc
            SendData.Send_NpcVitality(Map, Victim, NStruct.tempnpc[Map, Victim].Vitality);

            if ((NStruct.npc[Map, Victim].Type == 1) && (NStruct.tempnpc[Map, Victim].Target == 0)) { NStruct.tempnpc[Map, Victim].Target = Attacker; }

            if (NStruct.tempnpc[Map, Victim].Vitality <= 0)
            {
                //Npc era um coletor?
                if (NStruct.tempnpc[Map, Victim].guildnum > 0)
                {
                    SendData.Send_MsgToAll(lang.the_area + " " + MStruct.map[Map].name + " " + lang.is_free_now, Globals.ColorYellow, Globals.Msg_Type_Server);
                    SendData.Send_MsgToGuild(NStruct.tempnpc[Map, Victim].guildnum, lang.the_colector_of + " " + MStruct.map[Map].name + " " + lang.has_been_defeated, Globals.ColorYellow, Globals.Msg_Type_Server);
                    SendData.Send_MsgToPlayer(Attacker, lang.colector_defeated_success, Globals.ColorYellow, Globals.Msg_Type_Server);
                    PlayerRelations.GivePlayerGold(Attacker, MStruct.map[Map].guildgold);
                    MStruct.map[Map].guildnum = 0;
                    MStruct.map[Map].guildgold = 0;
                    NStruct.ClearTempNpc(Map, Victim);
                    SendData.Send_MapGuildToMap(Map);
                    MStruct.tempmap[Map].NpcCount = MStruct.GetMapNpcCount(Map);
                    //Avisamos que o npc tem que sumir
                    SendData.Send_NpcLeft(Map, Victim);
                    return;
                }

                //O mapa possúi um coletor?
                int guildnum = MStruct.map[Map].guildnum;
                if (guildnum > 0)
                {
                    int total_exp = (NStruct.npc[Map, Victim].Exp / 100) * 10; //10%
                    if (total_exp <= 0) { total_exp = 1; }
                    int total_gold = (NStruct.npc[Map, Victim].Gold / 100) * 10; //10%
                    if (total_gold <= 0) { total_gold = 1; }
                    GStruct.guild[guildnum].exp += total_exp;
                    MStruct.map[Map].guildgold += total_gold;
                }

                //Entrega a exp para o grupo
                PartyRelations.PartyShareExp(Attacker, Victim, Map);

                //Avisamos que o npc tem que sumir
                SendData.Send_NpcLeft(Map, Victim);

                //Morto
                NStruct.tempnpc[Map, Victim].Dead = true;

                //Drop
                for (int i = 0; i <= NStruct.GetNpcDropCount(Map, Victim); i++)
                {
                    chance = Globals.Rand(1, NStruct.npcdrop[Map, Victim, i].Chance);
                    if (chance == NStruct.npcdrop[Map, Victim, i].Chance)
                    {
                        if (MStruct.GetNullMapItem(Map) == 0) { break; }
                        int NullMapItem = MStruct.GetNullMapItem(Map);
                        if (NStruct.npcdrop[Map, Victim, i].ItemType > 1) { DropItem(Map, NullMapItem, NpcX, NpcY, NStruct.npcdrop[Map, Victim, i].Value, NStruct.npcdrop[Map, Victim, i].ItemNum, NStruct.npcdrop[Map, Victim, i].ItemType, GetRefinDrop()); }
                        else { DropItem(Map, NullMapItem, NpcX, NpcY, NStruct.npcdrop[Map, Victim, i].Value, NStruct.npcdrop[Map, Victim, i].ItemNum, NStruct.npcdrop[Map, Victim, i].ItemType, 0); }
                        SendData.Send_MapItem(Map, NullMapItem);
                    }
                    else
                    {
                        //Tentar de novo
                        if (PlayerRelations.IsPlayerPremmy(Attacker))
                        {
                            chance = Globals.Rand(1, NStruct.npcdrop[Map, Victim, i].Chance * 2);
                            if (chance == NStruct.npcdrop[Map, Victim, i].Chance * 2)
                            {
                                if (MStruct.GetNullMapItem(Map) == 0) { break; }
                                int NullMapItem = MStruct.GetNullMapItem(Map);
                                if (NStruct.npcdrop[Map, Victim, i].ItemType > 1) { DropItem(Map, NullMapItem, NpcX, NpcY, NStruct.npcdrop[Map, Victim, i].Value, NStruct.npcdrop[Map, Victim, i].ItemNum, NStruct.npcdrop[Map, Victim, i].ItemType, GetRefinDrop()); }
                                else { DropItem(Map, NullMapItem, NpcX, NpcY, NStruct.npcdrop[Map, Victim, i].Value, NStruct.npcdrop[Map, Victim, i].ItemNum, NStruct.npcdrop[Map, Victim, i].ItemType, 0); }
                                SendData.Send_MapItem(Map, NullMapItem);
                            }
                        }
                    }
                }


                //GOLD
                PlayerRelations.GivePlayerGold(Attacker, NStruct.npc[Map, Victim].Gold);

                //Limpar dados de estudo de movimento
                NpcIA.ClearPrevMove(Map, Victim);

                ///Temporizador para voltar
                NStruct.tempnpc[Map, Victim].RespawnTimer = Loops.TickCount.ElapsedMilliseconds + NStruct.npc[Map, Victim].Respawn;
            }
        }
        //*********************************************************************************************
        // GetMinerLevel / Revisto pela última vez em 01/08/2016, criado por Allyson S. Bacon
        //*********************************************************************************************
        public static int GetMinerLevel(int index)
        {
            //EXTEND
            if (Extensions.ExtensionApp.ExtendMyApp
                (MethodBase.GetCurrentMethod().Name, index) != null)
            {
                return Convert.ToInt32(Extensions.ExtensionApp.ExtendMyApp
                (MethodBase.GetCurrentMethod().Name, index));
            }

            //CÓDIGO
            int exp = 0;//PStruct.character[index, PStruct.player[index].SelectedChar].Miner;

            int level = (exp / 100);

            return level;
        }
        //*********************************************************************************************
        // HaveToolToWork / Revisto pela última vez em 01/08/2016, criado por Allyson S. Bacon
        // Verifica se determinado jogador tem a ferramenta para interagir com determinado tipo de 
        // objeto
        //*********************************************************************************************
        public static bool HaveToolToWork(int index, int type)
        {
            //EXTEND
            if (Extensions.ExtensionApp.ExtendMyApp
                (MethodBase.GetCurrentMethod().Name, index, type) != null)
            {
                return Convert.ToBoolean(Extensions.ExtensionApp.ExtendMyApp
                (MethodBase.GetCurrentMethod().Name, index, type));
            }

            //CÓDIGO
            if (type == Globals.Job_Miner)
            {
                if (EquipmentRelations.GetPlayerWeapon(index) == 28)
                {
                    return true;
                }
            }
            return false;
        }
        //*********************************************************************************************
        // PlayerAttackWorkPoint / Revisto pela última vez em 01/08/2016, criado por Allyson S. Bacon
        // Interação com objetos de profissão
        //*********************************************************************************************
        public static void PlayerAttackWorkPoint(int index, int workpoint)
        {
            //EXTEND
            if (Extensions.ExtensionApp.ExtendMyApp
                (MethodBase.GetCurrentMethod().Name, index, workpoint) != null)
            {
                return;
            }

            //CÓDIGO
            if (MStruct.tempworkpoint[workpoint].vitality <= 0) 
            {
                SendData.Send_MsgToPlayer(index, lang.resource_empty, Globals.ColorRed, Globals.Msg_Type_Server);
                return;
            }

            int damage = 0;
            int profnum = 0;


            profnum = GetPlayerProf(index, MStruct.workpoint[workpoint].type);

            if (profnum <= 0)
            {
                SendData.Send_MsgToPlayer(index, lang.dont_have_prof_to_explore, Globals.ColorRed, Globals.Msg_Type_Server);
                return;
            }

            if (!HaveToolToWork(index, MStruct.workpoint[workpoint].type))
            {
                SendData.Send_MsgToPlayer(index, lang.dont_have_tool_to_interact, Globals.ColorRed, Globals.Msg_Type_Server);
                return;
            }
                
                damage = 1 + Convert.ToInt32(Convert.ToDouble(PStruct.character[index, PStruct.player[index].SelectedChar].Prof_Level[profnum] * 0.5));
                SendData.Send_Animation(PStruct.character[index, PStruct.player[index].SelectedChar].Map, Globals.Target_Player, index, WStruct.weapon[28].animation_id);

            if (damage == 0) { damage = 1; }

            MStruct.tempworkpoint[workpoint].vitality -= 1;
            SendData.Send_ActionMsg(index, "-" + damage, Globals.ColorWhite, MStruct.workpoint[workpoint].x, MStruct.workpoint[workpoint].y, 1, 0, MStruct.workpoint[workpoint].map);

            if (MStruct.tempworkpoint[workpoint].vitality <= 0)
            {
                InventoryRelations.GiveItem(index, 1, MStruct.workpoint[workpoint].reward, 1, 0, 0);
                MStruct.tempworkpoint[workpoint].respawn = Loops.TickCount.ElapsedMilliseconds + (MStruct.workpoint[workpoint].respawn_timer * 10000);
                character[index, PStruct.player[index].SelectedChar].Prof_Exp[profnum] += MStruct.workpoint[workpoint].exp;
                //Verificamos se ele subiu de nível
                if ((character[index, PStruct.player[index].SelectedChar].Prof_Exp[profnum] >= GetpProfExpToNextLevel(index, profnum)) && (character[index, PStruct.player[index].SelectedChar].Prof_Level[profnum] < 80))
                {
                    character[index, PStruct.player[index].SelectedChar].Prof_Exp[profnum] -= GetpProfExpToNextLevel(index, profnum);
                    character[index, PStruct.player[index].SelectedChar].Prof_Level[profnum] += 1;
                    SendData.Send_ProfLEVEL(index, profnum);
                }
                else
                {
                    //GetExpToNextLevel
                    SendData.Send_ProfEXP(index, profnum);
                   // SendData.Send_PlayerExp(memberindex);
                    //Enviamos uma animação bonitinha de exp :D
                    SendData.Send_ActionMsg(index, "+" + MStruct.workpoint[workpoint].exp + lang.pexp, 0, character[index, PStruct.player[index].SelectedChar].X, character[index, PStruct.player[index].SelectedChar].Y, 1, 0, MStruct.workpoint[workpoint].map);
                }
                SendData.Send_EventGraphicToMap(MStruct.workpoint[workpoint].map, MStruct.tile[MStruct.workpoint[workpoint].map, MStruct.workpoint[workpoint].x, MStruct.workpoint[workpoint].y].Event_Id, "", 0, 49);
                SendData.Send_InvSlots(index, PStruct.player[index].SelectedChar);
            }
        }
        //*********************************************************************************************
        // PlayerAttackPlayer / Revisto pela última vez em 01/08/2016, criado por Allyson S. Bacon
        // Determinado jogador efetua um ataque em outro jogador determinado
        //*********************************************************************************************
        public static void PlayerAttackPlayer(int Attacker, int Victim, int isSpell = 0, int Map = 0, bool isPassive = false, int skill_level = 0, int super_damage = 0, bool is_pet = false)
        {
            //EXTEND
            if (Extensions.ExtensionApp.ExtendMyApp
                (MethodBase.GetCurrentMethod().Name, Attacker, Victim, isSpell, Map, isPassive, skill_level, super_damage, is_pet) != null)
            {
                return;
            }

            //CÓDIGO
            if (Map == 0) { Map = Convert.ToInt32(PStruct.character[Attacker, PStruct.player[Attacker].SelectedChar].Map); }
            int Dir = PStruct.character[Attacker, PStruct.player[Attacker].SelectedChar].Dir;
            int VictimX = PStruct.character[Victim, PStruct.player[Victim].SelectedChar].X;
            int VictimY = PStruct.character[Victim, PStruct.player[Victim].SelectedChar].Y;
            int AttackerX = PStruct.character[Attacker, PStruct.player[Attacker].SelectedChar].X;
            int AttackerY = PStruct.character[Attacker, PStruct.player[Attacker].SelectedChar].Y;
            int PlayerX = Convert.ToInt32(PStruct.character[Attacker, PStruct.player[Attacker].SelectedChar].X);
            int PlayerY = Convert.ToInt32(PStruct.character[Attacker, PStruct.player[Attacker].SelectedChar].Y);
            int Damage = 0;

            bool is_critical = false;

            if (PStruct.tempplayer[Victim].isDead == true) { return; }
            if (!MStruct.tempmap[Map].WarActive) {
            if (PStruct.character[Victim, PStruct.player[Victim].SelectedChar].Level < 10) { return; }
            if (!MStruct.MapIsPVP(Map)) { return; }
            }

            if ((!isPassive) && (isSpell == 0)) { SkillPassive(Attacker, Globals.Target_Player, Victim); }
            if ((PStruct.tempplayer[Victim].Vitality <= 0) || (PStruct.tempplayer[Victim].isDead)) { return; }
            if ((!MStruct.tempmap[Map].WarActive) && (!PStruct.character[Attacker, player[Attacker].SelectedChar].PVP)) { return; }

            if (tempplayer[Victim].Reflect)
            {
                SendData.Send_Animation(Map, Globals.Target_Player, Victim, 155);
                SendData.Send_Animation(Map, Globals.Target_Player, Attacker, 156);
                PlayerAttackPlayer(Victim, Attacker, 0, 0 , false, 0, PlayerRelations.GetPlayerDefense(Victim) * 2);
                tempplayer[Victim].Reflect = false;
                tempplayer[Victim].ReflectTimer = 0;
                return;
            }

            //Cálculo do dano

            //Magias
            if (isSpell > 0)
            {
                if (PStruct.character[Victim, PStruct.player[Victim].SelectedChar].ClassId == 6)
                {
                    for (int i = 1; i < Globals.MaxPlayer_Skills; i++)
                    {
                        if ((PStruct.skill[Victim, i].num == 39) && (PStruct.skill[Victim, i].level > 0))
                        {
                            //Desviar do golpe?
                            int parry_test = Globals.Rand(0, 100);

                            if (parry_test <= (PlayerRelations.GetPlayerParry(Victim) - PlayerRelations.GetPlayerCritical(Attacker)))
                            {
                                SendData.Send_ActionMsg(Victim, lang.attack_missed, Globals.ColorWhite, PStruct.character[Victim, PStruct.player[Victim].SelectedChar].X, PStruct.character[Victim, PStruct.player[Victim].SelectedChar].Y, 1, 0, Map);
                                return;
                            }
                            break;
                        }
                    }
                }

                int skill_slot = 0;

                if (!isPassive) { skill_slot = GetPlayerSkillSlot(Attacker, isSpell); }
                else { skill_slot = GetPlayerSkillSlot(Attacker, isSpell, true); }

                if (skill_slot == 0) { return; }

                int extra_spellbuff = 0;

                for (int i = 1; i < Globals.MaxSpellBuffs; i++)
                {
                    if (PStruct.pspellbuff[Attacker, i].active)
                    {
                        if (PStruct.pspellbuff[Attacker, i].timer > Loops.TickCount.ElapsedMilliseconds) { extra_spellbuff += PStruct.pspellbuff[Attacker, i].value; }
                        else
                        {
                            PStruct.pspellbuff[Attacker, i].value = 0;
                            PStruct.pspellbuff[Attacker, i].type = 0;
                            PStruct.pspellbuff[Attacker, i].timer = 0;
                            PStruct.pspellbuff[Attacker, i].active = false;
                        }
                    }
                }

                //Multiplicador de dano
                double multiplier = Convert.ToDouble(SStruct.skill[isSpell].scope) / 7.2;

                //Elemento mágico multiplicado
                double min_damage = PlayerRelations.GetPlayerMinMagic(Attacker);
                double max_damage = PlayerRelations.GetPlayerMaxMagic(Attacker);


                if (PStruct.hotkey[Attacker, skill_slot].num > Globals.MaxPlayer_Skills)
                {
                    PStruct.hotkey[Attacker, skill_slot].num = 0;
                    return;
                }

                //Multiplicador de nível
                double levelmultiplier = (1.0 + multiplier) * PStruct.skill[Attacker, PStruct.hotkey[Attacker, skill_slot].num].level; //Except

                //Verificando se a skill teve algum problema e corrigindo
                if (levelmultiplier < 1.0) { levelmultiplier = 1.0; }

                //Dano total que pode ser causado
                double totaldamage = max_damage + (Convert.ToDouble(SStruct.skill[isSpell].damage_formula) * levelmultiplier);
                double totalmindamage = min_damage + (Convert.ToDouble(SStruct.skill[isSpell].damage_formula) * levelmultiplier);

                //Passamos para int para tornar o dano exato
                int MinDamage = Convert.ToInt32(totalmindamage);
                int MaxDamage = Convert.ToInt32(totaldamage) + 1;

                if (MinDamage >= MaxDamage) { MaxDamage = MinDamage; }

                //Definição geral do dano
                Damage = Globals.Rand(MinDamage, MaxDamage);
                Damage -= (Damage / 100) * PStruct.tempplayer[Attacker].ReduceDamage;
                if (PStruct.character[Victim, PStruct.player[Victim].SelectedChar].ClassId == 3)
                {
                    for (int i = 1; i < Globals.MaxPlayer_Skills; i++)
                    {
                        if ((PStruct.skill[Victim, i].num == 56) && (PStruct.skill[Victim, i].level > 0))
                        {
                            Damage -= ((Damage / 100) * (3 * PStruct.skill[Victim, i].level));
                        }
                    }
                }
                Damage -= ((Damage / 100) * PlayerRelations.GetPlayerMagicDef(Victim));

                if (PStruct.tempplayer[Attacker].ReduceDamage > 0)
                {
                    SendData.Send_ActionMsg(Victim, lang.damage_reduced + " ", Globals.ColorWhite, VictimX, VictimY, 1, 0, Map);
                    PStruct.tempplayer[Attacker].ReduceDamage = 0;
                }

                if (isSpell == 36)
                {
                    Damage += ((Damage / 100) * PlayerRelations.GetPlayerDefense(Attacker));
                }

                if (PStruct.character[Attacker, PStruct.player[Attacker].SelectedChar].ClassId == 6)
                {

                    for (int i = 1; i < Globals.MaxPlayer_Skills; i++)
                    {
                        if ((PStruct.skill[Attacker, i].num == 42) && (PStruct.skill[Attacker, i].level > 0))
                        {
                            //Dano crítico?
                            int critical_t = Globals.Rand(0, 100);

                            if (critical_t <= PlayerRelations.GetPlayerCritical(Attacker))
                            {
                                Damage = Convert.ToInt32((Convert.ToDouble(Damage) * 1.5));
                                SendData.Send_Animation(Map, Globals.Target_Player, Victim, 152);
                            }
                            break;
                        }
                        if ((PStruct.skill[Attacker, i].num == 41) && (PStruct.skill[Attacker, i].level > 0))
                        {
                            if (isSpell == 40)
                            {
                                int open_passive = GetOpenPassiveEffect(Attacker);

                                if (open_passive == 0) { return; }

                                PStruct.ppassiveffect[Attacker, open_passive].spellnum = PStruct.skill[Attacker, i].num;
                                PStruct.ppassiveffect[Attacker, open_passive].timer = Loops.TickCount.ElapsedMilliseconds + SStruct.skill[PStruct.skill[Attacker, i].num].passive_interval;
                                PStruct.ppassiveffect[Attacker, open_passive].target = Victim;
                                PStruct.ppassiveffect[Attacker, open_passive].targettype = Globals.Target_Player;
                                PStruct.ppassiveffect[Attacker, open_passive].type = 1;
                                PStruct.ppassiveffect[Attacker, open_passive].active = true;
                            }
                            //Dano crítico?
                            int critical_t = Globals.Rand(0, 100);

                            if (critical_t <= PlayerRelations.GetPlayerCritical(Attacker))
                            {
                                Damage = Convert.ToInt32((Convert.ToDouble(Damage) * 1.5));
                                SendData.Send_Animation(Map, Globals.Target_Player, Victim, 152);
                            }
                            break;
                        }
                    }
                }

                if (Damage < 1)
                {
                    SendData.Send_ActionMsg(Victim, lang.resisted, Globals.ColorPink, VictimX, VictimY, 1, 0, Map);
                    return;
                }

                if (extra_spellbuff > 0)
                {
                    //BUFFF :DDDD
                    Damage += (Damage / 100) * extra_spellbuff;
                }

                int drain = SStruct.skill[isSpell].drain;

                //Drenagem de vida?
                if (drain > 0)
                {
                    double real_drain = (Convert.ToDouble(Damage) / 100) * drain;
                    PlayerLogic.HealPlayer(Attacker, Convert.ToInt32(real_drain));
                    //SendData.Send_ActionMsg(Attacker, Convert.ToInt32(real_drain).ToString(), Globals.ColorGreen, PlayerX, PlayerY, 1, 1);
                    //SendData.Send_PlayerVitalityToMap(Map, Attacker, PStruct.tempplayer[Attacker].Vitality);
                }
            }
            //Ataques básicos
            else
            {
                if (tempplayer[Attacker].Blind)
                {
                    SendData.Send_ActionMsg(Attacker, lang.attack_missed, Globals.ColorWhite, VictimX, VictimY, 1, 0, Map);
                    return;
                }

                //Desviar do golpe?
                int parry_test = Globals.Rand(0, 100);

                if (parry_test <= (PlayerRelations.GetPlayerParry(Victim) - PlayerRelations.GetPlayerCritical(Attacker)))
                {
                    SendData.Send_ActionMsg(Victim, lang.attack_missed, Globals.ColorWhite, VictimX, VictimY, 1, 0, Map);
                    return;
                }

                //Dano comum
                int MinDamage = PlayerRelations.GetPlayerMinAttack(Attacker);
                int MaxDamage = PlayerRelations.GetPlayerMaxAttack(Attacker);

                if (is_pet)
                {
                    string equipment = PStruct.character[Attacker, PStruct.player[Attacker].SelectedChar].Equipment;
                    string[] equipdata = equipment.Split(',');
                    string[] petdata = equipdata[4].Split(';');

                    int petnum = Convert.ToInt32(petdata[0]);
                    int petlvl = Convert.ToInt32(petdata[1]);

                    MinDamage = (Convert.ToInt32(IStruct.item[petnum].damage_variance)) + ((petlvl / 2) * Convert.ToInt32(IStruct.item[petnum].damage_formula));
                    MaxDamage = (Convert.ToInt32(IStruct.item[petnum].damage_variance)) + ((petlvl) * Convert.ToInt32(IStruct.item[petnum].damage_formula));

                    if (MinDamage >= MaxDamage)
                    {
                        Damage = MinDamage + super_damage;
                        Damage -= (Damage / 100) * PStruct.tempplayer[Attacker].ReduceDamage;
                        Damage -= ((Damage / 100) * PlayerRelations.GetPlayerDefense(Victim));
                    }
                    else
                    {
                        Damage = (Globals.Rand(MinDamage, MaxDamage)) + super_damage;
                        Damage -= (Damage / 100) * PStruct.tempplayer[Attacker].ReduceDamage;
                        Damage -= ((Damage / 100) * PlayerRelations.GetPlayerDefense(Victim));
                    }//

                    SendData.Send_Animation(Map, Globals.Target_Player, Victim, IStruct.item[petnum].animation_id);
                    SendData.Send_ActionMsg(Victim, "-" + Damage.ToString(), Globals.ColorPurple, VictimX, VictimY, 1, PStruct.character[Attacker, PStruct.player[Attacker].SelectedChar].Dir, Map); 
                    goto important;
                }

                if (MinDamage >= MaxDamage) 
                {
                    Damage = MinDamage + super_damage;
                    Damage -= (Damage / 100) * PStruct.tempplayer[Attacker].ReduceDamage;
                    Damage -= ((Damage / 100) * PlayerRelations.GetPlayerDefense(Victim));
                }
                else 
                { 
                    Damage = (Globals.Rand(MinDamage, MaxDamage)) + super_damage;
                    Damage -= (Damage / 100) * PStruct.tempplayer[Attacker].ReduceDamage;
                    Damage -= ((Damage / 100) * PlayerRelations.GetPlayerDefense(Victim));
                }//

                if (PStruct.character[Attacker, PStruct.player[Attacker].SelectedChar].ClassId == 2)
                {
                    for (int i = 1; i < Globals.MaxPlayer_Skills; i++)
                    {
                        if ((PStruct.skill[Attacker, i].num == 52) && (PStruct.skill[Attacker, i].level > 0))
                        {
                            Damage += ((GetPlayerMaxVitality(Victim) / 100) * (2 + PStruct.skill[Attacker, i].level));
                        }
                    }
                }

                if (PStruct.tempplayer[Attacker].ReduceDamage > 0)
                {
                    SendData.Send_ActionMsg(Victim, lang.damage_reduced, Globals.ColorWhite, VictimX, VictimY, 1, 0, Map);
                    PStruct.tempplayer[Attacker].ReduceDamage = 0;
                }

                //Dano crítico?
                int critical_test = Globals.Rand(0, 100);

                if (critical_test <= PlayerRelations.GetPlayerCritical(Attacker))
                {
                    Damage = Convert.ToInt32((Convert.ToDouble(Damage) * 1.5));
                    is_critical = true;
                }

                //Dano e animação
                SendData.Send_Animation(Map, Globals.Target_Player, Victim, 7);
            }

            if (is_critical)
            {
                int true_range = 0;
                for (int i = 1; i <= 2; i++)
                {
                    if (PStruct.CanThrowPlayer(Victim, PStruct.character[Attacker, PStruct.player[Attacker].SelectedChar].Dir, i))
                    {
                        true_range += 1;
                    }
                    else
                    {
                        break;
                    }
                }

                if (true_range < 2)
                {
                    Damage += 2 - true_range;
                }

                if (true_range > 0)
                {
                    PStruct.ThrowPlayer(Victim, PStruct.character[Attacker, PStruct.player[Attacker].SelectedChar].Dir, true_range);
                }

                if (PStruct.tempplayer[Victim].preparingskill > 0)
                {
                    PStruct.tempplayer[Victim].preparingskill = 0;
                    PStruct.tempplayer[Victim].preparingskillslot = 0;
                    PStruct.tempplayer[Victim].skilltimer = 0;
                    SendData.Send_ActionMsg(Victim, lang.spell_broken, Globals.ColorPink, VictimX, VictimY, 1, 0, Map);
                    PStruct.tempplayer[Victim].movespeed = Globals.NormalMoveSpeed;
                    SendData.Send_MoveSpeed(Globals.Target_Player, Victim);
                    SendData.Send_BrokeSkill(Victim);
                }
                SendData.Send_ActionMsg(Victim, "-" + Damage.ToString(), 1, VictimX, VictimY, 1, PStruct.character[Attacker, PStruct.player[Attacker].SelectedChar].Dir, Map); 
            }
            else
            {
                if (isSpell > 0) { SendData.Send_ActionMsg(Attacker, "-" + Damage.ToString(), Globals.ColorPink, VictimX, VictimY, Globals.Action_Msg_Scroll, PStruct.character[Attacker, PStruct.player[Attacker].SelectedChar].Dir, Map); }
                else { SendData.Send_ActionMsg(Attacker, "-" + Damage.ToString(), 4, VictimX, VictimY, Globals.Action_Msg_Scroll, PStruct.character[Attacker, PStruct.player[Attacker].SelectedChar].Dir, Map); }
            }

            important:
            //Nova vida do jogador
            PStruct.tempplayer[Victim].Vitality -= Damage;

            //Sleep?
            if (PStruct.tempplayer[Victim].Sleeping)
            {
                PStruct.tempplayer[Victim].Sleeping = false;
                PStruct.tempplayer[Victim].SleepTimer = 0;
                SendData.Send_Sleep(Map, 2, Victim, 0);
            }

            //Enviamos a nova vida do jogador
            SendData.Send_PlayerVitalityToMap(Map, Victim, PStruct.tempplayer[Victim].Vitality);

            if (PStruct.tempplayer[Victim].Vitality <= 0)
            {
                tempplayer[Victim].PetTarget = 0;
                tempplayer[Victim].PetTargetType = 0;
                if (!MStruct.tempmap[Map].WarActive)
                {
                    if (!PStruct.tempplayer[Victim].SORE)
                    {
                        int lvd = PStruct.character[Attacker, PStruct.player[Attacker].SelectedChar].Level - PStruct.character[Victim, PStruct.player[Victim].SelectedChar].Level;
                        if (lvd > 5)
                        {
                            if (!PStruct.character[Victim, PStruct.player[Victim].SelectedChar].PVP)
                            {
                                PStruct.tempplayer[Attacker].SORE = true;
                                PStruct.character[Attacker, PStruct.player[Attacker].SelectedChar].PVPPenalty = 300000 + Loops.TickCount.ElapsedMilliseconds;
                                SendData.Send_PlayerSoreToMap(Attacker);
                                SendData.Send_PlayerPvpSoreTimer(Attacker);
                                SendData.Send_Animation(Map, Globals.Target_Player, Attacker, 147);

                                //Relacionado a definição de vida para novos e velhos jogadores
                                if (PStruct.character[Attacker, PStruct.player[Attacker].SelectedChar].Vitality > PStruct.GetPlayerMaxVitality(Attacker))
                                {
                                    PStruct.character[Attacker, PStruct.player[Attacker].SelectedChar].Vitality = PStruct.GetPlayerMaxVitality(Attacker);
                                    PStruct.tempplayer[Attacker].Vitality = PStruct.GetPlayerMaxVitality(Attacker);
                                    SendData.Send_PlayerVitalityToMap(Map, Attacker, PStruct.tempplayer[Attacker].Vitality);
                                    if (PStruct.tempplayer[Attacker].Party > 0)
                                    {
                                        SendData.Send_PlayerVitalityToParty(PStruct.tempplayer[Attacker].Party, Attacker, PStruct.tempplayer[Attacker].Vitality);
                                    }
                                }


                                //Relacionado a definição de mana para novos e velhos jogadores
                                if (PStruct.character[Attacker, PStruct.player[Attacker].SelectedChar].Spirit > PStruct.GetPlayerMaxSpirit(Attacker))
                                {
                                    PStruct.character[Attacker, PStruct.player[Attacker].SelectedChar].Spirit = PStruct.GetPlayerMaxSpirit(Attacker);
                                    PStruct.tempplayer[Attacker].Spirit = PStruct.GetPlayerMaxSpirit(Attacker);
                                    SendData.Send_PlayerSpiritToMap(Map, Attacker, PStruct.tempplayer[Attacker].Spirit);
                                    if (PStruct.tempplayer[Attacker].Party > 0)
                                    {
                                        SendData.Send_PlayerSpiritToParty(PStruct.tempplayer[Attacker].Party, Attacker, PStruct.tempplayer[Attacker].Spirit);
                                    }
                                }
                            }
                        }
                        else
                        {
                            //Matou na ordem, eai?
                        }
                    }
                }
                else
                {
                    int exp = PStruct.character[Victim, PStruct.player[Victim].SelectedChar].Exp / 2;
                    PlayerRelations.GivePlayerExp(Attacker, exp);
                    PStruct.character[Victim, PStruct.player[Victim].SelectedChar].Exp -= exp;
                    SendData.Send_PlayerExp(Victim);
                    SendData.Send_ActionMsg(Victim, "-" + exp + lang.exp, 0, PlayerX, PlayerY, 1, 0, Map);
                    SendData.Send_Animation(Map, Globals.Target_Player, Attacker, 148);
                    PStruct.tempplayer[Victim].SORE = false;
                    PStruct.character[Victim, PStruct.player[Victim].SelectedChar].PVPPenalty = 0;
                    PStruct.character[Victim, PStruct.player[Victim].SelectedChar].PVP = false;
                    PStruct.character[Victim, PStruct.player[Victim].SelectedChar].PVPBanTimer = 60000 + Loops.TickCount.ElapsedMilliseconds;
                    SendData.Send_PlayerPvpToMap(Victim);
                    SendData.Send_PlayerSoreToMap(Victim);
                    SendData.Send_PlayerPvpBanTimer(Victim);
                }
              //Morte
              PStruct.tempplayer[Victim].isDead = true;
              SendData.Send_PlayerDeathToMap(Victim);
            }
        }
        //*********************************************************************************************
        // CanThrowPlayer / Revisto pela última vez em 01/08/2016, criado por Allyson S. Bacon
        // Verifica se determinado pode ser empurrado em determinada direção e distância
        //*********************************************************************************************
        public static bool CanThrowPlayer(int index, byte Dir, int range)
        {
            //EXTEND
            if (Extensions.ExtensionApp.ExtendMyApp
                (MethodBase.GetCurrentMethod().Name, index, Dir, range) != null)
            {
                return Convert.ToBoolean(Extensions.ExtensionApp.ExtendMyApp
                (MethodBase.GetCurrentMethod().Name, index, Dir, range));
            }

            //CÓDIGO
            int map = PStruct.character[index, PStruct.player[index].SelectedChar].Map;
            int x = PStruct.character[index, PStruct.player[index].SelectedChar].X;
            int y = PStruct.character[index, PStruct.player[index].SelectedChar].Y;
            //Tentamos nos mover
            switch (Dir)
            {
                case 8:
                    if (y - range < 0)
                    {
                        return false;
                    }
                    if (Convert.ToBoolean(MStruct.tile[map, x, y].UpBlock) == false) { return false; }
                    if (Convert.ToBoolean(MStruct.tile[map, x, y - range].DownBlock) == false) { return false; }
                    if (Convert.ToBoolean(MStruct.tile[map, x, y - (range - 1)].UpBlock) == false) { return false; }

                    if ((MStruct.tile[map, x, y - range].Data1 == "3") || (MStruct.tile[map, x, y - range].Data1 == "10") || (MStruct.tile[map, x, y - range].Data1 == "2")) { return false; }
                    if ((MStruct.tile[map, x, y - range].Data1 == "17") || (MStruct.tile[map, x, y - range].Data1 == "18")) { return false; }                   
                    if (MStruct.tile[map, x, y - range].Data1 == "21")
                    {
                        if (!PlayerRelations.IsPlayerPremmy(index))
                        {
                            return false;
                        }
                    }
                    break;
                case 2:
                    if (y + range > 14)
                    {
                        return false;
                    }
                    if (Convert.ToBoolean(MStruct.tile[map, x, y].DownBlock) == false) { return false; }
                    if (Convert.ToBoolean(MStruct.tile[map, x, y + range].UpBlock) == false) { return false; }
                    if (Convert.ToBoolean(MStruct.tile[map, x, y + (range - 1)].DownBlock) == false) { return false; }
                    if ((MStruct.tile[map, x, y + range].Data1 == "3") || (MStruct.tile[map, x, y + range].Data1 == "10") || (MStruct.tile[map, x, y + range].Data1 == "2")) { return false; }
                    if ((MStruct.tile[map, x, y + range].Data1 == "17") || (MStruct.tile[map, x, y + range].Data1 == "18")) { return false; }
                    if (MStruct.tile[map, x, y + range].Data1 == "21")
                    {
                        if (!PlayerRelations.IsPlayerPremmy(index))
                        {
                            return false;
                        }
                    }
                    break;
                case 4:
                    if (x - range < 0)
                    {
                       return false;
                    }
                    if (Convert.ToBoolean(MStruct.tile[map, x, y].LeftBlock) == false) { return false; }
                    if (Convert.ToBoolean(MStruct.tile[map, x - range, y].RightBlock) == false) { return false; }
                    if (Convert.ToBoolean(MStruct.tile[map, x - (range - 1), y].LeftBlock) == false) { return false; }
                    if ((MStruct.tile[map, x - range, y].Data1 == "3") || (MStruct.tile[map, x - range, y].Data1 == "10") || (MStruct.tile[map, x - range, y].Data1 == "2")) { return false; }
                    if ((MStruct.tile[map, x - range, y].Data1 == "17") || (MStruct.tile[map, x - range, y].Data1 == "18")) { return false; }
                    if (MStruct.tile[map, x - range, y].Data1 == "21")
                    {
                        if (!PlayerRelations.IsPlayerPremmy(index))
                        {
                            return false;
                        }
                    }
                    break;
                case 6:
                    if (x + range > 19)
                    {
                       return false;
                    }
                    if (Convert.ToBoolean(MStruct.tile[map, x, y].RightBlock) == false) { return false; }
                    if (Convert.ToBoolean(MStruct.tile[map, x + range, y].LeftBlock) == false) { return false; }
                    if (Convert.ToBoolean(MStruct.tile[map, x + (range - 1), y].RightBlock) == false) { return false; }
                    if ((MStruct.tile[map, x + range, y].Data1 == "3") || (MStruct.tile[map, x + range, y].Data1 == "10") || (MStruct.tile[map, x + range, y].Data1 == "2")) { return false; }
                    if ((MStruct.tile[map, x + range, y].Data1 == "17") || (MStruct.tile[map, x + range, y].Data1 == "18")) { return false; }
                    if (MStruct.tile[map, x + range, y].Data1 == "21")
                    {
                        if (!PlayerRelations.IsPlayerPremmy(index))
                        {
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
        // ThrowPlayer / Revisto pela última vez em 01/08/2016, criado por Allyson S. Bacon
        // Empurra determinado jogador para determinada direção e distância
        //*********************************************************************************************
        public static void ThrowPlayer(int index, int dir, int range)
        {
            //EXTEND
            if (Extensions.ExtensionApp.ExtendMyApp
                (MethodBase.GetCurrentMethod().Name, index, dir, range) != null)
            {
                return;
            }

            //CÓDIGO
            int map = PStruct.character[index, PStruct.player[index].SelectedChar].Map;
            int x = PStruct.character[index, PStruct.player[index].SelectedChar].X;
            int y = PStruct.character[index, PStruct.player[index].SelectedChar].Y;

            switch (dir)
            {
                case 8:
                    PStruct.character[index, PStruct.player[index].SelectedChar].Y = Convert.ToByte(Convert.ToInt32(PStruct.character[index, PStruct.player[index].SelectedChar].Y) - range);
                    break;
                case 2:
                    PStruct.character[index, PStruct.player[index].SelectedChar].Y = Convert.ToByte(Convert.ToInt32(PStruct.character[index, PStruct.player[index].SelectedChar].Y) + range);
                    break;
                case 4:
                    PStruct.character[index, PStruct.player[index].SelectedChar].X = Convert.ToByte(Convert.ToInt32(PStruct.character[index, PStruct.player[index].SelectedChar].X) - range);
                    break;
                case 6:
                    PStruct.character[index, PStruct.player[index].SelectedChar].X = Convert.ToByte(Convert.ToInt32(PStruct.character[index, PStruct.player[index].SelectedChar].X) + range);
                    break;
                default:
                    WinsockAsync.Log(String.Format("Direção nula"));
                    break;
            }

            SendData.Send_KnockBack(map, 1, index, dir, range);
        }
        //*********************************************************************************************
        // CanThrowNpc / Revisto pela última vez em 01/08/2016, criado por Allyson S. Bacon
        // Verifica se determinado NPC pode ser empurrado para determinada direção e distância
        //*********************************************************************************************
        public static bool CanThrowNpc(int map, int index, byte Dir, int range)
        {
            //EXTEND
            if (Extensions.ExtensionApp.ExtendMyApp
                (MethodBase.GetCurrentMethod().Name, map, index, Dir, range) != null)
            {
                return Convert.ToBoolean(Extensions.ExtensionApp.ExtendMyApp
                (MethodBase.GetCurrentMethod().Name, map, index, Dir, range));
            }

            //CÓDIGO
            int x = NStruct.tempnpc[map, index].X;
            int y = NStruct.tempnpc[map, index].Y;

            //Tentamos nos mover
            switch (Dir)
            {
                case 8:
                    if (y - range < 0)
                    {
                        return false;
                    }
                    if (Convert.ToBoolean(MStruct.tile[map, x, y].UpBlock) == false) { return false; }
                    if (Convert.ToBoolean(MStruct.tile[map, x, y - range].DownBlock) == false) { return false; }
                    if ((MStruct.tile[map, x, y - range].Data1 == "3") || (MStruct.tile[map, x, y - range].Data1 == "10") || (MStruct.tile[map, x, y - range].Data1 == "2")) { return false; }
                    if ((MStruct.tile[map, x, y - range].Data1 == "17") || (MStruct.tile[map, x, y - range].Data1 == "18")) { return false; }
                    break;
                case 2:
                    if (y + range > 14)
                    {
                        return false;
                    }
                    if (Convert.ToBoolean(MStruct.tile[map, x, y].DownBlock) == false) { return false; }
                    if (Convert.ToBoolean(MStruct.tile[map, x, y + range].UpBlock) == false) { return false; }
                    if ((MStruct.tile[map, x, y + range].Data1 == "3") || (MStruct.tile[map, x, y + range].Data1 == "10") || (MStruct.tile[map, x, y + range].Data1 == "2")) { return false; }
                    if ((MStruct.tile[map, x, y + range].Data1 == "17") || (MStruct.tile[map, x, y + range].Data1 == "18")) { return false; }
                    break;
                case 4:
                    if (x - range < 0)
                    {
                        return false;
                    }
                    if (Convert.ToBoolean(MStruct.tile[map, x, y].LeftBlock) == false) { return false; }
                    if (Convert.ToBoolean(MStruct.tile[map, x - range, y].RightBlock) == false) { return false; }
                    if ((MStruct.tile[map, x - range, y].Data1 == "3") || (MStruct.tile[map, x - range, y].Data1 == "10") || (MStruct.tile[map, x - range, y].Data1 == "2")) { return false; }
                    if ((MStruct.tile[map, x - range, y].Data1 == "17") || (MStruct.tile[map, x - range, y].Data1 == "18")) { return false; }
                    break;
                case 6:
                    if (x + range > 19)
                    {
                        return false;
                    }
                    if (Convert.ToBoolean(MStruct.tile[map, x, y].RightBlock) == false) { return false; }
                    if (Convert.ToBoolean(MStruct.tile[map, x + range, y].LeftBlock) == false) { return false; }
                    if ((MStruct.tile[map, x + range, y].Data1 == "3") || (MStruct.tile[map, x + range, y].Data1 == "10") || (MStruct.tile[map, x + range, y].Data1 == "2")) { return false; }
                    if ((MStruct.tile[map, x + range, y].Data1 == "17") || (MStruct.tile[map, x + range, y].Data1 == "18")) { return false; }
                    break;
                default:
                    WinsockAsync.Log(String.Format("Direção nula"));
                    break;
            }


            return true;
        }
        //*********************************************************************************************
        // ThrowNpc / Revisto pela última vez em 01/08/2016, criado por Allyson S. Bacon
        // Empurra determinado NPC para determinada direção e distância
        //*********************************************************************************************
        public static void ThrowNpc(int Map, int index, int dir, int range)
        {
            //EXTEND
            if (Extensions.ExtensionApp.ExtendMyApp
                (MethodBase.GetCurrentMethod().Name, Map, index, dir, range) != null)
            {
                return;
            }

            //CÓDIGO
            switch (dir)
            {
                case 8:
                    NStruct.tempnpc[Map, index].Y = Convert.ToByte(NStruct.tempnpc[Map, index].Y - range);
                    break;
                case 2:
                    NStruct.tempnpc[Map, index].Y = Convert.ToByte(NStruct.tempnpc[Map, index].Y + range);
                    break;
                case 4:
                    NStruct.tempnpc[Map, index].X = Convert.ToByte(NStruct.tempnpc[Map, index].X - range);
                    break;
                case 6:
                    NStruct.tempnpc[Map, index].X = Convert.ToByte(NStruct.tempnpc[Map, index].X + range);
                    break;
                default:
                    WinsockAsync.Log(String.Format("Direção nula"));
                    break;
            }

            SendData.Send_KnockBack(Map, 2, index, dir, range);
        }
        //*********************************************************************************************
        // GetOpenPTempSpell / Revisto pela última vez em 01/08/2016, criado por Allyson S. Bacon
        //*********************************************************************************************
        public static int GetOpenPTempSpell(int id)
        {
            //EXTEND
            if (Extensions.ExtensionApp.ExtendMyApp
                (MethodBase.GetCurrentMethod().Name, id) != null)
            {
                return Convert.ToInt32(Extensions.ExtensionApp.ExtendMyApp
                (MethodBase.GetCurrentMethod().Name, id));
            }

            //CÓDIGO
            for (int i = 1; i < Globals.MaxPTempSpells; i++)
            {
                if (PStruct.ptempspell[id, i].active == false)
                {
                    return i;
                }
            }

            return 0;
        }
        //*********************************************************************************************
        // ExecutePTempSpell / Revisto pela última vez em 01/08/2016, criado por Allyson S. Bacon
        //*********************************************************************************************
        public static void ExecuteTempSpell(int index, int PStempSpell)
        {
            //EXTEND
            if (Extensions.ExtensionApp.ExtendMyApp
                (MethodBase.GetCurrentMethod().Name, index, PStempSpell) != null)
            {
                return;
            }

            //CÓDIGO
            int Attacker = PStruct.ptempspell[index, PStempSpell].attacker;
            int Map = PStruct.character[index, PStruct.player[index].SelectedChar].Map;

            if ((UserConnection.Getindex(Attacker) < 0) || (UserConnection.Getindex(Attacker) >= WinsockAsync.Clients.Count())) 
            { 
                PStruct.ptempspell[index, PStempSpell].attacker = 0;
                PStruct.ptempspell[index, PStempSpell].timer = 0;
                PStruct.ptempspell[index, PStempSpell].spellnum = 0;
                PStruct.ptempspell[index, PStempSpell].repeats = 0;
                PStruct.ptempspell[index, PStempSpell].active = false;
                return;
            }

            //Verificar se o jogador não se desconectou no processo
            if (!WinsockAsync.Clients[(UserConnection.Getindex(Attacker))].IsConnected)
            {
                PStruct.ptempspell[index, PStempSpell].attacker = 0;
                PStruct.ptempspell[index, PStempSpell].timer = 0;
                PStruct.ptempspell[index, PStempSpell].spellnum = 0;
                PStruct.ptempspell[index, PStempSpell].repeats = 0;
                PStruct.ptempspell[index, PStempSpell].active = false;
                return;
            }

            if (PStruct.tempplayer[index].Vitality <= 0)
            {
                PStruct.ptempspell[index, PStempSpell].attacker = 0;
                PStruct.ptempspell[index, PStempSpell].timer = 0;
                PStruct.ptempspell[index, PStempSpell].spellnum = 0;
                PStruct.ptempspell[index, PStempSpell].repeats = 0;
                PStruct.ptempspell[index, PStempSpell].active = false;
                return;
            }

            SendData.Send_Animation(Map, 1, index, PStruct.ptempspell[index, PStempSpell].anim);

            if (PStruct.ptempspell[index, PStempSpell].area_range <= 0)
            {
                if (!PStruct.ptempspell[index, PStempSpell].is_heal)
                {
                    PStruct.PlayerAttackPlayer(Attacker, index, PStruct.ptempspell[index, PStempSpell].spellnum, Map);
                }
                else
                {
                    PlayerLogic.HealPlayer(index, PlayerLogic.HealSpellDamage(Attacker, PStruct.ptempspell[index, PStempSpell].spellnum));
                }
            }
            else
            {
                if (!PStruct.ptempspell[index, PStempSpell].is_heal)
                {
                    PlayerAttackPlayer(Attacker, index, PStruct.ptempspell[index, PStempSpell].spellnum, Map);
                    for (int i = 0; i <= MStruct.tempmap[Map].NpcCount; i++)
                    {
                        for (int r = 1; r <= PStruct.ptempspell[index, PStempSpell].area_range; r++)
                        {
                            if ((NStruct.tempnpc[Map, i].X - r == PStruct.character[index, PStruct.player[index].SelectedChar].X) && (NStruct.tempnpc[Map, i].Y == PStruct.character[index, PStruct.player[index].SelectedChar].Y))
                            {
                                PStruct.PlayerAttackNpc(Attacker, i, PStruct.ptempspell[index, PStempSpell].spellnum, Map);
                            }
                            if ((NStruct.tempnpc[Map, i].X + r == PStruct.character[index, PStruct.player[index].SelectedChar].X) && (NStruct.tempnpc[Map, i].Y == PStruct.character[index, PStruct.player[index].SelectedChar].Y))
                            {
                                PStruct.PlayerAttackNpc(Attacker, i, PStruct.ptempspell[index, PStempSpell].spellnum, Map);
                            }
                            if ((NStruct.tempnpc[Map, i].X == PStruct.character[index, PStruct.player[index].SelectedChar].X) && (NStruct.tempnpc[Map, i].Y - r == PStruct.character[index, PStruct.player[index].SelectedChar].Y))
                            {
                                PStruct.PlayerAttackNpc(Attacker, i, PStruct.ptempspell[index, PStempSpell].spellnum, Map);
                            }
                            if ((NStruct.tempnpc[Map, i].X == PStruct.character[index, PStruct.player[index].SelectedChar].X) && (NStruct.tempnpc[Map, i].Y + r == PStruct.character[index, PStruct.player[index].SelectedChar].Y))
                            {
                                PStruct.PlayerAttackNpc(Attacker, i, PStruct.ptempspell[index, PStempSpell].spellnum, Map);
                            }


                            //Is line?
                            if (PStruct.ptempspell[index, PStempSpell].is_line)
                            {
                                if ((NStruct.tempnpc[Map, i].X - r == PStruct.character[index, PStruct.player[index].SelectedChar].X) && (NStruct.tempnpc[Map, i].Y + r == PStruct.character[index, PStruct.player[index].SelectedChar].Y))
                                {
                                    PStruct.PlayerAttackNpc(Attacker, i, PStruct.ptempspell[index, PStempSpell].spellnum, Map);
                                }
                                if ((NStruct.tempnpc[Map, i].X + r == PStruct.character[index, PStruct.player[index].SelectedChar].X) && (NStruct.tempnpc[Map, i].Y - r == PStruct.character[index, PStruct.player[index].SelectedChar].Y))
                                {
                                    PStruct.PlayerAttackNpc(Attacker, i, PStruct.ptempspell[index, PStempSpell].spellnum, Map);
                                }
                                if ((NStruct.tempnpc[Map, i].X + r == PStruct.character[index, PStruct.player[index].SelectedChar].X) && (NStruct.tempnpc[Map, i].Y + r == PStruct.character[index, PStruct.player[index].SelectedChar].Y))
                                {
                                    PStruct.PlayerAttackNpc(Attacker, i, PStruct.ptempspell[index, PStempSpell].spellnum, Map);
                                }
                                if ((NStruct.tempnpc[Map, i].X - r == PStruct.character[index, PStruct.player[index].SelectedChar].X) && (NStruct.tempnpc[Map, i].Y - r == PStruct.character[index, PStruct.player[index].SelectedChar].Y))
                                {
                                    PStruct.PlayerAttackNpc(Attacker, i, PStruct.ptempspell[index, PStempSpell].spellnum, Map);
                                }
                            }
                        }
                    }

                    for (int i = 0; i <= Globals.Player_Highindex; i++)
                    {
                        if ((PStruct.character[i, PStruct.player[i].SelectedChar].Map == Map) && (PStruct.character[index, PStruct.player[index].SelectedChar].PVP) && (i != index))
                        {
                            for (int r = 1; r <= PStruct.ptempspell[index, PStempSpell].area_range; r++)
                            {
                                if ((PStruct.character[i, PStruct.player[i].SelectedChar].X - r == PStruct.character[index, PStruct.player[index].SelectedChar].X) && (PStruct.character[i, PStruct.player[i].SelectedChar].Y == PStruct.character[index, PStruct.player[i].SelectedChar].Y))
                                {
                                    PStruct.PlayerAttackPlayer(Attacker, i, PStruct.ptempspell[index, PStempSpell].spellnum, Map);
                                }
                                if ((PStruct.character[i, PStruct.player[i].SelectedChar].X + r == PStruct.character[index, PStruct.player[index].SelectedChar].X) && (PStruct.character[i, PStruct.player[i].SelectedChar].Y == PStruct.character[index, PStruct.player[i].SelectedChar].Y))
                                {
                                    PStruct.PlayerAttackPlayer(Attacker, i, PStruct.ptempspell[index, PStempSpell].spellnum, Map);
                                }
                                if ((PStruct.character[i, PStruct.player[i].SelectedChar].X == PStruct.character[index, PStruct.player[index].SelectedChar].X) && (PStruct.character[i, PStruct.player[i].SelectedChar].Y - r == PStruct.character[index, PStruct.player[i].SelectedChar].Y))
                                {
                                    PStruct.PlayerAttackPlayer(Attacker, i, PStruct.ptempspell[index, PStempSpell].spellnum, Map);
                                }
                                if ((PStruct.character[i, PStruct.player[i].SelectedChar].X == PStruct.character[index, PStruct.player[index].SelectedChar].X) && (PStruct.character[i, PStruct.player[i].SelectedChar].Y + r == PStruct.character[index, PStruct.player[i].SelectedChar].Y))
                                {
                                    PStruct.PlayerAttackPlayer(Attacker, i, PStruct.ptempspell[index, PStempSpell].spellnum, Map);
                                }


                                //Is line?
                                if (PStruct.ptempspell[index, PStempSpell].is_line)
                                {
                                    if ((PStruct.character[i, PStruct.player[i].SelectedChar].X - r == PStruct.character[index, PStruct.player[index].SelectedChar].X) && (PStruct.character[i, PStruct.player[i].SelectedChar].Y + r == PStruct.character[index, PStruct.player[i].SelectedChar].Y))
                                    {
                                        PStruct.PlayerAttackPlayer(Attacker, i, PStruct.ptempspell[index, PStempSpell].spellnum, Map);
                                    }
                                    if ((PStruct.character[i, PStruct.player[i].SelectedChar].X + r == PStruct.character[index, PStruct.player[index].SelectedChar].X) && (PStruct.character[i, PStruct.player[i].SelectedChar].Y - r == PStruct.character[index, PStruct.player[i].SelectedChar].Y))
                                    {
                                        PStruct.PlayerAttackPlayer(Attacker, i, PStruct.ptempspell[index, PStempSpell].spellnum, Map);
                                    }
                                    if ((PStruct.character[i, PStruct.player[i].SelectedChar].X + r == PStruct.character[index, PStruct.player[index].SelectedChar].X) && (PStruct.character[i, PStruct.player[i].SelectedChar].Y + r == PStruct.character[index, PStruct.player[i].SelectedChar].Y))
                                    {
                                        PStruct.PlayerAttackPlayer(Attacker, i, PStruct.ptempspell[index, PStempSpell].spellnum, Map);
                                    }
                                    if ((PStruct.character[i, PStruct.player[i].SelectedChar].X - r == PStruct.character[index, PStruct.player[index].SelectedChar].X) && (PStruct.character[i, PStruct.player[i].SelectedChar].Y - r == PStruct.character[index, PStruct.player[i].SelectedChar].Y))
                                    {
                                        PStruct.PlayerAttackPlayer(Attacker, i, PStruct.ptempspell[index, PStempSpell].spellnum, Map);
                                    }
                                }
                            }
                        }
                    }
                }
                else
                {
                    PlayerLogic.HealPlayer(index, PlayerLogic.HealSpellDamage(Attacker, PStruct.ptempspell[index, PStempSpell].spellnum));
                    PlayerAttackPlayer(Attacker, index, PStruct.ptempspell[index, PStempSpell].spellnum, Map);
                    for (int i = 0; i <= MStruct.tempmap[Map].NpcCount; i++)
                    {
                        for (int r = 1; r <= PStruct.ptempspell[index, PStempSpell].area_range; r++)
                        {
                            if ((NStruct.tempnpc[Map, i].X - r == PStruct.character[index, PStruct.player[index].SelectedChar].X) && (NStruct.tempnpc[Map, i].Y == PStruct.character[index, PStruct.player[index].SelectedChar].Y))
                            {
                                PStruct.PlayerAttackNpc(Attacker, i, PStruct.ptempspell[index, PStempSpell].spellnum, Map);
                            }
                            if ((NStruct.tempnpc[Map, i].X + r == PStruct.character[index, PStruct.player[index].SelectedChar].X) && (NStruct.tempnpc[Map, i].Y == PStruct.character[index, PStruct.player[index].SelectedChar].Y))
                            {
                                PStruct.PlayerAttackNpc(Attacker, i, PStruct.ptempspell[index, PStempSpell].spellnum, Map);
                            }
                            if ((NStruct.tempnpc[Map, i].X == PStruct.character[index, PStruct.player[index].SelectedChar].X) && (NStruct.tempnpc[Map, i].Y - r == PStruct.character[index, PStruct.player[index].SelectedChar].Y))
                            {
                                PStruct.PlayerAttackNpc(Attacker, i, PStruct.ptempspell[index, PStempSpell].spellnum, Map);
                            }
                            if ((NStruct.tempnpc[Map, i].X == PStruct.character[index, PStruct.player[index].SelectedChar].X) && (NStruct.tempnpc[Map, i].Y + r == PStruct.character[index, PStruct.player[index].SelectedChar].Y))
                            {
                                PStruct.PlayerAttackNpc(Attacker, i, PStruct.ptempspell[index, PStempSpell].spellnum, Map);
                            }


                            //Is line?
                            if (PStruct.ptempspell[index, PStempSpell].is_line)
                            {
                                if ((NStruct.tempnpc[Map, i].X - r == PStruct.character[index, PStruct.player[index].SelectedChar].X) && (NStruct.tempnpc[Map, i].Y + r == PStruct.character[index, PStruct.player[index].SelectedChar].Y))
                                {
                                    PStruct.PlayerAttackNpc(Attacker, i, PStruct.ptempspell[index, PStempSpell].spellnum, Map);
                                }
                                if ((NStruct.tempnpc[Map, i].X + r == PStruct.character[index, PStruct.player[index].SelectedChar].X) && (NStruct.tempnpc[Map, i].Y - r == PStruct.character[index, PStruct.player[index].SelectedChar].Y))
                                {
                                    PStruct.PlayerAttackNpc(Attacker, i, PStruct.ptempspell[index, PStempSpell].spellnum, Map);
                                }
                                if ((NStruct.tempnpc[Map, i].X + r == PStruct.character[index, PStruct.player[index].SelectedChar].X) && (NStruct.tempnpc[Map, i].Y + r == PStruct.character[index, PStruct.player[index].SelectedChar].Y))
                                {
                                    PStruct.PlayerAttackNpc(Attacker, i, PStruct.ptempspell[index, PStempSpell].spellnum, Map);
                                }
                                if ((NStruct.tempnpc[Map, i].X - r == PStruct.character[index, PStruct.player[index].SelectedChar].X) && (NStruct.tempnpc[Map, i].Y - r == PStruct.character[index, PStruct.player[index].SelectedChar].Y))
                                {
                                    PStruct.PlayerAttackNpc(Attacker, i, PStruct.ptempspell[index, PStempSpell].spellnum, Map);
                                }
                            }
                        }
                    }

                    for (int i = 0; i <= Globals.Player_Highindex; i++)
                    {
                        if ((PStruct.character[i, PStruct.player[i].SelectedChar].Map == Map) && (PStruct.character[index, PStruct.player[index].SelectedChar].PVP) && (i != index))
                        {
                            for (int r = 1; r <= PStruct.ptempspell[index, PStempSpell].area_range; r++)
                            {
                                if ((PStruct.character[i, PStruct.player[i].SelectedChar].X - r == PStruct.character[index, PStruct.player[index].SelectedChar].X) && (PStruct.character[i, PStruct.player[i].SelectedChar].Y == PStruct.character[index, PStruct.player[i].SelectedChar].Y))
                                {
                                    PlayerLogic.HealPlayer(i, PlayerLogic.HealSpellDamage(Attacker, PStruct.ptempspell[index, PStempSpell].spellnum));
                                }
                                if ((PStruct.character[i, PStruct.player[i].SelectedChar].X + r == PStruct.character[index, PStruct.player[index].SelectedChar].X) && (PStruct.character[i, PStruct.player[i].SelectedChar].Y == PStruct.character[index, PStruct.player[i].SelectedChar].Y))
                                {
                                    PlayerLogic.HealPlayer(i, PlayerLogic.HealSpellDamage(Attacker, PStruct.ptempspell[index, PStempSpell].spellnum));
                                }
                                if ((PStruct.character[i, PStruct.player[i].SelectedChar].X == PStruct.character[index, PStruct.player[index].SelectedChar].X) && (PStruct.character[i, PStruct.player[i].SelectedChar].Y - r == PStruct.character[index, PStruct.player[i].SelectedChar].Y))
                                {
                                    PlayerLogic.HealPlayer(i, PlayerLogic.HealSpellDamage(Attacker, PStruct.ptempspell[index, PStempSpell].spellnum));
                                }
                                if ((PStruct.character[i, PStruct.player[i].SelectedChar].X == PStruct.character[index, PStruct.player[index].SelectedChar].X) && (PStruct.character[i, PStruct.player[i].SelectedChar].Y + r == PStruct.character[index, PStruct.player[i].SelectedChar].Y))
                                {
                                    PlayerLogic.HealPlayer(i, PlayerLogic.HealSpellDamage(Attacker, PStruct.ptempspell[index, PStempSpell].spellnum));
                                }


                                //Is line?
                                if (PStruct.ptempspell[index, PStempSpell].is_line)
                                {
                                    if ((PStruct.character[i, PStruct.player[i].SelectedChar].X - r == PStruct.character[index, PStruct.player[index].SelectedChar].X) && (PStruct.character[i, PStruct.player[i].SelectedChar].Y + r == PStruct.character[index, PStruct.player[i].SelectedChar].Y))
                                    {
                                        PlayerLogic.HealPlayer(i, PlayerLogic.HealSpellDamage(Attacker, PStruct.ptempspell[index, PStempSpell].spellnum));
                                    }
                                    if ((PStruct.character[i, PStruct.player[i].SelectedChar].X + r == PStruct.character[index, PStruct.player[index].SelectedChar].X) && (PStruct.character[i, PStruct.player[i].SelectedChar].Y - r == PStruct.character[index, PStruct.player[i].SelectedChar].Y))
                                    {
                                        PlayerLogic.HealPlayer(i, PlayerLogic.HealSpellDamage(Attacker, PStruct.ptempspell[index, PStempSpell].spellnum));
                                    }
                                    if ((PStruct.character[i, PStruct.player[i].SelectedChar].X + r == PStruct.character[index, PStruct.player[index].SelectedChar].X) && (PStruct.character[i, PStruct.player[i].SelectedChar].Y + r == PStruct.character[index, PStruct.player[i].SelectedChar].Y))
                                    {
                                        PlayerLogic.HealPlayer(i, PlayerLogic.HealSpellDamage(Attacker, PStruct.ptempspell[index, PStempSpell].spellnum));
                                    }
                                    if ((PStruct.character[i, PStruct.player[i].SelectedChar].X - r == PStruct.character[index, PStruct.player[index].SelectedChar].X) && (PStruct.character[i, PStruct.player[i].SelectedChar].Y - r == PStruct.character[index, PStruct.player[i].SelectedChar].Y))
                                    {
                                        PlayerLogic.HealPlayer(i, PlayerLogic.HealSpellDamage(Attacker, PStruct.ptempspell[index, PStempSpell].spellnum));
                                    }
                                }
                            }
                        }
                    }
                }
            }

            PStruct.ptempspell[index, PStempSpell].repeats -= 1;

            if (PStruct.ptempspell[index, PStempSpell].repeats <= 0)
            {
                if ((SStruct.skill[PStruct.ptempspell[index, PStempSpell].spellnum].slow) || (PStruct.ptempspell[index, PStempSpell].fast_buff))
                {
                    PStruct.tempplayer[index].movespeed = Globals.NormalMoveSpeed;
                    SendData.Send_MoveSpeed(1, index);
                }
                PStruct.ptempspell[index, PStempSpell].attacker = 0;
                PStruct.ptempspell[index, PStempSpell].timer = 0;
                PStruct.ptempspell[index, PStempSpell].spellnum = 0;
                PStruct.ptempspell[index, PStempSpell].repeats = 0;
                PStruct.ptempspell[index, PStempSpell].active = false;
            }

            PStruct.ptempspell[index, PStempSpell].timer = Loops.TickCount.ElapsedMilliseconds + SStruct.skill[PStruct.ptempspell[index, PStempSpell].spellnum].interval;

        }
        //*********************************************************************************************
        // PlayerDeath / Revisto pela última vez em 01/08/2016, criado por Allyson S. Bacon
        //*********************************************************************************************
        public static void PlayerDeath(int index)
        {
            //EXTEND
            if (Extensions.ExtensionApp.ExtendMyApp
                (MethodBase.GetCurrentMethod().Name, index) != null)
            {
                return;
            }

            //CÓDIGO
            tempplayer[index].Vitality = 1;
            tempplayer[index].Spirit = 1;

        }
        //*********************************************************************************************
        // PlayerIsSore / Revisto pela última vez em 01/08/2016, criado por Allyson S. Bacon
        //*********************************************************************************************
        public static bool PlayerIsSore(int index)
        {
            //EXTEND
            if (Extensions.ExtensionApp.ExtendMyApp
                (MethodBase.GetCurrentMethod().Name, index) != null)
            {
                return Convert.ToBoolean(Extensions.ExtensionApp.ExtendMyApp
                (MethodBase.GetCurrentMethod().Name, index));
            }

            //CÓDIGO
            if (PStruct.character[index, PStruct.player[index].SelectedChar].PVPPenalty > Loops.TickCount.ElapsedMilliseconds) { return true; } else { PStruct.character[index, PStruct.player[index].SelectedChar].PVPPenalty = 0; return false; }
        }
        //*********************************************************************************************
        // PlayerRegen / Revisto pela última vez em 01/08/2016, criado por Allyson S. Bacon
        //*********************************************************************************************
        public static void PlayerRegen(int index)
        {
            //EXTEND
            if (Extensions.ExtensionApp.ExtendMyApp
                (MethodBase.GetCurrentMethod().Name, index) != null)
            {
                return;
            }

            //CÓDIGO
            if (PStruct.tempplayer[index].isDead) { return; }
            if (PStruct.tempplayer[index].Vitality < PStruct.GetPlayerMaxVitality(index))
            {
                //Regen por segundo
                PStruct.tempplayer[index].Vitality += GetPlayerVitalityRegen(index);
                //Vida atual ficou maior que a máxima?
                if (PStruct.tempplayer[index].Vitality > GetPlayerMaxVitality(index))
                {
                    PStruct.tempplayer[index].Vitality = GetPlayerMaxVitality(index);
                }
                //Envia vida recuperada
                SendData.Send_PlayerVitalityToMap(PStruct.character[index, PStruct.player[index].SelectedChar].Map, index, PStruct.tempplayer[index].Vitality);
                //Se estiver em grupo atualiza para o grupo também
                if (PStruct.tempplayer[index].Party > 0)
                {
                    SendData.Send_PlayerVitalityToParty(PStruct.tempplayer[index].Party, index, PStruct.tempplayer[index].Vitality);
                }
            }
            if (PStruct.tempplayer[index].Spirit < PStruct.GetPlayerMaxSpirit(index))
            {
                //Regen por segundo
                PStruct.tempplayer[index].Spirit += GetPlayerSpiritRegen(index);
                //Mana atual ficou maior que a máxima?
                if (PStruct.tempplayer[index].Spirit > GetPlayerMaxSpirit(index))
                {
                    PStruct.tempplayer[index].Spirit = GetPlayerMaxSpirit(index);
                }
                //Envia vida recuperada
                SendData.Send_PlayerSpiritToMap(PStruct.character[index, PStruct.player[index].SelectedChar].Map, index, PStruct.tempplayer[index].Spirit);
                //Se estiver em grupo atualiza para o grupo também
                if (PStruct.tempplayer[index].Party > 0)
                {
                    SendData.Send_PlayerSpiritToParty(PStruct.tempplayer[index].Party, index, PStruct.tempplayer[index].Spirit);
                }
            }

            PStruct.tempplayer[index].RegenTimer = Loops.TickCount.ElapsedMilliseconds + 1000;
        }
    }

}
