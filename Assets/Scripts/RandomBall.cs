using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomBall : MonoBehaviour
{

    public float speed  = 1.0f;
    public Vector3 acceleration;
    public Vector3 velocity;
    public Vector3 ballPosition;
     

    // Start is called before the first frame update
    void Start()
    {
        this.ballPosition = this.transform.position;
        this.acceleration = Vector3.zero;
        this.velocity = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        float dt = Time.deltaTime;
        Vector3 target = Vector3.zero;

        float r = Random.value;
        float x =  Mathf.PerlinNoise(Mathf.Sin(Random.value), Mathf.Cos(Random.value) ) * 2.0f - 1.0f;
        float y =  Mathf.PerlinNoise(Mathf.Sin(Random.value), Mathf.Cos(Random.value) ) * 2.0f - 1.0f;
        float z =  Mathf.PerlinNoise(Mathf.Sin(Random.value), Mathf.Cos(Random.value) ) * 2.0f - 1.0f;
        
        target = new Vector3(x, y, z);
        var targetDiff = target - this.transform.position;
      
        this.velocity += targetDiff * dt;
        this.transform.position += this.velocity;
    }

    /// <summary>
    /// Callback to draw gizmos that are pickable and always drawn.
    /// </summary>
    void OnDrawGizmos()
    {
        
    }
}
