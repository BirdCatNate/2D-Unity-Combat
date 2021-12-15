using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class AccelerateToTarget : MonoBehaviour
{
    [Tooltip("The rate at which the acceleration ramps up")]
    [SerializeField]
    float accelSpeedupRate = 0.01f;
    float currAccel = 0;

    [Tooltip("Accelerate towards this transform. Can be set programatically using 'setTarget(Transform newTarget)'")]
    [SerializeField]
    Transform target;

    Rigidbody2D body;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    // Target MUST be set or this script won't work.
    public void setTarget(Transform newTarget)
    {
        target = newTarget;
    }

    void Update()
    {
        if(target)
        {
            currAccel += accelSpeedupRate * Time.deltaTime;

            Vector2 targDir = target.position - transform.position;
            if(targDir.magnitude > 1) targDir.Normalize();
            
            body.AddForce(targDir * currAccel, ForceMode2D.Force);
        }
    }
}
