using System.Collections;
using UnityEngine;

[RequireComponent(typeof(UnitCollector))]
[RequireComponent(typeof(UnitMover))]
public class Unit : MonoBehaviour
{
    private Base _base;
    private UnitCollector _collector;
    private UnitMover _mover;

    public bool IsBusy { get; private set; }

    private void Awake()
    {
        _base = GetComponentInParent<Base>();
        _collector = GetComponent<UnitCollector>();
        _mover = GetComponent<UnitMover>();
    }

    private void Start()
        => IsBusy = false;

    public IEnumerator CollectGold(Gold gold)
    {
        IsBusy = true;

        yield return _mover.MoveToPoint(gold.transform.position);

        _collector.TakeGold(gold);

        yield return _mover.MoveToPoint(_base.transform.position);

        _collector.GiveGold(_base);
        
        IsBusy = false;
        _base.GetUnit(this);
    }
}