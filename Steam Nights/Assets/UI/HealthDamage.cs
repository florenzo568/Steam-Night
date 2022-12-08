using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthDamage : MonoBehaviour
{
    public int health;
    public int maxHealth = 10;

    public HealthBar healthBar;

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    public void TakeDamage(int amount)
    {
        health -= amount;
        healthBar.SetHealth(health);
    }
}
