using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AnimalSearching : MonoBehaviour
{
    [SerializeField] Sprite[] listAnimal;
    [SerializeField] Image target;
    [SerializeField] Image nextTarget;
    [SerializeField] TextMeshProUGUI name;
    [SerializeField] string[] listName;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetTarget(int id)
    {
        //target.sprite = listAnimal[id];
        name.text = listName[id];
    }

    public void SetNextTarget(int id)
    {
        //nextTarget.sprite = listAnimal[id];
        name.text = listName[id];
    }

    public int GetAmountAnimals()
    {
        return listAnimal.Length;
    }
}
