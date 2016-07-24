using UnityEngine;
using System.Collections;

public class fakeChild : MonoBehaviour {

    public Transform target; //will rotate/follow this target

    public bool followPosition = true;
    public bool followRotate = true;
    public Vector3 rotationOffset = new Vector3(0, 0, 0);
	
	// Update is called once per frame
	void Update () {
        if (target != null)
        {
            if (followPosition)
                transform.position = target.position;
            if (followRotate)
                transform.eulerAngles = target.eulerAngles;
                    //transform.eulerAngles = new Vector3 (target.localRotation.x + rotationOffset.x, target.localRotation.y + rotationOffset.y, target.localRotation.z + rotationOffset.z);
        }
	}
}
