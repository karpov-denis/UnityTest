using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NotEnoughtMoneyScript : MonoBehaviour
{
    [SerializeField] private Button button;
    // Start is called before the first frame update
    private void OnEnable()
    {
        button.onClick.AddListener(onClosedButton);
    }

    void Start()
    {
        Close();
    }
    private void onClosedButton()
    {
        Close();
    }
    private void Close()
    {
        gameObject.SetActive(false);

    }
}
