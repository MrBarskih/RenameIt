using System;
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

    private int turnCount;
    private bool playerTurn = true;
    public Dictionary<bool, Character> characterThatTurns = new Dictionary<bool, Character>();
    public Dictionary<bool, WrapTags> characterTag = new Dictionary<bool, WrapTags>();

    Character leftCornerCharacter;
    Character rightCornerCharacter;
    ConsoleTextLogger gameConsole;
    CharacterCreator characterCreator;

    void Start()
    {
        characterCreator = FindObjectOfType<CharacterCreator>();

        leftCornerCharacter = characterCreator.CreateCharacter();
        characterThatTurns.Add(playerTurn, leftCornerCharacter);
        characterTag.Add(playerTurn, WrapTags.Left);

        rightCornerCharacter = characterCreator.CreateCharacter();
        characterThatTurns.Add(!playerTurn, rightCornerCharacter);
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
                if (leftCornerCharacter == null || rightCornerCharacter == null)
                {
                    if (leftCornerCharacter == null)
                        gameConsole.AddText("There is no leftCharacter", WrapTags.Neutral); 
                    if (rightCornerCharacter == null)
                        gameConsole.AddText("There is no rigthChrarcter", WrapTags.Neutral);
                }
                else
                {
                    gameConsole.AddText("Round " + turnCount.ToString(), WrapTags.Neutral);
                    gameConsole.NextLine();

                    int attack = characterThatTurns[playerTurn].MakeAnAttack();
                    string lineText = characterThatTurns[playerTurn].nickName + " hits on " + attack.ToString() + " damage";
                    gameConsole.AddText(lineText, characterTag[playerTurn]);
                    gameConsole.NextLine();

                    characterThatTurns[!playerTurn].GetAHit(attack);
                    lineText = characterThatTurns[!playerTurn].nickName + " now has " + characterThatTurns[!playerTurn].hp + " hp";
                    gameConsole.AddText(lineText, characterTag[playerTurn]);
                    gameConsole.NextLine();

                    if (characterThatTurns[!playerTurn].hp <= 0)
                    {
                        lineText = characterThatTurns[!playerTurn].nickName + " is dead now. Removing the corp.";
                        gameConsole.AddText(lineText, WrapTags.Neutral);
                        gameConsole.NextLine();
                        characterThatTurns[!playerTurn] = null;

                        characterThatTurns[!playerTurn] = characterCreator.CreateCharacter();
                        lineText = "Greatings to our new pretender " + characterThatTurns[!playerTurn].nickName;
                        gameConsole.AddText(lineText, WrapTags.Neutral);
                        gameConsole.NextLine();
                    }

                    playerTurn = !playerTurn;
                    turnCount++;
                }
            }
            yield return true;
        }
    } 
}
