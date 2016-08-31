using UnityEngine;
using System.Collections;

public class Rotator : MonoBehaviour {

	public float x,y,z;
	// Update is called once per frame
	/*void Start()
	{
		transform.position.x = Random.Range (0.15f, 0.45f);
	}*/
	void Update () {
		transform.Rotate (new Vector3 (x, y, z)*Time.deltaTime);
	}
}
