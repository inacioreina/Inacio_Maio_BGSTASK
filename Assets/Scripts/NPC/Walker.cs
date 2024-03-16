using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Walker : MonoBehaviour
{
    public Rigidbody2D body;
    public float walkSpeed;
    public List<GameObject> navPoints;
    Vector3 _target;
    private bool _canMove = true;

    void Start()
    {
        NewPoint();
    }

    void Update()
    {
        if(_canMove)
        {
            WalkTo(_target);
        }
        
    }

    void WalkTo(Vector3 point)
    {
        //Debug.Log("Distance: " + Vector2.Distance(point, transform.position));
        
        if(Vector2.Distance(point, transform.position) > 0.6f)
        {
            body.velocity = (point - transform.position).normalized * walkSpeed;
        }
        else
        {
            StartCoroutine(StopAndGetNewPoint());
        }
        
    }

    void NewPoint()
    {
        //Debug.Log("New Point");
        if (navPoints == null)
        {
            throw new System.NullReferenceException("navPoints is null");
        }
        else if (navPoints.Count == 0)
        {
            throw new System.InvalidOperationException("navPoints is empty");
        }
        int randomIndex = Random.Range(0, navPoints.Count);
        //Debug.Log("New Point: " + randomIndex);
        _target = navPoints[randomIndex].transform.position;
        
    }

    private IEnumerator<object> StopAndGetNewPoint()
    {
        ToggleCanMove();
        NewPoint();
        yield return new WaitForSeconds(Random.Range(3f, 12f));
        ToggleCanMove();
    }

    public void ToggleCanMove()
    {
        _canMove = !_canMove;
        body.velocity = Vector2.zero;
    }
}
