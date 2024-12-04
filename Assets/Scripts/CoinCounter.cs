using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CoinCounter : MonoBehaviour
{
    [SerializeField]
    private FloatSO coinSO;

    public int coins = 0; // The variable to display
    public TMP_Text coinText; // The TextMeshPro object to display

    private void Start()
    {
        coinText.SetText("????");
    }
    // Update is called once per frame
    void Update()
    {
        coinText.SetText("x" + coinSO.Value);
    }
}
