using Core.DataBase;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;

namespace Core
{
    public class DataAccess
    {
        public static List<Tour> GetTours() => VediGroupEntities.GetContext().Tours.ToList();
        public static List<Tourist> GetTourists() => VediGroupEntities.GetContext().Tourists.ToList();
        public static List<VisaAvailability> GetVisaAvailabilities() => VediGroupEntities.GetContext().VisaAvailabilities.ToList();
        public static List<Hotel> GetHotels() => VediGroupEntities.GetContext().Hotels.ToList();
        public static List<Country> GetCountries() => VediGroupEntities.GetContext().Countries.ToList();
        public static List<City> GetCities() => VediGroupEntities.GetContext().Cities.ToList();
        public static List<User> GetUsers() => VediGroupEntities.GetContext().Users.ToList();
        public static List<User> GetManagers() => GetUsers().FindAll(x => x.Role == GetRole("Manager"));
        public static List<Role> GetRoles() => VediGroupEntities.GetContext().Roles.ToList();

        public static Role GetRole(string name) => GetRoles().FirstOrDefault(x => x.Name == name);

        public static User GetUser(string login, string password)
        {
            return GetUsers().FirstOrDefault(x => x.Login == login && x.Password == password);
        }

        public static void SaveUser(User user)
        {
            if (user.Id == 0)
                VediGroupEntities.GetContext().Users.Add(user);

            VediGroupEntities.GetContext().SaveChanges();
        }
        public static Tour GetTour(int id) => GetTours().FirstOrDefault(x => x.Id == id);

        public static void SaveTour(Tour tour)
        {
            if (tour.Id == 0)
                VediGroupEntities.GetContext().Tours.Add(tour);

            VediGroupEntities.GetContext().SaveChanges();
        }

        public static void SaveCountry(Country country)
        {
            if (country.Id == 0)
                VediGroupEntities.GetContext().Countries.Add(country);

            VediGroupEntities.GetContext().SaveChanges();
        }

        public static void SaveCity(City city)
        {
            if (city.Id == 0)
                VediGroupEntities.GetContext().Cities.Add(city);

            VediGroupEntities.GetContext().SaveChanges();
        }

        public static void DeleteTour(Tour tour)
        {
            VediGroupEntities.GetContext().Tours.Remove(tour);
            VediGroupEntities.GetContext().SaveChanges();
        }

        public static Tourist GetTourist(int id) => GetTourists().FirstOrDefault(x => x.Id == id);

        public static void SaveTourist(Tourist tourist)
        {

            if (tourist.Id == 0)
            {
                tourist.VisaAvailabilityId = 1;
                VediGroupEntities.GetContext().Tourists.Add(tourist);
            }
            try
            {

                VediGroupEntities.GetContext().SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }
                throw;
            }
        }

        public static void SaveHotel(Hotel hotel)
        {
            if (hotel.Id == 0)
            {
                if (hotel.Id == 0)
                    VediGroupEntities.GetContext().Hotels.Add(hotel);

                VediGroupEntities.GetContext().SaveChanges();
            }
        }

        public static Hotel GetHotel(int id) => GetHotels().FirstOrDefault(x => x.Id == id);

        public static User GetManager(int id) => GetManagers().FirstOrDefault(x => x.Id == id);
        public static Country GetCountry(int id) => GetCountries().FirstOrDefault(x => x.Id == id);
        public static City GetCity(int id) => GetCities().FirstOrDefault(x => x.Id == id);
    }
}
