using System;
using System.Reflection;

namespace FORJERUM
{
    class QuestRelations
    {
        //*********************************************************************************************
        // GetActualPlayerQuestPerGiver
        // Retorna o número de quests que o jogador tem por npc
        //*********************************************************************************************
        public static int GetActualPlayerQuestPerGiver(int index, int questgiver)
        {
            //EXTEND
            if (Extensions.ExtensionApp.ExtendMyApp
                (MethodBase.GetCurrentMethod().Name, index, questgiver) != null)
            {
                return Convert.ToInt32(Extensions.ExtensionApp.ExtendMyApp
                (MethodBase.GetCurrentMethod().Name, index, questgiver));
            }

            //CÓDIGO
            int quest = 1;

            for (int q = 1; q < Globals.MaxQuestPerGiver; q++)
            {
                if (PStruct.queststatus[index, questgiver, q].status == 2)
                {
                    quest += 1;
                }
            }

            return quest;
        }
        //*********************************************************************************************
        // GetPlayerQuestGiversCount
        // Número de npc's que deram quest ao jogador
        //*********************************************************************************************
        public static int GetPlayerQuestGiversCount(int index)
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

            for (int g = 1; g <= Globals.MaxQuestGivers; g++)
            {
                if (PStruct.queststatus[index, g, 1].status != 0)
                {
                    count += 1;
                }
            }

            return count;
        }
        //*********************************************************************************************
        // GetPlayerQuestsCount
        // Número total de quests
        //*********************************************************************************************
        public static int GetPlayerQuestsCount(int index)
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

            for (int g = 1; g < Globals.MaxQuestGivers; g++)
            {
                for (int q = 1; q < Globals.MaxQuestPerGiver; q++)
                {
                    if (PStruct.queststatus[index, g, q].status != 0)
                    {
                        count += 1;
                    }
                }
            }

            return count;
        }
        //*********************************************************************************************
        // IsQuestGiverRepeatable
        // Retorna se a missão pode ser repetida
        //*********************************************************************************************
        public static bool IsQuestGiverRepeatable(int questgiver)
        {
            //EXTEND
            if (Extensions.ExtensionApp.ExtendMyApp
                (MethodBase.GetCurrentMethod().Name, questgiver) != null)
            {
                return Convert.ToBoolean(Extensions.ExtensionApp.ExtendMyApp
                (MethodBase.GetCurrentMethod().Name, questgiver));
            }

            //CÓDIGO
            if (questgiver == 7)
            {
                return true;
            }
            return false;
        }
    }
}
