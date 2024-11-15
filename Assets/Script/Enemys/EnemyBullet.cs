using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public int damage = 10;       // D�g�ts inflig�s
    public float lifeTime = 2f;   // Dur�e de vie de la balle

    private void Start()
    {
        Destroy(gameObject, lifeTime); // D�truit la balle apr�s un certain temps
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player")) // V�rifie si la balle touche le joueur
        {
            PlayerStats playerHealth = collision.gameObject.GetComponent<PlayerStats>();
            if (playerHealth != null)
            {
                Debug.Log("Player hit");
                playerHealth.TakeDamage(damage); // Applique des d�g�ts au joueur
            }
            Destroy(gameObject); // D�truit la balle apr�s l'impact
        }
    }
}
