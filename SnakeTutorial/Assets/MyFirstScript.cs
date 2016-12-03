using UnityEngine;
using System.Collections;

public class MyFirstScript : MonoBehaviour {

    // Use this for initialization

    public GameObject obj;
    public Transform trans;
    public BoxCollider boxcoll;
    public MyFirstScript myScript;
    public Light sceneLight;



	void Start ()
    {
        
	}
	
	// Update is called once per frame
	void Update ()
    {
        sceneLight.intensity -= 0.005f;
	
	}



}
