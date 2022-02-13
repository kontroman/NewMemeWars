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
        Debug.Log("”мер");
        characterTransform.gameObject.SetActive(false);
        int respawnpointIndex = RespawnpointIndexSelection();
        Vector3 respawnpointPos = respawnpoints[respawnpointIndex].GetComponent<Transform>().position;
        characterTransform.position = respawnpointPos;
        characterTransform.gameObject.SetActive(true);
        Debug.Log("∆ив");
    }

    public void RespawnCharacterHandler(int amount)
    {
        Invoke("RespawnCharacter", respawnDelay);
    }
}
