﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class Health : NetworkBehaviour  {
	
	public const int maxHealth = 100;
	[SyncVar(hook="OnChangeHealth")]public int currentHealth=maxHealth;

	public RectTransform healthbar;
	public bool destroyOnDead;
	private NetworkStartPosition[] spawnPoints;


	void Start(){
		if (isLocalPlayer) {
			spawnPoints = FindObjectsOfType<NetworkStartPosition> ();
		}
	}
	public void TakeDamage(int amount){

		if (!isServer) {
			return;
		}
		currentHealth -= amount;
		if (currentHealth <=0) {
			if (destroyOnDead) {
				Destroy (gameObject);
			} else {
				currentHealth = maxHealth;
				RpcRespawn ();
			}

		}
	}

    public void AddLife(int amount) {
        if (!isServer)
        {
            return;
        }

        if (currentHealth >= 100)
        {
            currentHealth = maxHealth;
        }
        else {
            currentHealth += amount;
        }
    }

	void OnChangeHealth(int health){
		healthbar.sizeDelta = new Vector2 (health * 2, healthbar.sizeDelta.y);
	}

	[ClientRpc]
	void RpcRespawn(){
		if (isLocalPlayer) {
			Vector3 spawnPoint = Vector3.zero;
			if (spawnPoints != null && spawnPoints.Length >0) {
				spawnPoint = spawnPoints[Random.Range(0,spawnPoints.Length)].transform.position;
			}
			transform.position = spawnPoint;
		}
	}
}
