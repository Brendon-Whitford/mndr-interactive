using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDatabase : MonoBehaviour
{
    public List<Item> items = new List<Item>();

    private void Awake()
    {
        BuildItemDatabase();
    }
    public Item GetItem(int id)
    {
        return items.Find(item => item.id == id);
    }

    public Item GetItem(string title)
    {
        return items.Find(item => item.title == title);
    }

    void BuildItemDatabase()
    {
        items = new List<Item>()
        { 
            new Item(1, "Ball", "just a ball.", 
            new Dictionary<string, int>{
                {"Power", 15 },
                {"Defence", 7 }
            }),
             new Item(2, "Cube", "just a Cube.",
            new Dictionary<string, int>{
                {"Power", 0 },
                {"Defence", 0}
            }),
              new Item(3, "Sawcon", "the chainsaw convention.",
            new Dictionary<string, int>{
                {"Value",500 }
            }),
        };

       // items[0].stats["Power"].ToString();
    }
}
