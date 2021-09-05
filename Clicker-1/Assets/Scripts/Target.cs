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

    public void AdvanceTarget(int level)
    {
        Health =(int)((float)Health* 0.5*level);
        _KineticArmor = (int)(_KineticArmor * 0.3 * level);
        _EMArmor = (int)(_EMArmor * 0.3 * level);
        _LaserArmor = (int)(_LaserArmor * 0.3 * level);
        _RocketArmor = (int)(_RocketArmor * 0.3 * level);
        _ProfitGold = (int)(_ProfitGold * 1.05 * level);
        _ProfitMetal = (int)(_ProfitMetal * 1.05 * level);
        _ProfitUranium = (int)(_ProfitUranium * 1.05 * level);
        _ProfitPlatinum = (int)(_ProfitPlatinum * 1.05 * level);
        _ProfitGas = (int)(_ProfitGas * 1.05 * level);
        if (level >30)
        {
            _KineticArmor++;
            _EMArmor++;
            _LaserArmor++;
            _RocketArmor++;
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
