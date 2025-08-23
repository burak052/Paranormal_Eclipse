using UnityEngine;

public class MainMenu : MonoBehaviour
{

    public Animation Camera;

    public void NewGame()
    {
        Application.LoadLevel(1);
    }
    public void LoadGame()
    {

    }
    public void Settings()
    {
        Camera.Play("MenutoSettings");
    }
    public void BacktoMenu()
    {
        Camera.Play("SettingstoMenu");
    }
    public void Exit()
    {
        Application.Quit();
    }
}
