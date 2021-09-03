using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerResourses : MonoBehaviour
{
    private int _gold;
    private int _metal;
    private int _uranium;
    private int _platinum;
    private int _gas;
    [SerializeField] private int _DamagePerTouch = 1;
    public int GoldAmount => _gold;
    public int DamagePerTouch => _DamagePerTouch;
    public int MetalAmount => _metal;
    public int UraniumAmount => _uranium;
    public int PlatinumAmount => _platinum;
    public int GasAmount => _gas;

    public event UnityAction<int> resourseGoldChanged;
    public event UnityAction<int> resourseMetalChanged;
  //  public event UnityAction<int> DamageChanged;
    // Start is called before the first frame update

    public void ChangeDamagePerTouch(int value)
    {
        _DamagePerTouch += value;
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
}
