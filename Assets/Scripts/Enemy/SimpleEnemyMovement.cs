using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleEnemyMovement : EnemyMovement
{
    public float respawnTimer = 25f; //Respawns the enemy after this many seconds
    public int numRespawns = 2;
    float timer;
 
    protected override void Start()
    {
        base.Start();
        timer = respawnTimer;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            timer = respawnTimer;
            if (numRespawns > 0)
            {
                numRespawns -= 1;
                Respawn();      // Unfortunately this will not add any score for respawns, but that is fine for the purposes of this demo/lab
            }
            else
            {
                Destroy(gameObject);
            }
        }
        transform.position = Vector2.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
    }

}
