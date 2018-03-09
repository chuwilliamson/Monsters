using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_ContainerBehaviour : MonoBehaviour
{
    // fields
    private Dropdown _dropdown;
    private bool opened = false;

    // Unity methods
    private void Start()
    {
        _dropdown = GetComponent<Dropdown>();
        _dropdown.ClearOptions();
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

        opened = true;
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

        opened = true;
        _dropdown.Show();
    }

    public void OnContainerClosed()
    {        
        _dropdown.ClearOptions();
        opened = false;
        _dropdown.Hide();
    }

    public void OnInventoryClosed()
    {        
        _dropdown.ClearOptions();
        opened = false;
        _dropdown.Hide();
    }

    private void Update()
    {
        if (opened != false)
        {
            if (Input.GetButtonDown("B Button"))
            {
                OnContainerClosed();
                OnInventoryClosed();
            }
        }
    }
}
