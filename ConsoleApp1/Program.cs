using System;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // ***************Menu * **************
            // 1.Sisteme giris
            // 0.Cixis

            // Sisteme giris oldugu zaman
            // 1.Hotel yarat(Hotel yarat secdikden sonra bir otel yaradirsiz.eyni adda hotel ola bilmez: D)
            // 2.Butun Hotelleri gor
            // 3.Hotel sec(hotelin adini daxil ederek secilecek)
            // 0.Exit

            // Hotel secildikden sonra
            // 1.Room yarat
            // 2.Roomlari gor
            // 3.Rezervasya et(eger hec bir otaq yoxdursa rezervasya xidmeti islemir)
            // 4.Evvelki menuya qayit.
            // 0.Exit

            Hotel hotel1 = new Hotel("relax");
            Room room = new Room("ab103", 23457, 54);

            hotel1.AddRoom(room);
            hotel1.MakeReservation(56);

            Console.WriteLine("-----------------------------------");

            bool exit = false;
            string choice;


            do
            {
                Console.WriteLine(" ***************  Menu **************");
                Console.WriteLine("xosh gelmisoozz");
                Console.WriteLine("1.sisteme girish");
                Console.WriteLine("0. Chixish");

                choice = Console.ReadLine();


                switch (choice)
                {
                    case "1":
                        Console.WriteLine("Sisteme girish");

                        string secondchoice;

                        do
                        {

                            Console.WriteLine("------ Menu --------");
                            Console.WriteLine("1.Hotel yarat");
                            Console.WriteLine("2.Butun Hotelleri gor");
                            Console.WriteLine("3.Hotel sec");
                            Console.WriteLine("0.Exit");

                            secondchoice = Console.ReadLine();


                            switch (secondchoice)
                            {
                                case "1":
                                    Console.WriteLine("Otel yarat.");
                                    Console.WriteLine("Otel adi daxil et:");

                                    string yourotelname = Console.ReadLine();
                                    Hotel hotel = new Hotel(yourotelname);
                                    Console.WriteLine($"{yourotelname} adli oteliniz yaradildi");
                                    break;


                                case "2":
                                    Console.WriteLine("Butun otelleri gor.");
                                    var hotelNames = Hotel.ShowAllHotels();

                                    foreach (var name in hotelNames)
                                    {
                                        Console.WriteLine(name);
                                    }
                                    break;


                                case "3":
                                    Console.WriteLine("Otel sech");
                                    Hotel selectedHotel = Hotel.SelectHotel();

                                    if (selectedHotel != null)
                                    {
                                        Console.WriteLine($"Secilen otel: {selectedHotel.Name}");

                                        string roomChoice;

                                        do
                                        {
                                            Console.WriteLine("1.Room yarat");
                                            Console.WriteLine("2.Roomlari gor");
                                            Console.WriteLine("3.Rezervasya et");
                                            Console.WriteLine("4.Evvelki menuya qayit");
                                            Console.WriteLine("0.Exit");

                                            roomChoice = Console.ReadLine();

                                            switch (roomChoice)
                                            {
                                                case "1":
                                                    Console.WriteLine("Room yarat.");

                                                    Console.WriteLine("Room adi daxil et:");
                                                    string yourroomname = Console.ReadLine();

                                                    Console.WriteLine("Room qiymetini daxil et:");

                                                    int price = Convert.ToInt32(Console.ReadLine());

                                                    Console.WriteLine("Room Person Capacityni daxil et:");
                                                    int perscap = Convert.ToInt32(Console.ReadLine());

                                                    Room room2 = new Room(yourroomname, price, perscap);

                                                    Console.WriteLine($"{yourroomname} adli room'nuz yaradildi");
                                                    break;



                                                case "2":
                                                    Console.WriteLine("Roomlari gor.");

                                                    if (selectedHotel != null)
                                                    {
                                                        Hotel.ShowAllRooms(selectedHotel);
                                                    }
                                                    else
                                                    {
                                                        Console.WriteLine("Otel tapilmadi.");
                                                    }

                                                    break;


                                                case "3":
                                                    Console.WriteLine("Rezervasya et.");

                                                    if (selectedHotel != null)
                                                    {
                                                        Console.WriteLine("Rezervasya etmek istediğiniz otag adı:");
                                                        string roomName = Console.ReadLine();

                                                        Room selectedRoom = selectedHotel.rooms.FirstOrDefault(r => r.Name == roomName);

                                                        if (selectedRoom != null)
                                                        {
                                                            if (selectedRoom.IsAvialable)
                                                            {
                                                                Console.WriteLine("Rezervasya edildi!");
                                                            }
                                                            else
                                                            {
                                                                Console.WriteLine("Seçilen otaq onsuzda rezerv edilib.");
                                                            }
                                                        }
                                                        else
                                                        {
                                                            Console.WriteLine("gosderilen ada uygun otag tapilmadi");
                                                        }
                                                    }
                                                    else
                                                    {
                                                        Console.WriteLine("Otel tapilmadi.");
                                                    }
                                                    break;

                                                    

                                                case "4":
                                                    Console.WriteLine("Evvelki menuya qayit.");
                                                    break;

                                                case "0":
                                                    exit = true; 
                                                    break;

                                                default:
                                                    Console.WriteLine("Duzgun secim edin.");
                                                    break;
                                            }

                                        } while (!exit);
                                    }

                            

                                    else
                                    {
                                        Console.WriteLine("Otel tapılmadı.");
                                    }

                                    break;

                            }

                        } while (secondchoice != "0");
                        break;


                

                    case "0":
                        exit = true;
                        break;

                    default:
                        Console.WriteLine("duzgun sechim edin");
                        break;
                }

            } while (!exit);

        }
    }

    public delegate void Showinfo();
}
