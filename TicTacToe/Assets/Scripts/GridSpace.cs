using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GridSpace : MonoBehaviour {
	
	public Button button;
	public Text buttonText;
    public Font font;
    public Color orange;
    public Color green;
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
            buttonText.color = orange;
        }
        else
        {
            buttonText.color = green;
        }
        button.interactable = false;
		gameController.EndTurn();
	}
}
