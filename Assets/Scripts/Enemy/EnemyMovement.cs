using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {
    public float speed = 6f;
    public float spawnDistance = 20f; //Distance away from the player that the enemy will spawn
    protected GameObject target; //protected allows the children to access this variable
    protected virtual void Start()
    {
        target = GameObject.Find("Player");
        Respawn();
    }

    // Update is called once per frame
    void Update () {

    }

    protected void Respawn()
    {
        Vector2 randDelta = Random.insideUnitCircle.normalized * spawnDistance;
        transform.position = target.transform.position + (Vector3)randDelta;
    }
}
