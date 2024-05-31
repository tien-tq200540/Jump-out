using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerLife : MonoBehaviour
{
    [SerializeField] private int m_currentHeart;
    [SerializeField] private int m_maxHeart;

    [SerializeField] protected Vector3 m_playerPositionRevive = new Vector3(0f, 0f, 0f);
    [SerializeField] private float intervalReviveTime = 3f;
    private void Start()
    {
        //In default, player have 2 heart
        m_currentHeart = 2;
        m_maxHeart = 5;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacles")) LoseHeart();

        if (collision.gameObject.CompareTag("Heart")) GetHeart();
    }

    public void GetHeart()
    {
        if (m_currentHeart >= m_maxHeart)
        {
            return;
        }

        m_currentHeart += 1;
        Debug.Log("Player gain 1 heart");
    }

    public void LoseHeart()
    {
        m_currentHeart -= 1;
        Debug.Log("Player lose 1 heart");

        if (m_currentHeart <= 0)
        {
            StartCoroutine(PlayerDie());
        } else
        {
            PlayerCtrl.Instance.playerStatus.setPlayerDisappear();
            PlayerCtrl.Instance.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
            setDeActiveModePlayer();
            Invoke("PlayerRevive", intervalReviveTime);
        }
    }

    private void PlayerRevive()
    {

        Debug.Log("Player Respawn");
        PlayerCtrl.Instance.playerStatus.setPlayerAppear();
        PlayerCtrl.Instance.transform.SetPositionAndRotation(m_playerPositionRevive, Quaternion.identity);
        PlayerCtrl.Instance.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        setActiveModePlayer();
    }

    IEnumerator PlayerDie()
    {
        Debug.Log("Player Die");

        PlayerCtrl.Instance.playerStatus.setPlayerDeath();
        PlayerCtrl.Instance.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
        setDeActiveModePlayer();
        yield return new WaitForSeconds(2f);
        GameManager.Instance.PauseGame();
    }



    private void setDeActiveModePlayer()
    {
        PlayerCtrl.Instance.playerMovement.gameObject.SetActive(false);
    }
    private void setActiveModePlayer()
    {
        PlayerCtrl.Instance.playerMovement.gameObject.SetActive(true);
    }
}
