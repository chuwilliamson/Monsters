using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_ContainerBehaviour : MonoBehaviour
{
    private Dropdown _dropdown;
    private void Start()
    {
        _dropdown = GetComponent<Dropdown>();
        _dropdown.ClearOptions();
        
    }
    public void OnLootBoxOpened(UnityEngine.Object[] args)
    {
        _dropdown.ClearOptions();
        var sender = args[0] as Container;
        if(sender == null)
            return;

        // make new option data list to populate dropdown
        var optionDataList = new List<Dropdown.OptionData>();

        // unpack objects as items
        var items = new List<Item>();
        sender.contents.ForEach(obj => items.Add(obj as Item));        

        // add those items to dropdown
        items.ForEach(i => optionDataList.Add(new Dropdown.OptionData(i.Name)));
        _dropdown.AddOptions(optionDataList);
    }
}
