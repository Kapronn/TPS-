using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float timeToDestroy = 4f;
    [HideInInspector] public WeaponManager weapon;
    
    void Start()
    {
        Destroy(gameObject, timeToDestroy);
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.GetComponentInParent<EnemyHealth>())
        {
            EnemyHealth enemyHealth = collision.gameObject.GetComponentInParent<EnemyHealth>();
            enemyHealth.TakeDamage(weapon.damage);
        }
        Debug.Log(collision.gameObject.name);
        Destroy(gameObject);
    }
}
