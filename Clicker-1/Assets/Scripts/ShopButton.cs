using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopButton : MonoBehaviour
{
    [SerializeField] private Shop _shop;
    [SerializeField] private Button OpenButton;
    [SerializeField] private Button CloseButton;
    // Start is called before the first frame update
    void Start()
    {
        _shop.gameObject.SetActive(false);
    }
    private void OnEnable()
    {
        OpenButton.onClick.AddListener(OpenShop);
        CloseButton.onClick.AddListener(CloseShop);
    }

    private void OnDisable()
    {
        OpenButton.onClick.RemoveListener(OpenShop);
        CloseButton.onClick.RemoveListener(CloseShop);
    }

    private void OpenShop()
    {
        _shop.gameObject.SetActive(true);
    }
    private void CloseShop()
    {
        _shop.gameObject.SetActive(false);
    }
}
