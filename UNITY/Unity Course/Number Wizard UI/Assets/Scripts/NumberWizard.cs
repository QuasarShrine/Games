using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NumberWizard : MonoBehaviour {

	int max;
	int min;
	int guess;
	public int maxGuessedAllowed = 10;
	static string cheaterReason;

	public Text text;
	public Text cheaterReasonText;

	// Use this for initialization
	void Start() {
		StartGame();
	}

	void StartGame() {
		max = 1000;
		min = 1;
		guess = Random.Range(max, min) - 1;
		cheaterReasonText.text = cheaterReason;
		text.text = guess.ToString();

		max++;
	}

	public void GuessHigher() {
		if (guess == 1000) {
			// We said not above 1000 !
			cheaterReason = "We said not above 1000 !";
			cheaterReasonText.text = cheaterReason;
			SceneManager.LoadScene("Cheater");
		} else {
			min = guess;
			NextGuess();
		}
	}

	public void GuessLower() {
		if (guess == 1) {
			// We said not bellow 1 !
			cheaterReason = "We said not bellow 1 !";
			cheaterReasonText.text = cheaterReason;
			SceneManager.LoadScene("Cheater");
		} else {
			max = guess;
			NextGuess();
		}
	}

	void NextGuess() {
		if (max == min) {
			cheaterReason = "Cheater ! You don't think in integer !";
			cheaterReasonText.text = cheaterReason;
			SceneManager.LoadScene("Cheater");
		} else {
			guess = Random.Range(max, min) - 1;
			text.text = guess.ToString();
			maxGuessedAllowed--;
			if (maxGuessedAllowed <= 0) {
				SceneManager.LoadScene("Win");
			}
		}
	}

}
