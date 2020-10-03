using UnityEngine;

public abstract class Character : MonoBehaviour
{
    [SerializeField]
    protected int _health = 0, _maxHealth = 0;

    public virtual int Health
    {
        get
        {
            return _health;
        }
        protected set
        {
            if (value <= 0)
                _health = 0;
            else
                _health = value;
        }
    }public int MaxHealth
    {
        get
        {
            return _maxHealth;
        }
        protected set
        {
            if (value <= 0)
                _maxHealth = 0;
            else
                _maxHealth = value;
        }
    }

    public void TakeDamage(int damage) 
    {
        Health -= damage;
        if (Health == 0)
            Die();
    }

    protected abstract void Die();

    
}
