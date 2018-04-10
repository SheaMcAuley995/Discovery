using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class RotationRandomized : MonoBehaviour {

    public float rotationSpeed = 3.0f;



    public float rotateX;

    public float rotateY;
    
    public float rotateZ;


    private void Start()
    {
        rotateX = Random.Range(-25f, 25f);
        rotateY = Random.Range(-25f, 25f);
        rotateZ = Random.Range(-25f, 25f);
    }


    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(rotateX, rotateY, rotateZ) * Time.deltaTime, Space.World);
    }


}
