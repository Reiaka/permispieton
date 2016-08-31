using UnityEngine;
using System.Collections;

public class TestWait : MonoBehaviour {

	void OnCollisionEnter(Collision col){
		if (col.gameObject.name == "unitychan") {
			if(Input.GetKey(KeyCode.Space)){
				print ("prout");
			}
		}
	}
}
