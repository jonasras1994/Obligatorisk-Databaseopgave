using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using HotelModel;
using HotelRest.Controllers;

namespace HotelApp
{
    class Program
    {
        private static string MenuString => "Hvad ønsker du at foretage dig? \n1: CREATE \n2: READ \n3: UPDATE \n4: DELETE \n0: Luk Programmet";
        static void Main(string[] args)
        {
            FacilitiesController controller = new FacilitiesController();
            Console.WriteLine(MenuString);
            int choice = Convert.ToInt16(Console.ReadLine());



            Console.Clear();
            while (choice != 0)
            {
                switch (choice)
                {
                    case 1:
                        {
                            CreateMethod(controller);
                            break;
                        }
                    case 2:
                        {
                            ReadMethod(controller);
                            break;
                        }
                    case 3:
                        {
                            UpdateMethod(controller);
                            break;
                        }
                    case 4:
                        {
                            DeleteMethod(controller);
                            break;
                        }
                }
                Console.ReadLine();
                Console.Clear();
                Console.WriteLine(MenuString);
                choice = Convert.ToInt16(Console.ReadLine());
            }

            Console.ReadLine();
        }


        private static void DeleteMethod(FacilitiesController controller)
        {
            Console.WriteLine("Hvilket hotel ønsker du at slette?");
            int hotelslet = Convert.ToInt16(Console.ReadLine());
            controller.Delete(hotelslet);
            Console.WriteLine($"Hotelnummer: {hotelslet} er slettet");

            return;
        }

        private static void UpdateMethod(FacilitiesController controller)
        {
            Facilities fUpdate = new Facilities();

            Console.WriteLine("Hvilket hotel vil du opdatere?");
            fUpdate.Hotel_no = Convert.ToInt16(Console.ReadLine());
            Console.Write("Swimmingpool: ");
            fUpdate.Swimmingpool = Convert.ToBoolean(Console.ReadLine());
            Console.Write("Bordtennis: ");

            fUpdate.Tabletennis = Convert.ToBoolean(Console.ReadLine());
            Console.Write("Poolbord: ");

            fUpdate.Pooltable = Convert.ToBoolean(Console.ReadLine());
            Console.Write("Bar: ");

            fUpdate.Bar = Convert.ToBoolean(Console.ReadLine());

            controller.Put(fUpdate.Hotel_no, fUpdate);
            Console.WriteLine(controller.Get(fUpdate.Hotel_no));
            return;
        }

        private static void ReadMethod(FacilitiesController controller)
        {
            Console.WriteLine("Hvilket hotel vil du have vist?");
            int hotelvalg = Convert.ToInt16(Console.ReadLine());

            if (hotelvalg == 0)
            {
                controller.Get().ForEach(Console.WriteLine);
            }
            else
            {
                Console.WriteLine(controller.Get(hotelvalg));
            }

            return;
        }

        private static void CreateMethod(FacilitiesController controller)
        {
            Facilities f = new Facilities();
            Console.WriteLine("Indtast hotel nummer:");
            f.Hotel_no = Convert.ToInt16(Console.ReadLine());
            Console.WriteLine("Hvilke faciliteter har hotellet?");
            Console.Write("Swimmingpool: ");
            f.Swimmingpool = Convert.ToBoolean(Console.ReadLine());

            Console.Write("Bordtennis: ");
            f.Tabletennis = Convert.ToBoolean(Console.ReadLine());

            Console.Write("Poolbord: ");
            f.Pooltable = Convert.ToBoolean(Console.ReadLine());

            Console.Write("Bar: ");
            f.Bar = Convert.ToBoolean(Console.ReadLine());

            controller.Post(f);
            controller.Get().ForEach(Console.WriteLine);
            return;
        }
    }
}
