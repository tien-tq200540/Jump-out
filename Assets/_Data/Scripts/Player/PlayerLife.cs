using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerLife : MonoBehaviour
{
    [SerializeField] private int m_currentHeart;
    [SerializeField] private int m_maxHeart;
    public int Heart { get => m_currentHeart;}

    [SerializeField] protected Vector3 m_playerPositionRevive = new Vector3(0f, 0f, 0f);
    [SerializeField] private float intervalReviveTime = 3f;
    private void Start()
    {
        //In default, player have 2 heart
        m_currentHeart = 2;
        m_maxHeart = 5;
    }

    public void PlayerGetHeart()
    {
        if (m_currentHeart >= m_maxHeart) return;

        m_currentHeart += 1;
        Debug.Log("Player gain 1 heart");
    }

    public void PlayerLoseHeart()
    {
        m_currentHeart -= 1;
        Debug.Log("Player lose 1 heart");

        if (m_currentHeart <= 0)
        {
            StartCoroutine(PlayerDie());
        } else
        {
            PlayerCtrl.Instance.playerStatus.SetPlayerDisappear();
            PlayerCtrl.Instance.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
            SetInActivePlayerMovement();
            Invoke("PlayerRevive", intervalReviveTime);
        }
    }

    private void PlayerRevive()
    {

        Debug.Log("Player Respawn");
        PlayerCtrl.Instance.playerStatus.SetPlayerAppear();
        PlayerCtrl.Instance.transform.SetPositionAndRotation(m_playerPositionRevive, Quaternion.identity);
        PlayerCtrl.Instance.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        SetActivePlayerMovement();
    }

    IEnumerator PlayerDie()
    {
        Debug.Log("Player Die");

        PlayerCtrl.Instance.playerStatus.SetPlayerDeath();
        PlayerCtrl.Instance.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
        SetInActivePlayerMovement();
        yield return new WaitForSeconds(2f);
        GameManager.Instance.PauseGame();
    }

    /* Change PlayerMovement from active to inactive:
     - Use when player is not dead but waiting to be revived
     - PlayerMovement cannot use velocity for static Rigidbody2D
    */
    private void SetInActivePlayerMovement()
    {
        PlayerCtrl.Instance.playerMovement.gameObject.SetActive(false);
    }
    private void SetActivePlayerMovement()
    {
        PlayerCtrl.Instance.playerMovement.gameObject.SetActive(true);
    }
}
