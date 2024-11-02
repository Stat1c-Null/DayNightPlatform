using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleSpawner : MonoBehaviour
{
    public GameObject prefab;
    public bool isWorldSpace;
    public void SpawnParticle()
    {
        if (prefab == null) return;
        print("spawning particle");
        var gameobject = Instantiate(prefab, transform.position, transform.rotation, isWorldSpace ? null : transform);
        // so it flips relative
        gameobject.transform.localScale = transform.localScale.normalized;
    }
}
