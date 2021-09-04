using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "New Shop Item", menuName = "Shop Item", order = 52)]
public class SO_ShopItem : ScriptableObject
{
 //   [SerializeField] private PlayerResourses _resourses;
    [SerializeField] private Sprite _image;
    [SerializeField] public int LimitOfBought;
    [SerializeField] private string _description;
//    [SerializeField] private Button _buyButton;
    [SerializeField] private DamageTypes.DamageType Type;
    [SerializeField] private int amount;
    [SerializeField] public Loot _Price;
    [SerializeField] public Loot _newPrice;
    
    /* [SerializeField] private int goldCost;
     [SerializeField] private int metalCost;
     [SerializeField] private int uraniumCost;
     [SerializeField] private int platinumCost;    [SerializeField] private int gasCost;*/

    public enum EditType
    {
        SUMM,
        MULTYPLY
    }

    public bool isBuy { get; private set; }
    public string Description => _description;
    public Sprite Icon => _image;

    public Loot getPrice => _Price;
    public void EditPrice(double ChangeGold, double ChangeMetal, double ChangePlatinum, double ChangeUranium, double ChangeGas, EditType T)
    {
        if(T==EditType.MULTYPLY)
        {
            _Price.Gold =(int)((double)_Price.Gold* ChangeGold);
            _Price.Metal = (int)((double)_Price.Metal * ChangeMetal);
            _Price.Platinum = (int)((double)_Price.Platinum * ChangePlatinum);
            _Price.Uranium = (int)((double)_Price.Uranium * ChangeUranium);
            _Price.Gas = (int)((double)_Price.Gas * ChangeGas);
        }
        else
        {
            _Price.Gold = (int)((double)_Price.Gold + ChangeGold);
            _Price.Metal = (int)((double)_Price.Metal + ChangeMetal);
            _Price.Platinum = (int)((double)_Price.Platinum + ChangePlatinum);
            _Price.Uranium = (int)((double)_Price.Uranium + ChangeUranium);
            _Price.Gas = (int)((double)_Price.Gas + ChangeGas);
        }
    }
    public DamageTypes.DamageType GetDamageType => Type;
    public int GetAmount => amount;
    public void Buy()
    {

        isBuy = true;
    }
}
