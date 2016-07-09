using UnityEngine;
using System.Collections;
using UnityEngine.UI;

//Attach to UI button you want to spawn a Transform

[RequireComponent(typeof(Button))]
public class spawnButton : MonoBehaviour {
    
    public Transform objectToSpawn;
    public Transform targetPositionObject; //where the particle will spawn
    Button thisButton;

    bool spawning = false;
    
	void Awake () {
	    
	}
	
	// Update is called once per frame
	void Update () {
	    
	}
    

    public void Spawn()
    {
        Transform particleClone = Instantiate(objectToSpawn, targetPositionObject.position, Quaternion.Euler(new Vector3(-90, 0, 0))) as Transform;
    }
}
