using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllSecretsManager : MonoBehaviour
{
    [HideInInspector] public string descriptionsReadString;

    private int descriptionsRead = 0;

    public static AllSecretsManager instance;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        descriptionsReadString = "Przeczytane opisy: 0 / 12";
    }

    public void AddDescriptionRead()
    {
        descriptionsRead += 1;

        descriptionsReadString = "Przeczytane opisy: " + descriptionsRead.ToString() + " / 12";
    }
}
