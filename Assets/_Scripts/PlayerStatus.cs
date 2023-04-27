using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    private float m_inputMovement;

    private Animator m_Anim;

    private enum State
    {
        Idle, Running, Falling, Appear, Disappear, Death
    }

    [SerializeField] private State m_State;

    private void Start()
    {
        m_Anim = GetComponent<Animator>();
    }

    private void Update()
    {
        m_inputMovement = PlayerCtrl.instance.PlayerMovement.getInputHorizontal();

        OnUpdateState();

        OnUpdateAnimation();
    }

    public void setState(int state)
    {
        this.m_State = (State)state;
    }

    private void OnUpdateState()
    {
        if (m_inputMovement > 0f)
        {
            m_State = State.Running;
            this.transform.eulerAngles = new Vector3(0f, 0f, 0f);
        } 
        else if (m_inputMovement < 0f)
        {
            m_State = State.Running;
            this.transform.eulerAngles = new Vector3(0f, 180f, 0f);
        } 
        else
        {
            m_State = State.Idle;
        }

        if (PlayerCtrl.instance.PlayerMovement.getRigidbody().velocity.y < -0.01f)
        {
            m_State = State.Falling;
        } else
        {
            return;
        }
    }

    private void OnUpdateAnimation()
    {
        switch (m_State)
        {
            case State.Idle:
                {
                    m_Anim.SetInteger("State", (int)State.Idle);
                    break;
                }
            case State.Running:
                {
                    m_Anim.SetInteger("State", (int)State.Running);
                    break;
                }
            case State.Falling:
                {
                    m_Anim.SetInteger("State", (int)State.Falling);
                    break;
                }
            case State.Appear:
                {
                    m_Anim.SetInteger("State", (int)State.Appear);
                    break;
                }
            case State.Disappear:
                {
                    m_Anim.SetInteger("State", (int)State.Disappear);
                    break;
                }
            case State.Death:
                {
                    m_Anim.SetInteger("State", (int)State.Death);
                    break;
                }
        }
    }
}
