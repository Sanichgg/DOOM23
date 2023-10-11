using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIPricel : MonoBehaviour
{
    [SerializeField] Image pricelImage;
    public bool CanSoot { get; set; }

    private void Update()
    {
        pricelImage.color = CanSoot ? Color.red : Color.white;
    }
}
