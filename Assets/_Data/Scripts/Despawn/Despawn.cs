using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Despawn : TienMonoBehaviour
{
    private void Update()
    {
        this.Despawning();
    }

    protected virtual void Despawning()
    {
        if (!CanDespawn()) return;
        else this.DespawnObject();
    }

    protected abstract bool CanDespawn();

    protected virtual void DespawnObject()
    {

    }
}
