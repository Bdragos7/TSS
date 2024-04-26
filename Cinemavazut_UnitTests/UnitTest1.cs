using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;


namespace Cinemavazut_UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        private IWebDriver driver;

        [TestInitialize]
        public void Initialize()
        {
        
            driver = new ChromeDriver();           
            driver.Navigate().GoToUrl("https://localhost:7231");
            driver.Manage().Window.Maximize();                    
      
        }
        [TestMethod]
        public void TestTitle()
        {
            System.Threading.Thread.Sleep(5000);
            string titlu = driver.Title;
            

            if(titlu == "Cinemavazut")
            {
                Console.WriteLine("Tiltu este corect");
            }
            else { Console.WriteLine("NU e corect"); }

        }
        [TestMethod]
        public void TestLogin()
        {
            driver.Navigate().GoToUrl("https://localhost:7231/Utilizatori/SignIn");
            WebElement username = (WebElement)driver.FindElement(By.Id("email"));
            WebElement password = (WebElement)driver.FindElement(By.Id("parola"));
            WebElement login = (WebElement)driver.FindElement(By.Id("SignIn"));
            username.SendKeys("iancumihaela@gmail.com");
            password.SendKeys("123456");
            login.Click();
            string actualUrl = "https://localhost:7231/";
            string expectedUrl = driver.Url;
            Assert.AreEqual(expectedUrl, actualUrl);
        }
        [TestMethod]
        public void TestWatchList()
        {
            driver.Navigate().GoToUrl("https://localhost:7231/Utilizatori/SignIn");
            WebElement username = (WebElement)driver.FindElement(By.Id("email"));
            WebElement password = (WebElement)driver.FindElement(By.Id("parola"));
            WebElement login = (WebElement)driver.FindElement(By.Id("SignIn"));
            username.SendKeys("iancumihaela@gmail.com");
            password.SendKeys("123456");
            login.Click();
            driver.Navigate().GoToUrl("https://localhost:7231/Filme/PaginaFilm/4");
            WebElement watchlist = (WebElement)driver.FindElement(By.Id("watchlist-1"));
            watchlist.Click();
            string actualUrl = "https://localhost:7231/Filme/PaginaFilm/4";
            string expectedUrl = driver.Url;
            WebElement watchlist2 = (WebElement)driver.FindElement(By.Id("watchlist-2"));
            watchlist2.Click();
            Assert.AreEqual(expectedUrl, actualUrl);
            
        }

        [TestMethod]
        public void TestRecenzi()
        {
            driver.Navigate().GoToUrl("https://localhost:7231/Utilizatori/SignIn");
            WebElement username = (WebElement)driver.FindElement(By.Id("email"));
            WebElement password = (WebElement)driver.FindElement(By.Id("parola"));
            WebElement login = (WebElement)driver.FindElement(By.Id("SignIn"));
            
            int recenzii_vechi = driver.FindElements(By.Id("grid_comment")).Count;
            username.SendKeys("iancumihaela@gmail.com");
            password.SendKeys("123456");
            login.Click();
            driver.Navigate().GoToUrl("https://localhost:7231/Filme/PaginaFilm/4");
            WebElement recenzie = (WebElement)driver.FindElement(By.Id("btn-recenzie"));
            recenzie.Click();
            WebElement titlu = (WebElement)driver.FindElement(By.Id("titlu"));
            WebElement comentariu = (WebElement)driver.FindElement(By.Id("comentariu"));
            WebElement rating = (WebElement)driver.FindElement(By.Id("rating"));
            WebElement create = (WebElement)driver.FindElement(By.Name("create_recenzie"));
            titlu.SendKeys("Recenzie Test");
            comentariu.SendKeys("Comentariu de test");
            rating.SendKeys("5");
            create.Click();
            int recenzii_noi = driver.FindElements(By.Id("grid_comment")).Count;
            Assert.AreNotEqual(recenzii_noi,recenzii_vechi);

        }
        [TestMethod]
        public void TestRegister()
        {
            driver.Navigate().GoToUrl("https://localhost:7231/Utilizatori/Create");

            //Nume
            WebElement nume = (WebElement)driver.FindElement(By.Name("nume"));
            nume.SendKeys("Ion");
            
            //Prenume
            WebElement prenume = (WebElement)driver.FindElement(By.Name("prenume"));
            prenume.SendKeys("Popescu");

            //parola
            WebElement parola = (WebElement)driver.FindElement(By.Id("parola"));
            parola.SendKeys("Parola10@");

            //email
            WebElement email = (WebElement)driver.FindElement(By.Name("email"));
            email.SendKeys("ionpopescu@gmail.com");

            //numamr telefon
            WebElement telefon = (WebElement)driver.FindElement(By.Id("telefon"));
            string phone = "1234567890";
            telefon.SendKeys(phone);

            WebElement data_nastere = (WebElement)driver.FindElement(By.Name("data_nastere"));
            data_nastere.SendKeys("2002-01-22T00:00:00.000");

            //Creare cont
            WebElement create = (WebElement)driver.FindElement(By.Name("create_util"));
            new Actions(driver).Click(create).Perform();
            System.Threading.Thread.Sleep(2000);
        }

        [TestMethod]
        public void TestAdmin()
        {
            driver.Navigate().GoToUrl("https://localhost:7231/SignIn");

            WebElement username = (WebElement)driver.FindElement(By.Id("email"));
            WebElement password = (WebElement)driver.FindElement(By.Id("parola"));
            WebElement login = (WebElement)driver.FindElement(By.Id("SignIn"));
            username.SendKeys("cioflancezar@gmail.com");
            password.SendKeys("567890");
            login.Click();
        }
        [TestMethod]
        public void TestEditUser()
        {
            driver.Navigate().GoToUrl("https://localhost:7231/SignIn");

            WebElement username = (WebElement)driver.FindElement(By.Id("email"));
            WebElement password = (WebElement)driver.FindElement(By.Id("parola"));
            WebElement login = (WebElement)driver.FindElement(By.Id("SignIn"));
            username.SendKeys("cioflancezar@gmail.com");
            password.SendKeys("567890");
            login.Click();

            driver.Navigate().GoToUrl("https://localhost:7231/Utilizatori");
            int linii_tabel = driver.FindElements(By.CssSelector("td")).Count;
            Console.WriteLine(linii_tabel);
            int id_util_test = 4 + (linii_tabel - 2) * 1000;

            driver.Navigate().GoToUrl("https://localhost:7231/Utilizatori/Edit/"+id_util_test);

            WebElement nume = (WebElement)driver.FindElement(By.Id("nume"));
            WebElement prenume = (WebElement)driver.FindElement(By.Id("prenume"));
            WebElement email = (WebElement)driver.FindElement(By.Id("email"));
            WebElement parola = (WebElement)driver.FindElement(By.Id("parola"));
            WebElement telefon = (WebElement)driver.FindElement(By.Id("telefon"));
            WebElement data_nastere = (WebElement)driver.FindElement(By.Id("nastere"));
            WebElement rol = (WebElement)driver.FindElement(By.Id("rol"));
            //discutabil aici ca nush cum sa trasmit ora inscrierii
            /*WebElement data_inscriere = (WebElement)driver.FindElement(By.Id("data_inscriere"));*/
            string nume_expected = "Ion";
            string prenume_expected = "Popescu";
            string email_expected = "ionpopescu@gmail.com";
            string parola_expected = "Parola10@";
            string telefon_expected = "1234567890";
            string data_nastere_expected = "2002-01-22T00:00:00.000";
            string rol_expected = "1";

            Assert.AreEqual(nume, nume_expected);
            Assert.AreEqual(prenume, prenume_expected);
            Assert.AreEqual(email, email_expected);
            Assert.AreEqual(parola, parola_expected);
            Assert.AreEqual(telefon, telefon_expected);
            Assert.AreEqual(data_nastere, data_nastere_expected);
            Assert.AreEqual(rol, rol_expected);

            //De continuat acasa sa vezi daca ii dai SendKeys pe nume completeaza sau scrie peste

        }

        [TestMethod]
        public void TestDeleteUser()
        {
            driver.Navigate().GoToUrl("https://localhost:7231/SignIn");

            WebElement username = (WebElement)driver.FindElement(By.Id("email"));
            WebElement password = (WebElement)driver.FindElement(By.Id("parola"));
            WebElement login = (WebElement)driver.FindElement(By.Id("SignIn"));
            username.SendKeys("cioflancezar@gmail.com");
            password.SendKeys("567890");
            login.Click();

            driver.Navigate().GoToUrl("https://localhost:7231/Utilizatori");

            int linii_tabel = driver.FindElements(By.CssSelector("td")).Count;
            Console.WriteLine(linii_tabel);
            int id_util_test = 4 + (linii_tabel - 2) * 1000; 

            driver.Navigate().GoToUrl("https://localhost:7231/Utilizatori/Delete/"+id_util_test);

            WebElement delete = (WebElement)driver.FindElement(By.Name("delete_btn"));
            delete.Click();
        }
        [TestMethod]
        public void TestSearchBar()
        {
            driver.Navigate().GoToUrl("https://localhost:7231");
            WebElement SearchString = (WebElement)driver.FindElement(By.Name("SearchString"));
            WebElement SearchBtn = (WebElement)driver.FindElement(By.Name("buton_search"));
            SearchString.SendKeys("Filantropica");
            SearchBtn.Click();

            string actualUrl = "https://localhost:7231/Filme/Search";
            string expectedUrl = driver.Url;

            Assert.AreEqual(expectedUrl, actualUrl);

            string result = driver.FindElement(By.XPath("/ html / body / div[2] / main / div / div / h5")).Text;//ceva getText() de facut acasa

            Assert.AreEqual(SearchString, result);



        }
        [TestCleanup]
        public void Cleanup()
        {
            driver.Quit();
        }
    }
}
