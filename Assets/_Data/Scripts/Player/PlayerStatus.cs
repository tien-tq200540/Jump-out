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

        UpdateState();
        UpdateAnimation();
    }

    public void SetPlayerAppear()
    {
        m_Anim.SetTrigger("Appear");
    }

    public void SetPlayerDisappear()
    {
        m_Anim.SetTrigger("Disappear");
    }
    
    public void SetPlayerDeath()
    {
        m_Anim.SetTrigger("isDeath");
        m_State = State.Death;
    }

    private void UpdateState()
    {
        if (m_State != State.Death)
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

            if (PlayerCtrl.Instance.playerMovement.GetRigidbody2D().velocity.y < -0.01f)
            {
                m_State = State.Falling;
            }
            else
            {
                return;
            }
        } 
    }

    private void UpdateAnimation()
    {
        m_Anim.SetInteger("State", (int)m_State);
    }
}
