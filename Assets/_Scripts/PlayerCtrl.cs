using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{
    static public PlayerCtrl instance;

    public PlayerMovement PlayerMovement;
    public PlayerStatus PlayerStatus;
    public PlayerLife PlayerLife;

    private void Awake()
    {
        PlayerCtrl.instance = this;
    }

    void Start()
    {
        PlayerMovement = GetComponent<PlayerMovement>();
        PlayerStatus = GetComponent<PlayerStatus>();
        PlayerLife = GetComponent<PlayerLife>();
    }
}
