using System.Collections;
using System;
using UnityEngine;

public class NumberOfHitsHealth : MonoBehaviour, IHealth
{
    [SerializeField]
    private int healthInHits = 5;

    [SerializeField]
    private float invulnerabilityTimeAfterEachHit = 1.0f;

    private int hitsRemaining;
    private bool canModHealth = true;

    public event Action<float> OnHPPctChanged = delegate (float f) { };
    public event Action OnDied = delegate { };

    public float CurrentHpPct
    {
        get { return (float)hitsRemaining / (float)healthInHits; }
    }

    private void Start()
    {
        hitsRemaining = healthInHits;
    }

    public void ChangeHealth(int amount)
    {
        
    
        if (canModHealth)
        {
            amount = amount > 0 ? 1 : -1;
            Debug.Log("Health changed by " + amount);

            StartCoroutine(InvunlerabilityTimer());

            hitsRemaining+=amount;

            OnHPPctChanged(CurrentHpPct);

            if (hitsRemaining <= 0)
            {
                OnDied();
                GameObject.Destroy(this.gameObject);
            }
        }
    }

    private IEnumerator InvunlerabilityTimer()
    {
        canModHealth = false;
        yield return new WaitForSeconds(invulnerabilityTimeAfterEachHit);
        canModHealth = true;
    }
}
