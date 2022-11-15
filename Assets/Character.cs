using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    private int hp;
    private int minDamage;
    private int maxDamage;

    public Character()
    {
        this.hp = 80;
        this.minDamage = 1;
        this.maxDamage = 2;
    }

    public int MakeAnAttack()
    {
        return Random.Range(minDamage, maxDamage);
    }

    public int GetAHit(int damage)
    {
        this.hp -= damage;

        if (this.hp <= 0)
            return 1;
        else 
            return 0;
    }
}
