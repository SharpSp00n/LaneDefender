using System.Collections;
using System.Collections.Generic;
using System.Data;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class EnemySpawner : MonoBehaviour
{

    [SerializeField] private Vector2 spawnLocation;
    public float Timer;
    public GameObject slimeBlue;
    public GameObject slimeGreen;
    public GameObject slimePink;
    private float picker;


    private void Start()
    {
        Timer = Random.Range(1, 7);
    }

    // Update is called once per frame
    void Update()
    {
        Timer -= Time.deltaTime;

        if (Timer <= 0)
        {
            picker = Random.Range(0, 3);
            if(picker == 0)
            {
                Instantiate(slimeBlue, spawnLocation, Quaternion.identity);
            }
            else if (picker == 1)
            {
                Instantiate(slimeGreen, spawnLocation, Quaternion.identity);
            }
            else
            {
                Instantiate(slimePink, spawnLocation, Quaternion.identity);
            }

                
            Timer = Random.Range(8, 16);
        }
    }

}