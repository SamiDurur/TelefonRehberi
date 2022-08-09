using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelefonRehberi
{
    internal static class Contacts
    {
        internal static List<Person> persons = new List<Person>();
        static Contacts()
        {

            persons.Add(new Person("sami", "durur", 1234567890));
            persons.Add(new Person("umit", "terzi", 9898864858));
            persons.Add(new Person("omer", "barz", 6878775235));
            persons.Add(new Person("damla", "kara", 1983372263));
            persons.Add(new Person("selim", "kamçı", 8576736621));
        }
        internal static void Add()
        {
            Console.Write("\n Lütfen isim girin               : ");
            string name = Console.ReadLine();
            Console.Write(" Lütfen soyisim giriniz          : ");
            string surname = Console.ReadLine();
            Console.Write(" Lütfen telefon numarası giriniz : ");
            UInt64.TryParse(Console.ReadLine(), out ulong number);
            if (!String.IsNullOrWhiteSpace(name) && !String.IsNullOrWhiteSpace(surname))
            {
                persons.Add(new Person(name, surname, number));
                Console.WriteLine("\n \n Ekleme işlemi tamamlandı. Ana menü için bir tuşa basın");
            }
            else
                Console.WriteLine("\n Kayıt oluşturulamadı. İsim veya soyisim kısmı boş girildi!\n Ana menü için bir tuşa basın.");
            Console.ReadKey();

        }
        internal static void Delete()
        {
            Console.Write("\n Lütfen numarasını silmek istediğiniz kişinin adını ya da soyadını giriniz: ");
            string nameOrSurname = Console.ReadLine();
            Person foundPerson = new();
            bool isPersonFound = false;
            int userChoice = 0;
            foreach (Person person in persons)
            {
                if (person.Surname == nameOrSurname || person.Name == nameOrSurname && !isPersonFound)
                {
                    foundPerson = person;
                    isPersonFound = true;
                }
            }
            if (!isPersonFound)
            {
                Console.WriteLine("\n Aradığınız kriterlere uygun veri rehberde bulunamadı. Lütfen bir seçim yapınız.");
                Console.WriteLine(" * Silmeyi sonlandırmak için : (1)");
                Console.WriteLine(" * Yeniden denemek için      : (2)");
                Int32.TryParse(Console.ReadLine(), out userChoice);
                if (userChoice == 2)
                    Contacts.Delete();
                else
                    Console.WriteLine("\n Hatalı tuşlama yapıldı veya işlem iptal edildi. Ana menü için bir tuşa basın");
            }
            else if (isPersonFound)
            {
                Console.Write("\n {0} isimli kişi rehberden silinmek üzere, onaylıyor musunuz ?(y/n)", foundPerson.Name);
                char yesOrNo;
                Char.TryParse(Console.ReadLine(), out yesOrNo);
                if (yesOrNo == 'y')
                {
                    persons.Remove(foundPerson);
                    Console.WriteLine("\n Silme işlemi tamamlandı. Ana menü için bir tuşa basın");
                }
                else
                {
                    Console.WriteLine("\n Hatalı tuşlama yapıldı veya işlem iptal edildi. Ana menü için bir tuşa basın");
                }
            }
            Console.ReadKey();
        }
        internal static void Update()
        {
            Console.Write("\n Lütfen numarasını güncellemek istediğiniz kişinin adını ya da soyadını giriniz: ");
            string nameOrSurname = Console.ReadLine();
            Person foundPerson = new();
            bool isPersonFound = false;
            int userChoice = 0;
            foreach (Person person in persons)
            {
                if (person.Surname == nameOrSurname || person.Name == nameOrSurname && !isPersonFound)
                {
                    foundPerson = person;
                    isPersonFound = true;
                }
            }
            if (!isPersonFound)
            {
                Console.WriteLine("\n Aradığınız kriterlere uygun veri rehberde bulunamadı. Lütfen bir seçim yapınız.");
                Console.WriteLine(" * Güncellemeyi sonlandırmak için : (1)");
                Console.WriteLine(" * Yeniden denemek için           : (2)");
                Int32.TryParse(Console.ReadLine(), out userChoice);
                if (userChoice == 2)
                    Contacts.Update();
                else
                    Console.WriteLine("\n Hatalı tuşlama yapıldı veya işlem iptal edildi. Ana menü için bir tuşa basın");
            }
            else if (isPersonFound)
            {
                Console.Write("\n {0} {1} kişisi bulundu güncellemek istiyor musunuz ?(y/n)", foundPerson.Name, foundPerson.Surname);
                char yesOrNo;
                Char.TryParse(Console.ReadLine(), out yesOrNo);
                if (yesOrNo == 'y')
                {
                    persons.Remove(foundPerson);
                    Console.WriteLine("\n Numarayı eksik girerseniz otomatik 1000000000 atanır");
                    Console.Write(" {0} {1} kişisinin yeni numarasını girin: ", foundPerson.Name, foundPerson.Surname);
                    UInt64.TryParse(Console.ReadLine(), out ulong updateNumber);
                    foundPerson.Number = updateNumber;
                    persons.Add(foundPerson);

                    Console.WriteLine("\n Numara güncelleme işlemi tamamlandı. Ana menü için bir tuşa basın");
                }
                else
                {
                    Console.WriteLine("\n Hatalı tuşlama yapıldı veya işlem iptal edildi. Ana menü için bir tuşa basın");
                }
            }
            Console.ReadKey();
        }
        internal static void List()
        {
            int listChoice;
            Console.WriteLine("\n A-Z Sıralamak için : (1)");
            Console.WriteLine(" Z-A Sıralamak için : (2)");
            Int32.TryParse(Console.ReadLine(), out listChoice);
            List<Person> sortedList = persons.OrderBy(person => person.Name).ToList();
            if (listChoice == 1)
            {
                Console.WriteLine("\n **********************************************");
                Console.WriteLine("            Telefon Rehberi A-Z");
                Console.WriteLine(" **********************************************");
                foreach (Person person in sortedList)
                {
                    Console.WriteLine(" İsim             : " + person.Name);
                    Console.WriteLine(" Soyisim          : " + person.Surname);
                    Console.WriteLine(" Telefon Numarası : " + person.Number);
                    Console.WriteLine("-");
                }
                Console.WriteLine(" Ana Menü için bir tuşa basın");
            }
            else if (listChoice == 2)
            {
                Console.WriteLine("\n **********************************************");
                Console.WriteLine("            Telefon Rehberi Z-A");
                Console.WriteLine(" **********************************************");
                sortedList.Reverse();
                foreach (Person person in sortedList)
                {
                    Console.WriteLine(" İsim             : " + person.Name);
                    Console.WriteLine(" Soyisim          : " + person.Surname);
                    Console.WriteLine(" Telefon Numarası : " + person.Number);
                    Console.WriteLine("-");
                }
                Console.WriteLine(" Ana Menü için bir tuşa basın");
            }
            else
            {
                Console.WriteLine("\n Hatalı tuşlama yapıldı veya işlem iptal edildi. Ana menü için bir tuşa basın");
            }
            Console.ReadKey();
        }
        internal static void Search()
        {
            uint userChoice;
            Console.WriteLine("\n\n Arama yapmak istediğiniz tipi seçiniz.");
            Console.WriteLine(" *****************************************");

            Console.WriteLine(" İsim veya soyisime göre arama yapmak için: (1)");
            Console.WriteLine(" Telefon numarasına göre arama yapmak için: (2)");
            UInt32.TryParse(Console.ReadLine(), out userChoice);
            int foundCount = 0;
            if (userChoice == 1)
            {
                Console.Write(" Aranacak kişinin isim veya soyismini yazın: ");
                string nameOrSurnameSearch = Console.ReadLine();

                Console.WriteLine("\n Arama Sonuçlarınız:");
                Console.WriteLine(" *****************************************");

                foreach (Person person in persons)
                {
                    if (person.Surname == nameOrSurnameSearch || person.Name == nameOrSurnameSearch)
                    {
                        Console.WriteLine(" İsim             : " + person.Name);
                        Console.WriteLine(" Soyisim          : " + person.Surname);
                        Console.WriteLine(" Telefon Numarası : " + person.Number);
                        Console.WriteLine("-");
                        foundCount++;
                    }
                }
                if (foundCount == 0)
                    Console.WriteLine("\n Aradığınız kişi bulunamadı!");
                Console.WriteLine("\n Ana Menü için bir tuşa basın");
            }



            else if (userChoice == 2)
            {
                Console.Write(" Aranacak kişinin numarasını yazın: ");
                UInt64.TryParse(Console.ReadLine(), out ulong numberSearch);
                Console.WriteLine("\n   Arama Sonuçlarınız:");
                Console.WriteLine(" *****************************************");
                foreach (Person person in persons)
                {
                    if (person.Number == numberSearch)
                    {
                        Console.WriteLine(" İsim             : " + person.Name);
                        Console.WriteLine(" Soyisim          : " + person.Surname);
                        Console.WriteLine(" Telefon Numarası : " + person.Number);
                        Console.WriteLine("-");
                        foundCount++;
                    }
                }
                if (foundCount == 0)
                    Console.WriteLine("\n Aradığınız kişi bulunamadı!");
                Console.WriteLine("\n Ana menü için bir tuşa basın");

            }
            else
            {
                Console.WriteLine("\n Hatalı tuşlama yapıldı. Ana menü için bir tuşa basın");
            }
            Console.ReadKey();
        }
    }
}
