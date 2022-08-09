using TelefonRehberi;

while (true)
{
    Console.WriteLine("\n *******************************************");
    Console.WriteLine("                 ANA MENÜ");
    Console.WriteLine("  Lütfen yapmak istediğiniz işlemi seçiniz");
    Console.WriteLine(" *******************************************");
    Console.WriteLine(" (1) Yeni Numara Kaydetmek");
    Console.WriteLine(" (2) Varolan Numarayı Silmek");
    Console.WriteLine(" (3) Varolan Numarayı Güncelleme");
    Console.WriteLine(" (4) Rehberi Listelemek");
    Console.WriteLine(" (5) Rehberde Arama Yapmak");
    Console.WriteLine(" (6) Uygulamayı Sonlandır");
    int a = 0;
    Int32.TryParse(Console.ReadLine(), out a);
    switch (a)
    {
        case 1:
            Contacts.Add();
            break;
        case 2:
            Contacts.Delete();
            break;
        case 3:
            Contacts.Update();
            break;
        case 4:
            Contacts.List();
            break;
        case 5:
            Contacts.Search();
            break;
        case 6:
            Environment.Exit(0);
            break;

        default:
            Console.WriteLine(" Geçersiz giriş");
            break;
    }
}
