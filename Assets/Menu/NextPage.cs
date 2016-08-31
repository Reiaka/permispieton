using UnityEngine;
using System.Collections;

public class NextPage : MonoBehaviour {

	public void next1(){
		Application.LoadLevel("explicationScene1");//Fonction qui quitte le jeu
	}

	public void next2(){
		Application.LoadLevel("explicationScene");//Fonction qui quitte le jeu
	}

	public void play(){
		Application.LoadLevel("NewRunner");//Fonction qui quitte le jeu
	}
}
