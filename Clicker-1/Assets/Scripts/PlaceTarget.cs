using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlaceTarget : MonoBehaviour
{
    [SerializeField] private Target _target;
    [SerializeField] private ClickerZone _clickerZone;

    public event UnityAction<Target> TargetDown;
    public event UnityAction<Target> TargetComplete;
    // Start is called before the first frame update
    void Start()
    {
  //      SetTarget(_target);
    }

    public void SetTarget(Target target)
    {
        _target = Instantiate(target, transform);
        _clickerZone.Click += _target.onClick;
        _target.TargetKilled += onTargetDone;
        Debug.Log("Событие привязано");
    }

    public void RemoveTarget(Target target)
    {
        _clickerZone.Click -= _target.onClick;
        _target.TargetKilled -= onTargetDone;
        Destroy(target.gameObject);
    }

    // Update is called once per frame
   public void onTargetDone()
    {
        TargetComplete?.Invoke(_target);
    }

    public void onCollected()
    {
        TargetDown?.Invoke(_target);
    }
}
