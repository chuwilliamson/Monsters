using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetTextBehaviour : MonoBehaviour {
    public StringVariable info;
    private string prefix;
    UnityEngine.UI.Text Text;
    private void Start()
    {
        Text = GetComponent<UnityEngine.UI.Text>();
        prefix = Text.text;
    }
    // Update is called once per frame
    void Update () {
        Text.text = prefix + " " + info.Value;
	}
}
