using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PillowScript : MonoBehaviour
{
    [SerializeField]
    private GameObject[] pillowSpawners;

    private List<GameObject> pillows = new List<GameObject>();
    [SerializeField]
    private GameObject pillowPrefab;


    [SerializeField]
    private GameObject[] enemySpawners;

    private List<GameObject> enemys = new List<GameObject>();
    [SerializeField]
    private GameObject enemyPrefab;

    void Start()
    {
        pillows.AddRange(GameObject.FindGameObjectsWithTag("Pillow"));
        PlayerMovement.swappedToDay.AddListener(RemovePillows);
        PlayerMovement.swappedToNight.AddListener(RespawnPillows);

        PlayerMovement.swappedToDay.AddListener(RespawnEnemys);
        PlayerMovement.swappedToNight.AddListener(RemoveEnemys);

        if (PlayerMovement.isDay)
        {
            RespawnEnemys();
            RemovePillows();
        }
        else
        {
            RemoveEnemys();
            RespawnPillows();
        }
    }
    // Update is called once per frame
    void Update()
    {
        return;
        foreach (GameObject obj in pillows)
            if (obj != null)
                obj.SetActive(!PlayerMovement.isDay);
    }


    public void RespawnPillows()
    {
        RemovePillows();
        print("spawning pillows");
        foreach (GameObject obj in pillowSpawners)
            pillows.Add(Instantiate(pillowPrefab, obj.transform.position, obj.transform.rotation, obj.transform));

    }

    public void RemovePillows()
    {
        foreach (GameObject obj in pillows)
            if (obj != null)
                Destroy(obj);
        pillows.Clear();
    }



    public void RespawnEnemys()
    {
        print("spawning enemys");
        RemoveEnemys();

        foreach (GameObject obj in enemySpawners)
            enemys.Add(Instantiate(enemyPrefab, obj.transform.position, obj.transform.rotation, obj.transform));

    }

    public void RemoveEnemys()
    {
        foreach (GameObject obj in enemys)
            if (obj != null)
                Destroy(obj);
        enemys.Clear();
    }
}
