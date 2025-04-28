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
        float curSpeed = speed * GameManager.Instance.gameSpeed;
        transform.Translate(Vector3.up * curSpeed * Time.deltaTime);
    }
}
