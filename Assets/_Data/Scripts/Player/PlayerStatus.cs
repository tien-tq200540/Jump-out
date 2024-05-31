using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    private float m_inputMovement;

    private Animator m_Anim;

    private enum State
    {
        Idle, Running, Falling, Death
    }

    [SerializeField] private State m_State;

    private void Start()
    {
        m_Anim = GetComponent<Animator>();
    }

    private void Update()
    {
        m_inputMovement = PlayerCtrl.Instance.playerMovement.getInputHorizontal();

        OnUpdateState();

        OnUpdateAnimation();
    }

    public void setPlayerAppear()
    {
        m_Anim.SetTrigger("Appear");
    }

    public void setPlayerDisappear()
    {
        m_Anim.SetTrigger("Disappear");
    }
    
    public void setPlayerDeath()
    {
        m_Anim.SetTrigger("isDeath");
        m_State = State.Death;
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
            if (m_State != State.Death) m_State = State.Idle;
        }

        if (PlayerCtrl.Instance.playerMovement.GetRigidbody2D().velocity.y < -0.01f)
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
        }
    }
}
