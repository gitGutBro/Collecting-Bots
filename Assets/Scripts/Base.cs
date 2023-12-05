using UnityEngine;

[RequireComponent(typeof(UnitsCommander))]
public class Base : MonoBehaviour 
{
    private UnitsCommander _commander;

    public int CountGold { get; private set; }

    private void Awake()
        => _commander = GetComponent<UnitsCommander>();

    private void Start()
        => CountGold = 0;

    public void GetGold(int countGold)
        => CountGold += countGold;

    public void GetUnit(Unit unit)
        => _commander.GetFreeUnit(unit);
}