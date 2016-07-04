using UnityEngine;
using System.Collections;
using System.Collections.Generic; //allows using lists

public class playerEvents : MonoBehaviour {

    public Transform tipPosition;
    [HideInInspector]
    public Transform cumParticleSmall; //must remain public for shaftPaddle to read
    [HideInInspector]
    public Transform cumParticleBig;

    public List<Transform> smallParticles = new List<Transform>(new Transform[3]);
    public List<Transform> bigParticles = new List<Transform>(new Transform[3]);

    public List<MeshRenderer> renderers = new List<MeshRenderer>(new MeshRenderer[3]);
    public List<SkinnedMeshRenderer> skinRenderers = new List<SkinnedMeshRenderer>(new SkinnedMeshRenderer[1]);
    public List<Material> playerMaterials = new List<Material>(new Material[3]);    //will randomly assign one to all the renderers

    void Awake()
    {
        //Assign random material
        int randomNo = 0;
        randomNo = Random.Range(0, playerMaterials.Count);
        for (int i = 0; i < renderers.Count; i++)
        {
            renderers[i].material = playerMaterials[randomNo];
        }
        for (int j = 0; j < skinRenderers.Count; j++)
        {
            skinRenderers[j].material = playerMaterials[randomNo];
        }

        //Assign Random Particles
        int randomNo2 = 0;
        int randomNo3 = 0;
        randomNo2 = Random.Range(0, smallParticles.Count);
        randomNo3 = Random.Range(0, bigParticles.Count);

        cumParticleSmall = smallParticles[randomNo2];
        cumParticleBig = bigParticles[randomNo2];

    }

    // Update is called once per frame
    void Update () {
	
	}

    public void Goal()
    {
        //big cum
        float lookDirection = tipPosition.rotation.z;
        Transform cumSmallClone = Instantiate(cumParticleBig, tipPosition.position, Quaternion.Euler(new Vector3(0, 0, lookDirection))) as Transform;
        cumSmallClone.parent = tipPosition; //so that the trail will follow the player
    }
}
