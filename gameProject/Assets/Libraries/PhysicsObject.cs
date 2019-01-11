using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsObject : MonoBehaviour {

    public float minGroundNormalY = 0.65f;
    public float gravityModifier = 2f;

    protected Vector2 targetVelocity;
    protected Vector2 velocity;
    protected Vector2 groundNormal;
    protected Rigidbody2D rb2d;
    protected ContactFilter2D contactFilter;
    protected RaycastHit2D[] hitBuffer = new RaycastHit2D[16];
    protected List<RaycastHit2D> hitBufferList = new List<RaycastHit2D>(16);

    protected const float minMoveDistance = 0.001f;
    protected const float shellRaduis = 0.01f;

    void OnEnable()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Use this for initialization
    void Start ()
    {
        contactFilter.useTriggers = false;
        contactFilter.SetLayerMask(Physics2D.GetLayerCollisionMask(gameObject.layer)); // In [Edit->Project Setttings->Physics 2D->Layer Collisoin Matrix] there is matrix which. This line of code tells it to use that matrix to determine what will collide with what 
        contactFilter.useLayerMask = true;
    }

    // Update is called once per frame
    void Update()
    {
        targetVelocity = Vector2.zero;
        ComputeVelocity();
    }

    protected virtual void ComputeVelocity()
    {

    }

    void FixedUpdate()
    {
        velocity = targetVelocity;

        Vector2 deltaPosition = velocity * Time.deltaTime;

        Movement(deltaPosition);
    }

    void Movement(Vector2 move) //Move is a vector to calculate the direction
    {
        float distance = move.magnitude;

        if (distance > minMoveDistance)
        {
            int count = rb2d.Cast(move, contactFilter, hitBuffer, distance + shellRaduis);
            hitBufferList.Clear();

            for (int i = 0; i < count; i++)
                hitBufferList.Add(hitBuffer[i]);

            for (int i = 0; i < hitBufferList.Count; i++)
            {
                Vector2 currentNormal = hitBufferList[i].normal;

                float projection = Vector2.Dot(velocity, currentNormal);
                if (projection < 0) // kills the velocity in the currentNormal angle
                {
                    velocity = velocity - projection * currentNormal;
                }

                float modifiedDistance = hitBufferList[i].distance - shellRaduis; // the distance from a collider minus the shell raduis.
                distance = modifiedDistance < distance ? modifiedDistance : distance; //distance will be the min from the both, that why it won't get in a collider(the other object)
            }
        }

        rb2d.position = rb2d.position + move.normalized * distance;
    }
}
