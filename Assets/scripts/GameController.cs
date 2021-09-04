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

    void Start()
    {
        
    }

    void Update()
    {
        ammoText.text = "Ammo: " + curAmmo.ToString() + "/" + maxAmmo.ToString();
    }

    public void AddAmmo(int ammo) {
        curAmmo += ammo;
        curAmmo = Mathf.Clamp(curAmmo, 0, 20);
    }
}
