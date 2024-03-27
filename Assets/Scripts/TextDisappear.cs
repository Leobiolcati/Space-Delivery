using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextDisappear : MonoBehaviour{
	[SerializeField] private Button exitTutorial;
	[SerializeField] private GameObject tutorialScreen;
	[SerializeField] private GameObject truckHUD;

	private void Start(){
		tutorialScreen.SetActive(true);
	}

	public void TutorialButtonClick(){
		tutorialScreen.SetActive(false);
		truckHUD.SetActive(true);
	}
}