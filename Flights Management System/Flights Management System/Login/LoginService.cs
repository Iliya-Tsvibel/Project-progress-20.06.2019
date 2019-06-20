using Flights_Management_System.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flights_Management_System
{
    class LoginService : ILoginService
    {
        public void UserLogin()
        {
            Console.Write("Please, input Username: ");
            string username = Console.ReadLine();
            Console.WriteLine();
            Console.Write("Please, input Password: ");
            string password = Console.ReadLine();
            Console.WriteLine();

            Administrator administrator = new Administrator(username, password);
            AirlineCompany airlineCompany = new AirlineCompany(username, password);
            Customer customer = new Customer(username, password);



            while ((administrator.ID == 0 && airlineCompany.ID == 0) || (administrator.ID == 0 && customer.ID == 0) || (airlineCompany.ID == 0 && customer.ID == 0) || (administrator.ID != 0 && airlineCompany.ID == 0 && customer.ID == 0))
            {
                throw new InvalidNameValueException("Please, contact to administrator");
            }
            while ((administrator.ID == 0 && administrator.ID == airlineCompany.ID) && (administrator.ID == 0 && administrator.ID == customer.ID))
            {
                throw new UserNotExistException("This User not exist. Create new user.");
            }
            while (administrator.ID == 0)
            {
                TryAdminLogin(username, password, out LoginToken<Administrator> token);
                return;
            }
            while (airlineCompany.ID == 0)
            {
                TryAirlineLogin(username, password, out LoginToken<AirlineCompany> token);
                return;
            }
            while (customer.ID == 0)
            {
                TryCustomerLogin(username, password, out LoginToken<Customer> token);
                return;
            }

        }
        //************************************************************************************************************

        private IAirlineDAO _arilineDAO;
        private ICustomerDAO _customerADO;

        public LoginService(IAirlineDAO arilineDAO)
        {
            _arilineDAO = arilineDAO;
        }

        public LoginService(ICustomerDAO customerADO)
        {
            _customerADO = customerADO;
        }
        public bool TryAdminLogin(string userName, string password, out LoginToken<Administrator> token)
        {
            throw new NotImplementedException();
            //if (userName.ToUpper() == Flights_Management_System.ADMIN_NAME && password == Flights_Management_System.ADMIN_PASSWORD)
            //{
            //    token = new LoginToken<Administrator>();
            //    token.User = new Administrator();
            //    return true;
            //}

            //token = null;
            //return false;
        }

        public bool TryAirlineLogin(string userName, string password, out LoginToken<AirlineCompany> token) // Not static?
        {
            AirlineCompany company = _arilineDAO.GetAirlineByUserame(userName);
            //AirlineCompany company = _arilineDAO.GetAirlineByUserame(userName);
            //if (company != null)
            //{
            //    if (company.PASSWORD == password)
            //    {
            //        token = new LoginToken<AirlineCompany>() { User = company };
            //        return true;
            //    }
         
            while (company == null) //AirlineID?
            {
                try
                {
                    AirlineDAOMSSQL.AirlineLogin(company);
                    token = new LoginToken<AirlineCompany>() { User = company };
                    Console.WriteLine("User was logged successfully");
                    return true;
                    

                    //ExistingAirflineUserMenu(company);

                }
                catch (AirlineCompanyDoesNotExistException)
                {
                   
                    Console.WriteLine("This airline company does not exist.");
                    Console.WriteLine("Input correct username or type e to exit.");
                    userName = Console.ReadLine();
                    Console.WriteLine();
                    if (userName == "e")
                    {
                        break;
                    }
                    else
                    {
                        company.USER_NAME = userName;
                        continue;
                    }
                }
                catch (WrongPasswordException)
                {
                    
                    Console.WriteLine("Incorrect password.");
                    Console.WriteLine("Input correct password or type e to exit.");
                    password = Console.ReadLine();
                    Console.WriteLine();
                    if (password == "e")
                    {
                        break;
                    }
                    else
                    {
                        company.PASSWORD = password;
                        continue;
                    }
                }
            }
            token = null;
            return false;
        }

        public bool TryCustomerLogin(string userName, string password, out LoginToken<Customer> token)
        {
            Customer name = _customerADO.GetCustomerByUserame(userName);
            //AirlineCompany company = _arilineDAO.GetAirlineByUserame(userName);
            //if (company != null)
            //{
            //    if (company.PASSWORD == password)
            //    {
            //        token = new LoginToken<AirlineCompany>() { User = company };
            //        return true;
            //    }

            while (name == null) //AirlineID?
            {
                try
                {
                    CustomerDAOMSSQL.CustomerLogin(name);
                    token = new LoginToken<Customer>() { User = name };
                    Console.WriteLine("User was logged successfully");
                    return true;


                    //ExistingAirflineUserMenu(company);

                }
                catch (CustomerDoesNotExistException)
                {

                    Console.WriteLine("This airline company does not exist.");
                    Console.WriteLine("Input correct username or type e to exit.");
                    userName = Console.ReadLine();
                    Console.WriteLine();
                    if (userName == "e")
                    {
                        break;
                    }
                    else
                    {
                        name.USER_NAME = userName;
                        continue;
                    }
                }
                catch (WrongPasswordException)
                {

                    Console.WriteLine("Incorrect password.");
                    Console.WriteLine("Input correct password or type e to exit.");
                    password = Console.ReadLine();
                    Console.WriteLine();
                    if (password == "e")
                    {
                        break;
                    }
                    else
                    {
                        name.PASSWORD = password;
                        continue;
                    }
                }
            }
            token = null;
            return false;
        }


        //*****************************************************************************************

       

        //}
        //public void TryAdminLogin() // Static?
        //{
        //    Console.WriteLine("Admin - OK");
        //    //while (administrator.AdministratorID == 0) //AdministratorID?
        //    //{
        //    //    try
        //    //    {
        //    //        OrderManagmentDAO.CustomerLogin(customer);
        //    //        OrderManagmentDAO.ActionRegistry("User - Customer", "Login Attempt", "Login Succesful");
        //    //        ExistingCustomerMenu(customer);

        //    //    }
        //    //    catch (UserDoesNotExistException)
        //    //    {
        //    //        OrderManagmentDAO.ActionRegistry("User - Customer", "Login Attempt", "Login Failed");
        //    //        OrderManagmentDAO.ActionRegistry("System", "UserDoesNotExistException");
        //    //        Console.WriteLine("This user does not exist.");
        //    //        Console.WriteLine("Input correct username or type // to exit.");
        //    //        username = Console.ReadLine();
        //    //        Console.WriteLine();
        //    //        if (username == "//")
        //    //        {
        //    //            return;
        //    //        }
        //    //        else
        //    //        {
        //    //            customer.Username = username;
        //    //            continue;
        //    //        }
        //    //    }
        //    //    catch (WrongPasswordException)
        //    //    {
        //    //        OrderManagmentDAO.ActionRegistry("User - Customer", "Login Attempt", "Login Failed");
        //    //        OrderManagmentDAO.ActionRegistry("System", "WrongPasswordException");
        //    //        Console.WriteLine("Incorrect password.");
        //    //        Console.WriteLine("Input correct password or type // to exit.");
        //    //        password = Console.ReadLine();
        //    //        Console.WriteLine();
        //    //        if (password == "//")
        //    //        {
        //    //            return;
        //    //        }
        //    //        else
        //    //        {
        //    //            customer.Password = password;
        //    //            continue;
        //    //        }
        //    //    }
        //    //}

        //}
        //public void TryAirlineLogin() // Static?
        //{
        //    Console.WriteLine("Airline - OK");
        //}

        //public void TryCustomerLogin() // Static?
        //{
        //    Console.WriteLine("Customer - OK");
        //}

    }
}
