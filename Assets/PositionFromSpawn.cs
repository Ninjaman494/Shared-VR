using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PositionFromSpawn : MonoBehaviour
{

    public Text text;
    private Vector3 spawnCoord;

    // Start is called before the first frame update
    void Start()
    {
        spawnCoord = gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 playerCoord = gameObject.transform.position;
        Vector3 displacement = playerCoord - spawnCoord;
        text.text = displacement.ToString();
    }
}
