using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Walker : MonoBehaviour
{
    public Rigidbody2D body;
    public float walkSpeed;
    public GameObject navPoints;
    List<Transform> _navPointsList;

    Vector3 _target;

    int _pointIndex = 0;

    bool _canMove = true;

    void Start()
    {
        navPoints.transform.parent = null;
        _navPointsList = navPoints.GetComponentsInChildren<Transform>().ToList();
        _navPointsList.RemoveAt(0);
        SetTarget();
    }

    void Update()
    {
        if (_canMove)
        {
            WalkTo(_target);
        }

    }

    void WalkTo(Vector3 point)
    {
        //Debug.Log("Distance: " + Vector2.Distance(point, transform.position));

        if (Vector2.Distance(point, transform.position) > 0.1f)
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
        if (_pointIndex < _navPointsList.Count - 1)
        {
            _pointIndex++;
        }
        else
        {
            _pointIndex = 0;
        }
        SetTarget();
    }

    void SetTarget()
    {
        _target = _navPointsList[_pointIndex].position;
    }

    private IEnumerator<object> StopAndGetNewPoint()
    {
        ToggleCanMove();
        NewPoint();
        yield return new WaitForSeconds(Random.Range(3f, 6f));
        ToggleCanMove();
    }

    public void ToggleCanMove()
    {
        _canMove = !_canMove;
        body.velocity = Vector2.zero;
    }
}
