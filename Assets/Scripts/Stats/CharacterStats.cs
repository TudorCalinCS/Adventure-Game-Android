using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    public int maxHealth;
    public int currentHealth { get;private set ;}
    public Stat damage;
    public Stat armour;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            TakeDamage(10);
        }
    }

    private void Awake()
    {
        currentHealth = maxHealth;
    }
    public void Heal(int healAmount)
    {
        Debug.Log(transform.name + " healed for " + healAmount.ToString());
        currentHealth = currentHealth += healAmount;
    }
    public void TakeDamage(int damage)
    {
        damage -= armour.GetValue();
        damage = Mathf.Clamp(damage, 0, int.MaxValue);
        currentHealth -= damage;
        Debug.Log(transform.name +" takes "+ damage +" damage.");
        if (currentHealth <= 0)
        {
            Die();
        }
    }
    public virtual void Die()
    {
        Debug.Log(transform.name + " died.");
    }
}
