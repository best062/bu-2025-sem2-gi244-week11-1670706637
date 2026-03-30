using UnityEngine;

public class StunPowerUp : MonoBehaviour
{
    [Header("Stun Settings")]
    public float stunDuration = 5f; 

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            var allEnemies = FindObjectsOfType<Enemy>();
            Debug.Log("เก็บ Power Up แล้ว!");

            // สั่งให้ศัตรูทุกคนติดสถานะ Stun
            foreach (Enemy enemy in allEnemies)
            {
                enemy.StunEnemy();
            }
            
            Destroy(gameObject);
        }
    }
}