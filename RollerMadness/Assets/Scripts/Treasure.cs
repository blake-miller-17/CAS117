using UnityEngine;
using System.Collections;

public class Treasure : MonoBehaviour {

    [Tooltip("How much the treasure is worth")]
	public int value = 10;
    [Tooltip("The game object to spawn when this treasure is collected")]
	public GameObject explosionPrefab;

	void OnTriggerEnter (Collider other)
	{
		if (other.gameObject.tag == "Player") {
			if (GameManagerRollerMadness.gm!=null)
			{
                // tell the game manager to Collect
                GameManagerRollerMadness.gm.Collect (value);
			}
			
			// explode if specified
			if (explosionPrefab != null) {
				Instantiate (explosionPrefab, transform.position, Quaternion.identity);
			}
			
			// destroy after collection
			Destroy (gameObject);
		}
	}
}
