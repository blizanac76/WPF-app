using Kolokvijum2.Models;

//Pozdrav Mladene,
//Nek svaki djak ima svoj ID (ako ne radis sa studentima, u suportnom umesto StudentID mozes koristiti njihov Indeks), FirstName, LastName, Age, YearOfStudy,  School i SchoolID.
//Skola moze da ima samo naziv i ID, mada ne bi bilo lose da dodas jos koji atribut poput mesta, mozda i broja djaka (broj trenutno djaka koji uce u toj skoli)...
//Omoguci da se novi djak dodaje samo u skole koje su unete ranije u bazu.
//Nek prozori za dodavanje, izmenu i prikaz studenta budu zasebni. 
//Sto se tice baze, mozes koristiti mySql, takodje mozes i druge poput SQLite, PostgreSQL...
//Ako budes imao dalje neka pitanja slobodno se javi.
//Srecno u radu :)


public class Student
{
    // Ne moze Index da bude key, jer druge skole imaju druga pravila za index, tako da mozda postoji overlap??
    // Ili pak neka unique relacija index/school id, ali ne znam pravila za sve skole trenutno pa cemo ovako raditi
    public int Id { get; set; }
    public string Index { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int Age { get; set; }
    public string Gender { get; set; }
    public int YearOfStudy { get; set; }
    // Smer, free input za simplicty. Inace bi bila reference tabela sa dostupnim smerovima
    public int SchoolId { get; set; }
    public virtual School School { get; set; }

}
