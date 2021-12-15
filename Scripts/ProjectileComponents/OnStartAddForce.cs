using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class OnStartAddForce : MonoBehaviour
{
    [Tooltip("Force to be applied to this object's rigidbody when it is created")]
    [SerializeField] 
    float force = 10f;

    [Tooltip("The direction for the force to be applied. This is relative to the local rotation, not the global rotation")]
    [SerializeField] 
    Vector2 movementDirection = Vector2.up;

    [Tooltip("The ForceMode used. Check the official unity documentation for more information")]
    [SerializeField] 
    ForceMode2D forceMode = ForceMode2D.Impulse;

    void Start()
    {
        movementDirection = movementDirection.normalized;
        AddForce();
    }

    void AddForce()
    {
        Rigidbody2D body = GetComponent<Rigidbody2D>();
        body.AddForce(transform.rotation * movementDirection * force, forceMode);
    }
}