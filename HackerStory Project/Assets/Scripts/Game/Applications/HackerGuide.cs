using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Collections;

public class HackerGuide : App { 

    public List<Sprite> Pages;
    public Button LastPageButton;
    public Button NextPageButton;
    public Image ContentImage;

    private int PageIndex;

    protected override void Start()
    {
        base.Start();
        PageIndex = 0;
        OpenPage(PageIndex);
    }

    public void NextPage()
    {
        if(PageIndex != Pages.Count-1)
        {
            PageIndex++;
            OpenPage(PageIndex);
        }
    }

    public void LastPage()
    {
        if (PageIndex != 0)
        {
            PageIndex--;
            OpenPage(PageIndex);
        }
    }

    public void OpenPage(int page)
    {
        LastPageButton.interactable = true;
        NextPageButton.interactable = true;
        PageIndex = page;

        if (page == 0)
            LastPageButton.interactable = false;
        if(page == Pages.Count-1)
            NextPageButton.interactable = false;

        ContentImage.sprite = Pages[page];
    }
     
}


