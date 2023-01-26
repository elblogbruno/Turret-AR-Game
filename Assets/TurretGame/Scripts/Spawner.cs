using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public static Spawner Instance { get; private set; }

    // The plane prefab
    [SerializeField] private GameObject redPlane;
    [SerializeField] private GameObject greenPlane;

    [SerializeField] private GameObject rainBowPlane;


    // The position of the turret
    private Vector3 turretPosition;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void setTurretPosition(Vector3 position)
    {
        turretPosition = position;
    }

    public void spawnPlane(GameObject plane)
    {
        // random height to add from the turret position
        float randomHeight = Random.Range(0.5f, 1.5f);

        // random depth to add from the turret position
        float randomDepth = Random.Range(0.5f, 1.5f);

        Vector3 planePosition = new Vector3(0.0f, turretPosition.y + randomHeight, turretPosition.z + randomDepth);

        // Spawn a plane at the turret position
        GameObject  planeSpawnPoint = Instantiate(plane, planePosition, Quaternion.identity);
    }

    public void spawnRedPlane()
    {
        spawnPlane(redPlane);
    }

    public void spawnGreenPlane()
    {
        spawnPlane(greenPlane);
    }

    public void spawnRainbowPlane()
    {
        spawnPlane(rainBowPlane);
    }

    public void spawnRedPlaneAfterTime(float delay)
    {
        Invoke("spawnRedPlane", delay);
    }

    public void spawnGreenPlaneAfterTime(float delay)
    {
        Invoke("spawnGreenPlane", delay);
    }

    public void spawnRainbowPlaneAfterTime(float delay)
    {
        Invoke("spawnRainbowPlane", delay);
    }
}
