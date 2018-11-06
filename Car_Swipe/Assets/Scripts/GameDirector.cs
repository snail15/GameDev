using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameDirector : MonoBehaviour {

    GameObject car;
    GameObject flag;
    GameObject distance;
    float remainingDistance;

    // Use this for initialization
    void Start () {
        this.car = GameObject.Find("car");
        this.flag = GameObject.Find("flag");
        this.distance = GameObject.Find("Distance");
        remainingDistance = this.flag.transform.position.x - this.car.transform.position.x;
        this.distance.GetComponent<Text>().text = remainingDistance.ToString("F2") + "m";
    }
	
	// Update is called once per frame
	void Update () {

        remainingDistance = this.flag.transform.position.x - this.car.transform.position.x;
        this.distance.GetComponent<Text>().text = remainingDistance.ToString("F2") + "m";

        if (remainingDistance < 0)
            this.distance.GetComponent<Text>().text = "Game Over";
    }
}
