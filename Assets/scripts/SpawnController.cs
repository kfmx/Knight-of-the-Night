using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    private GameObject controller;
    public GameObject prefab;
    private DayNightController controller2;
    private List<GameObject> enemies;
    private float timer;
    // Start is called before the first frame update
    void Start()
    {
        controller = GameObject.Find("NightAndDay");
        controller2 = controller.GetComponent<DayNightController>();
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (controller2.isNight)
        {
            if (timer <= 0)
            {
                SpawnMonsters();
            }
        } else if (!controller2.isNight)
        {
            if (enemies.Count > 0)
            {
                enemies = new List<GameObject>();
            }
        }
    }

    private void SpawnMonsters()
    {
        int days = controller2.GetDayCounter();
        timer = 10f;
        for (int i = 0; i < 5 * days+1; i++)
        {
            Instantiate(prefab);
        }
    }
}
