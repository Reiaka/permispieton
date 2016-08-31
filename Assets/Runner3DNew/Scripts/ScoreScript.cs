using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class ScoreScript : MonoBehaviour {

	public Text scoreValidation;
	public Text panneauxRamasses;

	public static int cptValidation = 0; //Compteur de points pour valider le niveau
	public static int cptPanneaux = 0;

	// Use this for initialization
	void Start () {
		scoreValidation.text = "Score : ";
		panneauxRamasses.text = "Panneaux récupérés : ";
	}
	
	// Update is called once per frame
	void Update () {
		SetCountText();
	}

	void SetCountText(){
		scoreValidation.text = "Score : " + cptValidation;
		panneauxRamasses.text = "Panneaux récupérés : " + cptPanneaux;
	}

	public static int ScoreCalcul(int scoreVal, int nbPanneaux){
		scoreVal = scoreVal * 100;
		nbPanneaux = nbPanneaux * 10;

		return scoreVal + nbPanneaux;
	}
}
