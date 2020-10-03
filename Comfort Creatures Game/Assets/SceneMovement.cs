using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
public class SceneMovement : MonoBehaviour
{
    /* Contains all of the scene loading functions to move form scene to scene
     */ 
    bool gameHasEnded = false;
    public float restartDelay = 1.5f;
    public GameObject loadingScreen;
    public Slider slider;
    public GameObject otherScreen;
    public TextMeshProUGUI progressText;


    #region Scene changers
    public void Exit()
    {

        Debug.Log("Exited");
        Application.Quit();
    }

    public void GameOver()
    {
        SceneManager.LoadScene("Game Over");
    }

    public void EndGame() 
    { 
        if (gameHasEnded == false)
        {
            gameHasEnded = true;
            Debug.Log("game over");
            Invoke("GameOver", restartDelay);
        }
    }
    #endregion

    public void LoadLevel(string sceneName)
    {
        StartCoroutine(LoadAsyncly(sceneName));
    }

    IEnumerator LoadAsyncly(string sceneName)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneName);
        loadingScreen.SetActive(true);
        otherScreen.SetActive(false);

        while (operation.isDone == false)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);
            //Debug.Log(operation.progress);
            slider.value = progress;
            progressText.text = "Loading..." + progress * 100f + "%";
            yield return null;
        }
    }
}
