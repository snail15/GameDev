using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    GameObject cat;

	// Use this for initialization
	void Start () {
        this.cat = GameObject.Find("cat");
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 catPos = this.cat.transform.position;
        transform.position = new Vector3(transform.position.x, catPos.y, transform.position.z);
	}
}
