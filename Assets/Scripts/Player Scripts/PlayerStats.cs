using System.Collections;
using UnityEngine;

public class PlayerStats : MonoBehaviour, IDamageable
{
    [SerializeField] private int healthPoints;
    private int currentPoints;

    private void Start()
    {
        currentPoints = healthPoints;
    }

    public void TakeDamage()
    {
        currentPoints -= 1;
    }

    private IEnumerator DamageBuffer()
    {
        yield return new WaitForSeconds(3f);
        TakeDamage();
    }
}
