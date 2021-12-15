using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
    ProjectileCollision includes 3 optional functionalities:
        1. Dealing damage on collision with an object with a Health component
        2. Despawning after a certain number of wall hits (AKA BOUNCES)
        3. Despawning after a certain number of enemy hits (AKA PIERCES)

    **IMPORTANT**
     THIS SCRIPT ONLY WORKS IF YOU USE "Health.cs" FOR YOUR HEALTH SYSTEM
*/

[RequireComponent(typeof(Collider2D))]
public class Projectile : MonoBehaviour
{
    [Tooltip("This projectile will deal N damage on collision. Setup physics collision layers to disable friendly fire")]
    [SerializeField] 
    float damage = 25;

    [Tooltip("This projectile will be destroyed after bouncing N times. Set to -1 for infinite bounces")]
    [SerializeField] 
    int maxBounces = 0;
    int remainingBounces;
    
    [Tooltip("This projectile will be destroyed after dealingn damage N times. Set to -1 for infinite hits")]
    [SerializeField] 
    int maxPierces = 0;
    int remainingPierces;

    void Start()
    {
        remainingBounces = maxBounces;
        remainingPierces = maxPierces;
    }

    /*
        Enabling the "trigger" flag on this object's Collider2D will disable bouncing and physics-based knockback.
        Whether the trigger flag is on or off, the OnEnter2D function is called by one of the following two functions
    */
    void OnTriggerEnter2D  (Collider2D  col) { OnEnter2D( col.gameObject); }
    void OnCollisionEnter2D(Collision2D col) { OnEnter2D( col.gameObject); }

    void OnEnter2D(GameObject other)
    {
        // If other has a Health component, deal damage
        Health hitHealth = other.GetComponent<Health>();
        if( hitHealth )
        {
            if( damage != 0)
                hitHealth.tryTakeDamage(damage);

            decrementPierce();
        }

        // Otherwise, assume other is a wall
        else 
        {
            decrementBounce();
        }
    }

    void decrementPierce()
    {
        if(maxPierces < 0) return;
        if(remainingPierces == 0)
            destroyThis();
        
        remainingPierces -= 1;
    }

    void decrementBounce()
    {
        if(maxBounces < 0) return;
        if(remainingBounces == 0)
            destroyThis();
        
        remainingBounces -= 1;
    }

    // I'm not sure how to centralize specialized destruction rules yet
    void destroyThis()
    {
        Destroy(gameObject);
    }
}
