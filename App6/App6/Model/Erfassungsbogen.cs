namespace App6.Model
{
    //The survey class
    public static class Erfassungsbogen
    {
        //Survey Propteries
        public static int id { get; set; }
        public static int id_form_ebqe { get; set; }
        public static int id_orga_Einrichtung { get; set; }
        public static int id_orga_Wohnbereich { get; set; }
        public static int id_pers_Bewohner { get; set; }
        public static int id_mstr_ebqe { get; set; }
        public static int bogenart { get; set; }
        public static string id_form_ebqe_string { get; set; }
        public static string ende { get; set; }
        public static string endedatum { get; set; }

        //Load Optimization
        public static bool loadedFromDB { get; set; }

        //Layout Properties
        public static bool Is_enabled { get; set; }
        public static string Bewohnerbezeichnung { get; set; }
        public static string Bewohnercode { get; set; }
        public static string Vorname { get; set; }
        public static string Nachname { get; set; }

        // Calculating %
        public static double alg_sum { get; set; }
        public static double mobilitat_sum { get; set; }
        public static double kognitive_sum { get; set; }
        public static double verhalt_sum { get; set; }
        public static double selbst_sum { get; set; }
        public static double bewalt_sum { get; set; }
        public static double gestalt_sum { get; set; }
        public static double dekubitus_sum { get; set; }
        public static double kopergrosse_sum { get; set; }
        public static double sturzfolgen_sum { get; set; }
        public static double freihalten_sum { get; set; }
        public static double schmerzen_sum { get; set; }
        public static double Heimzug_sum { get; set; }
        public static double Einschatzung_sum { get; set; }
        public static double medikamente_sum { get; set; }
        public static double bewgung_sum { get; set; }
        public static double dokumention_sum { get; set; }

        //0. Allgemeines

        public static string t00field01 { get; set; } //Heimeinzug
        public static string t00field02_1 { get; set; } //Geburtsmonat
        public static string t00field02_2 { get; set; } //Geburtsjahr
        public static string t00field03 { get; set; } //Geschlecht
        public static string t00field04 { get; set; } //Pflegegrad
        public static string t00field05 { get; set; } //Gesetzliche Betreuung?
        public static string t00field06 { get; set; } //richterlicher Beschluss zu freiheitsentziehenden Maßnahmen
        public static string t00field07_01 { get; set; } //Apoplex am:
        public static string t00field07_02 { get; set; } //Fraktur am:
        public static string t00field07_03 { get; set; } //Herzinfarkt am:
        public static string t00field07_04 { get; set; } //Amputation am:
        public static string t00field07_05 { get; set; } //Sonstiges Krankheitsereignis - Checkbox
        public static string t00field07_06 { get; set; } //Beschreibung sonstiges Krankheitsereignis:
        public static string t00field08 { get; set; } //0.8 Wurde der Bewohner innerhalb der letzten 6 Monate in einem Krankenhaus behandelt?
        public static string t00field08_01 { get; set; } //vom:
        public static string t00field08_02 { get; set; } //bis
        public static string t00field08_03 { get; set; } //Grund:
        public static string t00field08_04 { get; set; } //Bitte Anzahl der Krankenhausaufenthalte in den letzten 6 Monaten angeben:
        public static string t00field08_05 { get; set; } //Bitte Gesamtzahl der Tage angeben, die der Bewohner bzw. die Bewohnerin bei diesen Aufenthalten im Krankenhaus verbracht hat (falls nicht zutrifft, dann bitte 0 eintragen):
        public static string t00field09 { get; set; } //beatmet?
        public static string t00field10 { get; set; } //Bewusstseinszustand
        public static string t00field11 { get; set; } //0.11 In welcher Position verbringt der Bewohner die Zeit, in der er nicht im Bett liegt
        public static string t00field12 { get; set; } //0.12 Benutzt der Bewohner bei der Fortbewegung einen Rollstuhl?
        public static string t00field13_1 { get; set; } //Diabetes Mellitus
        public static string t00field13_2 { get; set; } //Osteoporose
        public static string t00field13_3 { get; set; } //Bösartige Tumorerkrankung
        public static string t00field13_4 { get; set; } //Demenz
        public static string t00field13_5 { get; set; } //Multiple Sklerose
        public static string t00field13_6 { get; set; } //Tetraplegie/Tetraparese
        public static string t00field13_7 { get; set; } //Parkinson
        public static string t00field13_7_1 { get; set; } //Chorea Huntington
        public static string t00field13_8 { get; set; } //Apallisches Syndrom
        public static string t00field13_9 { get; set; } //COPD (Chronisch obstruktive Lungenerkrankung)
        public static string t00field13_10 { get; set; } //Depression
        public static string t00field13_11 { get; set; } //Sonstige Diagnose
        public static string t00field13_11_1 { get; set; } //Beschreibung Sonstige Diagnose(n):
        public static string t00field13_11_2 { get; set; } //2. Textfeld Sonstige Diagnose(n)

        //1. Mobilität

        public static string t01field01 { get; set; } //1.1 Positionswechsel im Bett
        public static string t01field02 { get; set; } //1.2 Halten einer stabilen Sitzposition
        public static string t01field03 { get; set; } //1.3 Umsetzen
        public static string t01field04 { get; set; } //1.4 Fortbewegen innerhalb des Wohnbereichs
        public static string t01field05 { get; set; } //1.5 Treppensteigen
        public static string t01field06 { get; set; } //1.6 Gebrauchsunfähigkeit beider Arme und Beine

        //2. Kognitive und kommunikative Fähigkeiten

        public static string t02field01 { get; set; } //2.1 Erkennen von Personen aus dem näheren Umfeld
        public static string t02field02 { get; set; } //2.2 Örtliche Orientierung
        public static string t02field03 { get; set; } //2.3 Zeitliche Orientierung
        public static string t02field04 { get; set; } //2.4 Erinnern an wesentliche Ereignisse oder Beobachtungen
        public static string t02field05 { get; set; } //2.5 Steuern von mehrschrittigen Alltagshandlungen
        public static string t02field06 { get; set; } //2.6 Treffen von Entscheidungen im Alltag
        public static string t02field07 { get; set; } //2.7 Verstehen von Sachverhalten und Informationen
        public static string t02field08 { get; set; } //2.8 Erkennen von Risiken und Gefahren
        public static string t02field09 { get; set; } //2.9 Mitteilen von elementaren Bedürfnissen
        public static string t02field10 { get; set; } //2.10 Verstehen von Aufforderungen
        public static string t02field11 { get; set; } //2.11 Beteiligung an einem Gespräch

        //3. Verhaltensweisen und psychische Problemlagen

        public static string t03field01 { get; set; } //3.1 Motorisch geprägte Verhaltensauffälligkeiten
        public static string t03field02 { get; set; } //3.2 Nächtliche Unruhe
        public static string t03field03 { get; set; } //3.3 Selbstschädigendes und autoaggressives Verhalten
        public static string t03field04 { get; set; } //3.4 Beschädigung von Gegenständen
        public static string t03field05 { get; set; } //3.5 Physisch aggressives Verhalten gegenüber anderen Personen
        public static string t03field06 { get; set; } //3.6 Verbale Aggression
        public static string t03field07 { get; set; } //3.7 Andere pflegerelevante vokale Auffälligkeiten
        public static string t03field08 { get; set; } //3.8 Abwehr pflegerischer und anderer unterstützender Maßnahmen
        public static string t03field09 { get; set; } //3.9 Wahnvorstellungen
        public static string t03field10 { get; set; } //3.10 Ängste
        public static string t03field11 { get; set; } //3.11 Antriebslosigkeit bei depressiver Stimmungslage
        public static string t03field12 { get; set; } //3.12 Sozial inadäquate Verhaltensweisen
        public static string t03field13 { get; set; } //3.13 Sonstige pflegerelevante inadäquate Handlungen

        // 4. Selbstversorgung

        public static string t04fields2 { get; set; } //s2. Blasenkontrolle/Harnkontinenz
        public static string t04fields3 { get; set; } //s3. Darmkontrolle/Stuhlkontinenz
        public static string t04field01 { get; set; } //4.1 Waschen des vorderen Oberkörpers
        public static string t04field02 { get; set; } //4.2 Körperpflege im Bereich des Kopfes (Kämmen, Zahnpflege/ Prothesenreinigung, Rasieren)
        public static string t04field03 { get; set; } //4.3 Waschen des Intimbereichs
        public static string t04field04 { get; set; } //4.4 Duschen oder Baden einschließlich Waschen der Haare
        public static string t04field05 { get; set; } //4.5 An- und Auskleiden des Oberkörpers
        public static string t04field06 { get; set; } //4.6 An- und Auskleiden des Unterkörpers
        public static string t04field07 { get; set; } //4.7 Mundgerechtes Zubereiten d. Nahrung , Eingießen v. Getränken
        public static string t04field08 { get; set; } //4.8 Essen
        public static string t04field09 { get; set; } //4.9 Trinken
        public static string t04field10 { get; set; } //4.10 Benutzen einer Toilette oder eines Toilettenstuhls
        public static string t04field11 { get; set; } //4.11 Bewältigung der Folgen einer Harninkontinenz und Umgang mit Dauerkatheter und Urostoma
        public static string t04field12 { get; set; } //4.12 Bewältigung der Folgen einer Stuhlinkontinenz und Umgang mit Stoma
        public static string t04field13 { get; set; } //4.13 Ernährung parenteral oder über Sonde

        //5. Bewältigung von und selbständiger Umgang mit krankheits- und therapiebedingten Anforderungen und Belastungen

        public static string t05field01_03 { get; set; } //5.1 Medikation
        public static string t05field01_02 { get; set; } //Häufigkeit der Hilfe (Anzahl eintragen)
        public static string t05field02_03 { get; set; } //5.2 Injektionen
        public static string t05field02_02 { get; set; } //Häufigkeit der Hilfe
        public static string t05field03_03 { get; set; } //5.3 Versorgung intravenöser Zugänge (z.B. Port)
        public static string t05field03_02 { get; set; } //Häufigkeit der Hilfe (Anzahl eintragen)
        public static string t05field04_03 { get; set; } //5.4 Absaugen und Sauerstoffgabe
        public static string t05field04_02 { get; set; } //Häufigkeit der Hilfe (Anzahl eintragen)
        public static string t05field05_03 { get; set; } //5.5 Einreibungen, Kälte- und Wärmeanwendungen
        public static string t05field05_02 { get; set; } //Häufigkeit der Hilfe (Anzahl eintragen)
        public static string t05field06_03 { get; set; } //5.6 Messung und Deutung von Körperzuständen
        public static string t05field06_02 { get; set; } //Häufigkeit der Hilfe (Anzahl eintragen)
        public static string t05field07_03 { get; set; } //5.7 Körpernahe Hilfsmittel
        public static string t05field07_02 { get; set; } //Häufigkeit der Hilfe (Anzahl eintragen)
        public static string t05field08_03 { get; set; } //5.8 Verbandwechsel und Wundversorgung
        public static string t05field08_02 { get; set; } //Häufigkeit der Hilfe (Anzahl eintragen)
        public static string t05field09_03 { get; set; } //5.9 Versorgung mit Stoma
        public static string t05field09_02 { get; set; } //Häufigkeit der Hilfe (Anzahl eintragen)
        public static string t05field10_03 { get; set; } //5.10 Regelmäßige Einmalkatheterisierung und Nutzung von Abführmethoden
        public static string t05field10_02 { get; set; } //Häufigkeit der Hilfe (Anzahl eintragen)
        public static string t05field11_03 { get; set; } //5.11 Therapiemaßnahmen in häuslicher Umgebung
        public static string t05field11_02 { get; set; } //Häufigkeit der Hilfe (Anzahl eintragen)
        public static string t05field12_03 { get; set; } //5.12 Zeit- und technikintensive Maßnahmen in häuslicher Umgebung
        public static string t05field12_02 { get; set; } //Häufigkeit der Hilfe (Anzahl eintragen)
        public static string t05field13_03 { get; set; } //5.13 Arztbesuche
        public static string t05field13_02 { get; set; } //Häufigkeit der Hilfe (Anzahl eintragen)
        public static string t05field14_03 { get; set; } //5.14 Besuch anderer medizinischer oder therapeutischer Einrichtungen (bis zu 3 Stunden)
        public static string t05field14_02 { get; set; } //Häufigkeit der Hilfe (Anzahl eintragen)
        public static string t05field15_03 { get; set; } //5.15 Zeitlich ausgedehnte Besuche anderer medizinischer Einrichtungen (länger als 3 Stunden)
        public static string t05field15_02 { get; set; } //Häufigkeit der Hilfe (Anzahl eintragen)

        public static string t05field16_01 { get; set; } //5.16 Einhaltung einer Diät oder anderer krankheits- oder therapiebedingter Verhaltensvorschriften, und zwar (bitte angeben):
        public static string t05field16_02 { get; set; } //Auswahl für 5.16

        //6. Gestaltung des Alltagslebens und sozialer Kontakte

        public static string t06field01 { get; set; } //6.1 Gestaltung des Tagesablauf und Anpassung an Veränderungen
        public static string t06field02 { get; set; } //6.2 Ruhen und Schlafen
        public static string t06field03 { get; set; } //6.3 Sichbeschäftigen
        public static string t06field04 { get; set; } //6.4 Vornehmen von in die Zukunft gerichteten Planungen
        public static string t06field05 { get; set; } //6.5 Interaktion mit Personen im direkten Kontakt
        public static string t06field06 { get; set; } //6.6 Kontaktpflege zu Personen außerhalb des direkten Umfeldes

        //7. Dekubitus

        public static string t07field00 { get; set; } //7.0 Hat der Bewohner laut Pflegedokumentation ein erhöhtes Dekubitusrisiko?
        public static string t07field01 { get; set; } //7.1 Hatte der Bewohner während der vergangenen 6 Monate einen Dekubitus?
        public static string t07field02 { get; set; } //7.2 Maximales Dekubitusstadium in den letzten 6 Monaten:
        public static string t07field03_01 { get; set; } //7.3 Bitte Zeitraum angeben (nur Dekubitus Stadium 2, 3 oder 4 oder wenn unbekannt): von:
        public static string t07field03_02 { get; set; } //bis: (ggf. bis heute) höçhstes Stadium
        public static string t07field03_03 { get; set; } //von:
        public static string t07field03_04 { get; set; } //bis:
        public static string t07field04 { get; set; } //7.4.1 Wo ist der Dekubitus entstanden?
        public static string t07field04_02 { get; set; } //7.4.2 Wo ist der zweite Dekubitus entstanden?

        //8. Körpergröße und Gewicht
        public static string t08field01 { get; set; } //8.1 Körpergröße in cm:
        public static string t08field02_01 { get; set; } //8.2 Aktuelles Körpergewicht:
        public static string t08field02_02 { get; set; } //Dokumentiert am (Datum):
        public static string t08field03_01 { get; set; } //Medikamentöse Ausschwemmung/Diuretikatherapie
        public static string t08field03_02 { get; set; } //Diät aufgrund ärztlicher Anordnung
        public static string t08field03_03 { get; set; } //Erheblicher Gewichtsverlust (mind. 10%) während eines Krankenhausaufenthalts
        public static string t08field03_04 { get; set; } //Bewohner wird aufgrund einer Entscheidung des Arztes oder der Angehörigen oder eines Betreuers nicht mehr gewogen
        public static string t08field03_05 { get; set; } //Aktuelles Gewicht liegt nicht vor. Bewohner möchte nicht gewogen werden
        public static string t08field03_06 { get; set; } //sonstiger Grund
        public static string t08field04 { get; set; } //Beschreibung sonstiger Grund

        //9. Sturzfolgen

        public static string t09field01 { get; set; } //9.1 Ist der Bewohner in den vergangenen 6 Monaten gestürzt?
        public static string t09field02_01 { get; set; } //Frakturen
        public static string t09field02_02 { get; set; } //ärztlich behandlungsbedürftige Wunden
        public static string t09field02_03 { get; set; } //andauernde Schmerzen (länger als 48 Std.) mit Beeinträchtigung des Alltagshandelns
        public static string t09field02_04 { get; set; } //erhöhter Unterstützungsbedarf bei Alltagsverrichtungen
        public static string t09field02_05 { get; set; } //erhöhter Unterstützungsbedarf bei der Mobilität
        public static string t09field02_06 { get; set; } //keine der genannten Folgen ist aufgetreten

        //10. Freiheitsentziehende Maßnahmen

        public static string t10field01 { get; set; } //10.1 Wurden bei dem Bewohner in den vergangenen 4 Wochen Gurte angewendet?
        public static string t10field02_01 { get; set; } //Handfixierung
        public static string t10field02_02 { get; set; } //Fußfixierung
        public static string t10field02_03 { get; set; } //Hüftfixierung im Bett
        public static string t10field02_04 { get; set; } //Hüftfixierung im Stuhl oder Rollstuhl
        public static string t10field03 { get; set; } //10.3 Wenn ja: wie oft wurden Gurte angewendet?
        public static string t10field04 { get; set; } //10.4 Ist dokumentiert, dass die Gurte auf Wunsch des Bewohners angelegt wurden?
        public static string t10field05 { get; set; } //10.5 Wurden bei dem Bewohner in den vergangenen 4 Wochen Bettseitenteile angewendet?
        public static string t10field06 { get; set; } //10.6 Wenn ja: wie oft wurden Bettseitenteile angewendet?
        public static string t10field07 { get; set; } //10.7 Ist dokumentiert, dass die Bettseitenteile auf Wunsch des Bewohners angebracht wurden?

        //11. Schmerzen

        public static string t11field01 { get; set; } //11.1 Liegen bei dem Bewohner Anzeichen für wiederholt auftretende Schmerzen vor (z.B. Äußerungen des Bewohners, Hinweise in der Pflegedokumentation, Einnahme von Analgetika oder Verhaltensweisen demenzkranker Bewohner, die auf Schmerzen hindeuten könnten)?
        public static string t11field01a { get; set; } //11.1.a Ist der Bewohner aufgrund einer Schmerzmedikation schmerzfrei?
        public static string t11field02_01 { get; set; } //11.2 Liegt für den Bewohner eine Schmerzeinschätzung vor?
        public static string t11field02_02 { get; set; } //Wenn ja: Wie wurde die Einschätzung durchgeführt?
        public static string t11field02_03 { get; set; } //Welches Einschätzungsinstrument wurde verwendet
        public static string t11field02_04 { get; set; } //Gab es bei der letzten Schmerzeinschätzung Veränderungen gegenüber der davor durchgeführten Einschätzung?
        public static string t11field02_05 { get; set; } //Wann wurde die letzte Schmerzeinschätzung durchgeführt? (Datum):
        public static string t11field02_06 { get; set; } //Wann wurde die vorletzte Schmerzeinschätzung durchgeführt? (Datum):
        public static string t11field03_01 { get; set; } //11.3 Wurde der behandelnde Arzt über die aktuelle Schmerzeinschätzung informiert?
        public static string t11field03_02 { get; set; } //Wann erfolgte die Information (Datum):
        public static string t11field04 { get; set; } //11.4 Ist bei Schmerzzuständen dokumentiert, welche Maßnahmen zur Reduzierung von Schmerzen eingeleitet wurden.

        //12. Heimeinzug

        public static string t12field00 { get; set; } //12.0 Ist der Bewohner innerhalb der letzten 6 Monate neu in die Einrichtung eingezogen?
        public static string t12field01_01 { get; set; } //12.1 Ist der Bewohner innerhalb der ersten 8 Wochen nach dem Einzug länger als drei Tage in einem Krankenhaus versorgt worden?
        public static string t12field01_02 { get; set; } //vom:
        public static string t12field01_03 { get; set; } //bis zum:
        public static string t12field02_01 { get; set; } //12.2 Ist in den Wochen nach dem Heimeinzug mit dem Bewohner und/oder anderen Personen ein Gespräch über sein Einleben und die zukünftige Versorgung geführt worden?
        public static string t12field02_02 { get; set; } //Gespräch am (Datum):
        public static string t12field02_03_01 { get; set; } //Bewohner
        public static string t12field02_03_02 { get; set; } //Angehörige
        public static string t12field02_03_03 { get; set; } //Betreuer
        public static string t12field02_03_04 { get; set; } //andere Vertrauenspersonen, die nicht in der Einrichtung beschäftigt sind
        public static string t12field02_04 { get; set; } //Vertrauensperson:
        public static string t12field03 { get; set; } //12.3 Wurden die Ergebnisse dieses Gespräches dokumentiert?

        //13. Einschätzung von Verhaltensweisen

        public static string t13field01 { get; set; } //13.1 Ist dokumentiert, dass bei Verhaltensweisen und psychische Problemlagen des Bewohners individuelle Maßnahmen eingeleitet wurden?

        //14. Medikamente

        public static string t14field01 { get; set; } //Anzahl der Medikamente:
        public static string t14field02 { get; set; } //Anzahl der Psychopharmaka:
        public static string t14field03 { get; set; } //14.3. Bitte geben Sie an, ob der Bewohner ein verordnetes Schmerzmedikament regelmäßig einnimmt.

        //15. Bewegungseinschränkungen

        public static string t15field01 { get; set; } //15.1 Liegt bei dem Bewohner aktuell eine Bewegungseinschränkung vor?
        public static string t15field02_01 { get; set; } //Hüftgelenk
        public static string t15field02_02 { get; set; } //Kniegelenk
        public static string t15field02_03 { get; set; } //Sprunggelenk (Spitzfuß) 
        public static string t15field02_04 { get; set; } //Schultergelenk
        public static string t15field02_05 { get; set; } //Ellbogengelenk
        public static string t15field03 { get; set; } //15.3 Wo ist die  Bewegungseinschränkung bzw. wo sind die  Bewegungseinschränkungen entstanden?

        //16. Dokumentation

        public static string t16field01 { get; set; } //Ist dokumentiert, dass der Bewohner oder andere autorisierte Personen die Durchführung fachlich gebotener Prophylaxemaßnahmen vollständig ablehnen?
        public static string t16field02 { get; set; } //Dekubitusprophylaxe
        public static string t16field03 { get; set; } //Schmerzmanagement bei akuten Schmerzen
        public static string t16field04 { get; set; } //Schmerzmanagement bei chronischen Schmerzen
        public static string t16field05 { get; set; } //Sturzprophylaxe
        public static string t16field06 { get; set; } //Förderung der Harnkontinenz
        public static string t16field07 { get; set; } //Pflege von chronischen Wunden
        public static string t16field08 { get; set; } //Ernährungsmanagement
        public static string t16field09 { get; set; } //Erhalt und Förderung der Mobilität
        public static string t16field10 { get; set; } //Wurde in den letzten 6 Monaten eine  zahnärztliche Vorsorgeuntersuchung durchgeführt?
        public static string t16field11 { get; set; } //Wenn nein: Ist dokumentiert, dass der Bewohner oder andere autorisierte Personen die Durchführung der zahnärztlichen Vorsorgeuntersuchung ablehnen?
    }
}
