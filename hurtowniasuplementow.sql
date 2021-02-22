create database HurtowaniaSuplementow

use HurtowaniaSuplementow
 
Create TABLE Dostawcy (
  dostawcaID INTEGER NOT NULL primary key identity(1,1),
  nazwaFirmy nvarchar(50) NOT NULL,
  nazwa nvarchar(30) NOT NULL,
  stanowisko nvarchar(30),
  adres nvarchar(30) NOT NULL,
  miasto nvarchar(30) NOT NULL,
  kodPocztowy nvarchar(6) NOT NULL,
  telefon nvarchar(11) NOT NULL
);

Insert Into Dostawcy values('KFD Nutrition', 'Grzegorz Wałga', 'Menadżer', 'Maja 1', 'Katowice', '40-064','601661426')
Insert Into Dostawcy values('Olimp', 'Krzysztof Piekarz', 'Spec. ds. Marketingu', 'Malinowa 3', 'Sosnowiec', '41-200','503661422')
Insert Into Dostawcy values('BSN', 'Anna Miłoch', 'Menadżer', 'Kościuszki 9', 'Katowice', '40-064','533627422')
Insert Into Dostawcy values('BPI', 'Ryszard Dabrowski', 'Spec. ds. Marketingu', 'Achillesa 2B', 'Warszawa', '00-067','601631222')
Insert Into Dostawcy values('Ultimate', 'Anna Krzysztofik', 'Spec. ds. Sprzedaży', 'Jałowcowa 14', 'Sosnowiec', '41-218','501611422')
Insert Into Dostawcy values('Hi Tec', 'Maja Glowica', 'Spec. ds. Sprzedaży', 'Hrubieszowska 5', 'Warszawa', '00-067','503611322')
Insert Into Dostawcy values('FITMAX', 'Robert Różal', 'Menadżer', 'Morelowa 21', 'Katowice', '40-064','707611722')
Insert Into Dostawcy values('Muscle Care', 'Tomasz Kot', 'Spec. ds. Sprzedaży', 'Czarnoleska 1', 'Warszawa', '00-046','701656422')
Insert Into Dostawcy values('MHP', 'Ludwik Król', 'Menadżer', 'Motyli 4', 'Katowice', '40-064','601611422')
Insert Into Dostawcy values('Dorian Yates', 'Marta Nowak', 'Spec. ds. Sprzedaży', '1 Maja', 'Sosnowiec', '41-200','767611422')
Insert Into Dostawcy values('Dymatize', 'Eryk Kowalski', 'Spec. ds. Marketingu', 'Listopada 11', 'Warszawa', '00-046','565661422')
Insert Into Dostawcy values('BIG Zone', 'Jadwiga Nowak', 'Spec. ds. Sprzedaży', 'Kościelna 23', 'Sosnowiec', '41-218','551819422')
Insert Into Dostawcy values('SciTec Nutrition', 'Paweł Robak', 'Spec. ds. Sprzedaży', 'Kościelna 45', 'Sosnowiec', '41-218','554239422')
 
Create TABLE Kategorie (
  kategoriaID INTEGER NOT NULL primary key identity(1,1),
  nazwaKategoria nvarchar(50) NOT NULL,
  opis nvarchar(250)
);

Insert Into kategorie values('Białko', 'Z obserwacji naszych klientów wynika, że odżywki białkowe odgrywają kluczową rolę w diecie większości osób uprawiających sporty siłowe, siłowo-wytrzymałościowe oraz osób dążących do redukcji wagi ciała.')
Insert Into kategorie values('Kreatyna', 'Kreatyna jest uznawana obecnie za jedną z najpopularniejszych substancji, stosowaną przez kulturystów oraz osoby uprawiające sporty siłowe. Suplementacja kreatyną pozwala w stosunkowo krótkim czasie zwiększyć masę ciała.')
Insert Into kategorie values('Spalacze Tłuszczu', 'Tłuszcze (obok węglowodanów oraz białka) są jednym z najważniejszych składników odżywczych jaki możemy dostarczyć dla naszego organizmu.')
Insert Into kategorie values('Gainery', 'Gainery, powszechnie znane jako odżywki na masę, to wysokokaloryczne preparaty o bardzo wysokiej efektywności. ')
Insert Into kategorie values('Aminokwasy BCA', 'Aminokwasy BCAA od dawna są przedstawiane jako szczególnie ważny suplement, który warto dodać do swojej diety. Wynika to z tego, że ogromna część naszego organizmu składa się z aminokwasów.')
Insert Into kategorie values('Aminokwasy', 'Aminokwasy o różnej pojemności. W postaci płynnej, w proszku i tabletki. Aminokwasy wspomagają proces budowania masę mięśniowej')
Insert Into kategorie values('Arginina i Cytrulina', 'Wedle przeróżnych badań suplementacja aminokwasami jest jednym z wielu sposobów na osiągnięcie dobrych wyników podczas treningu.')
Insert Into kategorie values('Beta Alanina', 'Aminokwasy stały się bardzo istotnym suplementem diety dla wielu osób. Wynika to z tego, że stanowią budulec białek w naszym organizmie.')
Insert Into kategorie values('Boostery Wzrostu', 'Boostery (z ang. boost – zwiększać) wzrostu to grupa produktów, która ma rzekomo powodować wpływ na pracę przysadki mózgowej.')
Insert Into kategorie values('Glutamina', 'Ponieważ organizm potrafi wyprodukować jedynie ograniczoną ilość glutaminy, sportowcy, kulturyści muszą zazwyczaj uzupełniać ją sami.')
Insert Into kategorie values('HMB', 'HMB, czyli beta-hydroksy-beta-metylomaślan stanowi pochodną leucyny - jednego z aminokwasów rozgałęzionych, wchodzącego w skład BCAA')
Insert Into kategorie values('Witaminy i Minerały', 'Aby cieszyć się w pełni zdrowiem, przydadzą się witaminy i minerały. Bez nich nasz organizm nie będzie w stanie sprawnie funkcjonować.')
Insert Into kategorie values('ZMA', 'ZMA to suplement diety będący połączeniem (zazwyczaj) cynku, magnezu i witaminy B6. Wszystkie te składniki wspomagają ochronę organizmu przed nadmiernym obciążeniem, wynikającym z długotrwałego treningu.')
Insert Into kategorie values('Prozdrowotne', 'Preparaty prozdrowotne, dostarczające niezbędne organizmowi substancje.')
 
 
Create TABLE Produkty (
  produktID INTEGER NOT NULL primary key identity(1,1),
  nazwaProduktu nvarchar(50) NOT NULL,
  kategoriaID int foreign key references Kategorie(kategoriaID) on delete cascade on update cascade,
  dostawcaID int foreign key references Dostawcy(dostawcaID) on delete cascade on update cascade,
  cena int NOT NULL,
  iloscMagazyn int NOT NULL,
  iloscZamowienie int NOT NULL
);
 

Insert Into Produkty values('SciTec Whey Isolate', 1,13,199,50,8)
Insert Into Produkty values('SciTec Whey Protein', 1,13,44,143,37)
Insert Into Produkty values('KFD Premium X-Whey', 1,1,45,150,14)
Insert Into Produkty values('KFD Protein Desert', 1,1,67,99,21)
Insert Into Produkty values('KFD Whey 100', 1,1,199,67,9)
Insert Into Produkty values('Olimp Whey Protein Complex', 1,2,67,90,5)
Insert Into Produkty values('Olimp Pure Whey Isolate', 1,2,57,70,15)
Insert Into Produkty values('Olimp Mega Strong Protein', 1,2,62,90,11)
Insert Into Produkty values('SciTec Whey Isolate', 1,13,57,50,8)
Insert Into Produkty values('KFD CREATINE X-CAPS', 2,3,33,12,2)
Insert Into Produkty values('KFD PREMIUM CREATINE', 2,7,44,12,3)
Insert Into Produkty values('KFD PREMIUM TCM ', 2,7,22,43,4)
Insert Into Produkty values('OPTIMUM CREATINE POWDER', 2,7,11,12,5)
Insert Into Produkty values('SCITEC CREA-BOMB', 2,7,11,43,5)
Insert Into Produkty values('KFD F-BURNER', 3,7,12,12,6)
Insert Into Produkty values('OLIMP THERMO SPEED HARDCORE ', 3,2,12,43,7)
Insert Into Produkty values('OLIMP THERMO SPEED EXTREME', 3,2,16,56,7)
Insert Into Produkty values('UNIVERSAL SUPER CUTS 3', 3,5,34,14,7)
Insert Into Produkty values('ACTIVLAB THERMO SHAPE', 3,5,34,50,8)
Insert Into Produkty values('KFD PREMIUM X-GAINER', 4,1,56,43,9)
Insert Into Produkty values('ACTIVLAB MASS UP', 4,4,56,123,8)
Insert Into Produkty values('ACTIVLAB MASS UP', 4,4,67,43,10)
Insert Into Produkty values('MEGABOL GAINER', 4,4,67,23,10)
Insert Into Produkty values('ACTIVLAB MASS UP', 4,4,67,23,20)
Insert Into Produkty values('TREC MASS XXL', 4,9,67,50,12)
Insert Into Produkty values('KFD PREMIUM BCAA INSTANT+', 5,1,78,34,12)
Insert Into Produkty values('KFD PREMIUM BCAA 2:1:1', 5,1,123,45,12)
Insert Into Produkty values('ACTIVLAB BCAA XTRA', 5,10,123,45,12)
Insert Into Produkty values('HI TEC BCAA POWDER (TST) ', 5,6,15,45,12)
Insert Into Produkty values('HI TEC AMINO ANBOL PROFESSIONAL', 6,6,15,1,1)
Insert Into Produkty values('SCITEC AMINO 5600', 6,13,23,2,2)
Insert Into Produkty values('7 NUTRITION AOL 900', 6,10,24,3,3)
Insert Into Produkty values('BIO TECH USA MEGA AMINO 3200', 6,10,52,4,32)
Insert Into Produkty values('BIO TECH USA MEGA AMINO 3200', 6,10,25,5,31)
Insert Into Produkty values('KFD PREMIUM AAKG ', 7,1,25,6,12)
Insert Into Produkty values('KFD PURE CITRULLINE MALATE', 7,1,25,7,12)
Insert Into Produkty values('OLIMP ARGIPOWER 1500 MEGA ', 7,2,31,8,12)
Insert Into Produkty values('TREC AAKG MEGA HARDCORE ', 7,10,32,12,3)
Insert Into Produkty values('OLIMP AAKG EXTREME', 7,2,33,12,23)
Insert Into Produkty values('KFD PREMIUM BETA-ALANINE ', 8,1,49,12,23)
Insert Into Produkty values('SCITEC BETA-ALANINE', 8,13,45,22,41)
Insert Into Produkty values('TREC BETA-ALANINE 700', 8,10,56,22,12)
Insert Into Produkty values('OLIMP BETA ALANINE CARNO RUSH', 8,2,67,22,11)
Insert Into Produkty values('HI TEC BETA ALANIN', 8,6,78,11,22)
Insert Into Produkty values('ACTIVLAB HGH NIGHT ', 9,10,231,55,33)
Insert Into Produkty values('UNIVERSAL GH MAX ', 9,10,234,23,11)
Insert Into Produkty values('ACTIVLAB HGH DAY', 9,10,12,34,12)
Insert Into Produkty values('BIOTECH BRUTAL ANDROL', 9,10,11,31,12)
Insert Into Produkty values('2XHI TEC BLACK DEVIL', 9,6,5,13,23)
Insert Into Produkty values('KFD PREMIUM GLUTAMINE', 10,1,5,23,13)
Insert Into Produkty values('ACTIVLAB GLUTAMINE XTRA', 10,10,1,34,43)
Insert Into Produkty values('OLIMP L-GLUTAMINA MEGA', 10,10,45,41,54)
Insert Into Produkty values('OLIMP GLUTAMINE MEGA ', 10,2,45,23,1)
Insert Into Produkty values('OLIMP GLUTAMINE XPLODE', 10,2,5,67,32)
Insert Into Produkty values('OLIMP HMB 1250MG MEGA', 11,2,33,6,2)
Insert Into Produkty values('HI TEC HMB ', 11,6,33,6,5)
Insert Into Produkty values('OLIMP HMB ', 11,2,3,6,6)
Insert Into Produkty values('TREC HMB FC', 11,10,4,2,6)
Insert Into Produkty values('BIO TECH HMB', 11,10,4,3,12)
Insert Into Produkty values('OLIMP HMB 1250MG', 12,2,55,2,12)
Insert Into Produkty values('KFD VITAMIN D3+K2 ', 12,1,5,2,12)
Insert Into Produkty values('KFD OMEGA 3+ ', 12,1,55,12,3)
Insert Into Produkty values('KFD VITAMIN C+ / WITAMINA C+', 12,1,23,12,3)
Insert Into Produkty values('KFD ZINC', 12,1,23,12,3)
Insert Into Produkty values('KFD POTASSIUM', 13,1,23,13,33)
Insert Into Produkty values('KFD MG+ZN+B6', 13,1,23,13,33)
Insert Into Produkty values('SCITEC ZMB 6', 13,13,34,13,65)
Insert Into Produkty values('OLIMP ZMA', 13,2,34,33,3)
Insert Into Produkty values('HI TEC ZMA', 13,6,45,33,3)
Insert Into Produkty values('KFD SLEEP WELL', 14,1,56,56,61)
Insert Into Produkty values('KFD ASHWAGANDHA 66+', 14,1,56,56,62)
Insert Into Produkty values('KFD RÓŻENIEC GÓRSKI', 14,1,67,22,89)
Insert Into Produkty values('OLIMP CHELA CYNK', 14,2,89,11,23)
Insert Into Produkty values('OLIMP GOLD LECYTYNA', 14,2,123,98,10)
Insert Into Produkty values('OLIMP HEPAPLUS', 14,2,145,69,10)

Create TABLE Klienci (
  klientID INTEGER NOT NULL primary key identity(1,1),
  nazwaFirmy nvarchar(30),
  nazwaKontaktowa nvarchar(30) NOT NULL,
  adres nvarchar(30) NOT NULL,
  miasto nvarchar(30) NOT NULL,
  kodPocztowy nvarchar(6) NOT NULL,
  kraj nvarchar(30) NOT NULL,
  telefon nvarchar(30) NOT NULL
);
 
Insert Into Klienci values('Eryk i przyjaciele', 'Krzyś' , 'wiejska','Katowice','42-232','Polska', '524244223')
Insert Into Klienci values('Agent', 'Bolek' , ' Арбат','Moskwa','101000','Rosja', '666222111')
Insert Into Klienci values('Spławiki', 'kontakt' , 'Gacka','Sosnowiec','41-200','Polska', '888777231')
Insert Into Klienci values('OLIMP', 'Olimpijczyk' , 'Prestwick Road','Los Angeles','86556','USA', '202-555-0177')
Insert Into Klienci values('TREC', 'TrecTeam' , 'Ziołowa','Katowice','40-021','Polska', '509119555')
Insert Into Klienci values('BIOTECH', 'TechLab' , 'Maczka','Warszawa','00-012','Polska', '506111333')
Insert Into Klienci values('ACTIVLAB', 'ActivisonLab' , 'Klasyków','Warszawa','00-031','Polska', '222333111')
Insert Into Klienci values('SciTec', 'ScienticTech' , 'Estrady','Warszawa','00-008','Polska', '202202001')
Insert Into Klienci values('2XHI', 'Dunno' , 'Circle Way','Wisconsin','75502','USA', '1 222 333-4444')

Create TABLE Kurierzy (
  kurierID INTEGER NOT NULL primary key identity(1,1),
  NazwaFirmy nvarchar(30) NOT NULL,
  telefon nvarchar(30) NOT NULL,
);
 
Insert Into Kurierzy Values('DHL', '433434434')
Insert Into Kurierzy Values('UPS', '111156111')
Insert Into Kurierzy Values('DPD', '123123123')
Insert Into Kurierzy Values('POCZTEX', '566000222')
Insert Into Kurierzy Values('FEDEX', '987362231')
Insert Into Kurierzy Values('RABEN', '111555777')
Insert Into Kurierzy Values('inPOST', '123345321')
 
 
Create TABLE Pracownicy (
  pracownikID INTEGER NOT NULL primary key identity(1,1),
  imie nvarchar(30) NOT NULL,
  nazwisko nvarchar(30) NOT NULL,
  dataUrodzenia Date NOT NULL,
  dataZatrudnienia date NOT NULL,
  dataZwolnienia date,
  pesel nvarchar(11) NOT NULL,
  adres nvarchar(30) NOT NULL,
  miasto nvarchar(30) NOT NULL,
  email nvarchar(30) NOT NULL,
);

 
Insert Into Pracownicy Values('Eryk', 'Cesarek', '1997-10-06', '2015-12-12', null, '97012304433', 'Gacka 46', 'Sosnowiec', 'eryczekprogramista@gmail.com')
Insert Into Pracownicy Values('Kamil', 'Dudek', '1997-01-23', '2015-12-12', null, '9732435921', 'Gacka 1', 'Sosnowiec', 'kamilprogramista@gmail.com')
Insert Into Pracownicy Values('Mateusz', 'Lipinski', '1997-10-20', '2015-12-12', '2019-05-31', '9723145692', 'Dąbrowskiego 12', 'Katowice', 'mateuszwpfowiec@gmail.com')
Insert Into Pracownicy Values('Damian', 'Kubiczek', '1997-01-22', '2019-06-01', null, '9712121212', 'Hubala Dorzańskiego 42', 'Katowice', 'damianbazodanowiec@gmail.com')
Insert Into Pracownicy Values('Szymon', 'Latkowski', '1997-02-05', '2017-12-12', '2019-05-31', '9632232323', 'Edwarda 12/a', 'Katowice', 'szymoninołmatyk@gmail.com')


Create TABLE Zamowienia (
  zamowienieID INTEGER NOT NULL primary key identity(1,1),
  pracownikID int foreign key references Pracownicy(pracownikID) on delete set null on update cascade,
  kurierID int foreign key references Kurierzy(kurierID) on delete set null on update cascade,
  klientID int foreign key references klienci(klientID) on delete set null on update cascade,
  dataZamowienia Date NOT NULL,
  dataNadania date NOT NULL,
  adresDocelowy nvarchar(30) NOT NULL,
  miastoDocelowe nvarchar(30) NOT NULL,
  kodPocztowy nvarchar(6) NOT NULL,
  krajDostarczenia nvarchar(30) NOT NULL
);
 
Insert Into Zamowienia values(1,1,1,'2015-09-9','2015-9-23', 'Gacka 122', 'Sosnowiec', '41-219', 'Polska')
Insert Into Zamowienia values(2,1,2,'2015-01-12','2015-9-23', 'Skargi 2', 'Katowice', '40-021', 'Polska')
Insert Into Zamowienia values(2,2,3,'2015-09-9','2015-9-23', 'Uniwersytecka 2/a', 'Katowice', '40-021', 'Polska')
Insert Into Zamowienia values(2,2,4,'2015-01-12','2015-1-12', 'Circle Way 12/a', 'Chicago', '75502', 'USA')
Insert Into Zamowienia values(3,2,1,'2015-09-12','2015-9-12', 'Chmielna 2', 'Warszawa', '00-008', 'Polska')
Insert Into Zamowienia values(3,3,6,'2015-09-12','2015-9-12', 'Świętokrzyska 12/d', 'Warszawa', '00-008', 'Polska')
Insert Into Zamowienia values(3,3,7,'2015-09-12','2015-9-12', 'Gacka 122', 'Sosnowiec', '41-219', 'Polska')
Insert Into Zamowienia values(3,4,8,'2015-01-12','2015-1-13', 'North St', 'Boston', '41-219', 'USA')
Insert Into Zamowienia values(1,4,9,'2015-01-12','2015-1-14', 'Ziołowa 5/a', 'Katowice', '40-021', 'Polska')
Insert Into Zamowienia values(1,4,3,'2016-02-12','2016-02-14', 'N 1st St', 'Las Vegas', '41-219', 'USA')
Insert Into Zamowienia values(1,5,4,'2016-12-12','2016-12-12', 'E Ogden Ave 12/a', 'Las Vegas', '41-219', 'USA')
Insert Into Zamowienia values(2,5,5,'2016-12-12','2016-12-23', 'Ziołowa 12', 'Katowice', '41-219', 'Polska')
Insert Into Zamowienia values(5,6,7,'2017-12-12','2017-12-23', 'Circle Way 13/bc', 'Chicago', '75502', 'USA')
Insert Into Zamowienia values(5,6,8,'2017-12-12','2017-12-23', 'Hubala 12/a', 'Sosnowiec', '41-200', 'Polska')
Insert Into Zamowienia values(3,7,2,'2017-11-19','2017-11-21', 'Hubala 13/a', 'Sosnowiec', '41-200', 'Polska')
Insert Into Zamowienia values(4,7,3,'2018-07-29','2018-07-30', 'Circle Ave 2', 'Chicago', '75502', 'USA')
Insert Into Zamowienia values(2,2,7,'2018-09-29','2018-09-30', 'Gacka 122', 'Sosnowiec', '41-218', 'Polska')
Insert Into Zamowienia values(3,3,4,'2018-09-15','2018-09-20', 'Gacka 42', 'Sosnowiec', '41-212', 'Polska')
Insert Into Zamowienia values(5,4,9,'2018-09-15','2018-09-19', 'Stewart Ave 2', 'Las Vegas', '41-219', 'USA')
Insert Into Zamowienia values(1,5,3,'2016-03-15','2016-03-17', 'Chamber St 12/f', 'New York', '85512', 'USA')
Insert Into Zamowienia values(2,5,5,'2016-03-15','2016-03-18', 'Ziołowa 123', 'Katowice', '40-021', 'Polska')
Insert Into Zamowienia values(3,1,9,'2016-04-14','2016-04-16', 'Park Row 12/bc', 'New York', '85502', 'USA')
Insert Into Zamowienia values(4,1,1,'2017-04-14','2017-04-16', 'Wronia 2/a', 'Warszawa', '00-012', 'Polska')
Insert Into Zamowienia values(4,3,2,'2016-05-14','2016-05-16', 'Ziołowa 112', 'Katowice', '40-021', 'Polska')
Insert Into Zamowienia values(4,6,3,'2017-07-14','2017-07-16', 'Śliksa 12/a', 'Warszawa', '00-008', 'Polska')
Insert Into Zamowienia values(1,5,3,'2018-07-14','2018-07-16', 'Gacka 42', 'Sosnowiec', '41-200', 'Polska')
 
Create TABLE ZamowieniaSzczegoly (
  zamowienieID int foreign key references Zamowienia(zamowienieID) on delete cascade on update cascade,
  produktID int foreign key references Produkty(produktID) on delete cascade on update cascade,
  ilosc int NOT NULL
);

Insert Into ZamowieniaSzczegoly Values(1,1,7)
Insert Into ZamowieniaSzczegoly Values(2,12,11)
Insert Into ZamowieniaSzczegoly Values(3,13,22)
Insert Into ZamowieniaSzczegoly Values(4,14,31)
Insert Into ZamowieniaSzczegoly Values(5,15,51)
Insert Into ZamowieniaSzczegoly Values(6,16,211)
Insert Into ZamowieniaSzczegoly Values(7,17,291)
Insert Into ZamowieniaSzczegoly Values(8,18,121)
Insert Into ZamowieniaSzczegoly Values(9,19,53)
Insert Into ZamowieniaSzczegoly Values(10,4,20)
Insert Into ZamowieniaSzczegoly Values(11,5,29)
Insert Into ZamowieniaSzczegoly Values(12,1,28)
Insert Into ZamowieniaSzczegoly Values(13,6,321)
Insert Into ZamowieniaSzczegoly Values(14,7,121)
Insert Into ZamowieniaSzczegoly Values(15,22,721)
Insert Into ZamowieniaSzczegoly Values(16,23,120)
Insert Into ZamowieniaSzczegoly Values(17,26,240)
Insert Into ZamowieniaSzczegoly Values(18,25,260)
Insert Into ZamowieniaSzczegoly Values(19,24,210)
Insert Into ZamowieniaSzczegoly Values(20,31,220)
Insert Into ZamowieniaSzczegoly Values(21,21,220)
Insert Into ZamowieniaSzczegoly Values(22,8,210)
Insert Into ZamowieniaSzczegoly Values(23,10,810)
Insert Into ZamowieniaSzczegoly Values(24,11,73)
Insert Into ZamowieniaSzczegoly Values(25,22,65)
Insert Into ZamowieniaSzczegoly Values(26,33,23)

create table DaneLogowania
(
pracownikID int foreign key references Pracownicy(PracownikID) on delete cascade on update cascade,
login nvarchar(50),
haslo nvarchar(50)
)

Insert into DaneLogowania values(1, 'login1', 'haslo1')
insert into DaneLogowania values(2, 'login2' , 'haslo2')
insert into DaneLogowania values(3, 'login3' , 'haslo3')
insert into DaneLogowania values(4, 'login4' , 'haslo4')
insert into DaneLogowania values(5, 'login5' , 'haslo5')


create procedure PracownicyEdytuj
@pracownikID as int,
@imie as nvarchar(30),
@nazwisko as nvarchar(30),
@dataUrodzenia as Date,
@dataZatrudnienia as Date,
@dataZwolnienia as Date,
@pesel as nvarchar(11),
@adres as nvarchar(30),
@miasto as nvarchar(30),
@email as nvarchar(30)
as
begin
	UPDATE Pracownicy set imie = @imie, 
							nazwisko = @nazwisko, 
							dataUrodzenia = cast(@dataUrodzenia as DATETIME2),
							dataZatrudnienia = cast(@dataZatrudnienia as DATETIME2),
							dataZwolnienia = cast(@dataZwolnienia as DATETIME2),
							pesel = @pesel,
							adres = @adres,
							miasto = @miasto,
							email = @email 
							where pracownikID = @pracownikID
end



create procedure ZamowieniaEdytuj
@zamowienieID as int,
@pracownikID as int,
@kurierID as int,
@klientID as int,
@dataZamowienia as Date,
@dataNadania as Date,
@adresDocelowy as nvarchar(30),
@miastoDocelowe as nvarchar(30),
@kodPocztowy as nvarchar(6),
@krajDostarczenia as nvarchar(30)
as
begin
           UPDATE zamowienia set 
                    pracownikID = @pracownikID,
                    kurierID = @kurierID,
                    klientID = @klientID,
                    dataZamowienia = cast(@dataZamowienia as DATETIME2),
                    dataNadania = cast(@dataNadania as DATETIME2),
                    adresDocelowy = @adresDocelowy,
                    miastoDocelowe = @miastoDocelowe,
                    kodPocztowy = @kodPocztowy,
                    krajDostarczenia = @krajDostarczenia
                    where zamowienieID = @zamowienieID
end
