using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AISightController : MonoBehaviour
{

    private Transform botTransform;

    public float sightRange;

    public LayerMask characterLayer;

    public Collider[] enemiesInSightColliders;

    public List<GameObject> enemiesInSight = new List<GameObject>();

    private void Start()
    {
            
        botTransform = GetComponent<Transform>();
    }
    private void FixedUpdate()
    {
        enemiesInSightColliders = Physics.OverlapSphere(botTransform.position  + new Vector3(0, 0, sightRange), sightRange, characterLayer);
        foreach (Collider enemy in enemiesInSightColliders)
        {
            if (!enemiesInSight.Contains(enemy.gameObject) && (enemy.gameObject != botTransform.gameObject))
                enemiesInSight.Add(enemy.gameObject);
        }
    }
}
