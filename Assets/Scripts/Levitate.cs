using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Levitate : MonoBehaviour
{
    [SerializeField] protected bool USE_RANDOM_ROTATION = true;
    [SerializeField] protected Vector3 levitateDirection = new Vector3(0,1,0);
    [SerializeField] protected Vector3 levitateRandomWeight = new Vector3(0,0,0);
    [SerializeField] protected Vector3 rotationDirection;
    [SerializeField] protected float rotationTimeSpeed = 100.0f;
    [SerializeField] protected float rotationSpeed = 1.0f;
    [SerializeField] protected float levitateSpeed = 1.0f;
    [SerializeField] protected float levitateAmplitude = 1.0f;
    [SerializeField] protected Vector3 initialPosition;


    void Start()
    {
        this.initialPosition = this.transform.position;
    }

    void Update()
    {
        float randomPerlin = Mathf.PerlinNoise(Time.time, Time.time);
        float sinY = Mathf.Sin(Time.time * this.levitateSpeed) * this.levitateAmplitude;
        this.transform.position = this.initialPosition + new Vector3(
            this.levitateDirection.x * sinY + ((this.levitateRandomWeight.x * randomPerlin * this.levitateSpeed) * this.levitateAmplitude), 
            this.levitateDirection.y * sinY + ((this.levitateRandomWeight.y * randomPerlin * this.levitateSpeed) * this.levitateAmplitude), 
            this.levitateDirection.z * sinY + ((this.levitateRandomWeight.z * randomPerlin * this.levitateSpeed) * this.levitateAmplitude)
            );

        if(this.USE_RANDOM_ROTATION)
        {
            float smooth = Time.deltaTime * this.rotationSpeed * rotationTimeSpeed;
            transform.Rotate(this.rotationDirection * smooth);
        }
    }
}
