using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Collections.Generic;
using System.Collections;

public class OmniBox : MonoBehaviour {

    public GameObject SuggestionTemplate;
    public LayoutElement SuggestionLayout;
    public GameObject SiteSuggestionBox;
    public InputField AdressBarText;

    private Dictionary<string, GameObject> TabDict;

    void Start()
    {
        TabDict = new Dictionary<string, GameObject>();
        TabDict.Add("", transform.parent.GetComponent<Browser>().HomeTab.gameObject);
        SiteSuggestionBox.SetActive(false);
        SuggestionLayout.preferredHeight = Screen.height / 10f;

        foreach (GameObject TabObject in GameManager.Game.Hack.CurrentHack.Tabs)
        {
            GameObject Tab = Instantiate(TabObject); // Create the Tab, set its parent, and reset values.
            Tab tab = Tab.GetComponent<Tab>();
            Tab.transform.SetParent(GameManager.Game.Hack.Browser.Tabs.transform);
            Tab.transform.localScale = GameManager.Game.Hack.Browser.Tabs.transform.localScale;
            Tab.transform.position = GameManager.Game.Hack.Browser.Tabs.transform.position;
            Tab.GetComponent<RectTransform>().offsetMin = new Vector2(0, 0);
            Tab.GetComponent<RectTransform>().offsetMax = new Vector2(0, 0);

            GameObject SugButton = Instantiate(SuggestionTemplate); // Create a button for the tab and put it in Layout Group.
            SugButton.SetActive(true);
            SugButton.transform.SetParent(SuggestionTemplate.transform.parent);
            SugButton.transform.FindChild("Text").GetComponent<Text>().text = tab.Address;
            SugButton.transform.localScale = SuggestionTemplate.transform.localScale;
            SugButton.transform.position = SuggestionTemplate.transform.position;
            string sug = tab.Address; // Call it for something to do with Pointers and stuff. Doesn't work otherwise. Edit: No I don't know anymore I changed stuff, but let it be.
            SugButton.GetComponent<Button>().onClick.AddListener(() => { OnSuggestionClick(sug); });

            TabDict.Add(tab.Address, Tab); // Put the tab address and GameObject instance in the dictionary for easy access. 
            Tab.SetActive(false); 
        }

    }

    public void OnValueChange()
    {
        SiteSuggestionBox.SetActive(true);
    }

    public void OnEndEdit()
    {
        StartCoroutine(WaitBeforeResolve(0.2f));
    }

    public void OnSuggestionClick(string Suggestion)
    {
        AdressBarText.text = Suggestion;
        SiteSuggestionBox.SetActive(false);
    }

    public void SetAddress(string address)
    {
        AdressBarText.text = address;
        SiteSuggestionBox.SetActive(false);
    }

    public void SetAddressAndOpen(string address, bool sametab)
    {
        AdressBarText.text = address;
        SiteSuggestionBox.SetActive(false);
        ResolveAddress(address, sametab);
    }

    IEnumerator WaitBeforeResolve(float wait)
    {
        yield return new WaitForSeconds(wait);
        ResolveAddress(AdressBarText.text);
    }

    private void ResolveAddress(string address, bool sametab = true)
    {
        SiteSuggestionBox.SetActive(false);
        if (TabDict != null)
        {
            if (TabDict.ContainsKey(address) && sametab)
                transform.parent.GetComponent<Browser>().OpenInSameTab(TabDict[address].GetComponent<Tab>(), address);
            else if (TabDict.ContainsKey(address))
                transform.parent.GetComponent<Browser>().OpenTab(TabDict[address].GetComponent<Tab>(), address);
            else
                transform.parent.GetComponent<Browser>().PageNotFound(address); 
        }
    }
}
