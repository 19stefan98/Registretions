﻿using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace UnitTestProject2
{
    public class Reg
    {
        public IWebDriver driver { get; set; }
        public string text { get; set; }

        public Reg(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void Test()
        {
            TimeSpan timeout = new TimeSpan(00, 01, 00);
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("http://bolshoy.itech-test.ru/");

            var human = (new WebDriverWait(driver, timeout)).Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".gh-extras > a:nth-child(3) > svg:nth-child(1)")));
            human.Click();
            var registracia = (new WebDriverWait(driver, timeout)).Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id=\"body\"]/div[2]/div[4]/div[2]/div/div[2]/a[2]")));
            registracia.Click();

            string a = "";
            Random rand = new Random();
            for (int v = 0; v < 4; v++)

            {

                a += Convert.ToChar(rand.Next(97, 122));

            }

            var login = (new WebDriverWait(driver, timeout)).Until(ExpectedConditions.ElementIsVisible(By.Name("REGISTER[LOGIN]")));
            login.SendKeys(a + "test");

            var name = (new WebDriverWait(driver, timeout)).Until(ExpectedConditions.ElementIsVisible(By.Name("REGISTER[NAME]")));
            name.SendKeys("Тест");
            var last_name = (new WebDriverWait(driver, timeout)).Until(ExpectedConditions.ElementIsVisible(By.Name("REGISTER[LAST_NAME]")));
            last_name.SendKeys("Тестовая");
            var email = (new WebDriverWait(driver, timeout)).Until(ExpectedConditions.ElementIsVisible(By.Name("REGISTER[EMAIL]")));
            email.SendKeys(a + "@mail.ru");

            string sum = "";

            Random randj = new Random();

            for (int v = 0; v < 6; v++)

            {

                sum += Convert.ToChar(rand.Next(48, 57));

            }

            var phone = (new WebDriverWait(driver, timeout)).Until(ExpectedConditions.ElementIsVisible(By.Name("REGISTER[PERSONAL_PHONE]")));
            phone.SendKeys("+7929" + sum);

            var password = (new WebDriverWait(driver, timeout)).Until(ExpectedConditions.ElementIsVisible(By.Name("REGISTER[PASSWORD]")));
            password.SendKeys("123456");
            var passsword1 = (new WebDriverWait(driver, timeout)).Until(ExpectedConditions.ElementIsVisible(By.Name("REGISTER[CONFIRM_PASSWORD]")));
            passsword1.SendKeys("123456");
            var checkbox = (new WebDriverWait(driver, timeout)).Until(ExpectedConditions.ElementIsVisible(By.ClassName("checkbox-label")));
            checkbox.Click();
            checkbox.Submit();
            text = (new WebDriverWait(driver, timeout)).Until(ExpectedConditions.ElementIsVisible(By.ClassName("is-personal-escape"))).Text;
        }
    }
}