using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AreaScanner))]
public class UnitsCommander : MonoBehaviour
{
    private AreaScanner _scanner;
    private Queue<Unit> _freeUnits;

    private void Awake()
    {
        _scanner = GetComponent<AreaScanner>();
        Unit[] units = GetComponentsInChildren<Unit>();
        _freeUnits = new Queue<Unit>();

        foreach (Unit unit in units)
            _freeUnits.Enqueue(unit);
    }

    private void Start()
        => StartCoroutine(StartWorking());

    public void GetFreeUnit(Unit unit)
        => _freeUnits.Enqueue(unit);
    
    private IEnumerator StartWorking()
    {
        while(true)
        {
            if (TryGiveOrder(out Unit freeUnit))
                TryUnitRelease(freeUnit);

            yield return null;
        }
    }

    private bool TryGiveOrder(out Unit freeUnit)
    {
        Gold gold = _scanner.TryGetGold();
        bool isUnitFree = _freeUnits.TryDequeue(out freeUnit);

        if (gold != null && isUnitFree)
            GiveOrderCollectGold(gold, freeUnit);

        return isUnitFree;
    }

    private void TryUnitRelease(Unit freeUnit)
    {
        if (freeUnit != null && freeUnit.IsBusy == false)
            _freeUnits.Enqueue(freeUnit);
    }

    private void GiveOrderCollectGold(Gold gold, Unit unit)
        => StartCoroutine(unit.CollectGold(gold));
}