using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleSystem : MonoBehaviour
{
    [SerializeField]
    private bool isBattleActive;

    [SerializeField]
    [Range(0, 5)]
    private int sec_between_turns;

    Character leftCornerCharacter;
    Character rightCornerCharacter;
    ConsoleTextLogger gameConsole;

    private bool playerTurn = true;

    void Start()
    {
        leftCornerCharacter = new Character("");
        rightCornerCharacter = new Character("");
        gameConsole = FindObjectOfType<ConsoleTextLogger>();
        StartCoroutine(BattleProcess());
    }

    private IEnumerator BattleProcess() 
    {
        while (isBattleActive)
        {
            yield return new WaitForSeconds(sec_between_turns);
            if (leftCornerCharacter == null || rightCornerCharacter == null)
            {
                if (leftCornerCharacter == null)
                    gameConsole.AddText("There is no leftCharacter", WrapTags.Neutral);
                if (rightCornerCharacter == null)
                    gameConsole.AddText("There is no rigthChrarcter", WrapTags.Neutral);
            }
            else
            {
                //int attack;
                if (playerTurn)
                {
                    
                }
            }
        }

    } 
}
