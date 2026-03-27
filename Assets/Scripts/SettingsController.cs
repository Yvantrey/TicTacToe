using UnityEngine;
using UnityEngine.SceneManagement;

public class SettingsController : MonoBehaviour
{
    public void SetGameMode(int index)
    {
        GameSettings.isAI = (index == 1);
    }

    public void SetDifficulty(float value)
    {
        GameSettings.difficulty = value;
    }

    public void SetSound(bool isOn)
    {
        GameSettings.soundOn = isOn;
    }

    public void GoBack()
    {
        SceneManager.LoadScene("MainMenu");
    }
}