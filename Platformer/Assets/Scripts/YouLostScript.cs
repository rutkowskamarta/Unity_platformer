using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class YouLostScript : MonoBehaviour
{
    [SerializeField] private GameObject gameoverContent;

    private bool isLost = false;

    public void GameOverContentActive()
    {
        isLost = true;
        gameoverContent.SetActive(true);
    }

    private void Update()
    {
        ScreenControllerWhenlost();
    }

    private void ScreenControllerWhenlost()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && isLost)
        {
            Application.Quit();
        }
        if (Input.GetKeyDown(KeyCode.Return) && isLost)
        {
            Scene activeScene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(activeScene.name);
        }
    }

}
