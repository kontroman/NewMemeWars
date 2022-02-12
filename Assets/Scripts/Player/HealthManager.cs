using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : Singleton<HealthManager>
{
    public int health;
    private int maxHealth;

    public void DecreaseHealth(int amount)
    {
        health -= amount;
    }

}
