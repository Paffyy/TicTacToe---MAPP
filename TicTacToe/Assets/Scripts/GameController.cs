using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

[Serializable]
public class Player {
	public Image panel;
	public Text text;
	public Button button;
}

[Serializable]
public class PlayerColor {
	public Color panelColor;
	public Color textColor;
}

public class GameController : MonoBehaviour {
    public Color orange;
    public Color green;
    public Text winnerText;
    public Text drawText;
	public Text[] buttonList;
	public GameObject gameOverPanel;
	public Text gameOverText;
	public GameObject restartButton;
	public Player playerX;
	public Player playerO;
	public PlayerColor activePlayerColor;
	public PlayerColor inactivePlayerColor;
    public GameObject startInfo;
    private string playerSide;
	private int moveCount;

	void Awake ()
	{
		SetGameControllerReferenceOnButtons();
		gameOverPanel.SetActive(false);
		moveCount = 0;
		restartButton.SetActive(false);
        playerX.text.color = orange;
        playerO.text.color = green;
    }

    void SetGameControllerReferenceOnButtons ()
	{
		for (int i = 0; i < buttonList.Length; i++)
		{
			buttonList[i].GetComponentInParent<GridSpace>().SetGameControllerReference(this);
		}
	}

	public void SetStartingSide (string startingSide)
	{
		playerSide = startingSide;
		if (playerSide == "X")
		{
			SetPlayerColors(playerX, playerO);
		} 
		else
		{
			SetPlayerColors(playerO, playerX);
		}

		StartGame();
	}

	void StartGame ()
	{
		SetBoardInteractable(true);
		SetPlayerButtons (false);
		startInfo.SetActive(false);
	}

	public string GetPlayerSide ()
	{
		return playerSide;
	}

	public void EndTurn ()
	{
		moveCount++;

		if (buttonList [0].text == playerSide && buttonList [1].text == playerSide && buttonList [2].text == playerSide)
		{
			GameOver(playerSide);
		} 
		else if (buttonList [3].text == playerSide && buttonList [4].text == playerSide && buttonList [5].text == playerSide)
		{
			GameOver(playerSide);
		} 
		else if (buttonList [6].text == playerSide && buttonList [7].text == playerSide && buttonList [8].text == playerSide)
		{
			GameOver(playerSide);
		} 
		else if (buttonList [0].text == playerSide && buttonList [3].text == playerSide && buttonList [6].text == playerSide)
		{
			GameOver(playerSide);
		} 
		else if (buttonList [1].text == playerSide && buttonList [4].text == playerSide && buttonList [7].text == playerSide)
		{
			GameOver(playerSide);
		} 
		else if (buttonList [2].text == playerSide && buttonList [5].text == playerSide && buttonList [8].text == playerSide)
		{
			GameOver(playerSide);
		} 
		else if (buttonList [0].text == playerSide && buttonList [4].text == playerSide && buttonList [8].text == playerSide)
		{
			GameOver(playerSide);
		} 
		else if (buttonList [2].text == playerSide && buttonList [4].text == playerSide && buttonList [6].text == playerSide)
		{
			GameOver(playerSide);
		} 
		else if (moveCount >= 9)
		{
			GameOver("draw");
		} 
		else
		{
			ChangeSides();
		}
	}

	void ChangeSides ()
	{
		playerSide = (playerSide == "X") ? "N" : "X";
		if (playerSide == "X")
		{
			SetPlayerColors(playerX, playerO);
		} 
		else
		{
			SetPlayerColors(playerO, playerX);
		}
	}

	void SetPlayerColors (Player newPlayer, Player oldPlayer)
	{
        if (newPlayer.text.text.Contains("X"))
        {
            newPlayer.text.color = orange ;
        }
        else
        {
            newPlayer.text.color = green;
        }
        newPlayer.panel.color = activePlayerColor.panelColor;
		oldPlayer.panel.color = inactivePlayerColor.panelColor;
		oldPlayer.text.color = inactivePlayerColor.textColor;
	}

	void GameOver (string winningPlayer)
	{
		SetBoardInteractable(false);
		if (winningPlayer == "draw")
		{
			SetDrawText("It's a Draw!");
			SetPlayerColorsInactive();
		} 
		else
		{
            if (winningPlayer == "X")
            {
                gameOverText.color = orange;
                winnerText.color = orange;
                SetGameOverText(winningPlayer + "");
            }
            else
            {
                gameOverText.color = green;
                winnerText.color = green;
                SetGameOverText(winningPlayer + "");
            }
        }
		restartButton.SetActive(true);
	}

	void SetGameOverText (string value)
	{
        drawText.text = "";
        winnerText.text = "WINS!";
        gameOverText.text = value;
        gameOverPanel.SetActive(true);
	}
    void SetDrawText(string value)
    {
        winnerText.text = "";
        gameOverText.text = "";
        drawText.text = value;
        gameOverPanel.SetActive(true);
    }

    public void RestartGame ()
	{
		moveCount = 0;
		gameOverPanel.SetActive(false);
		restartButton.SetActive(false);
		SetPlayerButtons (true);
		SetPlayerColorsInactive();
		startInfo.SetActive(true);

		for (int i = 0; i < buttonList.Length; i++)
		{
			buttonList [i].text = "";
		}
	}

    public void returnToMenu()
    {
        SceneManager.LoadScene(0);
    }

	void SetBoardInteractable (bool toggle)
	{
		for (int i = 0; i < buttonList.Length; i++)
		{
			buttonList[i].GetComponentInParent<Button>().interactable = toggle;
		}
	}
	void SetPlayerButtons (bool toggle)
	{
		playerX.button.interactable = toggle;
		playerO.button.interactable = toggle;  
	}

	void SetPlayerColorsInactive ()
	{
		playerX.panel.color = inactivePlayerColor.panelColor;
		playerX.text.color = inactivePlayerColor.textColor;
		playerO.panel.color = inactivePlayerColor.panelColor;
		playerO.text.color = inactivePlayerColor.textColor;
	}
}