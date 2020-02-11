using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumaneSociety
{
    public static class Query
    {
        static HumaneSocietyDataContext db;

        static Query()
        {
            db = new HumaneSocietyDataContext();
        }

        internal static List<USState> GetStates()
        {
            List<USState> allStates = db.USStates.ToList();

            return allStates;
        }

        internal static Client GetClient(string userName, string password)
        {
            Client client = db.Clients.Where(c => c.UserName == userName && c.Password == password).Single();

            return client;
        }

        internal static List<Client> GetClients()
        {
            List<Client> allClients = db.Clients.ToList();

            return allClients;
        }

        internal static void AddNewClient(string firstName, string lastName, string username, string password, string email, string streetAddress, int zipCode, int stateId)
        {
            Client newClient = new Client();

            newClient.FirstName = firstName;
            newClient.LastName = lastName;
            newClient.UserName = username;
            newClient.Password = password;
            newClient.Email = email;

            Address addressFromDb = db.Addresses.Where(a => a.AddressLine1 == streetAddress && a.Zipcode == zipCode && a.USStateId == stateId).FirstOrDefault();

            // if the address isn't found in the Db, create and insert it
            if (addressFromDb == null)
            {
                Address newAddress = new Address();
                newAddress.AddressLine1 = streetAddress;
                newAddress.City = null;
                newAddress.USStateId = stateId;
                newAddress.Zipcode = zipCode;

                db.Addresses.InsertOnSubmit(newAddress);
                db.SubmitChanges();

                addressFromDb = newAddress;
            }

            // attach AddressId to clientFromDb.AddressId
            newClient.AddressId = addressFromDb.AddressId;

            db.Clients.InsertOnSubmit(newClient);

            db.SubmitChanges();
        }

        internal static void UpdateClient(Client clientWithUpdates)
        {
            // find corresponding Client from Db
            Client clientFromDb = null;

            try
            {
                clientFromDb = db.Clients.Where(c => c.ClientId == clientWithUpdates.ClientId).Single();
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine("No clients have a ClientId that matches the Client passed in.");
                Console.WriteLine("No update have been made.");
                return;
            }

            // update clientFromDb information with the values on clientWithUpdates (aside from address)
            clientFromDb.FirstName = clientWithUpdates.FirstName;
            clientFromDb.LastName = clientWithUpdates.LastName;
            clientFromDb.UserName = clientWithUpdates.UserName;
            clientFromDb.Password = clientWithUpdates.Password;
            clientFromDb.Email = clientWithUpdates.Email;

            // get address object from clientWithUpdates
            Address clientAddress = clientWithUpdates.Address;

            // look for existing Address in Db (null will be returned if the address isn't already in the Db
            Address updatedAddress = db.Addresses.Where(a => a.AddressLine1 == clientAddress.AddressLine1 && a.USStateId == clientAddress.USStateId && a.Zipcode == clientAddress.Zipcode).FirstOrDefault();

            // if the address isn't found in the Db, create and insert it
            if (updatedAddress == null)
            {
                Address newAddress = new Address();
                newAddress.AddressLine1 = clientAddress.AddressLine1;
                newAddress.City = null;
                newAddress.USStateId = clientAddress.USStateId;
                newAddress.Zipcode = clientAddress.Zipcode;

                db.Addresses.InsertOnSubmit(newAddress);
                db.SubmitChanges();

                updatedAddress = newAddress;
            }

            // attach AddressId to clientFromDb.AddressId
            clientFromDb.AddressId = updatedAddress.AddressId;

            // submit changes
            db.SubmitChanges();
        }

        internal static void AddUsernameAndPassword(Employee employee)
        {
            Employee employeeFromDb = db.Employees.Where(e => e.EmployeeId == employee.EmployeeId).FirstOrDefault();

            employeeFromDb.UserName = employee.UserName;
            employeeFromDb.Password = employee.Password;

            db.SubmitChanges();
        }

        internal static Employee RetrieveEmployeeUser(string email, int employeeNumber)
        {
            Employee employeeFromDb = db.Employees.Where(e => e.Email == email && e.EmployeeNumber == employeeNumber).FirstOrDefault();

            if (employeeFromDb == null)
            {
                throw new NullReferenceException();
            }
            else
            {
                return employeeFromDb;
            }
        }

        internal static Employee EmployeeLogin(string userName, string password)
        {
            Employee employeeFromDb = db.Employees.Where(e => e.UserName == userName && e.Password == password).FirstOrDefault();

            return employeeFromDb;
        }

        internal static bool CheckEmployeeUserNameExist(string userName)
        {
            Employee employeeWithUserName = db.Employees.Where(e => e.UserName == userName).FirstOrDefault();

            return employeeWithUserName != null;
        }


        //// TODO Items: ////

        // TODO: Allow any of the CRUD operations to occur here
        internal static void RunEmployeeQueries(Employee employee, string crudOperation)
        {
            switch (crudOperation)
            {
                case ("create"):
                    {
                        CreateEmployee(employee);
                        break;
                    }
                case ("read"):
                    {
                        UserInterface.DisplayEmployeeInfo(ReadEmployee(employee));
                        break;
                    }
                case ("update"):
                    {
                        UpdateEmployee(employee);
                        break;
                    }
                case ("delete"):
                    {
                        DeleteEmployee(employee);
                        break;
                    }
            }
        }

        internal static void CreateEmployee(Employee employee)
        {
            try
            {
                db.Employees.InsertOnSubmit(employee);
                db.SubmitChanges();
            }
            catch
            {
                throw new Exception();
            }
        }

        internal static Employee ReadEmployee(Employee employee)
        {
            try
            {
                return db.Employees.Where(a => employee.EmployeeId == a.EmployeeId).SingleOrDefault();
            }
            catch
            {
                throw new Exception();
            }
        }

        internal static void UpdateEmployee(Employee employee)
        {
            try
            {
                Employee updating = db.Employees.Where(a => employee.EmployeeId == a.EmployeeId).SingleOrDefault();
                if (employee.FirstName != "") { updating.FirstName = employee.FirstName; }
                if (employee.LastName != "") { updating.LastName = employee.LastName; }
                if (employee.Email != "") { updating.Email = updating.Email; }
            }
            catch
            {
                throw new Exception();
            }
        }

        internal static void DeleteEmployee(Employee employee)
        {
            try
            {
                db.Employees.DeleteOnSubmit(employee);
                db.SubmitChanges();
            }
            catch
            {
                throw new Exception();
            }
        }

        // TODO: Animal CRUD Operations
        internal static void AddAnimal(Animal animal)
        {
            try
            {
                db.Animals.InsertOnSubmit(animal);
                db.SubmitChanges();
            }
            catch
            {
                throw new Exception();
            }
        }

        internal static Animal GetAnimalByID(int id)
        {
            try
            {
                return db.Animals.Where(a => id == a.AnimalId).SingleOrDefault();
            }
            catch
            {
                throw new Exception();
            }
        }

        internal static void UpdateAnimal(int animalId, Dictionary<int, string> updates)
        {
            foreach (var item in updates)
            {
                switch (item.Key)
                {
                    case 1:
                        db.Animals.Where(a => a.AnimalId == animalId).SingleOrDefault().Category = db.Categories.Where(c => c.Name == item.Value).SingleOrDefault();
                        break;
                    case 2:
                        db.Animals.Where(a => a.AnimalId == animalId).SingleOrDefault().Name = item.Value;
                        break;
                    case 3:
                        db.Animals.Where(a => a.AnimalId == animalId).SingleOrDefault().Age = Int32.Parse(item.Value);
                        break;
                    case 4:
                        db.Animals.Where(a => a.AnimalId == animalId).SingleOrDefault().Demeanor = item.Value;
                        break;
                    case 5:
                        db.Animals.Where(a => a.AnimalId == animalId).SingleOrDefault().KidFriendly = bool.Parse(item.Value);
                        break;
                    case 6:
                        db.Animals.Where(a => a.AnimalId == animalId).SingleOrDefault().PetFriendly = bool.Parse(item.Value);
                        break;
                    case 7:
                        db.Animals.Where(a => a.AnimalId == animalId).SingleOrDefault().Weight = Int32.Parse(item.Value);
                        break;
                }
                //db.SubmitChanges();
            }
            db.SubmitChanges();
        }

        internal static void RemoveAnimal(Animal animal)
        {
            try
            {
                db.Animals.DeleteOnSubmit(animal);
                db.SubmitChanges();
            }
            catch
            {
                throw new Exception();
            }
        }

        // TODO: Animal Multi-Trait Search
        internal static IQueryable<Animal> SearchForAnimalsByMultipleTraits(Dictionary<int, string> updates) // parameter(s)?
        {
            var animals = db.Animals.Where(a => true);
            foreach (var item in updates)
            {
                switch (item.Key)
                {
                    case 1:
                        animals = animals.Where(a => a.Category.Name == item.Value);
                        break;
                    case 2:
                        animals = animals.Where(a => a.Name == item.Value);
                        break;
                    case 3:
                        animals = animals.Where(a => a.Age == Int32.Parse(item.Value));
                        break;
                    case 4:
                        animals = animals.Where(a => a.Demeanor == item.Value);
                        break;
                    case 5:
                        animals = animals.Where(a => a.KidFriendly == bool.Parse(item.Value));
                        break;
                    case 6:
                        animals = animals.Where(a => a.PetFriendly == bool.Parse(item.Value));
                        break;
                    case 7:
                        animals = animals.Where(a => a.Weight == Int32.Parse(item.Value));
                        break;
                    case 8:
                        animals = animals.Where(a => a.AnimalId == Int32.Parse(item.Value));
                        break;
                }
            }
            return animals;
        }


        // TODO: Misc Animal Things
        internal static int GetCategoryId(string categoryName)
        {
            try
            {
                return (db.Categories.Where(a => a.Name == categoryName).SingleOrDefault()).CategoryId;
            }
            catch
            {
                throw new Exception();
            }
        }

        internal static Room GetRoom(int animalId)
        {
            try
            {
                return db.Rooms.Where(a => a.AnimalId == animalId).SingleOrDefault();
            }
            catch
            {
                throw new Exception();
            }
        }

        internal static int GetDietPlanId(string dietPlanName)
        {
            try
            {
                return (db.DietPlans.Where(a => a.Name == dietPlanName).SingleOrDefault()).DietPlanId;
            }
            catch
            {
                throw new Exception();
            }
        }

        // TODO: Adoption CRUD Operations
        internal static void Adopt(Animal animal, Client client)
        {
            try
            {
                Adoption adoption = new Adoption();
                adoption.AdoptionFee = 75;
                adoption.Animal = animal;
                adoption.Client = client;
                adoption.ApprovalStatus = "approved";
                adoption.AnimalId = animal.AnimalId;
                adoption.ClientId = client.ClientId;
                adoption.PaymentCollected = true;
                db.Adoptions.InsertOnSubmit(adoption);
                db.SubmitChanges();
            }
            catch
            {
                throw new Exception();
            }
        }

        internal static IQueryable<Adoption> GetPendingAdoptions()
        {
            try
            {
                return db.Adoptions.Where(a => a.ApprovalStatus == "pending");
            }
            catch
            {
                throw new Exception();
            }
        }

        internal static void UpdateAdoption(bool isAdopted, Adoption adoption)
        {
            throw new NotImplementedException();
        }

        internal static void RemoveAdoption(int animalId, int clientId)
        {
            try
            {
                db.Adoptions.DeleteOnSubmit(db.Adoptions.Where(a => a.ClientId == clientId && a.AnimalId == animalId).SingleOrDefault());
                db.SubmitChanges();
            }
            catch
            {
                throw new Exception();
            }
        }

        // TODO: Shots Stuff
        internal static IQueryable<AnimalShot> GetShots(Animal animal)
        {
            try
            {
                return db.AnimalShots.Where(a => a.AnimalId == animal.AnimalId);
            }
            catch
            {
                throw new Exception();
            }
        }

        internal static void UpdateShot(string shotName, Animal animal)
        {
            try
            {
                AnimalShot shot = new AnimalShot();
                shot.ShotId = db.Shots.Where(a => a.Name == shotName).SingleOrDefault().ShotId;
                shot.AnimalId = animal.AnimalId;
                shot.Animal = animal;
                shot.DateReceived = DateTime.Now;
                shot.Shot = db.Shots.Where(a => a.Name == shotName).SingleOrDefault();
                db.AnimalShots.InsertOnSubmit(shot);
                db.SubmitChanges();
            }
            catch
            {
                throw new Exception();
            }
        }
    }
}