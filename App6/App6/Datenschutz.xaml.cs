using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App6
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Datenschutz : ContentPage, INotifyPropertyChanged
    {
        public Datenschutz()
        {
            InitializeComponent();
            BindingContext = this;
        }

        //Back Button
        private async void MenuItem1_Activated(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new HomePage());
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            var browser = new WebView();
            var htmlSource = new HtmlWebViewSource();
            htmlSource.Html = @"<html><body>
                          <h4>inQS - Indikatorengestützte Qualitätsförderung
    <br/></h4>

    <h4>Datenschutzerklärung
    <br/></h4>
    <p><strong> Einleitung </strong>
    <br/>
    Mit der folgenden Datenschutzerklärung möchten wir Sie darüber aufklären, welche Arten Ihrer personenbezogenen Daten (nachfolgend auch kurz als &quot;Daten&quot; bezeichnet) wir zu welchen Zwecken und in welchem Umfang verarbeiten. Die
    Datenschutzerklärung gilt für alle von uns durchgeführten
    Verarbeitungen personenbezogener Daten, sowohl im Rahmen
    der Erbringung unserer Leistungen als auch insbesondere auf
    unseren Webseiten, Webapplikationen, sowie mobilen
    Applikationen(nachfolgend zusammenfassend bezeichnet als
    &quot;Onlineangebot&quot;).
    <br/>
    <br/>
    Stand: 16.September 2019
   <br/>

   <br/>

   <strong> Inhaltsübersicht </strong>

   <br/>
   Einleitung
   <br/>
   Verantwortlicher
   <br/>
   Übersicht der Verarbeitungen
   <br/>
   Kontakt Datenschutzbeauftragter
   <br/>
   Maßgebliche Rechtsgrundlagen
   <br/>
   Sicherheitsmaßnahmen
   <br/>
   Datenverarbeitung in Drittländern
   <br/>
   Kontaktaufnahme
   <br/>
   Bereitstellung des Onlineangebotes und Webhosting
   <br/>
   Löschung von Daten
   <br/>
   Änderung und Aktualisierung der Datenschutzerklärung
   <br/>
   Rechte der betroffenen Personen
   <br/>
   Begriffsdefinitionen </p>


   <p><strong><br/>
   Verantwortlicher </strong>

   <br/>
   Universität Siegen
   <br/>
   Projektverantwortlicher: Johannes Zenkert
   <br/>
   Institut für Wissensbasierte Systeme & amp;
            Wissensmanagement
            <br/>
            Hölderlinstraße 3
            <br/>
            57076 Siegen
            <br/>
            Deutschland
            <br/>
        
            <br/>
            E-Mail-Adresse: johannes.zenkert@uni-siegen.de
                 <br/>
             
                 <br/>
             
                 <strong> Kontakt Datenschutzbeauftragter </strong>
                
                    <br/>
                    Datenschutzbeauftragter
                    <br/>
                
                    <br/>
                    Sebastian Zimmermann
                    <br/>
                
                    <br/>
                    Adolf-Reichwein-Str. 2a / Gebäude NA
                          <br/>
                      
                          <br/>
                          57076 Siegen
                          <br/>
                      
                          <br/>
                      
                          <strong> Übersicht der Verarbeitungen</strong>
                         
                             <br/>
                             Die nachfolgende Übersicht fasst die Arten der
    verarbeiteten Daten und die Zwecke ihrer Verarbeitung
    zusammen und verweist auf die betroffenen Personen.
    <br/>
    <strong><br/>
    Arten der verarbeiteten Daten </strong>
    <br/>
    Bestandsdaten (z.B. Namen, Adressen).
    <br/>
    <br/>
    Inhaltsdaten (z.B. Texteingaben).
    <br/>
    <br/>
    Kontaktdaten (z.B. E-Mail, Telefonnummern, Adressen).
    <br/>
    <br/>
    Meta -/ Kommunikationsdaten (z.B.Geräte - Informationen,
    IP - Adressen).
    <br/>
    <br/>
    Nutzungsdaten (z.B.besuchte Webseiten, Interesse an
    Inhalten, Zugriffszeiten).
    <br/>
    <br/>
    Kategorien betroffener Personen
    <br/>
    Kommunikationspartner.
    <br/>
    <br/>
    Nutzer (z.B. Webseitenbesucher, Nutzer von Onlinediensten).
    <br/>
    <strong><br/>
    Zwecke der Verarbeitung</strong>
    <br/>
    Kontaktanfragen und Kommunikation.
    <br/>
    <br/>
    <strong> Maßgebliche Rechtsgrundlagen </strong>
   
       <br/>
       Im Folgenden teilen wir die Rechtsgrundlagen der
    Datenschutzgrundverordnung(DSGVO), auf deren Basis wir die
   personenbezogenen Daten verarbeiten, mit. Bitte beachten
    Sie, dass zusätzlich zu den Regelungen der DSGVO die
    nationalen Datenschutzvorgaben in Ihrem bzw. unserem Wohn-
    und Sitzland gelten können.
    <br/>
    <br/>
    Vertragserfüllung und vorvertragliche Anfragen(Art. 6 Abs.
    1 S. 1 lit.b.DSGVO) - Die Verarbeitung ist für die
    Erfüllung eines Vertrags, dessen Vertragspartei die
    betroffene Person ist, oder zur Durchführung
    vorvertraglicher Maßnahmen erforderlich, die auf Anfrage
    der betroffenen Person erfolgen.
    <br/>
    <br/>
    Berechtigte Interessen(Art. 6 Abs. 1 S. 1 lit.f.DSGVO) -
    Die Verarbeitung ist zur Wahrung der berechtigten
    Interessen des Verantwortlichen oder eines Dritten
    erforderlich, sofern nicht die Interessen oder Grundrechte
    und Grundfreiheiten der betroffenen Person, die den Schutz
    personenbezogener Daten erfordern, überwiegen.
    <br/>
    <br/>
    <strong> Sicherheitsmaßnahmen </strong>
    <br/>
    Wir treffen nach Maßgabe der gesetzlichen Vorgaben unter
    Berücksichtigung des Stands der Technik, der
    Implementierungskosten und der Art, des Umfangs, der
    Umstände und der Zwecke der Verarbeitung sowie der
    unterschiedlichen Eintrittswahrscheinlichkeiten und des
    Ausmaßes der Bedrohung der Rechte und Freiheiten
    natürlicher Personen geeignete technische und
    organisatorische Maßnahmen, um ein dem Risiko angemessenes
    Schutzniveau zu gewährleisten.
    <br/>
    <br/>
    Zu den Maßnahmen gehören insbesondere die Sicherung der
    Vertraulichkeit, Integrität und Verfügbarkeit von Daten
    durch Kontrolle des physischen und elektronischen Zugangs
    zu den Daten als auch des sie betreffenden Zugriffs, der
    Eingabe, der Weitergabe, der Sicherung der Verfügbarkeit
    und ihrer Trennung. Des Weiteren haben wir Verfahren
    eingerichtet, die eine Wahrnehmung von Betroffenenrechten,
    die Löschung von Daten und Reaktionen auf die Gefährdung
    der Daten gewährleisten.Ferner berücksichtigen wir den
    Schutz personenbezogener Daten bereits bei der Entwicklung
    bzw.Auswahl von Hardware, Software sowie Verfahren
   entsprechend dem Prinzip des Datenschutzes, durch
    Technikgestaltung und durch datenschutzfreundliche
    Voreinstellungen.
    <br/>
    <br/>
    <strong> Datenverarbeitung in Drittländern </strong>
   
       <br/>
       Gemäß vertraglicher Regelungen findet die Datenverarbeitung
       nur innerhalb Deutschlands statt.Eine Inanspruchnahme von
      Diensten Dritter oder der Offenlegung bzw.Übermittlung von
    Daten an andere Personen, Stellen oder Unternehmen findet
    nicht statt.
    <br/>
    <br/>
    <strong> Kontaktaufnahme </strong>
    <br/>
    Bei der Kontaktaufnahme mit uns (z.B. per Kontaktformular,
    E-Mail, Telefon oder via soziale Medien) werden die Angaben
    der anfragenden Personen verarbeitet, soweit dies zur
    Beantwortung der Kontaktanfragen und etwaiger angefragter
    Maßnahmen erforderlich ist.
    <br/>
    <br/>
    Die Beantwortung der Kontaktanfragen im Rahmen von
    vertraglichen oder vorvertraglichen Beziehungen erfolgt zur
    Erfüllung unserer vertraglichen Pflichten oder zur
    Beantwortung von(vor)vertraglichen Anfragen und im Übrigen
   auf Grundlage der berechtigten Interessen an der
    Beantwortung der Anfragen.
    <br/>
    <br/>
    Verarbeitete Datenarten: Bestandsdaten (z.B. Namen,
    Adressen), Kontaktdaten (z.B. E-Mail, Telefonnummern),
    Inhaltsdaten (z.B. Texteingaben, Fotografien, Videos).
    <br/>
    <br/>
    Betroffene Personen: Kommunikationspartner.
    <br/>
    <br/>
    Zwecke der Verarbeitung: Kontaktanfragen und Kommunikation.
    <br/>
    <br/>
    Rechtsgrundlagen: Vertragserfüllung und vorvertragliche
    Anfragen(Art. 6 Abs. 1 S. 1 lit.b.DSGVO), Berechtigte
    Interessen(Art. 6 Abs. 1 S. 1 lit.f.DSGVO).
    <br/>
    <br/>
    <strong> Bereitstellung des Onlineangebotes und
    Webhosting </strong>
    <br/>
    Um unser Onlineangebot sicher und effizient bereitstellen
    zu können, nehmen wir die Leistungen von einem oder
    mehreren Webhosting-Anbietern(innerhalb Deutschlands) in
    Anspruch, von deren Servern(bzw.von ihnen verwalteten
    Servern) das Onlineangebot abgerufen werden kann.Zu diesen
    Zwecken können wir Infrastruktur-und
    Plattformdienstleistungen, Rechenkapazität, Speicherplatz
    und Datenbankdienste sowie Sicherheitsleistungen und
    technische Wartungsleistungen in Anspruch nehmen.
    <br/>
    <br/>
    Zu den im Rahmen der Bereitstellung des Hostingangebotes
    verarbeiteten Daten können alle die Nutzer unseres
    Onlineangebotes betreffenden Angaben gehören, die im Rahmen
    der Nutzung und der Kommunikation anfallen. Hierzu gehören
    regelmäßig die IP - Adresse, die notwendig ist, um die
    Inhalte von Onlineangeboten an Browser ausliefern zu
    können, und alle innerhalb unseres Onlineangebotes oder von
    Webseiten getätigten Eingaben.
    <br/>
    <br/>
    Erhebung von Zugriffsdaten und Logfiles: Wir selbst(bzw.
    unser Webhostinganbieter) erheben Daten zu jedem Zugriff
    auf den Server(sogenannte Serverlogfiles). Zu den
    Serverlogfiles können die Adresse und Name der abgerufenen
    Webseiten und Dateien, Datum und Uhrzeit des Abrufs,
    übertragene Datenmengen, Meldung über erfolgreichen Abruf,
    Browsertyp nebst Version, das Betriebssystem des Nutzers,
    Referrer URL(die zuvor besuchte Seite) und im Regelfall
    IP - Adressen und der anfragende Provider gehören.
  
      <br/>
  
      <br/>
      Die Serverlogfiles können zum einen zu Zwecken der
      Sicherheit eingesetzt werden, z.B., um eine Überlastung der
    Server zu vermeiden(insbesondere im Fall von
    missbräuchlichen Angriffen, sogenannten DDoS - Attacken) und
      zum anderen, um die Auslastung der Server und ihre
      Stabilität sicherzustellen.
  
      <br/>
  
      <br/>
      Verarbeitete Datenarten: Inhaltsdaten (z.B. Texteingaben),
    Nutzungsdaten (z.B. besuchte Webseiten, Interesse an
    Inhalten, Zugriffszeiten), Meta -/ Kommunikationsdaten (z.B. Geräte - Informationen, IP - Adressen).
    <br/>
    <br/>
    Betroffene Personen: Nutzer (z.B. Webseitenbesucher, Nutzer
    von Onlinediensten).
    <br/>
    <br/>
    Rechtsgrundlagen: Berechtigte Interessen(Art. 6 Abs. 1 S.
    1 lit.f.DSGVO).
    <br/>
    <br/>
    <strong> Löschung von Daten</strong>
   
       <br/>
       Die von uns verarbeiteten Daten werden nach Maßgabe der
    gesetzlichen Vorgaben gelöscht, sobald deren zur
    Verarbeitung erlaubten Einwilligungen widerrufen werden
    oder sonstige Erlaubnisse entfallen (z.B., wenn der Zweck
    der Verarbeitung dieser Daten entfallen ist oder sie für
    den Zweck nicht erforderlich sind).
    <br/>
    <br/>
    Sofern die Daten nicht gelöscht werden, weil sie für andere
    und gesetzlich zulässige Zwecke erforderlich sind, wird
    deren Verarbeitung auf diese Zwecke beschränkt. D.h., die
    Daten werden gesperrt und nicht für andere Zwecke
    verarbeitet.Das gilt z.B.für Daten, die aus handels-oder
    steuerrechtlichen Gründen aufbewahrt werden müssen oder
    deren Speicherung zur Geltendmachung, Ausübung oder
    Verteidigung von Rechtsansprüchen oder zum Schutz der
    Rechte einer anderen natürlichen oder juristischen Person
    erforderlich ist.
    <br/>
    <br/>
    Änderung und Aktualisierung der Datenschutzerklärung
    <br/>
    Wir bitten Sie, sich regelmäßig über den Inhalt unserer
    Datenschutzerklärung zu informieren. Wir passen die
    Datenschutzerklärung an, sobald die Änderungen der von uns
    durchgeführten Datenverarbeitungen dies erforderlich
    machen.Wir informieren Sie, sobald durch die Änderungen
    eine Mitwirkungshandlung Ihrerseits (z.B. Einwilligung)
    oder eine sonstige individuelle Benachrichtigung
    erforderlich wird.
    <br/>
    <br/>
    <strong> Rechte der betroffenen Personen </strong>
   
       <br/>
       Ihnen stehen als Betroffene nach der DSGVO verschiedene
       Rechte zu, die sich insbesondere aus Art. 15 bis 18 und 21
    DS - GVO ergeben:
    <br/>
    <br/>
    Widerspruchsrecht: Sie haben das Recht, aus Gründen, die
    sich aus Ihrer besonderen Situation ergeben, jederzeit
    gegen die Verarbeitung der Sie betreffenden
    personenbezogenen Daten, die aufgrund von Art. 6 Abs. 1
    lit.e oder f DSGVO erfolgt, Widerspruch einzulegen; dies
   gilt auch für ein auf diese Bestimmungen gestütztes
    Profiling.Werden die Sie betreffenden personenbezogenen
   Daten verarbeitet, um Direktwerbung zu betreiben, haben Sie
   das Recht, jederzeit Widerspruch gegen die Verarbeitung der
    Sie betreffenden personenbezogenen Daten zum Zwecke
    derartiger Werbung einzulegen; dies gilt auch für das
    Profiling, soweit es mit solcher Direktwerbung in
    Verbindung steht.
    <br/>
    Widerrufsrecht bei Einwilligungen: Sie haben das Recht,
    erteilte Einwilligungen jederzeit zu widerrufen.
    <br/>
    Auskunftsrecht: Sie haben das Recht, eine Bestätigung
    darüber zu verlangen, ob betreffende Daten verarbeitet
    werden und auf Auskunft über diese Daten sowie auf weitere
    Informationen und Kopie der Daten entsprechend den
    gesetzlichen Vorgaben.
    <br/>
    Recht auf Berichtigung: Sie haben entsprechend den
    gesetzlichen Vorgaben das Recht, die Vervollständigung der
    Sie betreffenden Daten oder die Berichtigung der Sie
    betreffenden unrichtigen Daten zu verlangen.
    <br/>
    Recht auf Löschung und Einschränkung der Verarbeitung: Sie
    haben nach Maßgabe der gesetzlichen Vorgaben das Recht, zu
    verlangen, dass Sie betreffende Daten unverzüglich gelöscht
    werden, bzw.alternativ nach Maßgabe der gesetzlichen
   Vorgaben eine Einschränkung der Verarbeitung der Daten zu
    verlangen.
    <br/>
    Recht auf Datenübertragbarkeit: Sie haben das Recht, Sie
    betreffende Daten, die Sie uns bereitgestellt haben, nach
    Maßgabe der gesetzlichen Vorgaben in einem strukturierten,
    gängigen und maschinenlesbaren Format zu erhalten oder
    deren Übermittlung an einen anderen Verantwortlichen zu
    fordern.
    <br/>
    Beschwerde bei Aufsichtsbehörde: Sie haben ferner nach
    Maßgabe der gesetzlichen Vorgaben das Recht, bei einer
    Aufsichtsbehörde, insbesondere in dem Mitgliedstaat Ihres
    gewöhnlichen Aufenthaltsorts, Ihres Arbeitsplatzes oder des
    Orts des mutmaßlichen Verstoßes, wenn Sie der Ansicht sind,
    dass die Verarbeitung der Sie betreffenden
    personenbezogenen Daten gegen die DSGVO verstößt.</p>

    <p><br/>
    <strong> Begriffsdefinitionen </strong>
    <br/>
    In diesem Abschnitt erhalten Sie eine Übersicht über die in
    dieser Datenschutzerklärung verwendeten Begrifflichkeiten.
    Viele der Begriffe sind dem Gesetz entnommen und vor allem
    im Art. 4 DSGVO definiert. Die gesetzlichen Definitionen
    sind verbindlich.Die nachfolgenden Erläuterungen sollen
    dagegen vor allem dem Verständnis dienen. Die Begriffe sind
    alphabetisch sortiert.
    <br/>
    <br/>
    Personenbezogene Daten: &quot;Personenbezogene Daten&quot; sind alle
    Informationen, die sich auf eine identifizierte oder
    identifizierbare natürliche Person(im Folgenden
    &quot;betroffene Person&quot;) beziehen; als identifizierbar wird
    eine natürliche Person angesehen, die direkt oder indirekt,
    insbesondere mittels Zuordnung zu einer Kennung wie einem
    Namen, zu einer Kennnummer, zu Standortdaten, zu einer
    Online - Kennung (z.B. Cookie) oder zu einem oder mehreren
    besonderen Merkmalen identifiziert werden kann, die
    Ausdruck der physischen, physiologischen, genetischen,
    psychischen, wirtschaftlichen, kulturellen oder sozialen
    Identität dieser natürlichen Person sind.
    <br/>
    Verantwortlicher: Als &quot;Verantwortlicher&quot; wird die
    natürliche oder juristische Person, Behörde, Einrichtung
    oder andere Stelle, die allein oder gemeinsam mit anderen
    über die Zwecke und Mittel der Verarbeitung von
    personenbezogenen Daten entscheidet, bezeichnet.
    <br/>
    Verarbeitung: &quot;Verarbeitung&quot; ist jeder mit oder ohne Hilfe
    automatisierter Verfahren ausgeführte Vorgang oder jede
    solche Vorgangsreihe im Zusammenhang mit personenbezogenen
    Daten.Der Begriff reicht weit und umfasst praktisch jeden
    Umgang mit Daten, sei es das Erheben, das Auswerten, das
    Speichern, das Übermitteln oder das Löschen.</p>

                          </body></html>";
            webview.Source = htmlSource;
        }
    }
}