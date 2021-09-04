using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Target : MonoBehaviour
{
    [SerializeField] private int Health;
    private float tekValue=1;
    [SerializeField] private Slider _Slider;
    [SerializeField] private int _KineticArmor = 1;
    [SerializeField] private int _EMArmor = 0;
    [SerializeField] private int _LaserArmor = 0;
    [SerializeField] private int _RocketArmor = 0;

    [SerializeField] private int _ProfitGold;
    [SerializeField] private int _ProfitMetal;
    [SerializeField] private int _ProfitUranium;
    [SerializeField] private int _ProfitPlatinum;
    [SerializeField] private int _ProfitGas;

    public event UnityAction TargetKilled;
    public int GoldProfit => _ProfitGold;
    public int MetalProfit => _ProfitMetal;
    public int UraniumProfit => _ProfitUranium;
    public int PlatinumProfit => _ProfitPlatinum;
    public int GasProfit => _ProfitGas;

    public int DefeatingProcess { get; private set; }

    public void IncreaceDefeatProcess(int damage)
    {
        DefeatingProcess+=damage;
        tekValue = (float)(Health - DefeatingProcess) / (float)Health;
        _Slider.value = tekValue;
    }

    private bool isPenetrated(DamageTypes types)
    {
        //if (types.Kinetic < _KineticArmor || types.EM < _EMArmor || types.Laser < _LaserArmor || types.Rocket < _RocketArmor)
        //{
        //    return false;
        //}
        //else
        //    return true;

        return !(types.Kinetic < _KineticArmor || types.EM < _EMArmor || types.Laser < _LaserArmor || types.Rocket < _RocketArmor);
    }

    private bool isDefeated()
    {
        return Health <= DefeatingProcess;         
    }

    private bool TryDefeatTarget(DamageTypes types, int damage)
    {
        if (isPenetrated(types))
        {
            IncreaceDefeatProcess(damage);
        }
        else
        {
            IncreaceDefeatProcess(1);
            Debug.Log("Броня не пробита");
        }
        return isDefeated();
    }

    public void AdvanceTarget(int level, int advance)
    {
        Health = Health * ((level / 5) + 1);
        if (advance > 0)
        {
            _KineticArmor = _KineticArmor * ((level / 20) + 1) + 1;
            _EMArmor = _KineticArmor * ((level / 20) + 1) + 1;
            _LaserArmor = _LaserArmor * ((level / 20) + 1) + 1;
            _RocketArmor = _RocketArmor * ((level / 20) + 1) + 1;
        }
        else
        {
            _KineticArmor = _KineticArmor * ((level / 20) + 1);
            _EMArmor = _KineticArmor * ((level / 20) + 1);
            _LaserArmor = _LaserArmor * ((level / 20) + 1);
            _RocketArmor = _RocketArmor * ((level / 20) + 1);
        }
    }
    private void Start()
    {
        _Slider = GameObject.Find("Slider").GetComponent<Slider>();
        _Slider.value = 1;
    }
    public void onClick(DamageTypes Types, int  damage)
    {
        if(TryDefeatTarget(Types,damage))
        {
            Debug.Log("Враг побежден");
            TargetKilled?.Invoke();
        }
        else
        {
            Debug.Log(DefeatingProcess.ToString());
        }

    }
}
