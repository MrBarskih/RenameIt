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

    void Start()
    {
        StartCoroutine(BattleProcess());
        leftCornerCharacter = new Character();
        rightCornerCharacter = new Character();
    }

    private IEnumerator BattleProcess() 
    {
        while (isBattleActive)
        {
            yield return new WaitForSeconds(sec_between_turns);
            if (leftCornerCharacter == null || rightCornerCharacter == null)
            { 
                //class for console text outpus
            }
        }

    } 
}
