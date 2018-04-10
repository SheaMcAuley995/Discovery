using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randomizeMass : MonoBehaviour {

	void Start () {
        GetComponent<Rigidbody>().mass = Random.Range(0.5f, 1f);
	}
	
}
