using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float m_Speed;

    private Rigidbody2D m_Rigidbody;

    private float m_inputHorizontal;

    private void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        m_inputHorizontal = Input.GetAxisRaw("Horizontal");
    }

    private void FixedUpdate()
    {
        m_Rigidbody.velocity = new Vector2(m_inputHorizontal * m_Speed, m_Rigidbody.velocity.y);    
    }

    public float getInputHorizontal()
    {
        return this.m_inputHorizontal;
    }

    public Rigidbody2D getRigidbody()
    {
        return this.m_Rigidbody;
    }
}