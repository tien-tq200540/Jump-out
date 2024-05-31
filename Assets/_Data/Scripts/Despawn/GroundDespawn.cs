using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundDespawn : DespawnByPosition
{
    protected override void DespawnObject()
    {
        GroundSpawner.Instance.DeSpawn(transform.parent);
    }
}
