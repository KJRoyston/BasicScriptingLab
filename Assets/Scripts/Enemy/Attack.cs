using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour {
    public int damage = 1;

	void Start () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Health other = collision.gameObject.GetComponent<Health>();
        if (other != null)
        {
            other.takeDamage(damage);
            Destroy(gameObject);
        }
    }
}
