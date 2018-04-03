using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GridSpace : MonoBehaviour {
	
	public Button button;
	public Text buttonText;
    public Font font;
	private GameController gameController;

    void Awake()
    {
        //this.buttonText.font = new Font()
        //{

        //};
    }

	public void SetGameControllerReference (GameController controller)
	{
		gameController = controller;
	}

	public void SetSpace()
	{
		buttonText.text = gameController.GetPlayerSide();
        if (buttonText.text.Contains("X"))
        {
            buttonText.color = new Color(255f,63f,13f); 
        }
        else
        {
            buttonText.color = new Color(67f, 209f, 5f);
        }
        button.interactable = false;
		gameController.EndTurn();
	}
}
