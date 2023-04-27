using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLife : MonoBehaviour
{
    [SerializeField] private int m_currentHeart;
    [SerializeField] private int m_maxHeart;
    private void Start()
    {
        //In default, player have 2 heart
        m_currentHeart = 2;
        m_maxHeart = 5;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("DeathZone"))
        {
            this.PlayerLoseHeart();
        }

        if (collision.gameObject.CompareTag("Heart"))
        {
            this.PlayerGainHeart();
        }
    }

    private void PlayerGainHeart()
    {
        if (m_currentHeart >= m_maxHeart)
        {
            return;
        }

        m_currentHeart += 1;
        Debug.Log("Player gain 1 heart");
    }

    private void PlayerLoseHeart()
    {
        m_currentHeart -= 1;
        Debug.Log("Player lose 1 heart");

        if (m_currentHeart <= 0)
        {
            PlayerDie();
        }
    }

    private void PlayerDie()
    {
        Debug.Log("Player Die");
    }
}
