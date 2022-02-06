using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private string sceneToLoad = "Amy";
    [SerializeField] private float transtionTime = 1f;
    [SerializeField] private Animator FadyFade;
    public void PlayGame()
    {
        StartCoroutine(LoadScene());
    }

    public void QuitGame()
    {
        StartCoroutine(Quiter());
    }

    IEnumerator LoadScene()
    {
        FadyFade.SetTrigger("StartFade");
        yield return new WaitForSeconds(transtionTime);
        SceneManager.LoadScene(sceneToLoad);

    }

    IEnumerator Quiter()
    {
        FadyFade.SetTrigger("StartFade");
        yield return new WaitForSeconds(transtionTime);
        Application.Quit();
    }
}
