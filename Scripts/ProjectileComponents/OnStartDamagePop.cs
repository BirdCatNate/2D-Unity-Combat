using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    DamagePop applies damage within a radius once, when the Start command is used
    This is usable for melee attacks and explosions

    **IMPORTANT**
     THIS SCRIPT ONLY WORKS IF YOU USE "Health.cs" FOR YOUR HEALTH SYSTEM
*/
public class OnStartDamagePop : MonoBehaviour
{
    [Tooltip("How much damage to deal? I've used a float, but you can use this for integer systems too")]
    [SerializeField] 
    float damage = 100;

    [Tooltip("How big is the radius of the damage? This can be visualized with gizmos")]
    [SerializeField] 
    float popRadius = 1;

    [Tooltip("Which physics layers can be hit by the damage pop? Use this to determine which characters are damaged.")]
    [SerializeField] 
    LayerMask layers = Physics2D.AllLayers;

    // Call DamagePop from other triggers to modify the functionality.
    void Start()
    {
        DamagePop();
    }

    // Core functionality
    void DamagePop()
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, popRadius, layers);
        foreach(Collider2D hit in hits)
        {
            Health hitHealth = hit.gameObject.GetComponent<Health>();
            if( hitHealth )
            {
                hitHealth.tryTakeDamage(damage);
            }
        }
    }

    // Draw the radius in inspector
    void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, popRadius);
    }
}
