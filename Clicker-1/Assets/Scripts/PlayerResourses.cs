using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerResourses : MonoBehaviour
{
    [SerializeField] private int _gold;
    [SerializeField] private int _metal;
    [SerializeField] private int _uranium;
    [SerializeField] private int _platinum;
    [SerializeField] private int _gas;


    [SerializeField] private int _KineticDamagePerTouch = 1;
    [SerializeField] private  int _EMDamagePerTouch = 0;
    [SerializeField] private  int _LaserDamagePerTouch = 0;
    [SerializeField] private  int _RocketDamagePerTouch = 0;

    [SerializeField] private int _KineticPenetration = 1;
    [SerializeField] private int _EMPenetration = 0;
    [SerializeField] private int _LaserPenetration = 0;
    [SerializeField] private int _RocketPenetration = 0;

    [SerializeField] private int _DamagePerTouch = 0;

    public int Kinetic => _KineticPenetration;
    public int EM => _EMPenetration;
    public int Laser => _LaserPenetration;
    public int Rocket => _RocketPenetration;


    public int GoldAmount => _gold;
    public int DamagePerTouch => _DamagePerTouch;
    public int MetalAmount => _metal;
    public int UraniumAmount => _uranium;
    public int PlatinumAmount => _platinum;
    public int GasAmount => _gas;

    public event UnityAction<int> resourseGoldChanged;
    public event UnityAction<int> resourseMetalChanged;

    void Start()
    {
        _DamagePerTouch = _KineticDamagePerTouch + _EMDamagePerTouch + _LaserDamagePerTouch + _RocketDamagePerTouch;
    }

    public void ChangeDamagePerTouch(DamageTypes.DamageType type,int value)
    {
        switch(type)
        {
            case DamageTypes.DamageType.Kinetic: _KineticDamagePerTouch += value;break;
            case DamageTypes.DamageType.EM: _EMDamagePerTouch += value; break;
            case DamageTypes.DamageType.Laser: _LaserDamagePerTouch += value; break;
            case DamageTypes.DamageType.Rocket: _RocketDamagePerTouch += value; break;
        }
        _DamagePerTouch = _KineticDamagePerTouch + _EMDamagePerTouch + _LaserDamagePerTouch + _RocketDamagePerTouch;
        //     DamageChanged?.Invoke(_DamagePerTouch);
    }



    public void AddTargetProfit(Loot looted)
    {
        _gold += looted.Gold;
        _metal += looted.Metal;
        _uranium += looted.Uranium;
        _platinum += looted.Platinum;
        _gas += looted.Gas;
        resourseGoldChanged?.Invoke(_gold);
        resourseMetalChanged?.Invoke(_metal);
    }

    public void WithdrawResourses(Loot price)
    {
        _gold -= price.Gold;
        _metal -= price.Metal;
        _uranium -= price.Uranium;
        _platinum -= price.Platinum;
        _gas -= price.Gas;
        resourseGoldChanged?.Invoke(_gold);
        resourseMetalChanged?.Invoke(_metal);
    }
}
