using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleSystem : MonoBehaviour
{
    [SerializeField]
    private bool isBattleActive = true;
    [SerializeField]
    [Range(0, 5)]
    private int sec_between_turns;

    private int turnCount;
    private bool playerTurn = true;
    public Dictionary<bool, Character> characterThatTurns = new Dictionary<bool, Character>();
    public Dictionary<bool, WrapTags> characterTag = new Dictionary<bool, WrapTags>();

    ConsoleTextLogger gameConsole;
    CharacterCreator characterCreator;

    void Start()
    {
        characterCreator = FindObjectOfType<CharacterCreator>();

        characterThatTurns.Add(playerTurn, null);
        characterTag.Add(playerTurn, WrapTags.Left);

        characterThatTurns.Add(!playerTurn, null);
        characterTag.Add(!playerTurn, WrapTags.Right);

        gameConsole = FindObjectOfType<ConsoleTextLogger>();

        StartCoroutine(BattleProcess());
    }

    private IEnumerator BattleProcess() 
    {
        while (true)
        {
            while (isBattleActive)
            {
                yield return new WaitForSeconds(sec_between_turns);
                if (characterThatTurns[playerTurn] == null || characterThatTurns[!playerTurn] == null)
                {
                    //create characters if atleast one is dead
                    characterThatTurns[!playerTurn] = characterCreator.CreateCharacter();
                    characterThatTurns[playerTurn] = characterCreator.CreateCharacter();
                }

                gameConsole.AddText("Round " + turnCount.ToString(), WrapTags.Neutral);
                gameConsole.NextLine();

                int numOfDamage = StageOfAttack();

                StageOfDefense(numOfDamage);

                if (characterThatTurns[!playerTurn].hp <= 0)
                {
                    StageOfDeath();
                }

                playerTurn = !playerTurn;
                turnCount++;
            }
            yield return true;
        }
    }

    int StageOfAttack() 
    {
        int numOfDamage = characterThatTurns[playerTurn].MakeAnAttack();
        string lineText = characterThatTurns[playerTurn].nickName + " hits on " + numOfDamage.ToString() + " damage";
        gameConsole.AddText(lineText, characterTag[playerTurn]);
        gameConsole.NextLine();

        return numOfDamage;
    }

    void StageOfDefense(int numOfDamage)
    {
        characterThatTurns[!playerTurn].GetAHit(numOfDamage);
        string lineText = characterThatTurns[!playerTurn].nickName + " now has " + characterThatTurns[!playerTurn].hp + " hp";
        gameConsole.AddText(lineText, characterTag[playerTurn]);
        gameConsole.NextLine();
    }

    void StageOfDeath() 
    {
        string lineText = characterThatTurns[!playerTurn].nickName + " is dead now. Removing the corp.";
        gameConsole.AddText(lineText, WrapTags.Neutral);
        gameConsole.NextLine();

        characterThatTurns[!playerTurn] = null;
        characterThatTurns[playerTurn] = null;
    }
}
