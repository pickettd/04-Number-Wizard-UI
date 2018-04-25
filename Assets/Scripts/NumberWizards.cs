using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class NumberWizards : MonoBehaviour {

	public Text guessText;
	private Color32 yellowColor;
	private Color32 whiteColor;
	private Color32 blackColor;
	
	int max = 1000;
	int min = 1;
	int guess;
	
	void Start () {
		yellowColor = new Color32(251,255,0,255);
		whiteColor = new Color32(255,255,255,255);
		blackColor = new Color32(0,0,0,0);

		StartGame();
	}
	
	void StartGame () {
		max = max + 1;
		NextGuess();
	}

	public void GuessHigher(){
		min = guess;
		NextGuess();
	}

	public void GuessLower(){
		max = guess;
		NextGuess ();
	}

	public void GuessCorrect(){
		LevelManager.LoadScene("Win Screen");
		StartGame ();
	}
	
	void NextGuess () {
		//guess = (max + min) / 2;
		if (max > 950) {
			guessText.color = yellowColor;
		}
		else if ((max <= 950)&&(max > 100)) {
			guessText.color = whiteColor;
		}
		else if ((max <= 100)&&(max > 50)) {
			guessText.color = blackColor;
		}
		else if (max <= 50) {
			guessText.color = yellowColor;
		}
		if (max < 5) {
			guess = -1;
		}
		else {
			guess = Random.Range(min, max);
		}
		print ("Next guess is " + guess);
		guessText.text = guess.ToString();
	}
}
