using System.Collections;
using UnityEngine;

public class GoldSpawner : MonoBehaviour
{
    [SerializeField] private Gold _goldTemplate;
    [SerializeField] private float _timeInSeconds;

    private void Start()
        => StartCoroutine(SpawnGold());
    
    private IEnumerator SpawnGold()
    {
        WaitForSeconds wait = new(_timeInSeconds);

        while (true) 
        {
            yield return wait;
            Instantiate(_goldTemplate, transform.position, Quaternion.identity);
        }
    }
}