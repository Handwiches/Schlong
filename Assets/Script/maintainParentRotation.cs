using UnityEngine;
using System.Collections;

public class maintainParentRotation : MonoBehaviour {



	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (transform.parent != null)
        {
            transform.rotation = Quaternion.Euler(new Vector3((transform.parent.eulerAngles.x + 270.0f), (transform.parent.eulerAngles.y), transform.parent.eulerAngles.z)); //Quaternion.Euler(new Vector3(-90, 0, transform.parent.rotation.z));
        }
	}
}
