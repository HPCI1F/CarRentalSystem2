using CarRentalSystem2;
using System.ComponentModel.DataAnnotations;

public class CarRentalSystem
{
    [Key]
    public int Id { get; private set; }

    private List<RegisteredUser> Users = new List<RegisteredUser>();
    private List<Car> Cars = new List<Car>();
    private RentalsContainer Rentals = new RentalsContainer();
    private RentalHistoryContainer RentalHistories = new RentalHistoryContainer();
    private RegisteredUser? loggedInUser; // Nullable, hogy nullal kezdődjön

    private List<Clerk> Clerks = new List<Clerk>();
    private List<Administrator> Administrators = new List<Administrator>();

    private CarRentalSystem() { }

    public void AddCar(Car car)
    {
        Cars.Add(car);
    }

    public List<Car> GetAvailableCars()
    {
        return Cars.Where(car => car.IsAvailable).ToList();
    }

    public void RegisterUser(string name, string email, string address, string phoneNumber, string password)
    {
        if (Users.Any(u => u.Email == email))
        {
            throw new InvalidOperationException("E-mail cím már regisztrált.");
        }

        var user = new RegisteredUser(Users.Count + 1, name, email, address, phoneNumber, password);
        Users.Add(user);
    }

    public void Login(string email, string password)
    {
        var user = Users.FirstOrDefault(u => u.Email == email && u.VerifyPassword(password));
        if (user == null)
        {
            throw new InvalidOperationException("Helytelen e-mail vagy jelszó.");
        }
        loggedInUser = user;
    }

    public void Logout()
    {
        loggedInUser = null;
    }

    public void SubmitRental(int carId, DateTime startDate, DateTime endDate)
    {
        if (loggedInUser == null)
        {
            throw new InvalidOperationException("Bejelentkezés szükséges a kölcsönzéshez.");
        }

        var car = Cars.FirstOrDefault(c => c.CarId == carId && c.IsAvailable)
                  ?? throw new InvalidOperationException("Az autó nem érhető el.");

        var rental = new Rental(Rentals.GetAllRentals().Count + 1, car, loggedInUser, startDate, endDate);
        Rentals.AddRental(rental);
    }

    public void SubmitGuestRentalRequest(int carId, string name, string address, string phoneNumber, DateTime startDate, DateTime endDate)
    {
        var car = Cars.FirstOrDefault(c => c.CarId == carId && c.IsAvailable);
        if (car == null)
        {
            throw new InvalidOperationException("Az autó nem érhető el.");
        }

        var guest = new NonRegisteredUser(name, address, phoneNumber);
        var rental = new Rental(Rentals.GetAllRentals().Count + 1, car, guest, startDate, endDate);
        Rentals.AddRental(rental);
    }

    public List<RentalHistory> GetRentalHistoryByCar(int carId)
    {
        return RentalHistories.GetHistoryByCar(carId);
    }

    public void AddClerk(Clerk clerk)
    {
        Clerks.Add(clerk);
    }

    public void AddAdministrator(Administrator administrator)
    {
        Administrators.Add(administrator);
    }

    public void RemoveCar(int carId)
    {
        Cars.RemoveAll(car => car.CarId == carId);
    }


    //public Rental GetRentalById(int rentalId)
    //{
    //    return Rentals.GetRentalById(rentalId);
    //}

    private RegisteredUser GetLoggedInUser()
    {
        // Feltételezzük, hogy van bejelentkezési logika
        return loggedInUser ?? throw new InvalidOperationException("Bejelentkezés szükséges.");
    }

    private Car GetCarById(int carId)
    {
        // Keresés a Car adatbázisban
        return Cars.FirstOrDefault(c => c.CarId == carId)
               ?? throw new KeyNotFoundException("Az autó nem található.");
    }

}
