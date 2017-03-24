using System;
using System.Linq;
using System.Reflection;

namespace FORJERUM
{
    //*********************************************************************************************
    // Estruturas e métodos relacionados aos npcs.
    // NStruct.cs
    //*********************************************************************************************
    class NStruct
    {
        //*********************************************************************************************
        // ESTRUTURA DOS NPCS
        // Estruturas gerais contendo o drop, magias, e informações temporárias
        //*********************************************************************************************
        public static TempNpc[,] tempnpc = new TempNpc[Globals.MaxMaps, 1001];
        public static NTempSpell[,,] ntempspell = new NTempSpell[Globals.MaxMaps, 1001, Globals.MaxNTempSpells];
        public static NSpell[, ,] nspell = new NSpell[Globals.MaxMaps, 1001, Globals.Max_Npc_Spells];
        public static Npc[,] npc = new Npc[Globals.MaxMaps, 1001];
        public static NpcDrop[,,] npcdrop = new NpcDrop[Globals.MaxMaps, 1001, 5];

        public struct Npc
        {
            public int Map;
            public string Name;
            public string Sprite;
            public int index;
            public string Talk;
            public int X;
            public int Y;
            public int Attack;
            public int Defense;
            public int Agility;
            public int MagicDefense;
            public int MagicAttack;
            public int Luck;
            public int Range;
            public int Vitality;
            public int Spirit;
            public int Type;
            public int Animation;
            public int Respawn;
            public int SpeedMove;
            public int Exp;
            public int Gold;
            public bool KnockAttack;
            public int KnockRange;
        }

        public struct NpcDrop
        {
            public int ItemNum;
            public int ItemType;
            public int Chance;
            public int Value;
        }

        public struct TempNpc
        {
            public int Target;
            public int curTargetX;
            public int curTargetY;
            public long curTimer;
            public int X;
            public int Y;
            public byte Dir;
            public byte Moving;
            public long AttackTimer;
            public int curTarget;
            public int Current;
            public int Vitality;
            public int Spirit;
            public long RespawnTimer;
            public long MoveTimer;
            public bool Dead;
            public long ParalyzeTimer;
            public long Blindtimer;
            public long RegenTimer;
            public bool Stunned;
            public long StunTimer;
            public bool Sleeping;
            public long SleepTimer;
            public bool Slowed;
            public long SlowTimer;
            public double movespeed;
            public int preparingskill;
            public int preparingskillslot;
            public long skilltimer;
            public bool Blind;
            public long BlindTimer;
            public int guildnum;
            public Point[] prev_move;
            public bool isFrozen;
            public byte ReduceDamage;
        }

        public struct Point
        {
            public int x;
            public int y;
        }

        public struct NTempSpell
        {
            public bool active;
            public int attacker;
            public int spellnum;
            public long timer;
            public int repeats;
            public int anim;
            public int area_range;
            public bool is_line;
        }

        public struct NSpell
        {
            public int spellnum;
            public long cooldown; //??? askapsoksa
        }

        //*********************************************************************************************
        // GetOpenNTempSpell / Revisto pela última vez em 01/08/2016, criado por Allyson S. Bacon
        //*********************************************************************************************
        public static int GetOpenNTempSpell(int map, int id)
        {
            //EXTEND
            if (Extensions.ExtensionApp.ExtendMyApp
                (MethodBase.GetCurrentMethod().Name, map, id) != null)
            {
                return Convert.ToInt32(Extensions.ExtensionApp.ExtendMyApp
                (MethodBase.GetCurrentMethod().Name, map, id));
            }

            //CÓDIGO
            for (int i = 1; i < Globals.MaxNTempSpells; i++)
            {
                if (ntempspell[map, id, i].active == false)
                {
                    return i;
                }
            }

            return 0;
        }
        //*********************************************************************************************
        // GetNpcDropCount / Revisto pela última vez em 01/08/2016, criado por Allyson S. Bacon
        // Quantidade de itens a dropar de determinado monstro
        //*********************************************************************************************
        public static int GetNpcDropCount(int map, int id)
        {
            //EXTEND
            if (Extensions.ExtensionApp.ExtendMyApp
                (MethodBase.GetCurrentMethod().Name, map, id) != null)
            {
                return Convert.ToInt32(Extensions.ExtensionApp.ExtendMyApp
                (MethodBase.GetCurrentMethod().Name, map, id));
            }

            //CÓDIGO
            int count = 0;

            for (int i = 0; i < Globals.MaxNpcDrops; i++)
            {
                if (npcdrop[map, id, i].ItemNum > 0)
                {
                    count += 1;
                }
            }
            return count;
        }
        //*********************************************************************************************
        // GetNpcCritical / Revisto pela última vez em 01/08/2016, criado por Allyson S. Bacon
        //*********************************************************************************************
        public static int GetNpcCritical(int Map, int index)
        {
            //EXTEND
            if (Extensions.ExtensionApp.ExtendMyApp
                (MethodBase.GetCurrentMethod().Name, Map, index) != null)
            {
                return Convert.ToInt32(Extensions.ExtensionApp.ExtendMyApp
                (MethodBase.GetCurrentMethod().Name, Map, index));
            }

            //CÓDIGO
            double WaterCritical = Convert.ToDouble(npc[Map, index].Luck) * 1.0;
            int critical = Convert.ToInt32(WaterCritical);

            return critical;
        }
        //*********************************************************************************************
        // GetNpcParry / Revisto pela última vez em 01/08/2016, criado por Allyson S. Bacon
        //*********************************************************************************************
        public static int GetNpcParry(int Map, int index)
        {
            //EXTEND
            if (Extensions.ExtensionApp.ExtendMyApp
                (MethodBase.GetCurrentMethod().Name, Map, index) != null)
            {
                return Convert.ToInt32(Extensions.ExtensionApp.ExtendMyApp
                (MethodBase.GetCurrentMethod().Name, Map, index));
            }

            //CÓDIGO
            double WindParry = Convert.ToDouble(npc[Map, index].Agility) * 1.0;
            int parry = Convert.ToInt32(WindParry);

            return parry;
        }
        //*********************************************************************************************
        // RegenNpc / Revisto pela última vez em 01/08/2016, criado por Allyson S. Bacon
        //*********************************************************************************************
        public static void RegenNpc(int Map, int index, bool SuperRegen = false)
        {
            //EXTEND
            if (Extensions.ExtensionApp.ExtendMyApp
                (MethodBase.GetCurrentMethod().Name, Map, index, SuperRegen) != null)
            {
                return;
            }

            //CÓDIGO
            if ((tempnpc[Map, index].Vitality <= 0) || (tempnpc[Map, index].Dead)) { return; }
            if ((tempnpc[Map, index].Vitality == npc[Map, index].Vitality) && (tempnpc[Map, index].Spirit == npc[Map, index].Spirit)) { return; }

            if (SuperRegen)
            {
                if (tempnpc[Map, index].Vitality < npc[Map, index].Vitality)
                {
                    tempnpc[Map, index].Vitality = npc[Map, index].Vitality;
                    return;
                }

                if (tempnpc[Map, index].Spirit < npc[Map, index].Spirit)
                {
                    tempnpc[Map, index].Spirit = npc[Map, index].Spirit;
                    return;
                }
                return;
            }

            if (tempnpc[Map, index].Vitality < npc[Map, index].Vitality)
            {
                tempnpc[Map, index].Vitality += (npc[Map, index].Vitality / 150);
                if (tempnpc[Map, index].Vitality > npc[Map, index].Vitality)
                {
                    tempnpc[Map, index].Vitality = npc[Map, index].Vitality;
                }
                SendData.Send_NpcVitality(Map, index, tempnpc[Map, index].Vitality);
            }

            if (tempnpc[Map, index].Spirit < npc[Map, index].Spirit)
            {
                tempnpc[Map, index].Spirit += (npc[Map, index].Spirit / 10);
                if (tempnpc[Map, index].Spirit > npc[Map, index].Spirit)
                {
                    tempnpc[Map, index].Spirit = npc[Map, index].Spirit;
                }
            }

            tempnpc[Map, index].RegenTimer = Loops.TickCount.ElapsedMilliseconds + 1000;
        }
        //*********************************************************************************************
        // ClearTempNpc / Revisto pela última vez em 01/08/2016, criado por Allyson S. Bacon
        // Limpa informações temporárias de um determinado NPC.
        //*********************************************************************************************
        public static void ClearTempNpc(int mapnum, int i2)
        {
            //EXTEND
            if (Extensions.ExtensionApp.ExtendMyApp
                (MethodBase.GetCurrentMethod().Name, mapnum, i2) != null)
            {
                return;
            }

            //CÓDIGO
            npc[mapnum, i2].Name = "";
            npc[mapnum, i2].Map = 0;
            npc[mapnum, i2].X = 0;
            npc[mapnum, i2].Y = 0;
            npc[mapnum, i2].Vitality = 0;
            npc[mapnum, i2].Spirit = 0;
            tempnpc[mapnum, i2].Target = 0;
            tempnpc[mapnum, i2].X = 0;
            tempnpc[mapnum, i2].Y = 0;
            tempnpc[mapnum, i2].curTargetX = 0;
            tempnpc[mapnum, i2].curTargetY = 0;
            tempnpc[mapnum, i2].Vitality = 0;
            npc[mapnum, i2].Attack = 0;
            npc[mapnum, i2].Defense = 0;
            npc[mapnum, i2].Agility = 0;
            npc[mapnum, i2].MagicDefense = 0;
            npc[mapnum, i2].MagicAttack = 0;
            npc[mapnum, i2].Luck = 0;
            npc[mapnum, i2].Sprite = "";
            npc[mapnum, i2].index = 0;
            npc[mapnum, i2].Type = 0;
            npc[mapnum, i2].Range = 0;

            //if (notedata.Length - 1 > 11)
            //{
            //    npc[mapnum, i2].KnockAttack = Convert.ToBoolean(notedata[12]);
            //    npc[mapnum, i2].KnockRange = Convert.ToInt32(notedata[13]);
            //    nspell[mapnum, i2, 1].spellnum = Convert.ToInt32(notedata[14]);
            //    nspell[mapnum, i2, 2].spellnum = Convert.ToInt32(notedata[15]);
            //    nspell[mapnum, i2, 3].spellnum = Convert.ToInt32(notedata[16]);
            //    nspell[mapnum, i2, 4].spellnum = Convert.ToInt32(notedata[17]);
            //}

            npc[mapnum, i2].Animation = 0;
            npc[mapnum, i2].SpeedMove = 0;
            tempnpc[mapnum, i2].movespeed = 0;
            npc[mapnum, i2].Respawn = 0;
            npc[mapnum, i2].Exp = 0;
            npc[mapnum, i2].Gold = 0;
            tempnpc[mapnum, i2].guildnum = 0;
        }
        //*********************************************************************************************
        // ExecuteTempSpell / Revisto pela última vez em 01/08/2016, criado por Allyson S. Bacon
        //*********************************************************************************************
        public static void ExecuteTempSpell(int Map, int index, int NStempSpell)
        {
            //EXTEND
            if (Extensions.ExtensionApp.ExtendMyApp
                (MethodBase.GetCurrentMethod().Name, Map, index, NStempSpell) != null)
            {
                return;
            }

            //CÓDIGO
            int Attacker = ntempspell[Map, index, NStempSpell].attacker;

            if ((UserConnection.Getindex(Attacker) < 0) || (UserConnection.Getindex(Attacker) >= WinsockAsync.Clients.Count()))
            {
                ntempspell[Map, index, NStempSpell].attacker = 0;
                ntempspell[Map, index, NStempSpell].timer = 0;
                ntempspell[Map, index, NStempSpell].spellnum = 0;
                ntempspell[Map, index, NStempSpell].repeats = 0;
                ntempspell[Map, index, NStempSpell].active = false;
                return;
            }

            //Verificar se o jogador não se desconectou no processo
            if (!WinsockAsync.Clients[(UserConnection.Getindex(Attacker))].IsConnected)
            {
                ntempspell[Map, index, NStempSpell].attacker = 0;
                ntempspell[Map, index, NStempSpell].timer = 0;
                ntempspell[Map, index, NStempSpell].spellnum = 0;
                ntempspell[Map, index, NStempSpell].repeats = 0;
                ntempspell[Map, index, NStempSpell].active = false;
                return;
            }

            if (tempnpc[Map, index].Vitality <= 0)
            {
                ntempspell[Map, index, NStempSpell].attacker = 0;
                ntempspell[Map, index, NStempSpell].timer = 0;
                ntempspell[Map, index, NStempSpell].spellnum = 0;
                ntempspell[Map, index, NStempSpell].repeats = 0;
                ntempspell[Map, index, NStempSpell].active = false;
                return;
            }

            SendData.Send_Animation(Map, 2, index, ntempspell[Map, index, NStempSpell].anim);
            
            if (ntempspell[Map, index, NStempSpell].area_range <= 0)
            {
                PStruct.PlayerAttackNpc(Attacker, index, ntempspell[Map, index, NStempSpell].spellnum, Map);
            }
            else
            {
                PStruct.PlayerAttackNpc(Attacker, index, ntempspell[Map, index, NStempSpell].spellnum, Map);
                for (int i = 0; i <= Globals.Player_Highindex; i++)
                {
                    if ((PStruct.character[i, PStruct.player[i].SelectedChar].Map == Map) && (PStruct.character[index, PStruct.player[index].SelectedChar].PVP) && (i != index))
                    {
                        for (int r = 1; r <= ntempspell[Map, index, NStempSpell].area_range; r++)
                        {
                            if ((PStruct.character[i, PStruct.player[i].SelectedChar].X - r == tempnpc[Map, index].X) && (PStruct.character[i, PStruct.player[i].SelectedChar].Y == tempnpc[Map, index].Y))
                            {
                                PStruct.PlayerAttackPlayer(Attacker, i, ntempspell[Map, index, NStempSpell].spellnum, Map);
                            }
                            if ((PStruct.character[i, PStruct.player[i].SelectedChar].X + r == tempnpc[Map, index].X) && (PStruct.character[i, PStruct.player[i].SelectedChar].Y == tempnpc[Map, index].Y))
                            {
                                PStruct.PlayerAttackPlayer(Attacker, i, ntempspell[Map, index, NStempSpell].spellnum, Map);
                            }
                            if ((PStruct.character[i, PStruct.player[i].SelectedChar].X == tempnpc[Map, index].X) && (PStruct.character[i, PStruct.player[i].SelectedChar].Y - r == tempnpc[Map, index].Y))
                            {
                                PStruct.PlayerAttackPlayer(Attacker, i, ntempspell[Map, index, NStempSpell].spellnum, Map);
                            }
                            if ((PStruct.character[i, PStruct.player[i].SelectedChar].X == tempnpc[Map, index].X) && (PStruct.character[i, PStruct.player[i].SelectedChar].Y + r == tempnpc[Map, index].Y))
                            {
                                PStruct.PlayerAttackPlayer(Attacker, i, ntempspell[Map, index, NStempSpell].spellnum, Map);
                            }


                            //Is line?
                            if (ntempspell[Map, index, NStempSpell].is_line)
                            {
                                if ((PStruct.character[i, PStruct.player[i].SelectedChar].X - r == tempnpc[Map, index].X) && (PStruct.character[i, PStruct.player[i].SelectedChar].Y + r == tempnpc[Map, index].Y))
                                {
                                    PStruct.PlayerAttackPlayer(Attacker, i, ntempspell[Map, index, NStempSpell].spellnum, Map);
                                }
                                if ((PStruct.character[i, PStruct.player[i].SelectedChar].X + r == tempnpc[Map, index].X) && (PStruct.character[i, PStruct.player[i].SelectedChar].Y - r == tempnpc[Map, index].Y))
                                {
                                    PStruct.PlayerAttackPlayer(Attacker, i, ntempspell[Map, index, NStempSpell].spellnum, Map);
                                }
                                if ((PStruct.character[i, PStruct.player[i].SelectedChar].X + r == tempnpc[Map, index].X) && (PStruct.character[i, PStruct.player[i].SelectedChar].Y + r == tempnpc[Map, index].Y))
                                {
                                    PStruct.PlayerAttackPlayer(Attacker, i, ntempspell[Map, index, NStempSpell].spellnum, Map);
                                }
                                if ((PStruct.character[i, PStruct.player[i].SelectedChar].X - r == tempnpc[Map, index].X) && (PStruct.character[i, PStruct.player[i].SelectedChar].Y - r == tempnpc[Map, index].Y))
                                {
                                    PStruct.PlayerAttackPlayer(Attacker, i, ntempspell[Map, index, NStempSpell].spellnum, Map);
                                }
                            }
                        }
                    }
                }
                
                for (int i = 0; i <= MStruct.tempmap[Map].NpcCount; i++)
                {
                    for (int r = 1; r <= ntempspell[Map, index, NStempSpell].area_range; r++)
                    {
                        if ((tempnpc[Map, i].X - r == tempnpc[Map, index].X) && (tempnpc[Map, i].Y == tempnpc[Map, index].Y))
                        {
                            PStruct.PlayerAttackNpc(Attacker, i, ntempspell[Map, index, NStempSpell].spellnum, Map);
                        }
                        if ((tempnpc[Map, i].X + r == tempnpc[Map, index].X) && (tempnpc[Map, i].Y == tempnpc[Map, index].Y))
                        {
                            PStruct.PlayerAttackNpc(Attacker, i, ntempspell[Map, index, NStempSpell].spellnum, Map);
                        }
                        if ((tempnpc[Map, i].X == tempnpc[Map, index].X) && (tempnpc[Map, i].Y - r == tempnpc[Map, index].Y))
                        {
                            PStruct.PlayerAttackNpc(Attacker, i, ntempspell[Map, index, NStempSpell].spellnum, Map);
                        }
                        if ((tempnpc[Map, i].X == tempnpc[Map, index].X) && (tempnpc[Map, i].Y + r == tempnpc[Map, index].Y))
                        {
                            PStruct.PlayerAttackNpc(Attacker, i, ntempspell[Map, index, NStempSpell].spellnum, Map);
                        }


                        //Is line?
                        if (ntempspell[Map, index, NStempSpell].is_line)
                        {
                            if ((tempnpc[Map, i].X - r == tempnpc[Map, index].X) && (tempnpc[Map, i].Y + r == tempnpc[Map, index].Y))
                            {
                                PStruct.PlayerAttackNpc(Attacker, i, ntempspell[Map, index, NStempSpell].spellnum, Map);
                            }
                            if ((tempnpc[Map, i].X + r == tempnpc[Map, index].X) && (tempnpc[Map, i].Y - r == tempnpc[Map, index].Y))
                            {
                                PStruct.PlayerAttackNpc(Attacker, i, ntempspell[Map, index, NStempSpell].spellnum, Map);
                            }
                            if ((tempnpc[Map, i].X + r == tempnpc[Map, index].X) && (tempnpc[Map, i].Y + r == tempnpc[Map, index].Y))
                            {
                                PStruct.PlayerAttackNpc(Attacker, i, ntempspell[Map, index, NStempSpell].spellnum, Map);
                            }
                            if ((tempnpc[Map, i].X - r == tempnpc[Map, index].X) && (tempnpc[Map, i].Y - r == tempnpc[Map, index].Y))
                            {
                                PStruct.PlayerAttackNpc(Attacker, i, ntempspell[Map, index, NStempSpell].spellnum, Map);
                            }
                        }
                    }
                }
            }

            ntempspell[Map, index, NStempSpell].repeats -= 1;

            if (ntempspell[Map, index, NStempSpell].repeats <= 0)
            {
                if (SStruct.skill[ntempspell[Map, index, NStempSpell].spellnum].slow)
                {
                    tempnpc[Map, index].movespeed = npc[Map, index].SpeedMove / 64;
                    SendData.Send_MoveSpeed(2, index, Map);
                }
                ntempspell[Map, index, NStempSpell].attacker = 0;
                ntempspell[Map, index, NStempSpell].timer = 0;
                ntempspell[Map, index, NStempSpell].spellnum = 0;
                ntempspell[Map, index, NStempSpell].repeats = 0;
                ntempspell[Map, index, NStempSpell].active = false;
            }

            ntempspell[Map, index, NStempSpell].timer = Loops.TickCount.ElapsedMilliseconds + SStruct.skill[ntempspell[Map, index, NStempSpell].spellnum].interval;

        }
    }
}
