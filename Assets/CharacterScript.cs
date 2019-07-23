using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterScript : MonoBehaviour
{
    public Image image;
    public Text text;
    public Text subText;
    public Text lore;
    public ScrollRect loreScroll;
    public Image checkMark;

    private List<Character> characters;
    private Character currentCharacter;
    private bool loreIsActive = false;

    // Start is called before the first frame update
    void Start()
    {
        image.enabled = false;
        checkMark.enabled = false;
        loreScroll.transform.parent.gameObject.SetActive(false);

        characters = new List<Character>()
        {
            new Character("Programmer", "Sloth", "Informatica", $"Naam: Sloth{Environment.NewLine}Primair: Een lasergeweer, welke meerdere vijanden tegelijk raakt.{Environment.NewLine}Speciaal: Een tijdelijke hack, welke de aanvalskracht verhoogt.{Environment.NewLine}{Environment.NewLine}Informatie: Bij informatica leer je alles over de verschillende aspecten van softwareontwikkeling en automatiseringsprojecten. Je leert onderzoeken aan welke eisen de software moet voldoen, hoe je die eisen vertaalt naar een ontwerp en dat omzet in een computerprogramma. Natuurlijk vergeet je niet te testen of de software ook werkt.{Environment.NewLine}{Environment.NewLine}Bij dit karakter wordt de opleiding vertaald naar het ‘hacken’ van het spel door een tijdelijke damage boost te geven aan het hele team. Een groot gedeelte van de opleiding is het leren (her)kennen van de verschillende onderdelen van software door middel van het kijken naar al bestaande code en door het experimenteren daarmee.{Environment.NewLine}{Environment.NewLine}Backstory: Toen ‘het ongeluk’ gebeurde was Informaticus druk bezig met zijn Mendix huiswerk te perfectioneren wat hij belangrijker vond dan naar zijn les professionele vaardigheden toe te gaan. Onwetend wat er gebeurd was op school werd de schokkende realiteit later bekend gemaakt. Zoals verwacht van een Mendix developer is hij gewend met monsters te maken te hebben en om met Mendix te kunnen werken is het te verwachten dat deze persoon een sociopaat is. Toen hij op het plein van school merkte hij dat hij al omsingelt was en moet zijn best doen om te overleven."),
            new Character("Mechatronica", "Parody", "Mechatronica", $"Naam: Parody{Environment.NewLine}Primair: Een automatisch geweer.{Environment.NewLine}Speciaal: Een robot schild dat voor je schiet.{Environment.NewLine}{Environment.NewLine}Informatie:  Bij de opleiding Mechatronica leer je producten te ontwerpen en te besturen waarin beweging een centrale rol heeft. Denk aan robots of productiemachines. Of het nu een auto, een vulmachine voor colablikjes of een achtbaan is. Al deze producten hebben de afgelopen jaren een verandering ondergaan: ze werden slimmer door het gebruik van sensoren en computers. Het vakgebied mechatronica is de aanjager van deze verandering. Het verbindt de kennis vanuit verschillende vakgebieden zoals werktuigbouwkunde, elektrotechniek en informatica om zo tot de slimme producten van de toekomst te komen.{Environment.NewLine}{Environment.NewLine}Bij dit karakter wordt dit vertaald naar het bouwen van een partner robotje die op de verschillende vijanden schiet. Tijdens de opleiding mechatronica ga je aan de slag met veel verschillende technieken zoals het bouwen van robots.{Environment.NewLine}{Environment.NewLine}Backstory: Optimus was op zijn vrije dag druk bezig met werken in de garage om geld te verdienen voor zijn studie. De weken die volgende leken normaal genoeg tot opeens de mensen die blootgesteld waren aan het gas begonnen te veranderen in zombies. Optimus was diep verontrust door wat er gebeurde en besloot te rennen naar een grote open gebied op het plein op zoek naar anderen om samen te werken. Hier kwam hij anderen tegen en samen hebben zij een verdediging opgezet door hulp van de turret van Optimus."),
            new Character("ElectroTechniek", "Nikola", "Electro Techniek", $"Naam: Nikola{Environment.NewLine}Primair: Een tesla geweer, welke voor een korte verlamming zorgt.{Environment.NewLine}Speciaal: Een tesla coil welke schade veroorzaakt bij dichtstbijzijnde vijanden.{Environment.NewLine}{Environment.NewLine}Informatie: Bij de opleiding Elektrotechniek leer je hoe je de wereld slimmer en makkelijker maakt met technische innovaties. Je staat aan de start van nieuwe ontwikkelingen waar veel mensen gemak van hebben. Elektrotechniek zit overal. Denk aan een gameconsole, een draaitafel van een dj en een formule 1-auto. Na je opleiding ben je dan ook zeker van een baan. Je werkt bijvoorbeeld mee aan de ontwikkeling van zonne- en windenergie, elektrische auto's, drones of productierobots. Stuk voor stuk ontwikkelingen die de wereld een beetje beter maken.{Environment.NewLine}{Environment.NewLine}Bij dit karakter wordt dit vertaald naar het verlammen van de vijanden. De vijanden zijn robots, en door gebruik te maken van een electro-magnetische pulse worden die tijdelijk onklaar gemaakt. Bij de opleiding leer je alles over energie, en in dit geval maak je daar misbruik van om een voordeel in het spel te behalen.{Environment.NewLine}{Environment.NewLine}Backstory: Nikola was op stage bij een bedrijf dat onderzoek doet naar nieuwe en efficiënte manieren om groene stroom te wekken. Op de dag dat hij zijn voortgang moest presenteren op school was hij verrast te vinden dat wat er op school rond liep geen mensen waren. Om proberen te ontsnappen rende Nikola richting het plein zodat hij goed overzicht had op wat er rond liep. Hier kwam hij meer mensen tegen die probeerden de robots af te houden. Toen de overlevenden moeite leken te krijgen kwam Nikola net op tijd aan met een EMP om de robots tijdelijk uit te schakelen wat de anderen tijd gaf om er zo veel mogelijk te slapen en op adem te komen. Nu moeten zij samen overleven tegen de horde die op hen af komt."),
            new Character("TechnischeInformatica", "Cipher", "Technische Informatica", $"Naam: Cipher{Environment.NewLine}Primair: Een pistool die een bloeding veroorzaakt wat schade veroorzaakt.{Environment.NewLine}Speciaal: Een radius om je heen die vijanden voor jou laten werken en elkaar aanvallen.{Environment.NewLine}{Environment.NewLine}Informatie: In de opleiding Technische Informatica leer je hoe mobieltjes software technisch in elkaar zitten. Jij zet de nieuwste technologieën op softwaregebied straks naar je hand. Je computer doet raar, dus je belt de helpdesk. Je maakt 'gewoon' gebruik van apparaten als auto's, printers, smartphones en GPS. Maar de software die daarin zit zijn hoogstandjes van technische informatica. Jij wilt er alles van weten. Ook van robots in industriële productiestraten. Van databases, besturingstechniek en gamestechnologie.{Environment.NewLine}{Environment.NewLine}Bij dit karakter wordt dit vertaald naar het maken van een schild om je te beschermen tegen de robots die je aanvallen. Bij de opleiding leer je verschillende technieken kennen en te bouwen, in dit geval gebruik je die kennis om voor jezelf en je teamgenoten een schild in elkaar te zetten.{Environment.NewLine}{Environment.NewLine}Backstory: Als kind verhuisde Klaus samen met zijn ouders naar Nederland. Klaus is in Nederland opgegroeid maar heeft de typische duitse uitkijk op zaken. Klaus was al sinds hij een kind was geobsedeerd met efficiëntie. Hierom wil Klaus studeren in robotica en zo veel mogelijk werk automatiseren. Hij vermoed dat als er zo veel mogelijk geautomatiseerd is alles een stuk sneller gaat en mensen zich kunnen concentreren op belangrijkere zaken. Het was een normale dag toen Klaus naar school kwam. Tijdens zijn pauze ging opeens het alarm af en probeerde hij kalm het gebouw te verlaten voordat hij erachter kwam dat er op hol geslagen robots van elke richting kwamen. De meeste mensen leken al ontsnapt te zijn maar Klaus had geen gelukkige dag. Het enige positieve dat voor Klaus gebeurde was dat terwijl hij aan het vluchten was hij anderen tegen kwam, nu vechten zij samen de horde van robots om te overleven."),
            new Character("Werktuigbouwkunde", "Bullseye", "Werktuigbouwkunde", $"Naam: Bullseye{Environment.NewLine}Primair: Een langzaam vurend, maar krachtig nail geweer.{Environment.NewLine}Speciaal: Een stilstaande turret welke op vijanden schiet.{Environment.NewLine}{Environment.NewLine}Informatie: Jij lost graag problemen op een constructieve manier op. Je leert bij de opleiding Werktuigbouwkunde producten maken die iets toevoegen aan het leven van de gebruiker. Een creatief en logisch vak. De overheid stimuleert de verkoop van milieuvriendelijke auto's. Jij bedenkt hoe dat nieuwe model eruit komt te zien. Jouw klant wil een productiemachine voor chocoladerepen. Als commercieel technicus weet jij precies hoe een installatie in elkaar zit en kun je de klant goed adviseren. Een werktuigbouwkundige werkt aan vrijwel elk product of machine.{Environment.NewLine}{Environment.NewLine}Bij dit karakter wordt dit vertaald naar het bouwen een helpende hand; een stilstaande turret die op de verschillende vijanden schiet die op je af komen. Het bouwen van milieuvriendelijke auto’s etc. komt je dan in zo’n geval goed van pas.{Environment.NewLine}{Environment.NewLine}Backstory: Sinds kinds af aan was Bill al aan het sleutelen met machines. Toen Bill een tiener werd kreeg hij interesse in de theorie achter hoe de verschillende machines werkten intern en waarom dit zo was. Toen het tijd werd voor Bill om een opleiding te kiezen wist hij precies wat hij wilde doen. Hij kon zo zijn kennis van machines uitbreiden en koppelen met zijn ambitie om het menselijk leven makkelijker te maken. Hoewel het een normale dag op school was voor Bill, veranderde dat snel toen hij net naar huis wilde gaan. Hij liep rustig over het plein toen hij merkte dat iets niet klopte. Toen hij zijn koptelefoon af deed hoorde hij dat er een alarm af ging over de hele school. Toen hij zijn ogen concentreerde op de figuren die hij op een afstandje zag realiseerde hij zich dat dit helemaal geen mensen waren. Nu hij geen kant op kan moet hij zijn best doen om dit te overleven en ontsnappen of gered te worden.")
        };

        currentCharacter = new Character("Programmer", "Press A to join", null, null);
    }

    // Update is called once per frame
    void Update()
    {
        image.sprite = currentCharacter.image;
        text.text = currentCharacter.text;
        subText.text = currentCharacter.subText;
        lore.text = currentCharacter.lore;
    }

    public void Init()
    {
        currentCharacter = characters[0];
        image.enabled = true;
        image.color = new Color(255, 255, 255, 1);
    }

    public Character GetCharacter()
    {
        return currentCharacter;
    }

    public void ToggleReady(bool ready)
    {
        checkMark.enabled = ready;
    }

    internal bool ToggleLore()
    {
        loreIsActive = !loreIsActive;
        loreScroll.transform.parent.gameObject.SetActive(loreIsActive);
        return loreIsActive;
    }

    public void NextSlide()
    {
        if (checkMark.enabled) return;

        int currentIndex = characters.FindIndex(c => c.text == currentCharacter.text);
        if(currentIndex + 1 < characters.Count)
        {
            currentCharacter = characters[currentIndex + 1];
        }
        else
        {
            currentCharacter = characters[0];
        }

        loreScroll.verticalNormalizedPosition = 1;
    }

    public void PreviousSlide()
    {
        if (checkMark.enabled) return;

        int currentIndex = characters.FindIndex(c => c.text == currentCharacter.text);
        if (currentIndex - 1 >= 0)
        {
            currentCharacter = characters[currentIndex - 1];
        }
        else
        {
            currentCharacter = characters[characters.Count - 1];
        }

        loreScroll.verticalNormalizedPosition = 1;
    }

    internal void ScrollLore(double pos)
    {
        loreScroll.verticalNormalizedPosition = (float) pos;
    }
}

public struct Character
{
    public Sprite image;
    public string text;
    public string subText;
    internal string lore;

    public Character(string image, string text, string subText, string lore)
    {
        this.image = Resources.Load<Sprite>(image);
        this.text = text;
        this.subText = subText;
        this.lore = lore;
    }
}
