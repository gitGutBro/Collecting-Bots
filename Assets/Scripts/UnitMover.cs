using System.Collections;
using UnityEngine;

public class UnitMover : MonoBehaviour
{
    private const float Speed = 3f;

    public IEnumerator MoveToPoint(Vector3 point)
    {
        while (transform.position != point)
        {
            transform.position = Vector3.MoveTowards(transform.position, point, Speed * Time.deltaTime);
            yield return null;
        }
    }
}