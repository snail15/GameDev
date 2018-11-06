using System.Collections.Generic;
using UnityEngine;

public class CubeFactory : MonoBehaviour
{

    private BoxCollider _area;

    public GameObject[] cubePrefabs;

    public int count;

    private List<GameObject> cubes = new List<GameObject>();

    // Use this for initialization
    void Start()
    {
        _area = GetComponent<BoxCollider>();

        for (int i = 0; i < count; i++)
        {
            Spawn();
        }

        _area.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void Spawn()
    {
        int selection = Random.Range(0, cubePrefabs.Length);

        GameObject selectedCube = cubePrefabs[selection];

        Vector3 spawnPos = GetRandomPosition();

        GameObject instance = Instantiate(selectedCube, spawnPos, Quaternion.identity);

        cubes.Add(instance);
    }

    private Vector3 GetRandomPosition()
    {
        Vector3 basePosition = transform.position;
        Vector3 size = _area.size;

        float posX = basePosition.x + Random.Range(-size.x / 2f, size.x / 2f);
        float posY = basePosition.y + Random.Range(-size.y / 2f, size.y / 2f);
        float posZ = basePosition.z + Random.Range(-size.z / 2f, size.z / 2f);

        return new Vector3(posX, posY, posZ);
    }

    public void Reset()
    {
        for (int i = 0; i < cubes.Count; i++)
        {
            cubes[i].transform.position = GetRandomPosition();
            cubes[i].SetActive(true);
        }

    }
}
