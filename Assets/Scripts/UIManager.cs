using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{

    public GameObject pauseScreen;
    public bool levels;
    public bool store;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PauseGame()
    {
        Time.timeScale = 0.0f;
        pauseScreen.SetActive(true);
    }

    public void resumeGame() {
        Time.timeScale = 1.0f;
        pauseScreen.SetActive(false);
    }

    public void restart()
    {   //from the active scene get the index and load the scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void levelsMenu()
    {   //from the active scene get the index and load the scene
        SceneManager.LoadScene(0);
        
    }
    public void storeMenu()
    {   //from the active scene get the index and load the scene

    }

    public void sceneLoader(string scene)
    {//loads the next scene
       Time.timeScale= 1.0f;
       SceneManager.LoadScene(scene);
    }
}

