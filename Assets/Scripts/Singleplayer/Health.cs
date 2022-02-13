using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    //public delegate void HealthChangerHandler(int anmountDamage);

    //public event HealthChangerHandler onHealthChange;
    //public event HealthChangerHandler death;

    [SerializeField]
    public UnityEvent onHealthChanged;
    public event Action<int> onHealthChangedAction;

    [SerializeField]
    public UnityEvent onDeath;
    public event Action<int> death;

    public int maxHealth;
    public int health;

    public bool isPlayer = false;

    void Start()
    {
        health = maxHealth;
    }

    public void TakeDamage(int amountDamage)
    {
        health -= amountDamage;

        if(isPlayer)
        onHealthChangedAction.Invoke(health);

        if (health == 0)
            death.Invoke(0);
    }

}
