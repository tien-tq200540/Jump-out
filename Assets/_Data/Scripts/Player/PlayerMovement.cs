using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : TienMonoBehaviour
{
    [SerializeField] private float m_Speed;

    private Rigidbody2D m_Rigidbody;
    private float m_inputHorizontal;

    private void Start()
    {
        m_Rigidbody = PlayerCtrl.Instance.rigid2D;
    }

    private void Update()
    {
        m_inputHorizontal = InputManager.Instance.GetInputHorizontal();
    }

    private void FixedUpdate()
    {
        m_Rigidbody.velocity = new Vector2(m_inputHorizontal * m_Speed, m_Rigidbody.velocity.y);
    }

    public Rigidbody2D GetRigidbody2D() { return m_Rigidbody; }

    public float getInputHorizontal()
    {
        return this.m_inputHorizontal;
    }
}