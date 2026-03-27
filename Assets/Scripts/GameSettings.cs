public static class GameSettings
{
    private const string AI_KEY = "IsAI";
    private const string DIFFICULTY_KEY = "Difficulty";
    private const string SOUND_KEY = "SoundOn";

    public static bool isAI
    {
        get { return UnityEngine.PlayerPrefs.GetInt(AI_KEY, 0) == 1; }
        set { UnityEngine.PlayerPrefs.SetInt(AI_KEY, value ? 1 : 0); }
    }

    public static float difficulty
    {
        get { return UnityEngine.PlayerPrefs.GetFloat(DIFFICULTY_KEY, 0.5f); }
        set { UnityEngine.PlayerPrefs.SetFloat(DIFFICULTY_KEY, value); }
    }

    public static bool soundOn
    {
        get { return UnityEngine.PlayerPrefs.GetInt(SOUND_KEY, 1) == 1; }
        set { UnityEngine.PlayerPrefs.SetInt(SOUND_KEY, value ? 1 : 0); }
    }
}
