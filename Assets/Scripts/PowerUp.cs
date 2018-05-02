using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
public class PowerUp : NetworkBehaviour {


    public int recoverValue = 5;


    void OnCollisionEnter(Collision other)
    {

        Debug.Log("Entro jugador" + other.gameObject);
        GameObject hit = other.gameObject;
        Health health = hit.GetComponent<Health>();

        if (health != null)
        {
            health.AddLife(recoverValue);
        }
        NetworkServer.Destroy(gameObject);
        //Destroy(gameObject);
    }

}
