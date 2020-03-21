using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BaseKinematic
{
    public Vector3 position;
    public Vector3 nextPosition;
    public float speed;
    public float radius;
    public float distanceThreshold;
    public Vector3 bounds;
    protected float size = 0.1f;
    private float startTime;
    private float journeyLength;
    

    public BaseKinematic(Vector3 position, Vector3 bounds, float speed, float radius, float distanceThreshold)
    {
        this.bounds = bounds;
        this.position = position;
        this.nextPosition = this.SetNextPosition();
        this.speed = speed;
        this.radius = radius;
        this.distanceThreshold = distanceThreshold;
    }

    public void Move()
    {
        // this.Borders();
        if(!this.CheckDistance())
            this.position = this.Lerp();
        else
            this.nextPosition = this.SetNextPosition();
    }

    internal void Borders()
    {
        //bounds
        // if(this.position.x < -this.bounds.x * 0.5f) 	this.position.x = this.bounds.x * 0.5f;
        // if(this.position.x > this.bounds.x * 0.5f) 		this.position.x = -this.bounds.x * 0.5f;
        // if(this.position.y < -this.bounds.y * 0.5f) 	this.position.y = this.bounds.y * 0.5f;
        // if(this.position.y > this.bounds.y * 0.5f) 		this.position.y = -this.bounds.y * 0.5f;
        // if(this.position.z < -this.bounds.z * 0.5f) 	this.position.z = this.bounds.z * 0.5f;
        // if(this.position.z > this.bounds.z * 0.5f) 		this.position.z = -this.bounds.z * 0.5f;

        //normalized
        if(this.position.x < 0) 	this.position.x = 1;
        if(this.position.x > 1) 	this.position.x = 0;
        if(this.position.y < 0) 	this.position.y = 1;
        if(this.position.y > 1) 	this.position.y = 0;
        if(this.position.z < 0) 	this.position.z = 1;
        if(this.position.z > 1) 	this.position.z = 0;
    }

    internal Vector3 SetNextPosition()
    {

        // Keep a note of the time the movement started.
        this.startTime = Time.time;
        // Calculate the journey length.
        this.journeyLength = Vector3.Distance(this.position, this.nextPosition);

        //sine
        // float x = Mathf.Sin(Random.Range(-1.0f,1.0f));
        // float y = Mathf.Sin(Random.Range(-1.0f,1.0f));
        // float z = Mathf.Sin(Random.Range(-1.0f,1.0f));

        //bounds
        // float x = Random.Range(-this.bounds.x * 0.5f, this.bounds.x * 0.5f);
        // float y = Random.Range(-this.bounds.y * 0.5f, this.bounds.y * 0.5f);
        // float z = Random.Range(-this.bounds.z * 0.5f, this.bounds.z * 0.5f);

        Vector3 insideSphere = this.position + (Random.insideUnitSphere * this.radius);
        //normalized
        // float x = Random.Range(0.0f, 1.0f);
        // float y = Random.Range(0.0f, 1.0f);
        // float z = Random.Range(0.0f, 1.0f);

        // return new Vector3(x,y,z);
        return insideSphere;
    }
    internal bool CheckDistance()
    {
        if(Vector3.Distance(this.position, this.nextPosition) < this.distanceThreshold)
            return true;
        else	
            return false;
    }

    internal Vector3 Lerp()
    {
        float distCovered = (Time.time - startTime) * speed;
        float fractionOfJourney = distCovered / journeyLength;
        return Vector3.Lerp(this.position, this.nextPosition, fractionOfJourney);
    }

    internal Vector3 Seek()
    {
        Vector3 desired = this.nextPosition - this.position;
        return desired * this.speed;
    }
    internal Vector3 Add(Vector3 target, Vector3 location)
    {
        Vector3 addition = target + location;
        return addition;
    }
    internal Vector3 Multiply(Vector3 target, float modfier)
    {
        Vector3 mult = target * modfier;
        return mult;
    }


    public virtual void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireCube(this.position, this.bounds);
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(this.position, this.size);
    }


}
public class Kinematic : MonoBehaviour
{
    [SerializeField] protected BaseKinematic kinematic;
    [SerializeField] protected Vector3 bounds = Vector3.one;
    [SerializeField] protected float speed = 1.0f;
    [SerializeField] protected float radius = 1.0f;
    [SerializeField] protected float distanceThreshold = 1.0f;

    void Start()
    {
        this.kinematic = new BaseKinematic(
            this.transform.position,
            this.bounds,
            this.speed,
            this.radius,
            this.distanceThreshold
        );
    }

    void Update()
    {
        this.kinematic.Move();
        this.transform.position = this.kinematic.position;
    }


    void UpdateKinematicParams()
    {
        this.kinematic.bounds = this.bounds;
        this.kinematic.speed = this.speed;
        this.kinematic.radius = this.radius;
        this.kinematic.distanceThreshold = this.distanceThreshold;

    }
    void OnDrawGizmos()
    {
        this.kinematic.OnDrawGizmos();
    }
}
