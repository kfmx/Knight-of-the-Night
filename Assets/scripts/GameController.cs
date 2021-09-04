using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameController : MonoBehaviour
{
    [HideInInspector]
    public int curAmmo, curHealth, curTorches = 0;
    [SerializeField]
    private int maxAmmo = 20;
    [SerializeField]
    private int maxHealth = 50;
    [SerializeField]
    private int maxTorches = 5;
    [SerializeField]
    private TextMeshProUGUI ammoText;
    private float iFrames;

    void Start()
    {
        
    }

    void Update()
    {
        Debug.Log(curAmmo);
        iFrames -= Time.deltaTime;
        //ammoText.text = "Ammo: " + curAmmo.ToString() + "/" + maxAmmo.ToString();
    }

    public void AddAmmo(int ammo) {
        curAmmo += ammo;
        curAmmo = Mathf.Clamp(curAmmo, 0, maxAmmo);
    }

    public void AddHealth(int health)
    {
        curHealth += health;
        curHealth = Mathf.Clamp(curHealth, 0, maxHealth);
    }

    public void RemoveHealth(int health)
    {
        if (iFrames <= 0)
        {
            curHealth -= health;
            curHealth = Mathf.Clamp(curHealth, 0, maxHealth);
            iFrames = .5f;
        }
    }

    public float getMaxHealth()
    {
        return maxHealth;
    }

    public int GetHealth()
    {
        return curHealth;
    }
}
