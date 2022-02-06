using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private string sceneToLoad = "Amy";
    [SerializeField] private float transtionTime = 1f;
    public void PlayGame()
    {
        StartCoroutine(LoadScene());
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    IEnumerator LoadScene()
    {
        //play fade animation
        yield return new WaitForSeconds(transtionTime);
        SceneManager.LoadScene(sceneToLoad);

    }
}
