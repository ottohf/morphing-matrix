using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class Shop : MonoBehaviour
{

    public TextMeshProUGUI coinCountText;
    public GameObject shopItemPrefab;
    public GameObject itemsContent;

    [Serializable]
    public class ItemInfo
    {
        public string name;
        public int price;
        public bool owned;
        public bool equipped;
        public Sprite image;
    }

    public List<ItemInfo> items;
    [SerializeField]
    private FloatSO coinSO;


    // TODO: replace these:
    int GetItemPrice(string name)
    {
        var item = items.Find(x => x.name == name);
        return item.price;
    }

    void SetItemOwned(string name)
    {
        var item = items.Find((x) => x.name == name);
        item.owned = true;
    }


    // **************************

    void Start()
    {
        foreach (var item in items)
        {
            // var newObj = Instantiate(shopItemPrefab);
            // itemsContent.GetComponent<ScrollView>().Add(newObj.GetComponent<Image>());
            var newObj = Instantiate(shopItemPrefab, itemsContent.transform);
            var newItem = newObj.GetComponent<ShopItem>();
            newItem.nameText.text = item.name;
            newItem.priceText.text = $"x{item.price}";
            newItem.image.sprite = item.image;
            if (item.owned)
            {
                newItem.buttonText.text = item.equipped ? "Un-equip" : "Equip";
            }
            else
            {
                newItem.buttonText.text = "Buy";
            }
            if (coinSO.Value < item.price)
            {
                newItem.button.enabled = false;
            }
            newItem.button.onClick.AddListener(new UnityEngine.Events.UnityAction(() =>
            {
                if (item.owned)
                {
                    if (item.equipped)
                    {
                        item.equipped = false;
                        newItem.buttonText.text = "Equip";
                    }
                    else
                    {
                        item.equipped = true;
                        newItem.buttonText.text = "Un-equip";
                    }
                }
                else
                {
                    if (BuyItem(item.name)) {
                        item.equipped = false;
                        newItem.buttonText.text = "Equip";
                    };
                    
                }
            }));
        }
    }


    void Update()
    {
        coinCountText.text = $"x{coinSO.Value}";
    }

    public bool BuyItem(string name)
    {
        int price = GetItemPrice(name);
        if (coinSO.Value > price)
        {
            coinSO.Value -= price;
            SetItemOwned(name);
            return true;
        }
        else { return false; }

    }

    public void OnGotoMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
