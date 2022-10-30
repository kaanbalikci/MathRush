using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    public static ButtonManager BM;

    private void Awake()
    {
        BM = this;
    }

    public void StartScene()
    {
        SceneManager.LoadScene("Game");
    }

    public void RestartGame()
    {     

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1.0f;
    }
}
