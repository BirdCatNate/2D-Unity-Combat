using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    [Tooltip("A reference to this character's Health script. Used to check the current health value.")]
    [SerializeField] 
    Health characterHealth;

    [Tooltip("A reference to the visual bar which depletes as this character takes damage. The bar should be on this gameObject or be one of it's children")]
    [SerializeField] 
    Transform fill;

    [Tooltip("Should the entire healthbar be hidden if the character dies?")]
    [SerializeField]
    bool hideBarOnDeath;

    // Internal variables
    float currPercent = 1f;
    float originalScale;

    void Start()
    {
        originalScale = fill.localScale.x;
    }

    void Update()
    {
        if(hideBarOnDeath && characterHealth.getDeathFlag())
        {
            gameObject.SetActive(false);
            return;
        }

        float newPercent = characterHealth.getHealthPercent();
        if(currPercent != newPercent)
        {
            UpdateBar( newPercent );
        }
    }

    void UpdateBar(float percentage)
    {
        // Redundancy
        if(percentage > 1f) 
            percentage = 1f;
        
        currPercent = percentage;

        var temp = fill.localScale;
        fill.localScale = new Vector3(percentage*originalScale, temp.y, temp.z);
        fill.localPosition = new Vector2( (percentage - 1)*originalScale / 2 , 0);
    }
}
