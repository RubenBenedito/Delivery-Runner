using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour // MenuOptions
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void BacktoMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void MenuOptions()
    {
        SceneManager.LoadScene(3);
    }

    public void SoundEfects()
    {

    }

    public void Music()
    {

    }
}
