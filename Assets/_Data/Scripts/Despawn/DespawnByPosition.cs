using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DespawnByPosition : Despawn
{
    [SerializeField] protected Transform groundLimit;
    protected override void LoadComponents()
    {
        base.LoadComponents();

        this.LoadGroundLimit();
    }

    protected virtual void LoadGroundLimit()
    {
        this.groundLimit = GameObject.Find("GroundLimit").transform;
        Debug.Log(transform + ": Load GroundLimit", gameObject);
    }

    protected override bool CanDespawn()
    {
        if (this.transform.parent.position.y < this.groundLimit.position.y) return false;
        return true;
    }
}
