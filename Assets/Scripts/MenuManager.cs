using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MenuManager : MonoBehaviour
{
    public GameObject showAboutCanvas;
    public GameObject mainMenuCanvas;
   

    // Start is called before the first frame update
    void Start()
    {
     

    }

    // Update is called once per frame
    void Update()
    {


    }

    
    public void PlayNow()
    {

        SceneManager.LoadScene(1);

        AdManager.HideBanner();
        
    }

    public void ShowAbout()
    {
        showAboutCanvas.SetActive(true);
        mainMenuCanvas.SetActive(false);

    }

    public void ShowMainMenu()
    {
        showAboutCanvas.SetActive(false);
        mainMenuCanvas.SetActive(true);

    }

    public void QuitGame()
    {
        Application.Quit();

    }

}