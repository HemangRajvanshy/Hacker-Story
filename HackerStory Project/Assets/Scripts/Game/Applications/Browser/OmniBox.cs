using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Collections.Generic;
using System.Collections;

public class OmniBox : MonoBehaviour {

    public GameObject SuggestionTemplate;
    public LayoutElement SuggestionLayout;
    public GameObject SiteSuggestionBox;
    public Text AdressBarText;

    private Dictionary<string, Tab> TabDict;

    void Start()
    {
        TabDict = new Dictionary<string, Tab>();
        SiteSuggestionBox.SetActive(false);
        SuggestionLayout.preferredHeight = Screen.height / 10f;
        foreach(string Suggestion in GameManager.Game.Hack.CurrentHack.TabAddress)
        {
            GameObject SugButton = Instantiate(SuggestionTemplate);
            SugButton.SetActive(true);
            SugButton.transform.SetParent(SuggestionTemplate.transform.parent);
            SugButton.transform.FindChild("Text").GetComponent<Text>().text = Suggestion;
            SugButton.transform.localScale = SuggestionTemplate.transform.localScale;
            SugButton.transform.position = SuggestionTemplate.transform.position;
        }
    }

    public void OnValueChange()
    {
        SiteSuggestionBox.SetActive(true);
    }
}
