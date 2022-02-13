using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Respawn : MonoBehaviour
{
    public Health healthComponent;

    public GameObject respawnpointsBase;

    public Transform characterTransform;

    List<Transform> respawnpoints = new List<Transform>();

    public float respawnDelay;

    void Start()
    {
        respawnpointsBase = GameObject.Find("Waypoints");
        respawnpoints = respawnpointsBase.GetComponentsInChildren<Transform>().Skip(1).ToList();
        healthComponent = GetComponent<Health>();
        healthComponent.death += RespawnCharacterHandler;
        characterTransform = GetComponent<Transform>();
    }

    void Update()
    {

        if (Input.GetKeyDown("space"))
            Invoke("RespawnCharacter", respawnDelay);
    }

    public int RespawnpointIndexSelection()
    {
        int respawnpointIndex = Random.Range(0, respawnpoints.Count);
        return respawnpointIndex;
    }

    public void RespawnCharacter()
    {
      //  characterTransform.gameObject.SetActive(false);
        int respawnpointIndex = RespawnpointIndexSelection();
        Vector3 respawnpointPos = respawnpoints[respawnpointIndex].GetComponent<Transform>().position;
        characterTransform.position = respawnpointPos;
        healthComponent.health = healthComponent.maxHealth;
        characterTransform.gameObject.SetActive(true);
    }

    public void RespawnCharacterHandler(int amount)
    {
        Invoke("RespawnCharacter", respawnDelay);
    }
}
