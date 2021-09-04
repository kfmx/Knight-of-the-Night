using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    [SerializeField]
    private DayNightController dnController;
    private GameObject controller;
    public GameObject prefab;
    private List<GameObject> enemies;
    private float timer;

    void Update()
    {
        timer -= Time.deltaTime;
        if (dnController.isNight)
        {
            if (timer <= 0)
            {
                SpawnMonsters();
            }
        } else if (!dnController.isNight)
        {
            var enemies = GameObject.FindGameObjectsWithTag("Enemy");
            foreach (var enemy in enemies) {
                Destroy(enemy);
            }
        }
    }

    private void SpawnMonsters()
    {
        int days = dnController.GetDayCounter();
        timer = 10f;
        for (int i = 0; i < 5 * days+1; i++)
        {
            Instantiate(prefab);
        }
    }
}
