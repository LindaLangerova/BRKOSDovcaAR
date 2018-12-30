using System;
using UnityEngine;

public class ParametrizedButton {
    public bool Enabled;
    public string GoTo;
    public string Label;
}

public class Environment {
    public ParametrizedButton Button1;
    public ParametrizedButton Button2;
    public ParametrizedButton Button3;
    public ParametrizedButton Button4;
    public bool Availabile = true;
    public string Name;
    public int State;
    public string[] Texts;
}

public class Places {
    public const string VSTUPNI_HALA = "Vstupní hala";
    public const string PRED_HOTELEM = "Před hotelem";
    public const string PLAZ = "Pláž";
    public const string ZASTAVKA = "Zastávka";
    public const string K_POKOJUM = "K pokojům";
    public const string SCHODY = "Schody";
    public const string VYTAH = "Výtah";
    public const string VYTAH2 = "Výtah nahoře";
    public const string CHODBA = "Chodba";
    public const string POKOJ = "Pokoj";
    public const string RECEPCE = "Recepce";
    public const string BAZEN = "Bazén";
    public const string JIDELNA = "Jídelna";
    public const string BAR = "Bar";

    public Environment VstupniHala = new Environment // 1
   {
        Name = VSTUPNI_HALA,
        Availabile = false,
        Texts = new string[] { "Září Vám oči štěstím. Jste ve vstupní hale luxusního hotelu." },
        State = 0, //0 = pocatecni stav
        Button1 = new ParametrizedButton { Label = "Zpět před hotel", GoTo = PRED_HOTELEM, Enabled = true },
        Button2 = new ParametrizedButton { Label = "K pokojům", GoTo = K_POKOJUM, Enabled = true },
        Button3 = new ParametrizedButton { Label = "K recepci", GoTo = RECEPCE, Enabled = true },
        Button4 = new ParametrizedButton { Label = "K bazénu", GoTo = BAZEN, Enabled = true }
    };

    public Environment PredHotelem = new Environment // 2
    {
        Name = PRED_HOTELEM,
        Texts = new string[] {
            "Po dlouhé cestě konečně stojíte před hotelem. Už se nemůžete dočkat, až budete uvnitř.",
            "Stojíte před hotelem. Rozhodujete se, jestli vejít dovnitř."
        },
        State = 0, //0 = pocatecni stav, 1 = lze jit do hotelu
        Button1 = new ParametrizedButton { Label = "K příjezdové zastávce", GoTo = ZASTAVKA, Enabled = true },
        Button2 = new ParametrizedButton { Label = "Na pláž", GoTo = PLAZ, Enabled = true },
        Button3 = new ParametrizedButton { Label = "Do hotelu", GoTo = VSTUPNI_HALA, Enabled = false }, 
        Button4 = new ParametrizedButton { Label = "", GoTo = "", Enabled = false }
    };

    public Environment Plaz = new Environment // 3
    {
        Name = PLAZ,
        Texts = new string[] {
            "Objevili jste se na pláži, vlny naráží o útesy, je zde prázdno. Kromě toho je tu hrad z písku.",
            "Objevili jste se na pláži, vlny naráží o útesy, je zde prázdno a hrouda písku. Jste to ale uličníci :(."
        },
        State = 0, //0 = pocatecni stav, 1 = rozkopnuty hrad
        Button1 = new ParametrizedButton { Label = "Zpět před hotel", GoTo = PRED_HOTELEM, Enabled = true },
        Button2 = new ParametrizedButton { Label = "", GoTo = "", Enabled = false },
        Button3 = new ParametrizedButton { Label = "", GoTo = "", Enabled = false },
        Button4 = new ParametrizedButton { Label = "", GoTo = "", Enabled = false }
    };

    public Environment PrijezdovaZastavka = new Environment // 4
    {
        Name = ZASTAVKA,
        Texts = new string[] { "Zde jste vystoupili z autobusu, který Vás vezl z letiště. Není tu nic moc, jen jízdní řády a spousta plakátů." },
        State = 0, //0 = pocatecni stav
        Button1 = new ParametrizedButton { Label = "Zpět před hotel", GoTo = PRED_HOTELEM, Enabled = true },
        Button2 = new ParametrizedButton { Label = "", GoTo = "", Enabled = false },
        Button3 = new ParametrizedButton { Label = "", GoTo = "", Enabled = false },
        Button4 = new ParametrizedButton { Label = "", GoTo = "", Enabled = false }
    };

    public Environment KPokojum = new Environment // 5
    {
        Name = K_POKOJUM,
        Texts = new string[] { "Tato chodba vede k samotnému místu ubytování. Pokračovat můžete výtahem, nebo po schodech." },
        State = 0, //0 = pocatecni stav
        Button1 = new ParametrizedButton { Label = "Zpět ke vstupu", GoTo = VSTUPNI_HALA, Enabled = true },
        Button2 = new ParametrizedButton { Label = "Schody", GoTo = SCHODY, Enabled = true },
        Button3 = new ParametrizedButton { Label = "Výtah", GoTo = VYTAH, Enabled = true },
        Button4 = new ParametrizedButton { Label = "", GoTo = "", Enabled = false }
    };

    public Environment Schody = new Environment // 6
    {
        Name = SCHODY,
        Texts = new string[] {
            "Jdete po schodech. Leč udýchaní, pokračujete dále. Samozřejmě bez kufrů, přeci je nepotáhnete po schodech! Nebo se otočíte?",
            "Utíkáte dolů tak rychle, že jste zakopli a kutálíte se dolů. Naštěstí se vám nic nestalo, jen se vám recepční pochechtl."
        },
        State = 0, //0 = ze spoda, 1 = shora
        Button1 = new ParametrizedButton { Label = "", GoTo = "", Enabled = false },
        Button2 = new ParametrizedButton { Label = "Vyjít schody", GoTo = CHODBA, Enabled = true },
        Button3 = new ParametrizedButton { Label = "Sejít schody", GoTo = K_POKOJUM, Enabled = true },
        Button4 = new ParametrizedButton { Label = "", GoTo = "", Enabled = false }
    };

    public Environment Vytah = new Environment // 7
    {
        Name = VYTAH,
        Texts = new string[] {
            "Jste ve výtahu. Podivně se kouří z řídící desky. Tím asi teď nepojedete... Leda byste si ho byli schopni opravit.",
            "Skvělé! Výtah je funkční, můžete jet nahoru."
        },
        State = 0, //0 = rozbity vytah, 1 = opraveny vytah - dole
        Button1 = new ParametrizedButton { Label = "", GoTo = "", Enabled = false },
        Button2 = new ParametrizedButton { Label = "Vyjít z výtahu", GoTo = K_POKOJUM, Enabled = true },
        Button3 = new ParametrizedButton { Label = "", GoTo = "", Enabled = false },
        Button4 = new ParametrizedButton { Label = "", GoTo = "", Enabled = false }
    };

    public Environment Vytah2 = new Environment // 7
    {
        Name = VYTAH2,
        Texts = new string[] {
            "Vyjeli jste nahoru"
        },
        State = 0, //0 = opraveny vytah - nahore
        Button1 = new ParametrizedButton { Label = "", GoTo = "", Enabled = false },
        Button2 = new ParametrizedButton { Label = "Vyjít z výtahu", GoTo = CHODBA, Enabled = true },
        Button3 = new ParametrizedButton { Label = "", GoTo = "", Enabled = false },
        Button4 = new ParametrizedButton { Label = "", GoTo = "", Enabled = false }
    };

    public Environment Chodba = new Environment // 8
    {
        Name = CHODBA,
        Texts = new string[] {
            "Tahle chodba je ale dloooouhá, kdo by to čekal. Je zde spousta pokojů a pár květináčů."
        },
        State = 0, //0 = puvodni stav
        Button1 = new ParametrizedButton { Label = "Jít do pokoje", GoTo = "", Enabled = false },
        Button2 = new ParametrizedButton { Label = "Jít na schody", GoTo = SCHODY, Enabled = true },
        Button3 = new ParametrizedButton { Label = "", GoTo = "", Enabled = false },
        Button4 = new ParametrizedButton { Label = "", GoTo = "", Enabled = false }
    };

    public Environment Pokoj = new Environment // 9
    {
        Name = POKOJ,
        Availabile = false,
        Texts = new string[] {
            "Zde je vaše hnízdečko. Nyní je ten správný čas se ubytovat.",
            "Toto je vaše hnízdečko. Je skvělé, že už jste ubytovaní."
        },
        State = 0, //0 = puvodni stav, 1 = ubytováni
        Button1 = new ParametrizedButton { Label = "", GoTo = "", Enabled = false },
        Button2 = new ParametrizedButton { Label = "", GoTo = "", Enabled = false },
        Button3 = new ParametrizedButton { Label = "Jít na chodbu", GoTo = CHODBA, Enabled = true },
        Button4 = new ParametrizedButton { Label = "", GoTo = "", Enabled = false }
    };

    public Environment Recepce = new Environment // 10
    {
        Name = RECEPCE,
        Texts = new string[] {
            "Zde se nejspíš vyřizují všechny formální záležitosti spojené s Vašim pobytem."
        },
        State = 0, //0 = puvodni stav
        Button1 = new ParametrizedButton { Label = "Ke vstupu", GoTo = VSTUPNI_HALA, Enabled = true },
        Button2 = new ParametrizedButton { Label = "", GoTo = "", Enabled = false },
        Button3 = new ParametrizedButton { Label = "Do jídelny", GoTo = JIDELNA, Enabled = true },
        Button4 = new ParametrizedButton { Label = "", GoTo = "", Enabled = false }
    };

    public Environment Bazen = new Environment // 11
    {
        Name = BAZEN,
        Texts = new string[] {
            "Kolem Vás se ráchají děti v brouzdališti a vy už se nemůžete dočkat, až tu taky budete blbnout v plavkách."
        },
        State = 0, //0 = puvodni stav
        Button1 = new ParametrizedButton { Label = "Ke vstupu", GoTo = VSTUPNI_HALA, Enabled = true },
        Button2 = new ParametrizedButton { Label = "", GoTo = "", Enabled = false },
        Button3 = new ParametrizedButton { Label = "K baru", GoTo = BAR, Enabled = true },
        Button4 = new ParametrizedButton { Label = "", GoTo = "", Enabled = false }
    };

    public Environment Jidelna = new Environment // 12
    {
        Name = JIDELNA,
        Texts = new string[] {
            "Moderní židle, lesknoucí se příbory, stoly však zejí prázdnotou. I tak se Vám už sbíhají sliny, protože jíst tady bude pecka!",
            "Jídlo... jídlo! všude spousta jídla! Tohle musí být ráj! Teď už můžete v klidu papkat a užívat si, že jste vše zvládli. Však jak se říká, vítězství prochází žaludkem."
        },
        State = 0, //0 = puvodni stav, 1 = veca 
        Button1 = new ParametrizedButton { Label = "K recepci", GoTo = RECEPCE, Enabled = true },
        Button2 = new ParametrizedButton { Label = "", GoTo = "", Enabled = false },
        Button3 = new ParametrizedButton { Label = "", GoTo = "", Enabled = false },
        Button4 = new ParametrizedButton { Label = "", GoTo = "", Enabled = false }
    };

    public Environment Bar = new Environment // 13
    {
        Name = BAR,
        Texts = new string[] {
            "A hele, u baru nasává delegátka. Co takhle se k ní přidat?"
        },
        State = 0, //0 = puvodni stav 
        Button1 = new ParametrizedButton { Label = "Zpět k bazénu", GoTo = BAZEN, Enabled = true },
        Button2 = new ParametrizedButton { Label = "", GoTo = "", Enabled = false },
        Button3 = new ParametrizedButton { Label = "", GoTo = "", Enabled = false },
        Button4 = new ParametrizedButton { Label = "", GoTo = "", Enabled = false }
    };
}