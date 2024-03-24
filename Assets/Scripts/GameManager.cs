using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject gameOverCanvas;


    // Start is called before the first frame update
    void Start()
    {

        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void GameOver()
    {
        gameOverCanvas.SetActive(true);

        Time.timeScale = 0;

        AdManager.ShowBanner();

        AdManager.ShowIntersitial();



    }


    public void Replay()
    {
        SceneManager.LoadScene(1);

        Time.timeScale = 1;
        AdManager.HideBanner();

    }


    public void mainMenu()
    {

        SceneManager.LoadScene(0);
    }

    public void Exit()
    {

        Application.Quit();
    }

}
