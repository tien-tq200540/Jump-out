using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainMovement : MonoBehaviour
{
    [SerializeField] private float m_TerrainSpeed;
    
    private const float m_minX_GridTerrain = -1f;
    private const float m_maxX_GridTerrain = 4f;
    
    [SerializeField] private float m_Y_TerrainSpawn = -10f;

    private float newX;

    private Rigidbody2D m_Rigidbody;

    private void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        m_Rigidbody.velocity = new Vector2(m_Rigidbody.velocity.x, m_TerrainSpeed * 1f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("TerrainLooper"))
        {
            newX = Random.Range(m_minX_GridTerrain, m_maxX_GridTerrain);
            this.transform.position = new Vector3(newX, m_Y_TerrainSpawn, 0f);
        }
    }
}
