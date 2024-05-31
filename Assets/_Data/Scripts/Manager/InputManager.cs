using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : TienMonoBehaviour
{
    private static InputManager instance;
    public static InputManager Instance { get => instance; }

    [SerializeField] private float inputHorizontal;

    protected override void Awake()
    {
        base.Awake();
        this.LoadInputManager();
    }

    protected virtual void LoadInputManager()
    {
        if (InputManager.instance != null) Debug.LogError("Only 1 InputManager allow");
        InputManager.instance = this;
    }

    private void Update()
    {
        this.inputHorizontal = Input.GetAxis("Horizontal");
    }

    public virtual float GetInputHorizontal()
    {
        return this.inputHorizontal;
    }
}
