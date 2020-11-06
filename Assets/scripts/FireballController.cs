using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballController : MonoBehaviour
{

    public float speed = 0.5f;
    public Vector2 direction;
    public float distanciaRecorida;
    private Transform transform;
    // Start is called before the first frame update
    void Start()
    {
        transform = this.GetComponent<Transform>();
        speed = 10.0f;
        distanciaRecorida = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {

        float lastPositionX = transform.position.x;


        transform.position = new Vector3(this.transform.position.x + (speed * Time.deltaTime) * direction.x, this.transform.position.y, this.transform.position.z);
        if(direction.x > 0)
        {
            transform.rotation = new Quaternion(this.transform.rotation.x, 0.0f, this.transform.rotation.z, this.transform.rotation.w);
        }
        else
        {
            transform.rotation = new Quaternion(this.transform.rotation.x, 90.0f, this.transform.rotation.z, this.transform.rotation.w);
        }

        distanciaRecorida += Math.Abs(transform.position.x - lastPositionX);

        if(distanciaRecorida > 5)
        {
            Destroy(gameObject);
        }
    }

    void SetDirection(Vector2 direction)
    {
        this.direction = direction;
    }
}
