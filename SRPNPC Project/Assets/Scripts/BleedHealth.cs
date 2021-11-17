using System;
using System.Collections;
using UnityEngine;

public class BleedHealth : MonoBehaviour, IHealth
{
    [SerializeField] private int startingHealth = 100;

    private float BleedDelay = 1.0f;
    private int BleedingDuration = 4;

    private int currentHealth;
    public event Action<float> OnHPPctChanged = delegate { };
    public event Action OnDied = delegate { };

    private void Start()
    {
        currentHealth = startingHealth;
    }

    public float CurrentHpPct
    {
        get { return (float)currentHealth / (float)startingHealth; }
    }

    public void ChangeHealth(int amount)
    {
        Debug.Log("Health changed by " + amount);

        currentHealth = Mathf.Min(currentHealth + amount, startingHealth);

        OnHPPctChanged(CurrentHpPct);
        if (amount < 0)
            StartCoroutine(Bleed());
        if (CurrentHpPct <= 0)
            Die();
    }

    private IEnumerator Bleed()
    {
        Debug.Log("Bleeding");
        for (int i = 0; i < BleedingDuration; ++i)
        {
            yield return new WaitForSeconds(BleedDelay);
            currentHealth -= 5;
            OnHPPctChanged(CurrentHpPct);
            if (CurrentHpPct <= 0)
                Die();
        }
    }

    private void Die()
    {
        OnDied();
        GameObject.Destroy(this.gameObject);
    }
}
