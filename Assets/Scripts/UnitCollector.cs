using UnityEngine;

public class UnitCollector : MonoBehaviour
{
    private int _currentCountGold;

    private void Start()
        => _currentCountGold = 0;

    public void TakeGold(Gold gold)
    {
        gold.Destroy();
        _currentCountGold++;
    }

    public void GiveGold(Base unitsBase)
    {
        unitsBase.GetGold(_currentCountGold);
        _currentCountGold = 0;
    }
}
