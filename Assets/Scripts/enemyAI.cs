using UnityEngine;

public class enemyAI : MonoBehaviour
{
    public int currentEnemyHealth = 3;
    void Start()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Explosion"))
        {
            currentEnemyHealth--;
            if(currentEnemyHealth<=0) Destroy(gameObject);
        }
    }
}
