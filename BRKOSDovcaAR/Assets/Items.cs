using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ParametrizedItem {
    public Sprite ItemSprite;
    public string Name;
}

public class Items: MonoBehaviour {

    public Sprite PropiskaImage;
    public Sprite NuzkyImage;
    public Sprite KlicImage;
    public Sprite SroubovakImage;
    public Sprite KufrZabalenyImage;
    public Sprite KufrRozbalenyImage;

    public static ParametrizedItem Propiska;
    public static ParametrizedItem Nuzky;
    public static ParametrizedItem Klic;
    public static ParametrizedItem Sroubovak;
    public static ParametrizedItem KufrZabaleny;
    public static ParametrizedItem KufrRozbaleny;

    void Start() {
        Propiska = new ParametrizedItem()
        {
            ItemSprite = PropiskaImage,
            Name = "Propiska"
        };
        Nuzky = new ParametrizedItem() {
            ItemSprite = NuzkyImage,
            Name = "Nůžky"
        };
        Klic = new ParametrizedItem() {
            ItemSprite = KlicImage,
            Name = "Klíč"
        };
        Sroubovak = new ParametrizedItem() {
            ItemSprite = SroubovakImage,
            Name = "Šroubovák"
        };
        KufrZabaleny = new ParametrizedItem()
        {
            ItemSprite = KufrZabalenyImage,
            Name = "Kufr1"
        };
        KufrRozbaleny = new ParametrizedItem()
        {
            ItemSprite = KufrRozbalenyImage,
            Name = "Kufr2"
        };
    }
    

}
