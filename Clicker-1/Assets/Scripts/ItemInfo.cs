using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ItemInfo : MonoBehaviour
{
    [SerializeField] private int TimesBought=0;
    [SerializeField] private int LimitOfBought;
    [SerializeField] private Image targetImage;
    [SerializeField] private Sprite _image;
    [SerializeField] private Text _description;
    [SerializeField] private Button _buyButton;
    private SO_ShopItem _item;
    [SerializeField] private Text price;
    public event UnityAction<SO_ShopItem, ItemInfo> BuyButtonClick;

    private void OnEnable()
    {
        _buyButton.onClick.AddListener(OnButtonClick);
    }
    private void OnDisable()
    {
        _buyButton.onClick.RemoveListener(OnButtonClick);
    }

    public bool isDepleted()
    {
        return LimitOfBought <= TimesBought;
    }

    public void Disable()
    {
        _buyButton.interactable = false;
        _description.text="Распродано";
    }

    private void OnButtonClick()
    {
        BuyButtonClick?.Invoke(_item, this);
    }

    public void SetItem(SO_ShopItem item)
    {
        _item = item;
        _item._Price = new Loot(_item._newPrice.Gold, _item._newPrice.Metal, _item._newPrice.Uranium, _item._newPrice.Platinum, _item._newPrice.Gas);

        RenderItem(item);
    }

    private void RenderItem(SO_ShopItem item)
    {
        LimitOfBought = item.LimitOfBought;
        _image = item.Icon;
        _description.text = item.Description;
        targetImage.sprite= _image;
        price.text = item.getPrice.Gold + "  " + item.getPrice.Metal + " " + item.getPrice.Uranium + "\n" + item.getPrice.Platinum + " " + item.getPrice.Gas;
    }

    public void increaceBuy()
    {
        TimesBought++;
        if(TimesBought<10)
        _item.EditPrice(1.5, 1.5, 1.5, 1.5, 1.5, SO_ShopItem.EditType.MULTYPLY);
        else if (TimesBought < 30)
            _item.EditPrice(3, 3, 3, 3, 3, SO_ShopItem.EditType.MULTYPLY);
        else if (TimesBought < 60)
            _item.EditPrice(5, 5, 5, 5, 5, SO_ShopItem.EditType.MULTYPLY);
        else if (TimesBought < 100)
            _item.EditPrice(9, 9, 9, 9, 9, SO_ShopItem.EditType.MULTYPLY);
        RenderItem(_item);
    }
}
