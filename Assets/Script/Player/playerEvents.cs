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

    public Vector3 cumSpawnRotation = new Vector3(0, 0, 0);

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
        randomNo2 = Random.Range(0, smallParticles.Count);

        cumParticleSmall = smallParticles[randomNo2];
        cumParticleBig = bigParticles[randomNo2];

    }

    public void Goal()
    {
        //big cum

        //cumSmallClone.parent = tipPosition; //so that the trail will follow the player
        StartCoroutine(CoGoal());
    }

    public IEnumerator CoGoal()
    {
        float lookDirection = tipPosition.rotation.z;
        Transform cumSmallClone = Instantiate(cumParticleBig, tipPosition.position, Quaternion.Euler(new Vector3(cumSpawnRotation.x, cumSpawnRotation.y, cumSpawnRotation.z))) as Transform;
        cumSmallClone.GetComponent<fakeChild>().target = tipPosition;
        //cumSmallClone.rotation = new Vector3 ()
        yield return new WaitForSeconds(0.1f);
        //cumSmallClone.parent = tipPosition; //so that the trail will follow the player
    }
}
