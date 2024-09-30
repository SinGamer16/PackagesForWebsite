using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

[ExecuteInEditMode, RequireComponent(typeof(SphereCollider))]
public class SpawnPointScript : MonoBehaviour
{
    public bool SpawnUsed;

    [SerializeField] private float spawnRadius;

    private void Awake()
    {
        GetComponent<SphereCollider>().isTrigger = true;
    }

    void Update()
    {
        GetComponent<SphereCollider>().radius = spawnRadius;
    }

    private void OnTriggerEnter(Collider other)
    {
        SpawnUsed = true;
    }
    private void OnTriggerExit(Collider other)
    {
        SpawnUsed = false;
    }
}
