using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawnMobs : MonoBehaviour
{
    public TilemapGenerator Gen;
    public GameObject[] Mob;
    public Transform Pos;
 
    
    void Start()
    {
        Spawn();
    }
    void Spawn()
    {
        for (int x = 50; x < Gen.Amount_Blocks-100; x += Random.Range(40, 50))
        {
            int i = Random.Range(0, Mob.Length);
            var SpawnMob = Instantiate(Mob[i], Pos);
            SpawnMob.transform.localPosition = new Vector3(x, 16f, 0);
        }
    }
}
