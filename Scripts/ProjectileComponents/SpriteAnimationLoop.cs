using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SpriteAnimationLoop : MonoBehaviour
{
    [SerializeField] 
    Sprite[] spriteFrames;
    int currSpriteFrame = 0;

    [SerializeField] 
    float timeBetweenFrames = 0.15f;
    float timeSinceLastFrameChange;

    [Tooltip("Amount of times the entire list in spriteframes is repeated until object destruction. Set to -1 for infinite loops")]
    [SerializeField] 
    int loopsUntilDestruction = -1;
    
    SpriteRenderer spriteDisplay;

    void Start()
    {
        spriteDisplay = GetComponent<SpriteRenderer>();
        spriteDisplay.sprite = spriteFrames[ currSpriteFrame ];
    }
 
    void Update()
    {
        timeSinceLastFrameChange += Time.deltaTime;
        if( timeSinceLastFrameChange > timeBetweenFrames )
        {
            NextSpriteFrame();
        }
    }

    //
    void NextSpriteFrame()
    {
        currSpriteFrame++;
        if(currSpriteFrame >= spriteFrames.Length) 
        {
            if( checkDestroyThis() )
            {
                destroyThis();
                return;
            }
            currSpriteFrame = 0;
        }
        timeSinceLastFrameChange = 0;
        spriteDisplay.sprite = spriteFrames[ currSpriteFrame ];
    }

    bool checkDestroyThis()
    {
        if( loopsUntilDestruction == -1 ) return false;
        if( loopsUntilDestruction == 0 ) return true;

        loopsUntilDestruction -= 1;
        return false;
    }

    // I'm not sure how to centralize specialized destruction rules yet
    void destroyThis()
    {
        Destroy(gameObject);
    }
}
