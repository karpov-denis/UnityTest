using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Target : MonoBehaviour
{
    [SerializeField] private int Health;
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

    // Start is called before the first frame update
    public int DefeatingProcess { get; private set; }
    public void IncreaceDefeatProcess(int damage)
    {
        DefeatingProcess+=damage;
    }

    private bool isDefeated()
    {
        return Health <= DefeatingProcess;         
    }

    private bool TryDefeatTarget(int damage)
    {
        IncreaceDefeatProcess(damage);
        return isDefeated();
    }


    public void onClick(int  damage)
    {
        if(TryDefeatTarget(damage))
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
