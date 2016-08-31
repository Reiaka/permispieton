using UnityEngine;
using System.Collections;
//using UnityEngine.SceneManagement;

public class FinDuJeu : MonoBehaviour {

	void OnCollisionEnter(Collision col){
		if (col.gameObject.name == "unitychan") {
			Application.LoadLevel("FinalScene");
		}

	}
}
