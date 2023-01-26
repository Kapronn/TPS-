using UnityEngine;

public class EnemyDamageDealer : MonoBehaviour
{
    [SerializeField] private int damage = 20;

    public int GetDamageDealer()
    {
        return damage;
    }
}