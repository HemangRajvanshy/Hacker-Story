using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class App : MonoBehaviour {

    [HideInInspector]
    public bool open;

    public string AppName;
    public Sprite Icon;
    public Text TitleText;
    public Image TitleIcon;


    protected virtual void Start()
    {
        TitleText.text = AppName;
        TitleIcon.sprite = Icon;
    }

    public virtual void Open()
    {
        this.gameObject.SetActive(true);
        this.transform.SetAsLastSibling();
        open = true;
    }

    public virtual void Minimize()
    {
        this.gameObject.SetActive(false);
        open = false;
    }

    public virtual void Close()
    {
        this.gameObject.SetActive(false);
        open = false;
    }

}
