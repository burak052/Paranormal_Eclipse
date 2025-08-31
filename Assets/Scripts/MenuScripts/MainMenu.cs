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
        Camera.Play("Menu2Settings");
    }
    public void BacktoMenu()
    {
        Camera.Play("Settings2Menu");
    }
    public void Exit()
    {
        Application.Quit();
    }
}
