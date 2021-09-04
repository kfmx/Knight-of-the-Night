using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

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
    [SerializeField]
    private TextMeshProUGUI healthText;
    [SerializeField]
    private TextMeshProUGUI torchesText;
    private float iFrames;

    void Start()
    {
        curHealth = maxHealth;
    }

    void Update()
    {
        iFrames -= Time.deltaTime;
        if (curHealth <= 0)
        {
            SceneManager.LoadScene(sceneName: "endScreen");
        }
        ammoText.text = "Ammo: " + curAmmo.ToString() + "/" + maxAmmo.ToString();
        healthText.text = "Health: " + curHealth.ToString() + "/" + maxHealth.ToString();
        torchesText.text = "Torches: " + curTorches.ToString() + "/" + maxTorches.ToString();
        Debug.Log(iFrames);
        
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
            Debug.Log(curHealth);
            iFrames = .5f;
        }
    }

    public void AddTorch(int torches) {
        curTorches += torches;
        curTorches = Mathf.Clamp(curTorches, 0, maxTorches);
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
