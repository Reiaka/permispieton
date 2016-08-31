using UnityEngine;
using System.Collections;

public class MenuPrincipalScript : MonoBehaviour {

	private GUISkin skin;

	void Start(){
		//Changement de l'apparence des bouton
		skin = Resources.Load ("GUISkin") as GUISkin;
	}

	void OnGUI(){

		//On applique l'apparence
		GUI.skin = skin;

		//Change le background du bouton
		GUI.backgroundColor = Color.white;
			
	}//OnGUI

	public void PlayRunner(){
		/*Fonction permettant de lancer la scène contenant le runner 
			en cliquant sur le bouton Mode Runner*/
		Application.LoadLevel("presentationScene");//Fonction qui charge la scène du runner
	}

	public void PlayQuiz(){
		/*Fonction permettant de lancer la scène contenant le runner 
			en cliquant sur le bouton Mode Runner*/
		Application.LoadLevel("NewRunner");//Fonction qui charge la scène du runner
	}

	public void Journal(){
		/*Fonction permettant de lancer la scène contenant le runner 
			en cliquant sur le bouton Mode Runner*/
		Application.LoadLevel("NewRunner");//Fonction qui charge la scène du runner
	}

	public void Settings(){
		/*Fonction permettant de lancer la scène contenant le runner 
			en cliquant sur le bouton Mode Runner*/
		Application.LoadLevel("NewRunner");//Fonction qui charge la scène du runner
	}
}//Class
