using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetSpawner : MonoBehaviour
{
    [SerializeField] private PlaceTarget _placetarget;
    [SerializeField] private List<Target> _targetTemplates;
    // Start is called before the first frame update
    private void Start()
    {
        SpawnTarget();
        
    }
    private void OnEnable()
    {
        _placetarget.TargetDown += onTargetDefeated;
    }

    private void OnDisable()
    {
        _placetarget.TargetDown -= onTargetDefeated;
    }

    private void SpawnTarget()
    {
        int rnd = Random.Range(0, _targetTemplates.Count);
        Target rndTarget = _targetTemplates[rnd];
        _placetarget.SetTarget(rndTarget);
    }

    private void onTargetDefeated(Target target)
    {
        _placetarget.RemoveTarget(target);
        Debug.Log("TargetRemoved");
        SpawnTarget();
    }
}
