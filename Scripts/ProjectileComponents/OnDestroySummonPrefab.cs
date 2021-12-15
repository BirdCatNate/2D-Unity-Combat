using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// A simple trigger function
// Spawn any prefab when this gameobject is destroyed.
public class OnDestroySummonPrefab : MonoBehaviour
{
    [Tooltip("Summon the following prefab at this objects position and orientation when this object is destroyed")]
    [SerializeField] GameObject prefabToSummon;

    void OnDestroy()
    {
        Instantiate(prefabToSummon, transform.position, transform.rotation);
    }
}
