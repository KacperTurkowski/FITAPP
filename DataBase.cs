using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace FITAPP
{
    class DataBase
    {
        public static Dictionary<string, string> passwords = new Dictionary<string, string>();//uzytkownicy
        public static Training todayT;//dzisiejszy trening
        public static Diet todayD;//dzisiejsza dieta
        public static List<Exercise> exercises;//lista ćwiczeń
        public static List<Dish> dishes;//lista posiłków
        public static List<Training> trainings;//lista treningów
        public static List<Diet> diets;//lista diet
        public static List<Training> likedTrainings;
        public static List<Diet> likedDiets;
        public static Training nextTraining;//następny trening
        public static Diet nextDiet;//następna dieta
        public static List<Tag> trainingTag;
        public static List<Tag> dietTags;
        static DataBase()//taki odpowiednik bloku statycznyego w Javie
        {
            passwords.Add("Kacper", "abc");
            passwords.Add("Krystian", "Karczyński");

            exercises = new List<Exercise>();

            Exercise ex1 = new Exercise("Wyciskanie sztangi leżąc ");
            ex1.description = "Kładziemy się tyłem na poziomej ławeczce, stopy opieramy całą powierzchnią na podłożu, sztangę trzymamy nachwytem nad sobą, rozstaw dłoni na gryfie (w zależności elastyczności nadgarstków) powinien wynosić ok. 15-40 cm. Bierzemy wdech, a następnie powoli opuszczamy gryf sztangi w kierunku środkowej części klatki piersiowej (nieco powyżej linii sutków). Zwracamy uwagę, by w trakcie opuszczania sztangi ramiona rozchodziły się na boki. W chwili gdy gryf sztangi dotknie klatki piersiowej, rozpoczynamy ruch powrotny wyciskając (wypychając) sztangę do pozycji wyjściowej. W końcowej fazie ruchu następuje wydech.";
            ex1.image = @"C:\Users\Kacper\source\repos\FITAPP\cw1.png";
            exercises.Add(ex1);

            Exercise ex2 = new Exercise("Przysiad ze sztangą");
            ex2.description = "Chwytamy sztangę dosyć szerokim rozstawem rąk w okolicach talerzy obciążających, a następnie prześlizgujemy się pod nią w taki sposób, aby znalazła się ona z tyłu na naszych barkach, łokcie ściągamy do tyłu. Stajemy na całych stopach, ustawiamy je w pozycji naturalnej, palce skierowane lekko na zewnątrz, rozstaw nieco szerszy od szerokości bioder. Nabieramy powietrza, klatka piersiowa uwypuklona, plecy wyprostowane, dolny grzbiet odchylony do tyłu, mięśnie brzucha napięte, wzrok skierowany w jeden punkt, przed siebie, lekko do góry. Uginamy powoli nogi w kolanach, pochylając się jednocześnie lekko do przodu.Przez cały czas utrzymujemy proste plecy.Schodzimy w sposób kontrolowany do pozycji, w której uda znajdą się mniej więcej równolegle do podłogi, a następnie rozpoczynamy ruch powrotny.W końcowej fazie ruchu powrotnego następuje wydech.";
            ex2.image = @"C:\Users\Kacper\source\repos\FITAPP\cw2.png";
            exercises.Add(ex2);

            Exercise ex3 = new Exercise("Martwy ciąg");
            ex3.description = "Stajemy przodem do sztangi, w niewielkim rozkroku, golenie znajdują się tuż przed gryfem sztangi. Pochylamy się do przodu, nogi mocno ugięte w kolanach. Dla wzmocnienia siły uchwytu, chwytamy gryf jedną ręką nachwytem, a drugą podchwytem nieco szerzej od szerokości barków. Utrzymując plecy wyprostowane, dolny grzbiet odchylony do tyłu i mięśnie brzucha napięte, nabieramy powietrza, a następnie wykorzystując siłę mięśni nóg i grzbietu zaczynamy stawać do pozycji wyprostowanej. Gryf sztangi prowadzimy blisko ciała, cały czas na wyprostowanych rękach. W końcowej fazie ruchu(tułów wyprostowany, sztanga opiera się o górne części ud) następuje wydech. Po osiągnięciu górnej pozycji możemy zatrzymać ruch na 1 - 2 sekundy, po czym rozpoczynamy kontrolowany ruch powrotny, robiąc jednocześnie wdech. W dolnej pozycji nie odkładamy sztangi, tylko rozpoczynamy kolejny ruch do góry.";
            ex3.image = @"C:\Users\Kacper\source\repos\FITAPP\cw3.png";
            exercises.Add(ex3);

            Exercise ex4 = new Exercise("Uginanie przedramion ze sztangą prostą");
            ex4.description = "Stajemy w postawie wyprostowanej, rozkrok na szerokość bioder. Sztangę prostą trzymamy w obu dłoniach podchwytem na wysokości górnej części ud, rozstaw rąk na szerokość barków lub nieco szerzej, plecy wyprostowane, brzuch wciągnięty. Przed rozpoczęciem ruchu, bierzemy wdech, a następnie uginając przedramiona unosimy sztangę powoli, płynnym ruchem po kole do góry, aż do pełnego ugięcia rąk.W końcowej fazie ruchu następuje wydech.Następnie, trzymając przez cały czas ciężar pod kontrolą, opuszczamy sztangę po tym samym torze do pozycji wyjściowej. W trakcie opuszczania sztangi robimy jednocześnie wdech. Należy zwrócić szczególną uwagę, aby w trakcie unoszenia, jak i opuszczania ciężaru nie ułatwiać sobie ruchu kołysaniem tułowia. Łokcie powinny przez cały czas przylegać do boków tułowia.";
            ex4.image = @"C:\Users\Kacper\source\repos\FITAPP\cw4.png";
            exercises.Add(ex4);

            Exercise ex5 = new Exercise("Francuskie wyciskanie sztangą leżąc");
            ex5.description = "W leżeniu na plecach na płaskiej ławce, trzymamy sztangę nachwytem na wyprostowanych ramionach prostopadle do podłoża, rozstaw dłoni nieco węższy od szerokości barków. Bierzemy wdech i trzymając ramiona nieruchomo, powoli uginamy ręce w łokciach opuszczając ciężar po kole do czoła lub tuż za głowę. Następnie powracamy do pozycji wyjściowej robiąc jednocześnie wydech. Należy zwrócić uwagę, aby w trakcie wykonywania ćwiczenia łokcie nie rozchylały się nam na boki. Ważne jest też utrzymanie ciągłego napięcia mięśni w każdej fazie ruchu, w szczególności w górnym położeniu sztangi.   Jeśli odczuwamy zbyt duże naprężenia w obrębie stawów nadgarstkowych, możemy zastosować sztangę łamaną zamiast prostej lub nieco zmienić rozstaw dłoni na gryfie.Ruch w fazie negatywnej(opuszczania ciężaru) powinien być też nieco wolniejszy od unoszenia.";
            ex5.image = @"C:\Users\Kacper\source\repos\FITAPP\cw5.png";
            exercises.Add(ex5);

            Exercise ex6 = new Exercise("Unoszenie nóg w zwisie na drążku");
            ex6.description = "Rękoma chwytamy drążek, nogi lekko ugięte w kolanach. Bierzemy wdech i unosimy nogi z poziomu do pozycji mniej więcej prostopadłej do tułowia, robiąc w końcowej fazie unoszenia wydech. Następnie nie zmieniając ugięcia w stawach kolanowych, opuszczamy nogi do pozycji wyjściowej, robiąc jednocześnie wdech. Należy zwracać szczególną uwagę, aby zarówno w trakcie unoszenia, jak i opuszczania nóg nie rozluźniać mięśni grzbietu.Grzbiet powinien przez cały czas być prosty.Wygięcie go na kształt mostka w dużym stopniu niweluje skuteczność tego ćwiczenia i może być przyczyną bólu w obrębie kręgosłupa.";
            ex6.image = @"C:\Users\Kacper\source\repos\FITAPP\cw6.png";
            exercises.Add(ex6);

            Exercise ex7 = new Exercise("Wyciskanie hantli nad głowę");
            ex7.description = "Przyjmujemy pozycję siedzącą na ławeczce. Plecy przylegają do oparcia ławeczki, ustawionego pod kątem 80° - 90° w stosunku do podłoża. Bierzemy wdech i wyciskamy hantle prosto do góry, robiąc w końcowej fazie wydech. W górnym położeniu hantli, dla utrzymania ciągłego napięcia mięśni naramiennych, nie blokujemy rąk w stawach łokciowych – zostawiamy minimalne ugięcie.Następnie w sposób kontrolowany opuszczamy hantle do pozycji wyjściowej, robiąc jednocześnie wdech.";
            ex7.image = @"C:\Users\Kacper\source\repos\FITAPP\cw7.png";
            exercises.Add(ex7);

            Exercise ex8 = new Exercise("Podciąganie na drążku nachwytem");
            ex8.description = "W zwisie na drążku (drążek trzymany nachwytem), ramiona szeroko rozstawione, bierzemy wdech i podciągamy się w taki sposób, aby górna część klatki znalazła się prawie na wysokości drążka. W końcowej fazie ruchu następuje wydech. Następnie w sposób kontrolowany opuszczamy się do pozycji wyjściowej biorąc jednocześnie wdech. Można dojść do dużej wprawy w podciąganiu się na drążku. Stąd też, aby zwiększyć intensywność tego ćwiczenia w sytuacji, kiedy staje się ono już zbyt łatwe do wykonania, mocuje się do pasa dodatkowe obciążenie.";
            ex8.image = @"C:\Users\Kacper\source\repos\FITAPP\cw8.png";
            exercises.Add(ex8);

            Exercise ex9 = new Exercise("Ściąganie drążka wyciągu górnego do klatki ");
            ex9.description = "Przyjmujemy pozycję siedzącą pod wyciągiem górnym. Stopy przylegają równo do podłoża. W przypadku stosowania większych obciążeń kolana powinny być dodatkowo wsunięte pod wałek blokujący nogi. Drążek wyciągu trzymamy nachwytem nad sobą, ramiona rozstawione dosyć szeroko. Bierzemy wdech i przyciągamy drążek do górnej części klatki piersiowej, odwodząc jednocześnie łokcie do tyłu i uwypuklając klatkę piersiową. W końcowej fazie ruchu następuje wydech. Następnie powoli, w sposób kontrolowany powracamy do pozycji wyjściowej, biorąc jednocześnie wdech.Należy zwrócić szczególną uwagę, aby w trakcie ściągania drążka do klatki, nie odchylać górnej część tułowia za daleko do tyłu.Odchylenie od pionu nie powinno być większe niż 10 - 15°. Zbyt duże odchylenie tułowia do tyłu spowoduje, że ćwiczenie ogromnie straci na skuteczności. W trakcie ruchu powrotnego tułów powinien powrócić do pozycji wyjściowej czyli pionowego ustawienia względem podłoża.";
            ex9.image = @"C:\Users\Kacper\source\repos\FITAPP\cw9.png";
            exercises.Add(ex9);


            Exercise ex10 = new Exercise("Wyciskanie sztangielek w leżeniu na skośnej ławce");
            ex10.description = "W leżeniu na plecach na skośnej ławce, stopy oparte na podłożu, sztangielki trzymamy nachwytem na wysokości klatki piersiowej. Oparcie ławeczki powinno być uniesione pod kątem 35° do 45° względem podłoża. Bierzemy wdech i wypychamy(wyciskamy) obie sztangielki do góry, zbliżając je jednocześnie do siebie.W końcowej fazie ruchu napinamy mięśnie klatki piersiowej(stosując skurcz izometryczny) i robimy wydech.Następnie w sposób kontrolowany opuszczamy sztangielki do pozycji wyjściowej robiąc wdech.Podczas opuszczania sztangielek należy zwrócić uwagę, aby ramiona rozchodziły się na boki.";
            ex10.image = @"C:\Users\Kacper\source\repos\FITAPP\cw10.png";
            exercises.Add(ex10);

            dishes = new List<Dish>();

            Dish d1 = new Dish("Fit gofry");
            d1.recipe = "Dodajemy do miski kolejno mąkę pszenną, pełnoziarnistą, proszek do pieczenia, odzywkę białkową i sól. Mieszamy składniki łyżką aby wszystko ładnie się połączyło. Białka oddzielamy od żółtek. Ubijamy białka na sztywno. Do miski z sypkimi składnikami dodajemy żółtka jaj i mleko. Wszystko mieszamy mikserem.Po połączeniu się składników dodajemy ubite białko i mieszamy wszystko razem łyżką(nie używamy w tym kroku miksera).Porcję ciasta przelewamy do rozgrzanej gofrownicy. Ja piekę około 4 - 5 minut.Są wtedy idealne.Ale pewnie czas jest zależny od naszej gofrownicy. Proponuje poeksperymentować z czasem.Podajemy z ulubionymi dodatkami. Smacznego.";
            d1.image = @"C:\Users\Kacper\source\repos\FITAPP\d1.png";
            d1.ingredients = "•	Mąka pszenna pełnoziarnista – 1,5 szklanki\n•	Mąka pszenna – 0,5 szklanki\n•	Jajka – 2 sztuki\n•	Proszek do pieczenia – 1,5 łyżeczki\n•	Mleko – 1,5 szklanki\n•	Szczypta soli\n•	Odżywka białkowa – 50g(można nie dodawać)";
            d1.kcal = 168.75;
            d1.protein = 11.84;
            d1.fat = 23.88;
            d1.carbs = 23.69;

            dishes.Add(d1);

            Dish d2 = new Dish("Makaron z pesto i kurczakiem");
            d2.recipe = "Kurczaka kroimy na kawałki, mieszamy z przyprawą do kurczaka i pieprzem. Smażymy go na niewielkiej ilości wybranego tłuszczu. Stawiamy wodę na makaron. Makaron gotujemy według wskazówek na opakowaniu. Do prawie usmażonego kurczaka dodajemy przekrojone na pół oliwki. Odcedzamy makaron i dodajemy go na patelnie do kurczaka i oliwek.Wszystko mieszamy z pesto i chwilkę podsmażamy. Smaczego!";
            d2.image = @"C:\Users\Kacper\source\repos\FITAPP\d2.png";
            d2.ingredients = "•	Tagliatelle z dodatkiem szpinaku i pomidorów (biedronka) – 160g\n•	Przyprawa do kurczaka – 1 łyżki\n•	Pieprz\n•	Pierś z kurczaka – 200 \n•	Pesto zielone – około 6 łyżeczek\n•	Oliwki zielone drylowane - 2 łyżeczki";
            d2.kcal = 465;
            d2.protein = 32;
            d2.fat = 9.9;
            d2.carbs = 62.55;
            dishes.Add(d2);

            Dish d3 = new Dish("Deser Monte");
            d3.recipe = "Jogurt grecki dzielimy na pół. Do pierwszej połowy dodajemy stopniowo rozpuszczoną gorzą czekoladę i cały czas mieszamy. Gdy ładnie się wymiesza, dodajemy kakao i miód. Wlewamy do dwóch pucharków. Drugą połowę jogurtu blendujemy razem z bananem.Wlewamy powoli na górną warstwę czekoladowej masy.Całość posypujemy kakao.Pozostawiam na chwilkę w lodówce aby się schłodziło. Smacznego.";
            d3.image = @"C:\Users\Kacper\source\repos\FITAPP\d3.png";
            d3.ingredients = "•	Jogurt grecki – 400g\n•	Kakao – 1 łyżka\n•	Czekolada gorzka – 2 rządki\n•	Miód – 1 łyżka\n•	Banan – 1 sztuka";
            d3.kcal = 886;
            d3.protein = 20;
            d3.fat = 51.7;
            d3.carbs = 85.2;
            dishes.Add(d3);

            Dish d4 = new Dish("Makaron z serem");
            d4.recipe = "Makaron gotujemy według przepisu na opakowaniu. Odcedzamy i mieszamy z twarogiem i łyżką miodu. Posypujemy cynamonem.";
            d4.image = @"C:\Users\Kacper\source\repos\FITAPP\d4.png";
            d4.ingredients = "•	Kostka twarogu półtłustego – 250 g\n •	Makaron pene – 70 g\n•	Miód – 1 łyżka\n•	Cynamon";
            d4.kcal = 505;
            d4.protein = 48.1;
            d4.fat = 11.1;
            d4.carbs = 51.7;
            dishes.Add(d4);

            Dish d5 = new Dish("Fit przekąska z sera twarogowego, jabłka i cynamonu");
            d5.recipe = "Rozdrabiamy ser twarogowy na talerz. Trzemy jabłko na grubych oczkach i lekko odsączamy z wody papierem ręcznikowym. Na twaróg kładziemy jabłko i posypujemy cynamonem. Opcjonalnie do sera można dodać ksylitol lub erytrytol jeśli lubimy na bardzo słodko. ";
            d5.image = @"C:\Users\Kacper\source\repos\FITAPP\d5.png";
            d5.ingredients = "•	Kostka sera twarogowego – 250 g\n•	Jabłko 1 sztuka\n•	Cynamon";
            d5.kcal = 385;
            d5.protein = 43.2;
            d5.fat = 10.7;
            d5.carbs = 30.6;
            dishes.Add(d5);

            Dish d6 = new Dish("Zapiekanka makaronowa");
            d6.recipe = "Makaron gotujemy al dente. W tym czasie podsmażamy wyciśnięty przez praskę czosnek, a po 1 minucie dodajemy pokrojoną cebulę. Jak cebulka ładnie się zarumieni dodajemy mięso mielone. Posypujemy ulubionymi przyprawami.Ja dałam sól, pieprz, dużo papryki czerwonej, pieprz cayenne. Gdy mięso już będzie ładnie podsmażone dodajemy pomidory z puszki. Czas na przyprawy.przyprawy.Ja dosypałam sól, pieprz, miks przypraw do kuchni włoskiej. Wszystko dusimy około 10 minut.Makaron odcedzamy i mieszamy z sosem. Przekładamy gotowe danie do naszycia żaroodpornego. Na wierzch dodajemy rozdrobiony ser i posypujemy przyprawą do kuchni włoskiej lub np bazylią. Wszystko pieczemy bez przykrycia w 180 stopniach około 20 minut.";
            d6.image = @"C:\Users\Kacper\source\repos\FITAPP\d6.png";
            d6.ingredients = "•	Makaron pene – 300 g\n•	Mięso mielone z kurczaka – 400 g\n•	Pomidory z puszki – 2 puszki\n•	Kulka sera mozzarella – 1 sztuka\n•	Cebula – 1 sztuk\n•	Czosnek – 4 ząbki\n•	Ulubione przyprawy";
            d6.kcal = 363;
            d6.protein = 33.1;
            d6.fat = 11.65;
            d6.carbs = 29.13;
            dishes.Add(d6);

            Dish d7 = new Dish("Szakszuka z cieciorką");
            d7.recipe = "Na rozgrzaną patelnię z odrobiną oleju dodajemy wyciśnięty przez praskę czosnek. Chwilkę podsmażamy i dodajemy pomidory i umytą wcześniej z zalewy cieciorkę. Przyprawiamy do smaku chwilkę gotując. Zostawiamy pomidory na patelni na dużym ogniu na około 5 minut aby odparowała woda. Następnie formujemy łopatka niewielkie otwory i wbijamy tam jajka.Posypujemy jajka pieprzem i solą. Przykrywamy patelnią pokrywką i trzymamy tak około 5 minuta aż jaja się zetną.Wszystko posypujemy szczypiorkiem.";
            d7.image = @"C:\Users\Kacper\source\repos\FITAPP\d7.png";
            d7.ingredients = "•	Pomidory krojone w puszce\n•	Cieciorka z puszki – 100g\n•	Jajka – 2 sztuk\n•	Szczypiorek\n•	Sól i pieprz\n•	Czosnek – 2 ząbki";
            d7.kcal = 373;
            d7.protein = 25.4;
            d7.fat = 12;
            d7.carbs = 36.5;
            dishes.Add(d7);

            Dish d8 = new Dish("Nocna owsianka z jabłkiem i cynamonem");
            d8.recipe = "Płatki owsiane wsypujemy do naczynia. Dodajemy otręby, siemię lniane, pół łyżeczki cynamonu i ksylitol (bo bardzo lubię owsianki, które są bardzo słodkie). Wszystkie te suche składniki mieszamy ze sobą. Wszystko zalewam mlekiem.Ja używam krowiego, ale jeśli go nie pijesz to super będzie tu pasowało mleko sojowe lub woda. Owsiankę mieszam i zostawiam na noc w lodówcę. Rano ścieramy na tarce o grubych oczkach małe jabłko.Odsączamy lekko ręcznikiem papierowym i kładziemy na wierzch. Posypujemy odrobiną cynamonu.Smacznego!";
            d8.image = @"C:\Users\Kacper\source\repos\FITAPP\d8.png";
            d8.ingredients = "•	Płatki owsiane – 60g\n•	Ksylitol – 20g\n•	Siemię lniane — 1 łyżeczka\n•	Otręby pszenne – 2 łyżeczki\n•	Mleko 0,5 % – 200ml\n•	Cynamon\n•	Jabłko – jedno małe";
            d8.kcal = 449;
            d8.protein = 16.4;
            d8.fat = 8.2;
            d8.carbs = 90.6;
            dishes.Add(d8);

            Dish d9 = new Dish("Pizza z patelni");
            d9.recipe = "Miksujemy wszystkie składniki na ciasto. Dodajemy odrobinę wody jeśli ciasto jest bardzo geste. Ciasto wykładamy na rozgrzaną patelnie i formujemy łyżką okrągły placek. Smażymy na jednej stronie 2 minuty i delikatnie obracamy. Gdy smaży się na drugiej stronie smarujemy placek łyżką ketchupu, nakładamy mozzarellę i szynkę. Pizzę zamykamy pokrywką i smażymy około 10 minut na małym ogniu. Pizzę po wyjęciu z patelni kroję i posypuje szczypiorkiem.";
            d9.image = @"C:\Users\Kacper\source\repos\FITAPP\d9.png";
            d9.ingredients = "Ciasto\n•	Mąka pszenna pełnoziarnista – 50g\n•	Jajo kurze – 1 sztuka\n•	Otręby pszenne – 1 łyżka\n•	Proszek do pieczenia – 1 / 2 łyżeczki\n•	Olej – 1 łyżka\n•	Mleko 0,5 % – 40 ml\n Składniki na pizzę\n•	Ketchup – 1 łyżka\n•	Mozzarella – 1 / 2 opakowania\n•	Szynka z piersi z kurczaka – 30g\n•	Szczypiorek do posypania";
            d9.kcal = 576;
            d9.protein = 34.9;
            d9.fat = 27.7;
            d9.carbs = 45.9;
            dishes.Add(d9);

            Dish d10 = new Dish("Szybkie muffinki czekoladowe z bananami");
            d10.recipe = "Dodajemy wszystkie składniki do wysokiego naczynia i blendujemy na gładką masę (taką jak na zdjęciu poniżej). Wlewamy masę do foremek i pieczemy około 30 / 35 minut w temperaturze 180 stopni cały czas sprawdzając. Ciasto powinno być w miarę wilgotne.";
            d10.image = @"C:\Users\Kacper\source\repos\FITAPP\d10.png";
            d10.ingredients = "•	Banany – 2 sztuki\n•	Jajko\n•	Płatki owsiane – 80g\n•	Ksylitol – 30g\n•	Kakao ciemne – 20g\n•	Proszek do pieczenia – 1 łyżeczka\n•	Szczypta soli";
            d10.kcal = 65;
            d10.protein = 1.95;
            d10.fat = 1.35;
            d10.carbs = 12.7;
            dishes.Add(d10);

            trainingTag = new List<Tag>();

            Tag tr1 = new Tag("Brazylijskie Posladki", "");
            Tag tr2 = new Tag("Klatka Piersiowa", "");
            Tag tr3 = new Tag("Płaski brzuch", "");
            Tag tr4 = new Tag("Wielki Biceps", "");
            Tag tr5 = new Tag("Triceps", "");
            Tag tr6 = new Tag("Góra ciała", "");
            Tag tr7 = new Tag("Nogi", "");
            Tag tr8 = new Tag("Plecy", "");
            Tag tr9 = new Tag("Przedramię", "");
            Tag tr10 = new Tag("Core ciała", "");
            Tag tr11 = new Tag("Wydolność", "");
            Tag tr12 = new Tag("Cardio", "");

            trainingTag.Add(tr1);
            trainingTag.Add(tr2);
            trainingTag.Add(tr3);
            trainingTag.Add(tr4);
            trainingTag.Add(tr5);
            trainingTag.Add(tr6);
            trainingTag.Add(tr7);
            trainingTag.Add(tr8);
            trainingTag.Add(tr9);
            trainingTag.Add(tr10);
            trainingTag.Add(tr11);
            trainingTag.Add(tr12);

            //tagi diety
            dietTags = new List<Tag>();

            Tag di1 = new Tag("Wegetarianska", "");
            Tag di2 = new Tag("Ketogeniczna", "");
            Tag di3 = new Tag("Paleolityczna", "");
            Tag di4 = new Tag("Ducana", "");
            Tag di5 = new Tag("Atkinsa", "");
            Tag di6 = new Tag("Cukrzycowa", "");
            Tag di7 = new Tag("Lekkostrawna", "");

            dietTags.Add(di1);
            dietTags.Add(di2);
            dietTags.Add(di3);
            dietTags.Add(di4);
            dietTags.Add(di5);
            dietTags.Add(di6);
            dietTags.Add(di7);

            //treningi
            trainings = new List<Training>();

            List<Exercise> extemp = new List<Exercise>();
            List<int> amt = new List<int>();
            amt.Add(12);
            amt.Add(8);
            amt.Add(12);
            amt.Add(9);
            extemp.Add(exercises[0]);
            extemp.Add(exercises[3]);
            extemp.Add(exercises[4]);
            extemp.Add(exercises[9]);
            Training oneday = new Training("Jednodniowy trening góry ciała", extemp, amt);
            oneday.description = "Jednodniowy trening Góry ciała przeznaczony dla sportowców chcących rozbudować swoją klatkę piersiową oraz barki";
            oneday.tags = new List<Tag> { trainingTag[1], trainingTag[3], trainingTag[5] };
            oneday.average_grade = 4.3;
            trainings.Add(oneday);

            List<Exercise>[] extemp2 = new List<Exercise>[7];
            List<int>[] exAmount2 = new List<int>[7];
            for(int i = 0; i < 7; i++)
            {
                extemp2[i] = new List<Exercise>();
                exAmount2[i] = new List<int>();
            }
            extemp2[0].Add(exercises[0]);
            extemp2[0].Add(exercises[3]);
            extemp2[0].Add(exercises[9]);

            exAmount2[0].Add(12);
            exAmount2[0].Add(8);
            exAmount2[0].Add(9);

            extemp2[1].Add(exercises[1]);
            extemp2[1].Add(exercises[2]);
            extemp2[1].Add(exercises[5]);

            exAmount2[1].Add(5);
            exAmount2[1].Add(5);
            exAmount2[1].Add(16);

            extemp2[2].Add(exercises[7]);
            extemp2[2].Add(exercises[4]);
            extemp2[2].Add(exercises[8]);

            exAmount2[2].Add(10);
            exAmount2[2].Add(8);
            exAmount2[2].Add(5);

            Training fewday = new Training("Trzydniowy trening wielofunkcyjny", extemp2, exAmount2);
            fewday.description = "Trzydniowy trening całego ciała pozwalający na zachowanie równowagi pomiędzy każdą partią mięśniową";
            fewday.tags = new List<Tag> { trainingTag[1], trainingTag[3], trainingTag[5], trainingTag[9] };
            fewday.average_grade = 3.9;
            trainings.Add(fewday);

            List<Exercise>[] extemp3 = new List<Exercise>[7];
            List<int>[] exAmount3 = new List<int>[7];
            for(int i = 0; i < 7; i++)
            {
                extemp3[i] = new List<Exercise>();
                exAmount3[i] = new List<int>();
            }
            extemp3[0].Add(exercises[0]);
            extemp3[0].Add(exercises[3]);

            exAmount3[0].Add(12);
            exAmount3[0].Add(8);

            extemp3[1].Add(exercises[2]);
            extemp3[1].Add(exercises[5]);

            exAmount3[1].Add(5);
            exAmount3[1].Add(12);

            extemp3[2].Add(exercises[1]);
            extemp3[2].Add(exercises[9]);

            exAmount3[2].Add(9);
            exAmount3[2].Add(5);

            extemp3[3].Add(exercises[8]);
            extemp3[3].Add(exercises[5]);

            exAmount3[3].Add(6);
            exAmount3[3].Add(16);

            extemp3[4].Add(exercises[6]);
            extemp3[4].Add(exercises[4]);

            exAmount3[4].Add(3);
            exAmount3[4].Add(14);

            extemp3[5].Add(exercises[2]);
            extemp3[5].Add(exercises[6]);

            exAmount3[5].Add(8);
            exAmount3[5].Add(12);

            extemp3[6].Add(exercises[5]);
            extemp3[6].Add(exercises[7]);

            exAmount3[6].Add(7);
            exAmount3[6].Add(14);


            Training weekday = new Training("Całotygodniowa Aktywność", extemp3, exAmount3);
            weekday.description = "Całotygodniowy trening pozwalający na zachowanie swojej masy mięśniowej a także spalenie nadmiarowej tkanki tłuszczowej";
            weekday.tags = new List<Tag> { trainingTag[6], trainingTag[7], trainingTag[8], trainingTag[9], trainingTag[10] };
            weekday.average_grade = 3.2;
            trainings.Add(weekday);

            todayT = trainings[0];
            nextTraining = trainings[1];
            likedTrainings = new List<Training>();
            likedTrainings.Add(trainings[2]);
            likedTrainings.Add(trainings[0]);

           
            diets = new List<Diet>();
            List<Dish>[] dishtemp = new List<Dish>[6];
            List<double>[] dishAmount = new List<double>[6];
            for(int i = 0; i < 6; i++)
            {
                dishtemp[i] = new List<Dish>();
                dishAmount[i] = new List<double>();
            }
            dishtemp[0].Add(dishes[0]);
            dishtemp[0].Add(dishes[2]);
            dishtemp[1].Add(dishes[4]);
            dishtemp[2].Add(dishes[5]);
            dishtemp[3].Add(dishes[9]);
            dishtemp[4].Add(dishes[2]);
            dishtemp[5].Add(dishes[7]);

            dishAmount[0].Add(0.5);
            dishAmount[0].Add(0.5);
            dishAmount[1].Add(1);
            dishAmount[2].Add(1.5);
            dishAmount[3].Add(3);
            dishAmount[4].Add(0.5);
            dishAmount[5].Add(1);
            
            Diet onediet = new Diet("Jednodniowa dieta rozbudowująca masę mięśniową", dishtemp, dishAmount);
            onediet.description = "Dieta pełna smakowitych dań, zawierających przy tym odpowiednie dawki protein niezbędnych dla organizmu w procesie budowania masy mięśniowej";
            
            List<Tag> tempTag = new List<Tag>();
            onediet.tags = new List<Tag> { dietTags[4], dietTags[6] };
            onediet.average_grade = 3.54;
            
            diets.Add(onediet);

            List<Dish>[,] dishtemp2 = new List<Dish>[7, 6];
            List<double>[,] dishAmount2 = new List<double>[7, 6];

            for(int i = 0; i < 7; i++)
            {
                for(int j = 0; j < 6; j++)
                {
                    dishtemp2[i,j] = new List<Dish>();
                    dishAmount2[i,j] = new List<double>();
                }
            }

            dishtemp2[0, 0].Add(dishes[0]);
            dishtemp2[0, 1].Add(dishes[4]);
            dishtemp2[0, 2].Add(dishes[5]);
            dishtemp2[0, 3].Add(dishes[9]);
            dishtemp2[0, 4].Add(dishes[2]);
            dishtemp2[0, 5].Add(dishes[7]);

            dishAmount2[0, 0].Add(2);
            dishAmount2[0, 1].Add(1);
            dishAmount2[0, 2].Add(1.5);
            dishAmount2[0, 3].Add(3);
            dishAmount2[0, 4].Add(0.5);
            dishAmount2[0, 5].Add(1);

            dishtemp2[1, 0].Add(dishes[6]);
            dishtemp2[1, 1].Add(dishes[8]);
            dishtemp2[1, 2].Add(dishes[3]);
            dishtemp2[1, 3].Add(dishes[1]);
            dishtemp2[1, 4].Add(dishes[0]);
            dishtemp2[1, 5].Add(dishes[7]);

            dishAmount2[1, 0].Add(1);
            dishAmount2[1, 1].Add(2.5);
            dishAmount2[1, 2].Add(1.5);
            dishAmount2[1, 3].Add(0.5);
            dishAmount2[1, 4].Add(2);
            dishAmount2[1, 5].Add(1);

            dishtemp2[2, 0].Add(dishes[7]);
            dishtemp2[2, 1].Add(dishes[3]);
            dishtemp2[2, 2].Add(dishes[4]);
            dishtemp2[2, 3].Add(dishes[5]);
            dishtemp2[2, 4].Add(dishes[9]);
            dishtemp2[2, 5].Add(dishes[1]);

            dishAmount2[2, 0].Add(1.5);
            dishAmount2[2, 1].Add(1);
            dishAmount2[2, 2].Add(1.5);
            dishAmount2[2, 3].Add(1.5);
            dishAmount2[2, 4].Add(2.5);
            dishAmount2[2, 5].Add(1);

            dishtemp2[3, 0].Add(dishes[0]);
            dishtemp2[3, 1].Add(dishes[5]);
            dishtemp2[3, 2].Add(dishes[8]);
            dishtemp2[3, 3].Add(dishes[2]);
            dishtemp2[3, 4].Add(dishes[6]);
            dishtemp2[3, 5].Add(dishes[7]);

            dishAmount2[3, 0].Add(2);
            dishAmount2[3, 1].Add(1);
            dishAmount2[3, 2].Add(1.5);
            dishAmount2[3, 3].Add(3);
            dishAmount2[3, 4].Add(0.5);
            dishAmount2[3, 5].Add(1);

            dishtemp2[4, 0].Add(dishes[4]);
            dishtemp2[4, 1].Add(dishes[6]);
            dishtemp2[4, 2].Add(dishes[8]);
            dishtemp2[4, 3].Add(dishes[3]);
            dishtemp2[4, 4].Add(dishes[2]);
            dishtemp2[4, 5].Add(dishes[9]);

            dishAmount2[4, 0].Add(2.5);
            dishAmount2[4, 1].Add(1);
            dishAmount2[4, 2].Add(0.5);
            dishAmount2[4, 3].Add(2);
            dishAmount2[4, 4].Add(0.5);
            dishAmount2[4, 5].Add(1);


            dishtemp2[5, 0].Add(dishes[0]);
            dishtemp2[5, 1].Add(dishes[3]);
            dishtemp2[5, 2].Add(dishes[7]);
            dishtemp2[5, 3].Add(dishes[8]);
            dishtemp2[5, 4].Add(dishes[2]);
            dishtemp2[5, 5].Add(dishes[7]);
       
            dishAmount2[5, 0].Add(2);
            dishAmount2[5, 1].Add(1);
            dishAmount2[5, 2].Add(1.5);
            dishAmount2[5, 3].Add(1.5);
            dishAmount2[5, 4].Add(1.5);
            dishAmount2[5, 5].Add(1);

            dishtemp2[6, 0].Add(dishes[4]);
            dishtemp2[6, 1].Add(dishes[3]);
            dishtemp2[6, 2].Add(dishes[7]);
            dishtemp2[6, 3].Add(dishes[5]);
            dishtemp2[6, 4].Add(dishes[1]);
            dishtemp2[6, 5].Add(dishes[9]);

            dishAmount2[6, 0].Add(2);
            dishAmount2[6, 1].Add(1);
            dishAmount2[6, 2].Add(1.5);
            dishAmount2[6, 3].Add(3);
            dishAmount2[6, 4].Add(0.5);
            dishAmount2[6, 5].Add(1);


            Diet fulldiet = new Diet("Całotygodniowa dieta na masę", dishtemp, dishAmount);
            fulldiet.description = "Dieta pełna smakowitych dań, zawierających przy tym odpowiednie dawki protein niezbędnych dla organizmu w procesie budowania masy mięśniowej. Każdy posiłek posiada dostosowane ilości makroskładników dzięki czemu zapewnia energię na progresję objętości oraz częstotliwości treningów";
            fulldiet.tags = new List<Tag> { dietTags[4], dietTags[6], dietTags[1] };
            fulldiet.average_grade = 4.7;
            diets.Add(fulldiet);

            List<Dish>[] dishtemp1 = new List<Dish>[6];
            List<double>[] dishAmount1 = new List<double>[6];
            for(int i = 0; i < 6; i++)
            {
                dishtemp1[i] = new List<Dish>();
                dishAmount1[i] = new List<double>();
            }

            dishtemp1[0].Add(dishes[0]);
            dishtemp1[0].Add(dishes[2]);
            dishtemp1[1].Add(dishes[4]);
            dishtemp1[2].Add(dishes[5]);
            dishtemp1[3].Add(dishes[9]);
            dishtemp1[4].Add(dishes[2]);
            dishtemp1[5].Add(dishes[7]);

            dishAmount1[0].Add(0.5);
            dishAmount1[0].Add(0.5);
            dishAmount1[1].Add(1);
            dishAmount1[2].Add(1.5);
            dishAmount1[3].Add(3);
            dishAmount1[4].Add(0.5);
            dishAmount1[5].Add(1);

            Diet onediet1 = new Diet("Jednodniowa dieta wegetariańska dla cukrzyków", dishtemp1, dishAmount1);
            onediet1.description = "Dieta odpowiednia dla osób chorych na cukrzyce oraz odrzucających jedzenie zwierząt.";
            onediet1.tags = new List<Tag> { dietTags[0], dietTags[6] };
            onediet1.average_grade = 4.22;
            diets.Add(onediet1);

            List<Dish>[] dishtemp4 = new List<Dish>[6];
            List<double>[] dishAmount4 = new List<double>[6];

            for(int i = 0; i < 6; i++)
            {
                dishtemp4[i] = new List<Dish>();
                dishAmount4[i] = new List<double>();
            }

            dishtemp4[0].Add(dishes[0]);
            dishtemp4[0].Add(dishes[2]);
            dishtemp4[1].Add(dishes[4]);
            dishtemp4[2].Add(dishes[5]);
            dishtemp4[3].Add(dishes[9]);
            dishtemp4[4].Add(dishes[2]);
            dishtemp4[5].Add(dishes[7]);

            dishAmount4[0].Add(0.5);
            dishAmount4[0].Add(0.5);
            dishAmount4[1].Add(1);
            dishAmount4[2].Add(1.5);
            dishAmount4[3].Add(3);
            dishAmount4[4].Add(0.5);
            dishAmount4[5].Add(1);

            Diet onediet2 = new Diet("Ketogeniczna dieta na redukcję", dishtemp2, dishAmount2);
            onediet2.description = "Dieta dla osób chcących zrzucić nadmiar kalorii poprzez stan ketozy";
            onediet2.tags = new List<Tag> { dietTags[1], dietTags[6] };
            onediet2.average_grade = 3.94;

            diets.Add(onediet2);

            List<Dish>[] dishtemp3 = new List<Dish>[6];
            List<double>[] dishAmount3 = new List<double>[6];

            for(int i = 0; i < 6; i++)
            {
                dishtemp3[i] = new List<Dish>();
                dishAmount3[i] = new List<double>();
            }

            dishtemp3[0].Add(dishes[0]);
            dishtemp3[0].Add(dishes[2]);
            dishtemp3[1].Add(dishes[4]);
            dishtemp3[2].Add(dishes[5]);
            dishtemp3[3].Add(dishes[9]);
            dishtemp3[4].Add(dishes[2]);
            dishtemp3[5].Add(dishes[7]);

            dishAmount3[0].Add(0.5);
            dishAmount3[0].Add(0.5);
            dishAmount3[1].Add(1);
            dishAmount3[2].Add(1.5);
            dishAmount3[3].Add(3);
            dishAmount3[4].Add(0.5);
            dishAmount3[5].Add(1);

            Diet onediet3 = new Diet("Lekkostrawna jednodniowa dieta Atkinsa", dishtemp3, dishAmount3);
            onediet3.description = "Dieta dla osób z problemami żołądkowymi spełniająca zalecenia dr Roberta Atkinsa";
            onediet3.tags = new List<Tag> { dietTags[6], dietTags[4] };
            onediet3.average_grade = 4.36;

            diets.Add(onediet3);

            todayD = diets[0];

            likedDiets = new List<Diet>();
            likedDiets.Add(diets[0]);
            likedDiets.Add(diets[1]);
            nextDiet = diets[1];
        }
    }
}
