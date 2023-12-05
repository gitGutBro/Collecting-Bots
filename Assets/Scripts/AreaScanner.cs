using System.Collections.Generic;
using UnityEngine;

public class AreaScanner : MonoBehaviour
{
    private const float ScanningRadius = 20f;

    private Queue<Gold> _freeGold;

    private void Awake()
        => _freeGold = new Queue<Gold>();

    private void Update()
        => ScanningArea();

    public Gold TryGetGold()
    {
        _freeGold.TryDequeue(out Gold gold);
        return gold;
    }    

    private void ScanningArea()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, ScanningRadius);

        foreach (Collider collider in colliders)
            if (collider.gameObject.TryGetComponent(out Gold gold))
                if (_freeGold.Contains(gold) == false)
                    _freeGold.Enqueue(gold); 
    }
}