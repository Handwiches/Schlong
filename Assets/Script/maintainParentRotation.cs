using UnityEngine;
using System.Collections;

public class maintainParentRotation : MonoBehaviour {



	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        transform.rotation = Quaternion.Euler(new Vector3((transform.parent.eulerAngles.x + 180.0f), (transform.parent.eulerAngles.y), transform.parent.eulerAngles.z)); //Quaternion.Euler(new Vector3(-90, 0, transform.parent.rotation.z));
	}
}
