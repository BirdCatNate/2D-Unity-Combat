using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [Tooltip("Set the amount of time a character is invulnerable after being hit. Can be set to 0 to disable this mechanic")]
    [SerializeField] 
    float invulnTime = 0.5f;
    float invulnCD = 0f;

    [Tooltip("The maximum health of the character.")]
    [SerializeField] 
    float maxHealth = 100;
    float currHealth;

    // Optional flags usable by outer scripts, such as animators
    bool hurtFlag = false;
    bool deathFlag = false;

#region private

    void Start()
    {
        currHealth = maxHealth;
    }

    void Update()
    {
        if(invulnCD > 0f) 
            invulnCD -= Time.deltaTime;
    }

    // Called by "tryTakeDamage", in the setters section
    void takeDamage(float damage)
    {
        hurtFlag = true;
        currHealth -= damage;

        if(currHealth <= 0)
        {
            deathFlag = true;
        }
    }

    // Called by "tryReceiveHeal", in the setters section
    void receiveHeal(float heal)
    {
        currHealth += heal;
        if(currHealth > maxHealth) 
            currHealth = maxHealth;
    }

#endregion

#region setters

    // This is the most important function! It's called by ProjectileCollision and DamagePop!
    public void tryTakeDamage(float damage)
    {
        if(invulnCD <= 0f)
        {
            invulnCD = invulnTime;
            takeDamage(damage);
        }
    }

    public void tryReceiveHeal(float heal)
    {
        if(!deathFlag)
        {
            receiveHeal(heal);
        }
    }

    public void tryIncreaseMaxHealth(float healthIncrease)
    {
        maxHealth += healthIncrease;
        tryReceiveHeal(healthIncrease);
    }

#endregion

#region getters

    public float getHealth()
    {
        return currHealth;
    }

    public float getHealthPercent()
    {
        return currHealth / maxHealth;
    }

    public bool getHurtFlag()
    {
        return hurtFlag;
    }

    public bool getClearHurtFlag()
    {
        if(hurtFlag)
        {
            hurtFlag = false;
            return true;
        }
        return false;
    }

    public bool getDeathFlag()
    {
        return deathFlag;
    }

#endregion

}
