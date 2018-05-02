using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class ItemSpawner : NetworkBehaviour {

    public GameObject itemPrefab;
    public int numberOfItems;

    // se ejecuta cuando el servidor se crea
    public override void OnStartServer()
    {
        for (int i = 0; i < numberOfItems; i++)
        {
            Vector3 spawnPosition = new Vector3(Random.Range(-8f, 8f), 0, Random.Range(-8f, 8f));

            Quaternion spawnRotation = Quaternion.Euler(0f, Random.Range(0f, 180f), 0f);

            GameObject item = (GameObject)Instantiate(itemPrefab, spawnPosition, spawnRotation);

            NetworkServer.Spawn(item);
        }
    }
}
