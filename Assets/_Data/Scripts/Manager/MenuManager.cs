using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : TienMonoBehaviour
{
    private Animator transitionAnim;
    [SerializeField] private float transitionTime = 1f;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadTransAnim();
    }

    public void PlayButton()
    {
        StartCoroutine(LoadGameScene());
    }

    protected virtual void LoadTransAnim()
    {
        if (transitionAnim != null) return;
        transitionAnim = GameObject.Find("SceneTransition").GetComponent<Animator>();
        Debug.Log(transform.name + ": Load Transition animation", gameObject);
    }

    public void QuitButton()
    {
        Application.Quit();
    }

    IEnumerator LoadGameScene()
    {
        transitionAnim.SetTrigger("End");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
        DontDestroyOnLoad(gameObject);
        transitionAnim.SetTrigger("Start");
    }
}
