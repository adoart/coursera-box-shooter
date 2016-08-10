using UnityEngine;
using System.Collections;

public class EnemyBehavior : MonoBehaviour
{

	// target impact on game
	public int scoreAmount = 0;
	public float timeAmount = 0.0f;

	// explosion when hit?
	public GameObject explosionPrefab;

	// when collided with another gameObject
	void OnCollisionEnter (Collision newCollision)
	{
		switch(newCollision.gameObject.tag) {
		case "Projectile":
			hitByProjectile(newCollision);
			break;
		case "Player":
			hitByPlayer();
			break;
		case "Enemy":
			hitByAnotherEnemy(newCollision);
			break;
		}
	}

	private void hitByProjectile(Collision newCollision) {
		// exit if there is a game manager and the game is over
		if (GameManager.gm) {
			if (GameManager.gm.gameIsOver)
				return;
		}
		if (explosionPrefab) {
			// Instantiate an explosion effect at the gameObjects position and rotation
			Instantiate (explosionPrefab, transform.position, transform.rotation);
		}
		if (GameManager.gm) {
			GameManager.gm.targetHit (scoreAmount, 0);
			// destroy the projectile
			Destroy (newCollision.gameObject);
		}

		// destroy self
		Destroy (gameObject);
	}

	private void hitByAnotherEnemy(Collision newCollision) {
		if (explosionPrefab) {
			// Instantiate an explosion effect at the gameObjects position and rotation
			Instantiate (explosionPrefab, transform.position, transform.rotation);
			Instantiate (explosionPrefab, newCollision.transform.position, newCollision.transform.rotation);
		}

		// destroy the other enemy
		Destroy (newCollision.gameObject);
				
		// destroy self
		Destroy (gameObject);
	}

	private void hitByPlayer() {
		// exit if there is a game manager and the game is over
		if (GameManager.gm) {
			if (GameManager.gm.gameIsOver)
				return;
		}
		if (explosionPrefab) {
			// Instantiate an explosion effect at the gameObjects position and rotation
			Instantiate (explosionPrefab, transform.position, transform.rotation);
		}
		if (GameManager.gm) {
			GameManager.gm.targetHit (0, timeAmount);
		}
		
		// destroy self
		Destroy (gameObject);
	}
}
