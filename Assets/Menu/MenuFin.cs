using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MenuFin : MonoBehaviour {

	private GUISkin skin;
	public Image etoile_1;
	public Image etoile_2;
	public Image etoile_3;
	public Image etoile_4;
	public Image etoile_5;

	public Button Rejouer;
	public Button Quitter;

	public Text score;
	public Text scoreFinal;
	private string[] messagesDefin = {"Bravo ! Tu as validé tout le niveau !", "Pas mal ! Tu as presque validé tout le niveau !", "Oooh ... tu n'as presque pas validé le niveau ... Aller, tu peux mieux faire !"};
		
	void Start(){
		//Changement de l'apparence des bouton
		skin = Resources.Load ("GUISkin") as GUISkin;

		score.text = "Tu as validé " + ScoreScript.cptValidation + " mises en situation et récupéré " + ScoreScript.cptPanneaux + " panneaux en plus !";
		scoreFinal.text = "Ton score final est de " + ScoreScript.ScoreCalcul(ScoreScript.cptValidation,ScoreScript.cptPanneaux) + " points !\n";


		if (ScoreScript.cptValidation <= 1) {
			etoile_5.enabled = false;
			etoile_4.enabled = false;
			etoile_3.enabled = false;
			etoile_2.enabled = false;
			etoile_1.enabled = true;
			scoreFinal.text += messagesDefin[2];
		} else if (ScoreScript.cptValidation == 2) {
			etoile_5.enabled = false;
			etoile_4.enabled = false;
			etoile_3.enabled = false;
			etoile_2.enabled = true;
			etoile_1.enabled = false;
			scoreFinal.text += messagesDefin[2];
		} else if (ScoreScript.cptValidation == 3) {
			etoile_5.enabled = false;
			etoile_4.enabled = false;
			etoile_3.enabled = true;
			etoile_2.enabled = false;
			etoile_1.enabled = false;
			scoreFinal.text += messagesDefin[1];
		} else if (ScoreScript.cptValidation == 4) {
			etoile_5.enabled = false;
			etoile_4.enabled = true;
			etoile_3.enabled = false;
			etoile_2.enabled = false;
			etoile_1.enabled = false;
			scoreFinal.text += messagesDefin[1];
		} else {
			etoile_5.enabled = true;
			etoile_4.enabled = false;
			etoile_3.enabled = false;
			etoile_2.enabled = false;
			etoile_1.enabled = false;
			scoreFinal.text += messagesDefin[0];
		}
	}

	// Use this for initialization
	void OnGUI() {

		//On applique l'apparence
		GUI.skin = skin;
		
		//Change le background du bouton
		GUI.backgroundColor = Color.white;
	}

	public void Restart(){
		GenerationPlateformes.listDePlateformes.Clear();
		PlayerAnim.nbBlocks = 3;
		GenerationPickUp.cptPlateforme = 0;
		ScoreScript.cptValidation = 0;
		ScoreScript.cptPanneaux = 0;
		/*Fonction permettant de lancer la scène contenant le runner 
			en cliquant sur le bouton Mode Runner*/
		Application.LoadLevel("NewRunner");//Fonction qui charge la scène du runner
	}

	public void Quit(){
		Application.Quit();//Fonction qui quitte le jeu
	}
}
