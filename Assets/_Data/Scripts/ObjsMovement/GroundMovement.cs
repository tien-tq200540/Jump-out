using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundMovement : MonoBehaviour
{
    [SerializeField] private float speed = 1f;

    private void Update()
    {
        this.Moving();
    }

    protected virtual void Moving()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime);
    }
}
