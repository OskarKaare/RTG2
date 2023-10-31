using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
   public int amountToSpawn; //en størrelse for hvor mange props der skal spawnes
   public List<GameObject> spawnPool; //en liste over vores props, vi tilføjer hvad den indeholder i Unity
    public GameObject quad; // bruges til at opstille vores map
    void Start()
    {
        spawnObjects(); //kører functionen spawnObjects ved start
    }
    public void spawnObjects()
    {
        int randomItem = 0;
        GameObject toSpawn;
        MeshCollider c = quad.GetComponent<MeshCollider>();

        float screenX, screenY;
        Vector2 pos;

        for (int i = 0; i < amountToSpawn; i++)
        {
            randomItem = Random.Range(0, spawnPool.Count); // fortæller os hvor mange props der spawnes
            toSpawn = spawnPool[randomItem];
            screenX = Random.Range(c.bounds.min.x, c.bounds.max.x);
            screenY = Random.Range(c.bounds.min.y, c.bounds.max.y);
            pos = new Vector2(screenX, screenY);

            Instantiate(toSpawn, pos, toSpawn.transform.rotation);
        }
    }
    private void destroyAllObjects()
    {
        foreach (GameObject o in GameObject.FindGameObjectsWithTag("Spawnable")) ;
    }
}
// https://www.youtube.com/watch?v=4OQjnKUENoE
