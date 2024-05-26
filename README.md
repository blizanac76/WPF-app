<h1 align="center"><strong>Projekat iz WPF aplikacije za kolokvijum 2 PSNUS</strong></h1>

<h2 align="center">Kreirati WPF aplikaciju koja omogućava rad sa podacima za proizvoljan domen. Omogućiti pregled podataka u tabelarnom prikazu, kao i izvršavanje CRUD operacija (Create, Read, Update, Delete) nad tabelama iz baze podataka. Specifikacija:</h2>

- Definisati detaljan model podataka (sve potrebne klase).
- Upotrebom Entity Framework-a generisati bazu podataka koja se sastoji od dve tabele koje su u vezi 1-N (jedan na više).
- Implementirati glavni prozor korisničkog interfejsa koji sadrži tabelarni prikaz ključnih podataka, kao i dugmad potrebnu za izvršavanje svih CRUD operacija.
- Implementirati prozor koji sadrži formu za dodavanje novog objekta u odgovarajuću tabelu baze podataka (Create).
- Implementirati prozor koji u adekvatnoj formi prikazuje sve podatke o izabranom objektu (Read, tj. Details).
- Iskoristiti prozor za dodavanje novog objekta ili napraviti novi prozor koji sadrži formu za izmenu već postojećeg (selektovanog) objekta (Update).
- Prilikom brisanja objekta, otvoriti prozor koji proverava da li je korisnik siguran da želi da izvrši tu akciju (prilagoditi ugrađeni MessageBox dijalog).
- Adekvatno povezati sve podatke (Data Binding), tako da se podaci u tabelarnom prikazu osvežavaju u realnom vremenu.
- Implementirati sve potrebne validacije i obezbediti adekvatne povratne informacije u slučaju nevalidnog unosa.
- Sprečiti pucanje programa prilikom čuvanja nevalidnih podataka u bazu (npr. dodavanje primarnog ključa koji već postoji ili stranog ključa koji ne postoji).
- Stilizovati izgled aplikacije. (Predlog: upotreba biblioteke Material Design.)
