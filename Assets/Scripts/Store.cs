using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Purchasing;

public class Store : MonoBehaviour
{
    [SerializeField] private GameObject restoreButton;

    private const string NewCarId = "com.russell.simpledriving.newcar";
    public const string NewCarUnlockedKey = "NewCarUnlocked";

    private void Awake()
    {
        if(Application.platform != RuntimePlatform.IPhonePlayer)
        {
            restoreButton.SetActive(false);
        }
    }

    public void OnPurchaseComplete(Product product)
    {
        if(product.definition.id == NewCarId)
        { 
            PlayerPrefs.SetInt(NewCarUnlockedKey, 1); 
        }
    }

    public void OnPurchaseFailed(Product product, PurchaseFailureReason reason)
    {
        Debug.LogWarning($"Failed to purchse product {product.definition.id} because {reason}");
    }
}
