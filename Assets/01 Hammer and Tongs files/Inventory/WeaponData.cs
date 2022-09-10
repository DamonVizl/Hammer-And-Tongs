using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public  class WeaponData : ItemData
{

    //properties
    [SerializeField]
    //weapon data
    float weaponDmg;
    float baseWeaponDamage = 10f;

    private int minItemLevel = 1;
    private int maxItemLevel = 99;

   
    

    //explosive force for spawning from chest
    
    private int explosiveForce = 100;
    //Functions

    public void Awake()
    {
        SetVariables();
        Rigidbody rb = this.GetComponent<Rigidbody>();

        Vector3 randomSpawnDirection = new Vector3(Random.Range(-1f, 2f)*explosiveForce, explosiveForce, Random.Range(-1f, -1.5f)*explosiveForce);
        rb.AddForce(randomSpawnDirection);
        rb.AddRelativeTorque(Vector3.right*explosiveForce);
        //rb.detectCollisions = false;
        //rb.useGravity = false;
    }

    public void SetVariables()
    {
        itemLevel = Random.Range(minItemLevel, 10);
        weaponDmg = itemLevel * baseWeaponDamage;

    }
    

}
