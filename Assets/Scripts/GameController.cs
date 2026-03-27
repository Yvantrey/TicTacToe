using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject[] xTexts;
    public GameObject[] oTexts;
    public TextMeshProUGUI titleText;
    public GameObject[] strikeLines;
    public GameObject reloadButton;
    
    private string[] board = new string[9];
    private bool isXTurn = true;
    private bool gameOver = false;
    private bool isAIMode = false;

    void Start()
    {
        isAIMode = GameSettings.isAI;
        
        if (reloadButton != null)
            reloadButton.SetActive(false);
            
        for (int i = 0; i < 9; i++)
        {
            if (xTexts != null && i < xTexts.Length && xTexts[i] != null)
                xTexts[i].SetActive(false);
            if (oTexts != null && i < oTexts.Length && oTexts[i] != null)
                oTexts[i].SetActive(false);
        }
    }

    public void OnCellClick(int index)
    {
        if (gameOver || board[index] != null) return;
        
        board[index] = isXTurn ? "X" : "O";
        
        if (isXTurn && xTexts != null && index < xTexts.Length && xTexts[index] != null)
            xTexts[index].SetActive(true);
        else if (!isXTurn && oTexts != null && index < oTexts.Length && oTexts[index] != null)
            oTexts[index].SetActive(true);
        
        if (CheckWin())
        {
            gameOver = true;
            if (titleText != null)
                titleText.text = (isXTurn ? "Player X" : "Player O") + " Wins";
            if (reloadButton != null)
                reloadButton.SetActive(true);
        }
        else if (CheckDraw())
        {
            gameOver = true;
            if (titleText != null)
                titleText.text = "Draw";
            if (reloadButton != null)
                reloadButton.SetActive(true);
        }
        else
        {
            isXTurn = !isXTurn;
            if (isAIMode && !isXTurn && !gameOver)
                Invoke("AIMove", 0.5f);
        }
    }

    private void AIMove()
    {
        if (gameOver) return;
        
        int move = GetBestMove();
        if (move != -1)
            OnCellClick(move);
    }

    private int GetBestMove()
    {
        for (int i = 0; i < 9; i++)
            if (board[i] == null) return i;
        return -1;
    }

    private bool CheckWin()
    {
        int[][] lines = {
            new int[] {0,1,2}, new int[] {3,4,5}, new int[] {6,7,8},
            new int[] {0,3,6}, new int[] {1,4,7}, new int[] {2,5,8},
            new int[] {0,4,8}, new int[] {2,4,6}
        };
        
        for (int i = 0; i < lines.Length; i++)
        {
            if (board[lines[i][0]] != null &&
                board[lines[i][0]] == board[lines[i][1]] &&
                board[lines[i][1]] == board[lines[i][2]])
            {
                if (strikeLines != null && i < strikeLines.Length && strikeLines[i] != null)
                    strikeLines[i].SetActive(true);
                return true;
            }
        }
        return false;
    }

    private bool CheckDraw()
    {
        foreach (string cell in board)
            if (cell == null) return false;
        return true;
    }

    public void ReloadGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void ToggleAI()
    {
        GameSettings.isAI = !GameSettings.isAI;
        SceneManager.LoadScene("Game");
    }
}