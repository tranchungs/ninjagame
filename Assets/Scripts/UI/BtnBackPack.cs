using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnBackPack : MonoBehaviour
{
    [SerializeField] private GameObject BackPack;
    public void OpenBackPack()
    {
        BackPack.SetActive(true);
    }
    public void CloseBackPack()
    {
        BackPack.SetActive(false);
    }
}
