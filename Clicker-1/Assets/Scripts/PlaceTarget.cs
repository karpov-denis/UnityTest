using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class PlaceTarget : MonoBehaviour
{
    [SerializeField] private Target _target;
    [SerializeField] private Text _levelEnum;
    [SerializeField] private ClickerZone _clickerZone;
    [SerializeField] private int _currentLevel=0;
    [SerializeField] private int _currentlocation = 1;

    public event UnityAction<Target> TargetDown;
    public event UnityAction<Target> TargetComplete;
    // Start is called before the first frame update
    void Start()
    {
  //      SetTarget(_target);
    }

    public void SetTarget(Target target)
    {

        _currentLevel++;
        if(_currentLevel>99)
        {
            _currentlocation++;
            _currentLevel = 1;
        }
        _levelEnum.text = _currentlocation + "-" + _currentLevel;
        _target = Instantiate(target, transform);
            _target.AdvanceTarget(((_currentlocation-1)*100)+_currentLevel);
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
