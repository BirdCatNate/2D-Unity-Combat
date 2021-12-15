using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterDuration : MonoBehaviour
{
    [Tooltip("This GameObject will be destroyed after N seconds.")]
    [SerializeField] float maxDuration = 5;
    float durationSpent = 0;

    void Update()
    {
        durationSpent += Time.deltaTime;
        if(durationSpent >= maxDuration)
        {
            destroyThis();
        }
    }

    // I'm not sure how to centralize specialized destruction rules yet
    void destroyThis()
    {
        Destroy(gameObject);
    }
}