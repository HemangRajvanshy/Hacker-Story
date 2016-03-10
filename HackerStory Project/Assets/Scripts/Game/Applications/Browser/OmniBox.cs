﻿using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Collections.Generic;
using System.Collections;

public class OmniBox : MonoBehaviour {

    public GameObject SuggestionTemplate;
    public LayoutElement SuggestionLayout;
    public GameObject SiteSuggestionBox;
    public InputField AdressBarText;

    private Dictionary<string, Tab> TabDict;

    void Start()
    {
        TabDict = new Dictionary<string, Tab>();
        TabDict.Add("", transform.parent.GetComponent<Browser>().HomeTab);
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

            SugButton.GetComponent<Button>().onClick.AddListener(() => { OnSuggestionClick(Suggestion); });
        }

        List<GameObject> TabList = GameManager.Game.Hack.CurrentHack.Tabs;
        List<string> TabName = GameManager.Game.Hack.CurrentHack.TabAddress;
        for(int i = 0; i < TabName.Count; i++)
        {
            TabDict.Add(TabName[i], TabList[i].GetComponent<Tab>());
        }

    }

    public void OnValueChange()
    {
        SiteSuggestionBox.SetActive(true);
    }

    public void OnEndEdit()
    {
        StartCoroutine(WaitBeforeResolve(0.1f));
    }

    public void OnSuggestionClick(string Suggestion)
    {
        AdressBarText.text = Suggestion;
        SiteSuggestionBox.SetActive(false);
    }

    IEnumerator WaitBeforeResolve(float wait)
    {
        yield return new WaitForSeconds(wait);
        ResolveAddress(AdressBarText.text);
    }

    private void ResolveAddress(string address)
    {
        Debug.Log(address);
        if (TabDict.ContainsKey(address))
            transform.parent.GetComponent<Browser>().OpenTab(TabDict[address]);
        else
            transform.parent.GetComponent<Browser>().PageNotFound();
    }
}
