using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebDriverWebElement
{
    public class RegisterUser : BaseTest
    {
        [Test]
        [Description("Enter valid data with favourite techs and validate the user is successfully registered")]

        public void UserWithFavouriteTechnologies()
        {
            IWebElement firstNameField = Driver.FindElement(By.Id("fname"));
            firstNameField.SendKeys("Anna");

            IWebElement lastNameField = Driver.FindElement(By.Id("lname"));
            lastNameField.SendKeys("Smith");

            IWebElement femaleRadioInput = Driver.FindElement(By.CssSelector("input[id='female']"));
            femaleRadioInput.Click();

            List<IWebElement> checkBoxes = Driver.FindElements(By.Name("checkBox")).ToList();

            foreach (var item in checkBoxes)
            {
                string checkBoxValue = item.GetAttribute("value");
                if ( checkBoxValue == "HTML" || checkBoxValue == "CSS" || checkBoxValue == "JavaScript")
                {
                    item.Click();
                }
            }

            IWebElement submitButton = Driver.FindElement(By.Id("submit"));
            submitButton.Click();

            Driver.SwitchTo().Alert().Accept();
            IWebElement body = Driver.FindElement(By.CssSelector("body"));
            string text = body.Text;
            Assert.IsTrue(text.Contains("Name: Anna Smith, Gender:Female"));
            Assert.IsTrue(text.Contains("Favourite technologies: HTML,CSS,JavaScript"));
            Assert.IsTrue(text.Contains("Currently working as QA"));
        }

        [Test]
        [Description("Enter valid user data without favourite techs and validate the user is successfully registered")]

        public void UserWithoutFavouriteTechnologies()
        {
            IWebElement firstNameField = Driver.FindElement(By.Id("fname"));
            firstNameField.SendKeys("Anna");

            IWebElement lastNameField = Driver.FindElement(By.Id("lname"));
            lastNameField.SendKeys("Smith");

            IWebElement femaleRadioInput = Driver.FindElement(By.CssSelector("input[id='female']"));
            femaleRadioInput.Click();

            IWebElement submitButton = Driver.FindElement(By.Id("submit"));
            submitButton.Click();

            Driver.SwitchTo().Alert().Accept();
            IWebElement techInfo = Driver.FindElement(By.CssSelector("body p:nth-child(2)"));
            Assert.That(techInfo.Text, Is.EqualTo("No favourite technologies"));
        }

    }
}
