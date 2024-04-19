using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Metadata;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ConsoleApp1
{
	internal class Hotel
	{


//        Hotel class
//-Id
//Name
//Rooms List
//içində Room obyektləri saxlayır və private-dır.
//        AddRoom()
//Parametr olaraq Room obyekti qəbul edib rooms arrayinə əlavə edir.
//-FindAllRoom()-Parametr olaraq bir şərt qebul edecek ve gelen serte uygun olaraq otaqlari geriye qaytaracaq;
//        MakeReservation()
//Parametr olaraq nullable int tipindən bir roomId ve musteri sayi qəbul edir əgər roomId null olaraq geriyə NullReferanceException qaytarır əks halda göndərilən
//roomId-li otaq tapılır IsAvailable dəyəri ve Personal Capacity yoxlanılır əgər IsAvailable dəyəri false-dusa geriyə yuxarıda yaratdığınız NotAvailableException qaytarılır
//əgər true-dursa Personal Capacityde uygun gelirse həmin room-un IsAvailable dəyəri true olur.
//ps: Name dəyəri olmadan bir Hotel obyekti yaratmaq olmaz.





        public string Name { get; set; }

		public List<Room> rooms = new List<Room>(); 

        public static List<Hotel> Hotels = new List<Hotel>();


        public Hotel(string name) 
		{
			Name = name;
		}



		public void AddRoom(Room room)
		{
			rooms.Add(room);
		}


        public void AddHotel(Hotel hotel)
        {
            Hotels.Add(hotel);
        }


        public Room MakeReservation( int? roomId)
		{
			if(roomId==null) throw new NullReferenceException("ID SEHV DAXIL OLUNUB");

			foreach (Room room in rooms)
			{
				if (room.IsAvialable)
				{
					Console.WriteLine("rezerv olundu");
					room.IsAvialable = false;
					Console.WriteLine(room);
				}
				else
				{
					Console.WriteLine("artiq rezerv olunub");
				}
			}
			return null;

		}


		public static Hotel SelectHotel()
		{
			Console.WriteLine("Otel adi daxil edin:");
			string HotelName = Console.ReadLine();

            Hotel selectedHotel = Hotels.FirstOrDefault(p => p.Name == HotelName);

            return selectedHotel;
        }


		public static void ShowAllRooms(Hotel hotel)
		{
			if (hotel.rooms.Count == 0)
			{
				Console.WriteLine("Boshdur!");
				return;
			}
			Console.WriteLine($"Oteldeki Butun Otaglarr::");
			foreach (var room in hotel.rooms)
			{
				Console.WriteLine(room.ShowInfo());
			}

		
		}



        public static List<string> ShowAllHotels()
        {
            List<string> hotelNames = new List<string>();

            if (Hotels.Count == 0)
            {
                Console.WriteLine("Boshdur - Hotel yoxdur!");
                return hotelNames;
            }

            Console.WriteLine($"Butun oteller:");
            foreach (var otel in Hotels)
            {
				hotelNames.Add(otel.Name);
                Console.WriteLine(otel.Name);
            }

            return hotelNames;
        }

    }
}
