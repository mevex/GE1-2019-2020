using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform bulletSpawn;
    public int fireRate = 3;
    float elapsed = float.MaxValue;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float dTimeShooting = 1.0f / (float)fireRate;
        elapsed += Time.deltaTime;
        if (Input.GetKey(KeyCode.LeftControl) && (elapsed > dTimeShooting))
        {
            GameObject bullet = GameObject.Instantiate<GameObject>(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);
            elapsed = 0;
        }
    }
}
