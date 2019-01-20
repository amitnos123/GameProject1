using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float HP = 70.0f;
    public float minHP = 0.0f;
    public float maxHP = 100.0f;
    public bool dead = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void changeHP(float addHP) {
        if (!dead) {
            HP += addHP;
            if (HP <= minHP)
            {
                HP = minHP;
            }
            else if (HP >= maxHP)
            {
                HP = maxHP;
            }
        }
    }

    public void damag(float HPDamage){
        if (!dead)
        {
            HP -= HPDamage;
            if (HP <= minHP)
            {
                HP = minHP;
            }
        }
    }

    public void heal(float HPHeal){
        if (!dead)
        {
            HP += HPHeal;
            if (HP >= maxHP)
            {
                HP = maxHP;
            }
        }
    }
}
