using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_collectingResourses : MonoBehaviour
{
    [SerializeField] private PlaceTarget _placetarget;
    [SerializeField] private Button button;
    [SerializeField] private Image _gold;
    [SerializeField] private Image _metal;
    [SerializeField] private Image _uranium;
    [SerializeField] private Image _platinum;
    [SerializeField] private Image _gas;
    [SerializeField] private Text _goldT;
    [SerializeField] private Text _metalT;
    [SerializeField] private Text _uraniumT;
    [SerializeField] private Text _platinumT;
    [SerializeField] private Text _gasT;
    // Start is called before the first frame update

    private Target currenttarget;
    private CanvasGroup canvasGroup;

    private void OnEnable()
    {
        _placetarget.TargetComplete += onTargetCompleted;
        button.onClick.AddListener(onClosedButton);
    }

    void Start()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        Close();
    }

    private void onClosedButton()
    {
        Close();
        _placetarget.onCollected();
    }

    private void onTargetCompleted(Target target)
    {
        currenttarget = target;
        Open();
    }

    private void Open()
    {
        canvasGroup.alpha = 1;
        _goldT.text = Convert.ToString(currenttarget.GoldProfit);
        _metalT.text = Convert.ToString(currenttarget.MetalProfit);
        _uraniumT.text = Convert.ToString(currenttarget.UraniumProfit);
        _platinumT.text = Convert.ToString(currenttarget.PlatinumProfit);
        _gasT.text = Convert.ToString(currenttarget.GasProfit);

        if(currenttarget.GoldProfit==0)
        {
            _goldT.color = new Color(0, 0, 0, 0);
            _gold.color = new Color(0, 0, 0, 0);
            _metalT.transform.position -= new Vector3(166f,0,0);
            _uraniumT.transform.position -= new Vector3(166f, 0, 0);
            _platinumT.transform.position -= new Vector3(166f, 0, 0);
            _gasT.transform.position -= new Vector3(166f, 0, 0);
        }

        if (currenttarget.MetalProfit == 0)
        {
            _metalT.color = new Color(0, 0, 0, 0);
            _metal.color = new Color(0, 0, 0, 0);
            _uraniumT.transform.position -= new Vector3(166f, 0, 0);
            _platinumT.transform.position -= new Vector3(166f, 0, 0);
            _gasT.transform.position -= new Vector3(166f, 0, 0);
        }

        if (currenttarget.UraniumProfit == 0)
        {
            _uraniumT.color = new Color(0, 0, 0, 0);
            _uranium.color = new Color(0, 0, 0, 0);
            _platinumT.transform.position -= new Vector3(166f, 0, 0);
            _gasT.transform.position -= new Vector3(166f, 0, 0);
        }
        if (currenttarget.PlatinumProfit == 0)
        {
            _platinum.color = new Color(0, 0, 0, 0);
            _platinumT.color = new Color(0, 0, 0, 0);
            _gasT.transform.position -= new Vector3(166f, 0, 0);
        }
        if (currenttarget.GasProfit == 0)
        {
            _gasT.color = new Color(0, 0, 0, 0);
            _gas.color = new Color(0, 0, 0, 0);
        }
    }

    private void Close()
    {
        canvasGroup.alpha = 0;
    }
}
