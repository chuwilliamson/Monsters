using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Linq;

public class UI_InventoryBehaviour : MonoBehaviour
{
    TMPro.TMP_Dropdown dropdown;

    public Container PlayerContainer
    {
        get { return Resources.Load<PlayerContainer>("PlayerContainer"); }
    }

    private void OnEnable()
    {
        dropdown = GetComponent<TMPro.TMP_Dropdown>();
        dropdown.ClearOptions();
        var names = new List<string>();
        PlayerContainer.contents.ForEach(item => names.Add(item.name));
        dropdown.AddOptions(names);
    }
}
