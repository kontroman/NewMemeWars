using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public delegate void HealthChangerHandler(int anmountDamage);

    public event HealthChangerHandler onHealthChange;
    public event HealthChangerHandler death;

    public int maxHealth;
    public int health;
    void Start()
    {
        health = maxHealth;
    }

    public void TakeDamage(int amountDamage)
    {
        onHealthChange.Invoke(amountDamage);
        health -= amountDamage;
        if (health == 0)
            death.Invoke(0);
    }

}
