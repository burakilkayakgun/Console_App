using ConsoleApp1.Data;
using ConsoleApp1.Models;
using System;
using System.Data;
using System.Data.SqlClient;

namespace ConsoleApp1
{
    class Program
    {
        private static void SetCursorPosition(int LocationLeft, int LocationTop)
        {
            Console.SetCursorPosition(LocationLeft, LocationTop);
            Console.Write("\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t");
            Console.SetCursorPosition(LocationLeft, LocationTop);
        }

        private static animal FindAnimal(string str, string s)
        {
            animal animal = new animal();
            string sql = "select * from " + str + " where full_name = '" + s + "'";
            SqlDataAdapter adapter = new SqlDataAdapter(sql, Connection());
            DataTable dt = new DataTable();
            Connection().Open();
            adapter.Fill(dt);
            Connection().Close();
            foreach (DataRow item in dt.Rows)
            {
                animal.id = Int32.Parse($"{item["id"]}");
                animal.age = Int32.Parse($"{item["age"]}");
                animal.owner_name = ($"{item["owner_name"]}");
                animal.species = ($"{item["species"]}");
            }
            return animal;
        }

        private static info FindInfo(string str, string s)
        {
            info info = new info();
            string sql = "select * from " + str + " where full_name = '" + s + "'";
            SqlDataAdapter adapter = new SqlDataAdapter(sql, Connection());
            DataTable dt = new DataTable();
            Connection().Open();
            adapter.Fill(dt);
            Connection().Close();
            foreach (DataRow item in dt.Rows)
            {
                info.id = Int32.Parse($"{item["id"]}");
                info.adress = ($"{item["adress"]}");
                info.animal_name = ($"{item["animal_name"]}");
            }
            return info;
        }

        private static string FındAdress(string str, string s)
        {
            string adress = "";
            string sql = "select * from " + str + " where full_name = '" + s + "'";
            SqlDataAdapter adapter = new SqlDataAdapter(sql, Connection());
            DataTable dt = new DataTable();
            Connection().Open();
            adapter.Fill(dt);
            Connection().Close();
            foreach (DataRow item in dt.Rows)
            {
                adress = ($"{item["adress"]}");
            }
            return adress;
        }

        private static bool FindAllname(string str, string tuple)
        {
            int count = 0;
            string sql = "select * from " + str;
            SqlDataAdapter adapter = new SqlDataAdapter(sql, Connection());
            DataTable dt = new DataTable();
            Connection().Open();
            adapter.Fill(dt);
            Connection().Close();
            foreach (DataRow item in dt.Rows)
            {
                if (count > 0) { break; }
                if (tuple.Equals($"{item["full_name"]}"))
                {
                    count = count + 1;
                }
            }

            if (count > 0) { return true; } else { return false; }
        }

        public static SqlConnection Connection()
        {
            SqlConnection conn = new SqlConnection("Data Source=EXCALIBUR;Initial Catalog=test_db;Integrated Security=True");
            return conn;
        }

        private static void ErrorRepeat()
        {
            Console.WriteLine("invalid input");
            Console.Write("Try again: ");
        }

        private static void ListAllTuples(string str)
        {
            string sql = "select * from " + str;
            SqlDataAdapter adapter = new SqlDataAdapter(sql, Connection());
            DataTable dt = new DataTable();
            Connection().Open();
            adapter.Fill(dt);
            Connection().Close();
            Console.WriteLine("###");
            foreach (DataRow item in dt.Rows)
            {
                Console.WriteLine($"id: {item["id"]} \t name: {item["full_name"]}");
            }
            Console.WriteLine("###");
        }

        private static void ListAllTable()
        {
            string sql = "select name from sys.Tables";
            SqlDataAdapter adapter = new SqlDataAdapter(sql, Connection());
            DataTable dt = new DataTable();
            Connection().Open();
            adapter.Fill(dt);
            Connection().Close();
            foreach (DataRow item in dt.Rows)
            {
                Console.WriteLine($" - {item["name"]}");
            }
            Console.WriteLine();
        }

        private static void Case1_0(IRepository dBContext)
        {
            Clear_console();
            Console.WriteLine("  List all table");
            ListAllTable();
            Console.WriteLine("write any thing to go back");
            int a = Console.Read();
        }

        private static void Case2_2(IRepository dBContext)
        {
            Console.Write("Name: ");
            string name_2 = Console.ReadLine();
            if (FindAllname("info", name_2))
            {
                while (FindAllname("info", name_2))
                {
                    Console.Write("there exist an input as \" " + name_2 + " \". Try again: ");
                    name_2 = Console.ReadLine();
                }
            }
            Console.Write("Adress (can be null): ");
            string adress_2 = Console.ReadLine();
            Console.Write("Animal (can be null): ");
            string animal_name_2 = Console.ReadLine();
            info info = new info
            {
                full_name = name_2,
                adress = adress_2,
                animal_name = animal_name_2
            };
            dBContext.Insert(info, "info");
            //DBContextEF _dBContext = new DBContextEF();
            //_dBContext.Informations.Add(info);
            //_dBContext.SaveChanges();
            //var infolist = _dBContext.Informations.ToList();
        }

        private static void Case2_1(IRepository dBContext)
        {
            Console.Write("Name: ");
            string name_1 = Console.ReadLine();
            if (FindAllname("animal", name_1))
            {
                while (FindAllname("animal", name_1))
                {
                    Console.Write("there exist an input as \" " + name_1 + " \". Try again: ");
                    name_1 = Console.ReadLine();
                }
            }
            Console.Write("Age: ");
            string age_0 = Console.ReadLine();
            if (!int.TryParse(age_0, out int Number))
            {
                ErrorRepeat();
                do
                {
                    int LocationTop = Console.CursorTop;
                    int LocationLeft = Console.CursorLeft;
                    age_0 = Console.ReadLine();
                    if (!int.TryParse(age_0, out Number))
                    {
                        SetCursorPosition(LocationLeft, LocationTop);
                    }
                } while (!int.TryParse(age_0, out Number));

            }
            Console.Write("Owner Name (can be null): ");
            string owner_name_1 = Console.ReadLine();
            Console.Write("Species (can be null): ");
            string species_1 = Console.ReadLine();
            animal animal = new animal
            {
                full_name = name_1,
                age = Int32.Parse(age_0),
                owner_name = owner_name_1,
                species = species_1
            };
            dBContext.Insert(animal, "animal");
        }

        private static void Case2_0(IRepository dBContext)
        {
            Create_menu();
            string type_name_create = Console.ReadLine();
            switch (type_name_create)
            {
                case "1":
                    Case2_1(dBContext);
                    break;
                case "2":
                    Case2_2(dBContext);
                    break;
            }
        }

        private static void Case3_2(IRepository dBContext)
        {
            Console.Write("Name: ");
            string name_2 = Console.ReadLine();
            if (FindAllname("info", name_2))
            {
                Console.WriteLine(name_2);
                info info = new info()
                {
                    full_name = name_2,
                };
                dBContext.Delete(info, "info");
            }
            else
            {
                ErrorRepeat();
                do
                {
                    int LocationTop = Console.CursorTop;
                    int LocationLeft = Console.CursorLeft;
                    name_2 = Console.ReadLine();
                    if (!FindAllname("info", name_2))
                    {
                        SetCursorPosition(LocationLeft, LocationTop);
                    }
                } while (!FindAllname("info", name_2));
                Console.WriteLine(name_2);

                info info = new info()
                {
                    full_name = name_2,
                };
                dBContext.Delete(info, "info");
            }
        }

        private static void Case3_1(IRepository dBContext)
        {
            Console.Write("Name: ");
            string name_1 = Console.ReadLine();
            if (FindAllname("animal", name_1))
            {
                Console.WriteLine(name_1);
                animal animal = new animal()
                {
                    full_name = name_1,
                    
                };
                dBContext.Delete(animal, "animal");
            }
            else
            {
                ErrorRepeat();
                do
                {
                    int LocationTop = Console.CursorTop;
                    int LocationLeft = Console.CursorLeft;
                    name_1 = Console.ReadLine();
                    if (!FindAllname("animal", name_1))
                    {
                        SetCursorPosition(LocationLeft, LocationTop);
                    }
                } while (!FindAllname("animal", name_1));

                Console.WriteLine(name_1);
                animal animal = new animal()
                {
                    full_name = name_1,
                };
                dBContext.Delete(animal, "animal");
            }
        }

        private static void Case3_0(IRepository dBContext)
        {
            Delete_menu();
            string type_name_delete = Console.ReadLine();
            switch (type_name_delete)
            {
                case "1":
                    Case3_1(dBContext);
                    break;
                case "2":
                    Case3_2(dBContext);
                    break;
            }
        }

        private static void Case4_2(IRepository dBContext)
        {
            Console.WriteLine("Name that you want to update: ");
            string name_2 = Console.ReadLine();
            if (FindAllname("info", name_2))
            {
                Console.Write("Name: ");
                string new_name_2 = Console.ReadLine();
                Console.Write("Adress (can be null): ");
                string new_adress_2 = Console.ReadLine();
                Console.Write("Animal (can be null): ");
                string new_animal_name_2 = Console.ReadLine();
                info info = new info
                {
                    id = FindInfo("info", name_2).id,
                    full_name = new_name_2,
                    adress = new_adress_2,
                    animal_name = new_animal_name_2
                };
                OperationResult opResultToUpdate = dBContext.Update(info, "info", FindInfo("info", name_2).id);
                if (opResultToUpdate.IsFailed)
                {
                    //there is an error in this state
                    Console.WriteLine("Update başarısız. Hata Detayı : "+opResultToUpdate.ErrorMessage);
                }
            }
            else
            {
                ErrorRepeat();
                do
                {
                    int LocationTop = Console.CursorTop;
                    int LocationLeft = Console.CursorLeft;
                    name_2 = Console.ReadLine();
                    if (!FindAllname("info", name_2))
                    {
                        SetCursorPosition(LocationLeft, LocationTop);
                    }
                } while (!FindAllname("info", name_2));

                Console.Write("Name: ");
                string new_name_2 = Console.ReadLine();
                Console.Write("Adress (can be null): ");
                string new_adress_2 = Console.ReadLine();
                Console.Write("Animal (can be null): ");
                string new_animal_name_2 = Console.ReadLine();
                info info = new info
                {
                    id = FindInfo("info", name_2).id,
                    full_name = new_name_2,
                    adress = new_adress_2,
                    animal_name = new_animal_name_2
                };
                OperationResult opResultToUpdate = dBContext.Update(info, "info", FindInfo("info", name_2).id);
                if (opResultToUpdate.IsFailed)
                {
                    //there is an error in this state
                    Console.WriteLine("Update başarısız. Hata Detayı : " + opResultToUpdate.ErrorMessage);
                }
            }
        }

        private static void Case4_1(IRepository dBContext)
        {
            Console.Write("Name that you want to update: ");
            string name_1 = Console.ReadLine();
            if (FindAllname("animal", name_1))
            {
                Console.Write("new Name: ");
                string new_name_1 = Console.ReadLine();
                Console.Write("New Age: ");
                string new_age_1 = Console.ReadLine();
                if (!int.TryParse(new_age_1, out int Number))
                {
                    ErrorRepeat();
                    do
                    {
                        int LocationTop = Console.CursorTop;
                        int LocationLeft = Console.CursorLeft;
                        new_age_1 = Console.ReadLine();
                        if (!int.TryParse(new_age_1, out Number))
                        {
                            SetCursorPosition(LocationLeft, LocationTop);
                        }
                    } while (!int.TryParse(new_age_1, out Number));
                }
                Console.Write("New Owner Name (can be null): ");
                string new_owner_name_1 = Console.ReadLine();
                Console.Write("New Species (can be null): ");
                string new_species_1 = Console.ReadLine();
                animal animal = new animal
                {
                    id = FindAnimal("animal", name_1).id,
                    full_name = new_name_1,
                    age = Int32.Parse(new_age_1),
                    owner_name = new_owner_name_1,
                    species = new_species_1
                };
                dBContext.Update(animal, "animal", FindAnimal("animal", name_1).id);
            }
            else
            {
                ErrorRepeat();
                do
                {
                    int LocationTop = Console.CursorTop;
                    int LocationLeft = Console.CursorLeft;
                    name_1 = Console.ReadLine();
                    if (!FindAllname("animal", name_1))
                    {
                        SetCursorPosition(LocationLeft, LocationTop);
                    }
                } while (!FindAllname("animal", name_1));
                Console.Write("new Name: ");
                string new_name_1 = Console.ReadLine();
                Console.Write("New Age: ");
                string new_age_1 = Console.ReadLine();
                if (!int.TryParse(new_age_1, out int Number))
                {
                    ErrorRepeat();
                    do
                    {
                        int LocationTop = Console.CursorTop;
                        int LocationLeft = Console.CursorLeft;
                        new_age_1 = Console.ReadLine();
                        if (!int.TryParse(new_age_1, out Number))
                        {
                            SetCursorPosition(LocationLeft, LocationTop);
                        }
                    } while (!int.TryParse(new_age_1, out Number));
                }
                Console.Write("New Owner Name (can be null): ");
                string new_owner_name_1 = Console.ReadLine();
                Console.Write("New Species (can be null): ");
                string new_species_1 = Console.ReadLine();
                animal animal = new animal
                {
                    id = FindAnimal("animal", name_1).id,
                    full_name = new_name_1,
                    age = Int32.Parse(new_age_1),
                    owner_name = new_owner_name_1,
                    species = new_species_1
                };
                OperationResult opResultToUpdate = dBContext.Update(animal, "animal", FindAnimal("animal", name_1).id);
                if (opResultToUpdate.IsFailed)
                {
                    //there is an error in this state
                    Console.WriteLine("Update başarısız. Hata Detayı : " + opResultToUpdate.ErrorMessage);
                }
            }
        }

        private static void Case4_0(IRepository dBContext)
        {
            Update_menu();
            string type_name_update = Console.ReadLine();
            switch (type_name_update)
            {
                case "1":
                    Case4_1(dBContext);
                    break;
                case "2":
                    Case4_2(dBContext);
                    break;
            }
        }

        private static void Case5_2(IRepository dBContext)
        {
            ListAllTuples("info");
            Console.WriteLine("write any thing to go back");
            int a = Console.Read();
        }

        private static void Case5_1(IRepository dBContext)
        {
            ListAllTuples("animal");
            Console.WriteLine("write any thing to go back");
            int a = Console.Read();
        }

        private static void Case5_0(IRepository dBContext)
        {
            List_tuple_menu();
            string type_name_list = Console.ReadLine();
            switch (type_name_list)
            {
                case "1":
                    Case5_1(dBContext);
                    break;
                case "2":
                    Case5_2(dBContext);
                    break;
            }
        }

        private static void Main_menu()
        {
            Console.WriteLine("Please select one");
            Console.WriteLine("1- List all Tables ");
            Console.WriteLine("2- Create Data");
            Console.WriteLine("3- Delete Data");
            Console.WriteLine("4- Update Data");
            Console.WriteLine("5- List Tuples Names in a Table");
            Console.WriteLine("0- Exit");
        }

        private static void Welcome()
        {
            Console.WriteLine("Welcome");
        }

        private static void Clear_console()
        {
            Console.Clear();
        }

        private static void Create_menu()
        {
            Clear_console();
            Console.WriteLine("  Create Data");
            Console.WriteLine("  Choose a type to create");
            Console.WriteLine("1- animal");
            Console.WriteLine("2- info");
        }

        private static void Delete_menu()
        {
            Clear_console();
            Console.WriteLine("3- Delete Data");
            Console.WriteLine("  Choose a type to delete");
            Console.WriteLine("1- animal");
            Console.WriteLine("2- info");
        }

        private static void Update_menu()
        {
            Clear_console();
            Console.WriteLine("4- Update Data");
            Console.WriteLine("  Choose a type to update");
            Console.WriteLine("1- animal");
            Console.WriteLine("2- info");
        }

        private static void List_tuple_menu()
        {
            Clear_console();
            Console.WriteLine("5- List Tuples Names in a Table");
            Console.WriteLine("  Choose a table");
            Console.WriteLine("1- animal");
            Console.WriteLine("2- info");
        }

        private static void Process()
        {
            IRepository dBContext = new EFRepository();
            Boolean exit_flag = true;
            Welcome();
            do
            {
                Main_menu();
                string input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        Case1_0(dBContext);
                        break;
                    case "2":
                        Case2_0(dBContext);
                        break;
                    case "3":
                        Case3_0(dBContext);
                        break;
                    case "4":
                        Case4_0(dBContext);
                        break;
                    case "5":
                        Case5_0(dBContext);
                        break;
                    case "0":
                        exit_flag = false;
                        break;
                }
                Clear_console();
            } while (exit_flag);
        }

        static void Main(string[] args)
        {
            Process();
        }
    }
}
