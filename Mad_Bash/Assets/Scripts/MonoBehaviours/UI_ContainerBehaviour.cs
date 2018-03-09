using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_ContainerBehaviour : MonoBehaviour
{
    // fields
    private Dropdown _dropdown;

    // Unity methods
    private void Start()
    {
        _dropdown = GetComponent<Dropdown>();
        _dropdown.ClearOptions();

        _dropdown.Hide();
    }

    // methods
    public void OnContainerOpened(UnityEngine.Object[] args)
    {        
        _dropdown.ClearOptions();
        var sender = args[0] as ContainerBehaviour.ContainerEventData;
        if(sender == null)
            return;

        // make new option data list to populate dropdown
        var optionDataList = new List<Dropdown.OptionData>();

        // add those items to dropdown
        sender.Data.ForEach(i => optionDataList.Add(new Dropdown.OptionData(i.Name)));
        _dropdown.AddOptions(optionDataList);

        _dropdown.Show();
    }

    public void OnInventoryOpened(UnityEngine.Object[] args)
    {
        _dropdown.ClearOptions();
        var sender = args[0] as ContainerBehaviour.ContainerEventData;
        if (sender == null)
            return;

        // make new option data list to populate dropdown
        var optionDataList = new List<Dropdown.OptionData>();

        // add those items to dropdown
        sender.Data.ForEach(i => optionDataList.Add(new Dropdown.OptionData(i.Name)));
        _dropdown.AddOptions(optionDataList);

        _dropdown.Show();
    }

    public void OnContainerClosed()
    {
        _dropdown.Hide();
    }    
}
