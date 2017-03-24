using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotation : MonoBehaviour {

    int f;
    // Use this for initialization
    void Start () {
        f = Random.Range(-5, 5);

    }
	
	// Update is called once per frame
	void Update () {

        transform.rotation *= Quaternion.AngleAxis(f, new Vector3(0, 0, 1));//вращение

    }
}
