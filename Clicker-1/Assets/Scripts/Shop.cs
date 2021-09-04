using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    [SerializeField] private List<SO_ShopItem> _ShopItems;
    [SerializeField] private Player _player;
    [SerializeField] private PlayerResourses _playerResourses;
    [SerializeField] private ItemInfo _newItem;
    [SerializeField] private Transform _container;

    // Start is called before the first frame update
    void Start()
    {
        for(int i=0;i<_ShopItems.Count;i++)
        {
            AddItem(_ShopItems[i]);
        }
    }

    public void TrySellItem(SO_ShopItem _item,ItemInfo _info)
    {
        if(_player.isEnoughtResourses(_item.getPrice))
        {
            _playerResourses.WithdrawResourses(_item.getPrice);
            _info.increaceBuy();
            _playerResourses.ChangeDamagePerTouch(_item.GetDamageType, _item.GetAmount);
        }
        if(_info.isDepleted())
        {
            _info.Disable();
        }
    }
    
    private void AddItem(SO_ShopItem _addeditem)
    {
        var item = Instantiate(_newItem, _container);
        InitializeItem(item, _addeditem);
    }

    private void OnBuyButtonClick(SO_ShopItem _item, ItemInfo item)
    {
        TrySellItem(_item, item);
    }
    private void InitializeItem(ItemInfo item, SO_ShopItem _addedItem)
    {
        item.SetItem(_addedItem);
        item.BuyButtonClick += OnBuyButtonClick;
        item.name = _newItem.name + (transform.childCount + 1);
    }

}
