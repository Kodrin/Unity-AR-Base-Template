using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Levitate : MonoBehaviour
{
    [Range(1,10)]
    [SerializeField] protected int seed = 1;
    [SerializeField] protected float speed = 1.0f;
    [SerializeField] protected float amplitude = 1.0f;
    [SerializeField] protected Vector3 initialPosition;


    void Start()
    {
        this.initialPosition = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float sinY = Mathf.Sin(Time.time * this.speed) * this.amplitude;
        this.transform.position = this.initialPosition + new Vector3(0, sinY, 0);
    }
}
