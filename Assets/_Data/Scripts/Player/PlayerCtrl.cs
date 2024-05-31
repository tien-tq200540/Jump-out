using UnityEngine;

public class PlayerCtrl : TienMonoBehaviour
{
    private static PlayerCtrl instance;
    public static PlayerCtrl Instance { get => instance; }

    public Rigidbody2D rigid2D;
    public PlayerMovement playerMovement;
    public PlayerLife playerLife;
    public PlayerStatus playerStatus;

    protected override void Awake()
    {
        if (PlayerCtrl.Instance != null) Debug.LogError("Only 1 PlayerCtrl allow");
        instance = this;

        base.Awake();
    }

    protected override void LoadComponents()
    {
        this.LoadPlayerMovement();
        this.LoadPlayerRigidbody2D();
        this.LoadPlayerLife();
        this.LoadPlayerStatus();
    }

    protected virtual void LoadPlayerMovement()
    {
        if (this.playerMovement != null) return;
        this.playerMovement = transform.Find("PlayerMovement").GetComponent<PlayerMovement>();
        Debug.Log(transform.name + ": Load PlayerMovement", gameObject);
    }

    protected virtual void LoadPlayerRigidbody2D()
    {
        if (this.rigid2D != null) return;
        this.rigid2D = GetComponent<Rigidbody2D>();
        Debug.Log(transform.name + ": Load PlayerRigid2D", gameObject);
    }
    protected virtual void LoadPlayerLife()
    {
        if (this.playerLife != null) return;
        this.playerLife = transform.Find("PlayerLife").GetComponent<PlayerLife>();
        Debug.Log(transform.name + ": Load PlayerLife", gameObject);
    }

    protected virtual void LoadPlayerStatus()
    {
        if (this.playerStatus != null) return;
        this.playerStatus = transform.Find("PlayerModel").GetComponent<PlayerStatus>();
        Debug.Log(transform.name + ": Load PlayerStatus", gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacles")) playerLife.LoseHeart();

        if (collision.gameObject.CompareTag("Heart")) playerLife.GetHeart();
    }
}
