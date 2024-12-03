using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class Shop : MonoBehaviour
{
    public int coinCount = 100;

    public TextMeshProUGUI coinCountText;
    public GameObject shopItemPrefab;
    public GameObject itemsContent;

    [Serializable]
    public class ItemInfo
    {
        public string name;
        public int price;
        public bool owned;
        public bool equiped;
        public Sprite image;
    }

    public List<ItemInfo> items;


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
                newItem.buttonText.text = item.equiped ? "Un-equip" : "Equip";
            }
            else
            {
                newItem.buttonText.text = "Buy";
            }
            newItem.button.onClick.AddListener(new UnityEngine.Events.UnityAction(() =>
            {
                if (item.owned)
                {
                    if (item.equiped)
                    {
                        item.equiped = false;
                        newItem.buttonText.text = "Equip";
                    }
                    else
                    {
                        item.equiped = true;
                        newItem.buttonText.text = "Un-equip";
                    }
                }
                else
                {
                    BuyItem(item.name);
                    item.equiped = false;
                    newItem.buttonText.text = "Equip";
                }
            }));
        }
    }


    void Update()
    {
        coinCountText.text = $"x{coinCount}";
    }

    public void BuyItem(string name)
    {
        int price = GetItemPrice(name);
        coinCount -= price;
        SetItemOwned(name);
    }

    public void OnGotoMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
